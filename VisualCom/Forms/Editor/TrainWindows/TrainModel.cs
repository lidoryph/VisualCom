using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Reflection;
using VisualCom.Forms.Editor.TrainWindows;
using System.Xml.Linq;
using System.Diagnostics;

namespace VisualCom.Forms.Editor
{
    public partial class TrainModel : Form
    {
        private bool _cancelled = false;
        private CancellationTokenSource cts = new();
        private readonly XElement? pv_d_models = Configuration.ProjectVariables.Root?.Element("Directories")?.Element("Models");
        private readonly Dictionary<string, string> _modelFiles = new()
        {
            { "YOLO26 Nano", "yolo26n.pt" },
            { "YOLO26 Small", "yolo26s.pt" },
            { "YOLO26 Medium", "yolo26m.pt" },
            { "YOLO26 Large", "yolo26l.pt" },
            { "YOLO26 Extra", "yolo26x.pt" },
            { "YOLO11 Medium", "yolo11m.pt" },
            { "YOLO11 Extra", "yolo11x.pt" },
        };

        public TrainModel()
        {
            InitializeComponent();
            HelpButton.Image = SystemIcons.Question.ToBitmap();
            GetVersions();
            //GetGraphicsCards();
            DeviceSelector.Items.Add("CPU");
            DeviceSelector.Items.Add("GPU");
            GetModels();
        }

        private void GetVersions()
        {
            if (pv_d_models == null)
                return;

            foreach (var path in Directory.GetDirectories(pv_d_models.Value))
                VersionSelector.Items.Add(Path.GetFileName(Path.GetFileName(path)));
        }
        private void GetGraphicsCards()
        {
            ManagementObjectSearcher searcher = new("SELECT * FROM Win32_DisplayConfiguration");

            foreach (ManagementObject mo in searcher.Get().Cast<ManagementObject>())
            {
                foreach (PropertyData property in mo.Properties)
                {
                    if (property.Name == "Description")
                    {
                        DeviceSelector.Items.Add(property.Value);
                    }
                }
            }
        }

        private void GetModels()
        {
            string name = "";
            foreach (string model in Directory.GetFiles(Path.Join(".", "models")))
            {
                name = Path.GetFileName(Path.GetFileName(model));
                switch(name)
                {
                    case "yolo26n.pt":
                        ModelSelector.Items.Add("YOLO26 Nano");
                        break;

                    case "yolo26s.pt":
                        ModelSelector.Items.Add("YOLO26 Small");
                        break;

                    case "yolo26m.pt":
                        ModelSelector.Items.Add("YOLO26 Medium");
                        break;

                    case "yolo26l.pt":
                        ModelSelector.Items.Add("YOLO26 Large");
                        break;

                    case "yolo26x.pt":
                        ModelSelector.Items.Add("YOLO26 Extra");
                        break;

                    case "yolo11m.pt":
                        ModelSelector.Items.Add("YOLO11 Medium");
                        break;

                    case "yolo11x.pt":
                        ModelSelector.Items.Add("YOLO11 Extra");
                        break;

                    default:
                        ModelSelector.Items.Add(Path.GetFileName(Path.GetFileName(model)));
                        break;
                }
            }
        }

        private async void InitTrainModel(object sender, EventArgs e)
        {
            TrainModelButton.Enabled = false;
            TrainProgress.Enabled = true;

            string Device = "";

            if (DeviceSelector.SelectedItem == null)
                return;

            if (DeviceSelector.SelectedItem.ToString() == "CPU")
                Device = "cpu";
            else if (DeviceSelector.SelectedItem.ToString() == "GPU")
                Device = "0";
            else
                return;

            string? Version = VersionSelector.SelectedItem?.ToString();
            string? Model = ModelSelector.SelectedItem?.ToString();
            string modelFile = _modelFiles.TryGetValue(Model, out string? f) ? f : Model;

            if (Version == null || Model == null || pv_d_models == null)
            {
                MessageBox.Show("Ha habido un error recogiendo información.");
                TrainModelButton.Enabled = true;
                TrainProgress.Enabled = false;
                return;
            }

            var PythonArguments = (
                version: Path.Join(pv_d_models.Value, Version, "data.yaml"), 
                epoch: Convert.ToInt32(EpochNumeric.Value),
                imgsz: Convert.ToInt32(ImageSizeNum.Value), 
                seed: Convert.ToInt32(SeedNum.Value), 
                device: Device, 
                model: modelFile,
                path: Path.Join(pv_d_models.Value, Version)
            );

            PythonTrain.Initialize();

            void OnEpochEnd(int current, int total) =>
                TrainProgress.InvokeAsync(() => TrainProgress.Value = (int)Math.Round((double)current / total * 100), cts.Token);


            TrainProgress.Value = (int)await Task.Run(() => PythonTrain.StartTrain(PythonArguments, cts, cts.Token, OnEpochEnd));
            TrainModelButton.Enabled = true;
            TrainProgress.Enabled = false;

            TrainModelButton.Enabled = true;
            TrainProgress.Enabled = false;

            Process.Start("explorer", Path.Join(pv_d_models.Value, Version));

        }
        private void ShowHelpDlg(object sender, EventArgs e)
        {
            HelpTrain dialog = new();
            dialog.ShowDialog();
        }

        private async void TrainModCancelButton_Click(object sender, EventArgs e)
        {
            if (!_cancelled)
            {
                cts.Cancel();
                _cancelled = true;
            }
            Close();
        }

        private void EpochBar_ValueChanged(object sender, EventArgs e)
        {
            if (EpochBar.Value == 0)
                EpochNumeric.Value = 1;
            else
                EpochNumeric.Value = EpochBar.Value;
        }

        private void EpochNumeric_ValueChanged(object sender, EventArgs e)
        {
            EpochBar.Value = Convert.ToInt32(EpochNumeric.Value);
        }

        private void RateBar_ValueChanged(object sender, EventArgs e)
        {
            ImageSizeNum.Value = ImageSizeBar.Value;
        }

        private void RateNumeric_ValueChanged(object sender, EventArgs e)
        {
            ImageSizeBar.Value = Convert.ToInt32(ImageSizeNum.Value);
        }

        private void ImagesBar_ValueChanged(object sender, EventArgs e)
        {
            if (SeedBar.Value == 0)
                SeedNum.Value = 1;
            else
                SeedNum.Value = SeedBar.Value;

        }

        private void ImagesNumeric_ValueChanged(object sender, EventArgs e)
        {
            SeedBar.Value = Convert.ToInt32(SeedNum.Value);
        }

        private void OnFormClose(object sender,  FormClosingEventArgs e)
        {
            if (!_cancelled)
            {
                cts.Cancel();
                _cancelled = true;
            }
        }

    }
}
