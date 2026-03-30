using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using VisualCom.Forms.Errors;
using Windows.ApplicationModel.VoiceCommands;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.Design.AxImporter;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.Security.Policy;

namespace VisualCom
{

    public class ModelYaml
    {
        public string path { get; set; } = string.Empty;
        public string train { get; set; } = string.Empty;
        public string val { get; set; } = string.Empty;
        public int nc { get; set; } = new int();
        //public IEnumerable<string> Classes { get; set; } = new List<string>();
        public Dictionary<int, string> names { get; set; } = new Dictionary<int, string>();
    }

    internal static class ProjectActions
    {
        private static readonly ReadingDocument error = new();
        private static string? c_pf = Configuration.ProjectFile; 
        private static readonly XElement? pv_name = Configuration.ProjectVariables.Root?.Element("Name");
        private static readonly XElement? pv_created = Configuration.ProjectVariables.Root?.Element("Created");
        private static readonly XElement? pv_modified = Configuration.ProjectVariables.Root?.Element("Modified");

        private static readonly XElement? pv_dirs = Configuration.ProjectVariables.Root?.Element("Directories");
        private static readonly XElement? pv_main = Configuration.ProjectVariables.Root?.Element("Directories")?.Element("Main");
        private static readonly XElement? pv_images = Configuration.ProjectVariables.Root?.Element("Directories")?.Element("Images");
        private static readonly XElement? pv_annotations = Configuration.ProjectVariables.Root?.Element("Directories")?.Element("Annotations");
        private static readonly XElement? pv_models = Configuration.ProjectVariables.Root?.Element("Directories")?.Element("Models");
        private static readonly XElement? pv_versions = Configuration.ProjectVariables.Root?.Element("Directories")?.Element("Versions");

        public static void NewProject()
        {
            if (c_pf == null || pv_name == null || pv_main == null || pv_images == null || pv_annotations == null || pv_models == null ||
                pv_versions == null || pv_created == null || pv_modified == null || pv_dirs == null)
            {
                error.ShowDialog();
                return;
            }
               
            

            string ProjectName = Path.GetFileNameWithoutExtension(c_pf);
            pv_name.Value = ProjectName;

            string? ProjectDir = Path.GetDirectoryName(c_pf);

            if (ProjectDir == null)
                return;

            if (Directory.EnumerateFileSystemEntries(ProjectDir).Any())
            {
                ProjectDir = Path.Join(ProjectDir, ProjectName);
                System.IO.Directory.CreateDirectory(ProjectDir);
                c_pf = (string)Path.Join(ProjectDir, (ProjectName + ".xml"));
            }

            pv_main.Value = ProjectDir;

            pv_images.Value = Path.Join(ProjectDir, "images");
            pv_annotations.Value = Path.Join(ProjectDir, "annotations");
            pv_models.Value = Path.Join(ProjectDir, "models");
            pv_versions.Value = Path.Join(ProjectDir, "versions");

            pv_created.Value = DateTime.Now.ToString();
            pv_modified.Value = DateTime.Now.ToString();

            foreach (var directory in pv_dirs.Elements())
            {
                if((string) directory != "main")
                {
                    System.IO.Directory.CreateDirectory((string) directory);
                }
            }


            Configuration.ProjectVariables.Save(c_pf);
        }

        public static void LoadAnnotations(string filepath)
        {
            string json = File.ReadAllText(filepath);

            ImageAnnotation annotation = new();

            try 
            {
                annotation = JsonSerializer.Deserialize<ImageAnnotation>(json);
            } catch (JsonException)
            {
                File.Delete(filepath);
            }
            
            Configuration.JsonPath = filepath;
            if (annotation == null) return;

            Configuration.CurrentImageJson.Name = annotation.Name;
            Configuration.CurrentImageJson.Boxes = annotation.Boxes;
        }

        public static void LoadProject()
        {
            Configuration.ProjectVariables = XDocument.Load(Configuration.ProjectFile);
        }

        public static void SaveProject(bool notes)
        {
            if (pv_modified == null || c_pf == null || Configuration.CurrentImageCoordinates == null)
            {
                Clipboard.SetText(Configuration.ProjectVariables.ToString());
                MessageBox.Show("El contenido de tu proyecto esta en tu portapapeles. Copialo en un lugar seguro.");
                error.ShowDialog();
                return;
            }

            if (notes)
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(Configuration.CurrentImageJson, options);
                File.WriteAllText(Configuration.JsonPath, json);
            }
            
            pv_modified.Value = DateTime.Now.ToString();
            Configuration.ProjectVariables.Save(c_pf);
            Configuration.Saved = true;
        }

        public static void ExportToYOLO(string VersionPath, string outputDirectory, int imagesBar)
        {
            if (pv_annotations == null || pv_images == null)
            {
                error.ShowDialog();
                return;
            }

            string DocumentPath = Path.Combine(VersionPath, Path.GetFileName(VersionPath) + ".xml");
            XDocument VerDoc = XDocument.Load(DocumentPath);

            string? ImagesPath = VerDoc.Root?.Element("Directories")?.Element("Images")?.Value;
            string? AnnotationsPath = VerDoc.Root?.Element("Directories")?.Element("Annotations")?.Value;
            XElement? VersionClasses = VerDoc.Root?.Element("Classes");

            if (ImagesPath == null || AnnotationsPath == null || VersionClasses == null)
                return;

            var classIndex = new Dictionary<string, int>();
            int idx = 0;
            foreach (var cls in VersionClasses.Elements("Class"))
            {
                classIndex[cls.Value] = idx;
                idx++;
            }

            string path = Path.GetFullPath(outputDirectory);
            Directory.CreateDirectory(path);
            var myClass = classIndex.OrderBy(c => c.Value).ToDictionary(c => c.Value, c => c.Key);

            var ModelFile = new ModelYaml
            {
                path = path,
                train = Path.Join(path, "dataset", "images", "train"),
                val = Path.Join(path, "dataset", "images", "val"),
                nc = idx,
                names = myClass
            };

            var newdirs = new List<string> { Path.Join(path, "dataset"), Path.Join(path, "dataset", "images"), Path.Join(path, "dataset", "images", "train"), 
                Path.Join(path,"dataset", "images", "val"), Path.Join(path, "dataset", "labels"), Path.Join(path, "dataset", "labels", "train"), Path.Join(path, "dataset", "labels", "val")};

            foreach(var dir in newdirs)
                Directory.CreateDirectory(dir);


            double actualBar = 0;
            double BarDivider = Directory.GetFiles(ImagesPath).Length;
            double BarPlus = 100 / BarDivider;
            // Recorrer todos los JSON de anotaciones
            foreach (string jsonPath in Directory.GetFiles(AnnotationsPath, "*.json"))
            {
                string json = File.ReadAllText(jsonPath);
                var annotation = JsonSerializer.Deserialize<ImageAnnotation>(json);

                if (annotation == null || annotation.Boxes.Count == 0) continue;

                // Buscar la imagen correspondiente para obtener sus dimensiones
                string imageName = annotation.Name;
                string imagePath = Path.Join(ImagesPath, imageName);

                if (!File.Exists(imagePath)) continue;

                int imageWidth, imageHeight;
                using (var temp = new Bitmap(imagePath))
                {
                    imageWidth = temp.Width;
                    imageHeight = temp.Height;
                }

                // Generar el .txt de YOLO
                var lines = new List<string>();
                foreach (BoundingBox box in annotation.Boxes)
                {
                    if (!classIndex.TryGetValue(box.Class, out int classIdx)) continue;

                    float centerX = (box.BL[0] + box.TR[0]) / 2f / imageWidth;
                    float centerY = (box.TR[1] + box.BL[1]) / 2f / imageHeight;
                    float width = (box.TR[0] - box.BL[0]) / imageWidth;
                    float height = (box.BL[1] - box.TR[1]) / imageHeight;

                    lines.Add(string.Format(CultureInfo.InvariantCulture,
                        "{0} {1:F6} {2:F6} {3:F6} {4:F6}",
                        classIdx, centerX, centerY, width, height));
                }
                
                if(actualBar < imagesBar)
                {
                    string txtPath = Path.Join(Path.Join(ModelFile.path, "dataset", "labels", "train"), Path.GetFileNameWithoutExtension(imageName) + ".txt");
                    File.WriteAllLines(txtPath, lines);
                    File.Copy(Path.Combine(ImagesPath, imageName), Path.Combine(ModelFile.train, imageName));
                    actualBar = actualBar + BarPlus;
                    if (actualBar >= 100)
                        actualBar = 0;
                } else if (actualBar > imagesBar)
                {
                    string txtPath = Path.Join(Path.Join(ModelFile.path, "dataset", "labels", "val"), Path.GetFileNameWithoutExtension(imageName) + ".txt");
                    File.WriteAllLines(txtPath, lines);
                    File.Copy(Path.Combine(ImagesPath, imageName), Path.Combine(ModelFile.val, imageName));
                    actualBar = actualBar + BarPlus;
                    if (actualBar >= 100)
                        actualBar = 0;
                }

            }

            // Generar classes.txt con el listado de clases en orden
            var ModelSerializer = new SerializerBuilder().WithNamingConvention(CamelCaseNamingConvention.Instance).Build();
            var finalfile = ModelSerializer.Serialize(ModelFile);

            File.WriteAllText(Path.Join(outputDirectory, "data.yaml"), finalfile);
        }

    }
}
