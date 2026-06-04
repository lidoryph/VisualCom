using System.Xml.Linq;

namespace VisualCom.Forms.Editor.TrainWindows
{
    public partial class ExportToYolo : Form
    {

        string ModelPath = "";

        public ExportToYolo()
        {
            InitializeComponent();

             foreach (string version in Directory.GetDirectories(Configuration.ProjectVersions))
                VersionSelector.Items.Add(Path.GetFileName(version));
        }

        private void Export(object sender, EventArgs e)
        {
            if (VersionSelector.SelectedItem == null)
            {
                MessageBox.Show("¡Tienes que seleccionar una versión para exportar!");
                return;
            }

            ModelPath = Path.Join(Configuration.ProjectVersions, YOLOName.Text);

            if (Directory.Exists(ModelPath))
            {
                MessageBox.Show("¡El modelo ya existe!\nEscoge otro nombre.");
                return;
            }

            ModelPath = Path.Join(Configuration.ProjectVersions, YOLOName.Text);
            string VersionPath = Path.Join(Configuration.ProjectVersions, VersionSelector?.SelectedItem?.ToString());

            ProjectActions.ExportToYOLO(VersionPath, ModelPath, (Int32)ImagesNum.Value);
            ExportButton.Enabled = false;
        }

        private void Cancel(object sender, EventArgs e)
        {
            Close();
        }

        private void SetName(object sender, EventArgs e)
        {
            YOLOName.Text = VersionSelector?.SelectedItem?.ToString();
        }

        private void EnableCustomName(object sender, EventArgs e)
        {
            YOLOName.ReadOnly = !YOLOName.ReadOnly;
            YOLOName.Enabled = !YOLOName.Enabled;
        }

        private void ChangedNumeric(object sender, EventArgs e)
        {
            ImagesBar.Value = (Int32)ImagesNum.Value;
        }

        private void ChangedBar(object sender, EventArgs e)
        {
            ImagesNum.Value = (Int32)ImagesBar.Value;
        }

    }
}
