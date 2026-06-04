using System.Xml.Linq;

namespace VisualCom.Forms.Editor.Versions.Dialogs
{
    public partial class RemoveVersionOptions : Form
    {

        public Boolean Remove = false;
        public string Operation = "";
        private readonly string _vtr = "";

        public RemoveVersionOptions(string VersionToRemove)
        {
            InitializeComponent();
            foreach (string version in Directory.GetDirectories(Configuration.ProjectVersions))
                if (version != VersionToRemove) VersionSelector.Items.Add(Path.GetFileName(version));

            _vtr = VersionToRemove;
        }

        private void Accept(object sender, EventArgs e)
        {
            Remove = true;

            if (Operation == "")
            {
                MessageBox.Show("¡Tienes que seleccionar una opción!");
                return;
            }
            else if (Operation == "ADD")
            {
                string ImagesPath = Path.Join(Configuration.ProjectVersions, _vtr, "images");
                foreach (var image in Directory.GetFiles(ImagesPath))
                {
                    File.Copy(image, Path.Join(Configuration.ProjectVersions, DateTime.Now.Ticks.GetHashCode().ToString("x").ToUpper().ToString() + Path.GetExtension(image)));
                }
                Close();
            }
            else if (Operation == "MER")
            {
                string? VersionToMerge = VersionSelector.SelectedItem?.ToString();
                if (VersionToMerge == null) return;

                string ImagesPath = Path.Join(Configuration.ProjectVersions, VersionToMerge, "images");
                foreach (var image in Directory.GetFiles(ImagesPath))
                {
                    File.Copy(image, Path.Join(Configuration.ProjectVersions, VersionToMerge, "images", DateTime.Now.Ticks.GetHashCode().ToString("x").ToUpper().ToLower().ToString() + Path.GetExtension(image)));
                }
                Close();
            }
            else if (Operation == "DEL") Close();
        }

        private void Cancel(object sender, EventArgs e)
        {
            Remove = false;
            Close();
        }

        private void AddToCurrentVersion_Click(object sender, EventArgs e)
        {
            Operation = "ADD";
        }

        private void AddToSelectedVersion_Click(object sender, EventArgs e)
        {
            VersionSelector.Enabled = true;
            Operation = "MER";
        }

        private void EraseData_Click(object sender, EventArgs e)
        {
            Operation = "Del";
        }
    }
}
