using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using VisualCom.Forms.Errors;

namespace VisualCom
{
    internal static class ProjectActions
    {
        private static readonly ReadingDocument error = new();
        private static readonly string? c_pf = Configuration.ProjectFile; 
        private static readonly XElement? pv_name = Configuration.ProjectVariables.Root?.Element("Name");
        private static readonly XElement? pv_created = Configuration.ProjectVariables.Root?.Element("Created");
        //private static readonly XElement? pv_modified = Configuration.ProjectVariables.Root?.Element("Modified");
        private static readonly XElement? pv_modified = null;

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
               
            

            string projectName = Path.GetFileNameWithoutExtension(c_pf);
            pv_name.Value = projectName;

            string? projectDir = Path.GetDirectoryName(c_pf);

            if (projectDir == null)
                return;

            if (Directory.EnumerateFileSystemEntries(projectDir).Any())
            {
                System.IO.Directory.CreateDirectory(Path.Join(projectDir, projectName));
                projectDir = Path.Join(projectDir, projectName);
                Configuration.ProjectFile = (string)Path.Join(projectDir, (projectName + ".xml"));
            }

            pv_main.Value = projectDir;

            pv_images.Value = Path.Join(projectDir, "images");
            pv_annotations.Value = Path.Join(projectDir, "annotations");
            pv_models.Value = Path.Join(projectDir, "models");
            pv_versions.Value = Path.Join(projectDir, "versions");

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

        public static void LoadProject()
        {
            Configuration.ProjectVariables = XDocument.Load(Configuration.ProjectFile);
        }

        public static void SaveProject()
        {
            if (pv_modified == null || c_pf == null)
            {
                Clipboard.SetText(Configuration.ProjectVariables.ToString());
                MessageBox.Show("El contenido de tu proyecto esta en tu portapapeles. Copialo en un lugar seguro.");
                error.ShowDialog();
                return;
            }
                

            pv_modified.Value = DateTime.Now.ToString();
            Configuration.ProjectVariables.Save(c_pf);
        }


    }
}
