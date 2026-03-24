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

namespace VisualCom
{
    internal static class ProjectActions
    {
        private static readonly ReadingDocument error = new();
        private static readonly string? c_pf = Configuration.ProjectFile; 
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
                System.IO.Directory.CreateDirectory(Path.Join(ProjectDir, ProjectName));
                ProjectDir = Path.Join(ProjectDir, ProjectName);
                Configuration.ProjectFile = (string)Path.Join(ProjectDir, (ProjectName + ".xml"));
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


            Configuration.ProjectVariables.Save(Configuration.ProjectFile);
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

        public static void ExportToYOLO(string VersionPath, string outputDirectory)
        {
            if (pv_annotations == null || pv_images == null)
            {
                error.ShowDialog();
                return;
            }

            string DocumentPath = Path.Combine(VersionPath, Path.GetFileName(VersionPath) + ".xml");
            XDocument VerDoc = XDocument.Load(DocumentPath);

            string ImagesPath = VerDoc.Root?.Element("Directories")?.Element("Images")?.Value;
            string AnnotationsPath = VerDoc.Root?.Element("Directories")?.Element("Annotations")?.Value;
            XElement? v_classes = VerDoc.Root?.Element("Classes");


            // Construir el índice de clases desde el XML { "Perro": 0, "Gato": 1, ... }
            var classIndex = new Dictionary<string, int>();
            int idx = 0;
            foreach (var cls in v_classes.Elements("Class"))
            {
                classIndex[cls.Value] = idx;
                idx++;
            }

            Directory.CreateDirectory(outputDirectory);

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

                string txtPath = Path.Join(outputDirectory, Path.GetFileNameWithoutExtension(imageName) + ".txt");
                File.WriteAllLines(txtPath, lines);
            }

            string pathtest;

            foreach (var image in Directory.GetFiles(ImagesPath))
            {   
                pathtest = Path.Join(outputDirectory, Path.GetFileName(image));
                File.Copy(image, Path.Join(outputDirectory, Path.GetFileName(image)));
            }

            // Generar classes.txt con el listado de clases en orden
            var classList = classIndex.OrderBy(c => c.Value).Select(c => c.Key);
            File.WriteAllLines(Path.Join(outputDirectory, "classes.txt"), classList);
        }

    }
}
