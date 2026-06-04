import os

try:
    import cv2
except Exception:
    cv2 = None

from ultralytics import YOLO
from ultralytics.utils import LOGGER

AllModelsPath = os.path.join("models")
_LIVE_PLOT_WINDOWS = {}
_LIVE_PLOT_MTIMES = {}


def _resolve_output_path(path: str) -> str:
    return os.path.abspath(path)


def _ensure_live_plots() -> bool:
    return cv2 is not None


def _iter_plot_files(save_dir: str):
    yield os.path.join(save_dir, "results.png"), "Results"
    yield os.path.join(save_dir, "P_curve.png"), "Precision-Confidence Curve"
    yield os.path.join(save_dir, "confusion_matrix.png"), "Confusion Matrix"
    yield (
        os.path.join(save_dir, "confusion_matrix_normalized.png"),
        "Confusion Matrix (Normalized)",
    )

    labels_jpg = os.path.join(save_dir, "labels.jpg")
    labels_png = os.path.join(save_dir, "labels.png")
    if os.path.exists(labels_jpg):
        yield labels_jpg, "Labels"
    elif os.path.exists(labels_png):
        yield labels_png, "Labels"


def _update_live_plot(image_path: str, title: str) -> None:
    if not _ensure_live_plots():
        return
    if not os.path.exists(image_path):
        return

    try:
        mtime = os.path.getmtime(image_path)
    except OSError:
        return

    if _LIVE_PLOT_MTIMES.get(image_path) == mtime:
        return

    image = cv2.imread(image_path)
    if image is None:
        return

    _LIVE_PLOT_MTIMES[image_path] = mtime
    window_name = _LIVE_PLOT_WINDOWS.get(image_path)
    if window_name is None:
        window_name = title
        _LIVE_PLOT_WINDOWS[image_path] = window_name
        cv2.namedWindow(window_name, cv2.WINDOW_NORMAL)

    cv2.imshow(window_name, image)
    cv2.waitKey(1)


def _update_live_plots(trainer) -> None:
    if cv2 is None:
        return

    save_dir = getattr(trainer, "save_dir", None)
    if save_dir is None:
        return

    save_dir = os.fspath(save_dir)
    for image_path, title in _iter_plot_files(save_dir):
        _update_live_plot(image_path, title)


def _plot_confusion_matrix(validator, normalize: bool) -> None:
    plot_fn = getattr(validator, "plot_confusion_matrix", None)
    if callable(plot_fn):
        try:
            plot_fn(normalize=normalize)
            return
        except TypeError:
            try:
                plot_fn()
                return
            except Exception:
                return

    confusion = getattr(validator, "confusion_matrix", None)
    plot = getattr(confusion, "plot", None)
    if callable(plot):
        try:
            plot(normalize=normalize)
        except TypeError:
            plot()


def _plot_epoch(trainer) -> None:
    try:
        plot_metrics = getattr(trainer, "plot_metrics", None)
        if callable(plot_metrics):
            plot_metrics()

        plot_labels = getattr(trainer, "plot_training_labels", None)
        if callable(plot_labels):
            plot_labels()

        validator = getattr(trainer, "validator", None)
        if validator is None:
            return

        plot_results = getattr(validator, "plot_results", None)
        if callable(plot_results):
            plot_results()

        _plot_confusion_matrix(validator, normalize=False)
        _plot_confusion_matrix(validator, normalize=True)
        _update_live_plots(trainer)
    except Exception:
        # Best-effort plotting; keep training running if APIs differ.
        pass

def train(datapath: str, epochs: int, imgsz: int, device: str, modelname: str, seed:int, path: str, progress_callback=None):
    ModelsInDir = os.listdir(AllModelsPath)

    modelpath = os.path.join(AllModelsPath, modelname)

    if not (os.path.exists(os.path.join(modelpath))):
        return {"error": -1}
    
    model = YOLO(modelpath)
    LOGGER.setLevel(30)

    if not (os.path.exists(datapath)):
        return {"error": -2}

    output_dir = _resolve_output_path(path)
    os.makedirs(output_dir, exist_ok=True)

    if progress_callback is not None:
        model.add_callback(
            "on_train_epoch_end",
            lambda t: progress_callback(t.epoch + 1, epochs)
        )

    model.add_callback("on_fit_epoch_end", lambda t: _plot_epoch(t))
    
    if device != "cpu":
        int(device)

    results = model.train(data=datapath, epochs=epochs, imgsz=imgsz, save=True, verbose=False, seed=seed, device=device, project=output_dir, plots=True)
    save_dir = getattr(results, "save_dir", None)
    if save_dir is None:
        save_dir = os.path.join(output_dir, "train")

    return {"status": 100.0, "save_dir": str(save_dir)}