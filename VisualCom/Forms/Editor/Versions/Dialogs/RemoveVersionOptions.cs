using System.Xml.Linq;

namespace VisualCom.Forms.Editor.Versions.Dialogs
{
    public partial class RemoveVersionOptions : Form
    {

        public Boolean Remove = false;
        private readonly XElement? pv_versions = Configuration.ProjectVariables.Root?.Element("Directories")?.Element("Versions");
        private readonly XElement? pv_images = Configuration.ProjectVariables.Root?.Element("Directories")?.Element("Images");
        public string Operation = "";
        private readonly string _vtr = "";

        public RemoveVersionOptions(string VersionToRemove)
        {
            InitializeComponent();
            if (pv_versions?.Value != null && Directory.Exists(pv_versions.Value))
            {
                foreach (string version in Directory.GetDirectories(pv_versions.Value))
                    if (version != VersionToRemove)
                        VersionSelector.Items.Add(Path.GetFileName(version));
            }

            _vtr = VersionToRemove;
        }

        private void Accept(object sender, EventArgs e)
        {
            if (pv_versions == null || pv_images == null) return;
            Remove = true;


            if (Operation == "")
            {
                MessageBox.Show("¡Tienes que seleccionar una opción!");
                return;
            }
            else if (Operation == "ADD")
            {
                string ImagesPath = Path.Join(pv_versions.Value, _vtr, "images");
                foreach (var image in Directory.GetFiles(ImagesPath))
                {
                    File.Copy(image, Path.Join(pv_images.Value, DateTime.Now.Ticks.GetHashCode().ToString("x").ToUpper().ToString() + Path.GetExtension(image)));
                }
                Close();
            }
            else if (Operation == "MER")
            {
                string? VersionToMerge = VersionSelector.SelectedItem?.ToString();
                if (VersionToMerge == null) return;

                string ImagesPath = Path.Join(pv_versions.Value, VersionToMerge, "images");
                foreach (var image in Directory.GetFiles(ImagesPath))
                {
                    File.Copy(image, Path.Join(pv_versions.Value, VersionToMerge, "images", DateTime.Now.Ticks.GetHashCode().ToString("x").ToUpper().ToLower().ToString() + Path.GetExtension(image)));
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
