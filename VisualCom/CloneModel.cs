using System.Net.Http;
using System.Threading.Tasks;
using Octokit;

namespace VisualCom
{
    public class CloneModel
    {
        private static readonly Dictionary<string, string> AllModels = new(StringComparer.OrdinalIgnoreCase)
        {
            ["YOLO26 Nano"] = "yolo26n.pt",
            ["YOLO26 Small"] = "yolo26s.pt",
            ["YOLO26 Medium"] = "yolo26m.pt",
            ["YOLO26 Large"] = "yolo26l.pt",
            ["YOLO26 Extra"] = "yolo26x.pt",
            ["YOLO11 Medium"] = "yolo11m.pt",
            ["YOLO11 Extra"] = "yolo11x.pt"
        };

        private static readonly HttpClient HttpClient = new();

        public static async Task<int> DownloadModelAsync(string modelName)
        {
            if (!AllModels.TryGetValue(modelName, out var modelFile))
            {
                Console.WriteLine("error");
                return -1;
            }

            var client = new GitHubClient(new ProductHeaderValue("VisualCom"));
            var latest = await client.Repository.Release.GetLatest("ultralytics", "assets");
            var url = $"https://github.com/ultralytics/assets/releases/download/{latest.TagName}/{modelFile}";

            var modelsDirectory = Path.Combine("models");
            Directory.CreateDirectory(modelsDirectory);

            var modelPath = Path.Combine(modelsDirectory, modelFile);

            try
            {
                await using var responseStream = await HttpClient.GetStreamAsync(url);
                await using var fileStream = new FileStream(modelPath, System.IO.FileMode.CreateNew, FileAccess.Write, FileShare.None);
                await responseStream.CopyToAsync(fileStream);
            }
            catch (IOException) when (File.Exists(modelPath))
            {
                return -2;
            }

            return 0;
        }

        public static async Task<int> PullModelAsync(string modelUrl)
        {
            if (!modelUrl.Contains("https://", StringComparison.OrdinalIgnoreCase))
            {
                modelUrl = $"https://{modelUrl}";
            }

            var modelsDirectory = Path.Combine("models");
            Directory.CreateDirectory(modelsDirectory);

            if (!Uri.TryCreate(modelUrl, UriKind.Absolute, out var uri))
            {
                return -3;
            }

            var modelFile = Path.GetFileName(uri.LocalPath);
            var modelPath = Path.Combine(modelsDirectory, modelFile);

            try
            {
                await using var responseStream = await HttpClient.GetStreamAsync(modelUrl);
                await using var fileStream = new FileStream(modelPath, System.IO.FileMode.CreateNew, FileAccess.Write, FileShare.None);
                await responseStream.CopyToAsync(fileStream);
            }
            catch (HttpRequestException)
            {
                return -3;
            }
            catch (IOException) when (File.Exists(modelPath))
            {
                return -2;
            }

            return 0;
        }
    }
}
