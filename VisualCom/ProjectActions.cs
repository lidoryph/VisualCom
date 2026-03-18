using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace VisualCom
{
    internal static class ProjectActions
    {
        public static void NewProject()
        {
            string projectName = Path.GetFileNameWithoutExtension(Configuration.ProjectFile);
            string projectDir = Path.GetDirectoryName(Configuration.ProjectFile);
            Configuration.ProjectVariables.Root.Element("Name").Value = projectName;

            if(Directory.EnumerateFileSystemEntries(projectDir).Any())
            {
                System.IO.Directory.CreateDirectory(Path.Join(projectDir, projectName));
                projectDir = Path.Join(projectDir, projectName);
                Configuration.ProjectFile = (string) Path.Join(projectDir, (projectName + ".xml"));
            }

            Configuration.ProjectVariables.Root.Element("Directories").Element("Main").Value = projectDir;

            Configuration.ProjectVariables.Root.Element("Directories").Element("Images").Value = Path.Join(projectDir, "images");
            Configuration.ProjectVariables.Root.Element("Directories").Element("Annotations").Value = Path.Join(projectDir, "annotations");
            Configuration.ProjectVariables.Root.Element("Directories").Element("Models").Value = Path.Join(projectDir, "models");
            Configuration.ProjectVariables.Root.Element("Directories").Element("Versions").Value = Path.Join(projectDir, "versions");

            Configuration.ProjectVariables.Root.Element("Created").Value = DateTime.Now.ToString();
            Configuration.ProjectVariables.Root.Element("Modified").Value = DateTime.Now.ToString();

            foreach (var directory in Configuration.ProjectVariables.Root.Element("Directories").Elements())
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
            Configuration.ProjectVariables.Root.Element("Modified").Value = DateTime.Now.ToString();
            Configuration.ProjectVariables.Save(Configuration.ProjectFile);
        }


    }
}
