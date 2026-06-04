using System.Xml.Linq;
using VisualCom.Forms.Editor.Versions;

namespace VisualCom.Forms.Editor
{
    public partial class MainEditor
    {
        private void DialogNewVersion(object sender, EventArgs e)
        {
            NewVersion dialog = new(this);
            dialog.ShowDialog();
        }

        public void NewVersion((string, string, string, string) VersionArguments)
        {
            if (pv_version == null || pv_classes == null)
            {
                error.ShowDialog();
                return;
            }

            string FirstOctave = VersionArguments.Item1;
            string SecondOctave = VersionArguments.Item2;
            string ThirdOctave = VersionArguments.Item3;
            string VersionSuffix = VersionArguments.Item4;

            string VersionName = FirstOctave + "." + SecondOctave + "." + ThirdOctave + "-" + VersionSuffix;
            string VersionPath = Path.Join(Configuration.ProjectVersions, VersionName);
            string VersionImages = Path.Join(VersionPath, "images");
            string VersionAnnotations = Path.Join(VersionPath, "annotations");

            XDocument VersionDoc = new(
                new XElement("Version",
                    new XElement("Name", VersionName),
                    new XElement("Classes")
                )
            );

            foreach (XElement Class in pv_classes.Elements("Class"))
                VersionDoc.Root?.Element("Classes")?.Add(Class);

            System.IO.Directory.CreateDirectory(VersionPath);
            System.IO.Directory.CreateDirectory(VersionImages);
            System.IO.Directory.CreateDirectory(VersionAnnotations);

            foreach (var image in System.IO.Directory.GetFiles(Configuration.ProjectImages))
                System.IO.File.Copy(image, Path.Join(VersionImages, Path.GetFileName(image)));
            foreach (var note in System.IO.Directory.GetFiles(Configuration.ProjectAnnotations))
                System.IO.File.Copy(note, Path.Join(VersionAnnotations, Path.GetFileName(note)));

            VersionDoc.Save(Path.Join(VersionPath, VersionName + ".asaivc"));

            pv_version.Value = VersionName;
            ProjectActions.SaveProject(notes: false);
        }

        private void DialogRemoveVersion(object sender, EventArgs e)
        {
            RemoveVersion dialog = new();
            dialog.ShowDialog();
        }

        static public void RemoveVersion(string version)
        {
            string VersionPath = Path.Join(Configuration.ProjectVersions, version);
            System.IO.Directory.Delete(VersionPath, true);
        }
    }
}
