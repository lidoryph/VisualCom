using System.Xml.Linq;
using VisualCom.Forms.Editor.Versions.Dialogs;

namespace VisualCom.Forms.Editor.Versions
{
    public partial class RemoveVersion : Form
    {


        public RemoveVersion()
        {
            InitializeComponent();

            foreach (string version in Directory.GetDirectories(Configuration.ProjectVersions))
                VersionSelector.Items.Add(Path.GetFileName(version));

        }

        private void LocalRemoveVersion(object sender, EventArgs e)
        {
            string? Version = VersionSelector.SelectedItem?.ToString();
            if (Version == null)
                return;

            RemoveVersionOptions dialog = new(Version);
            dialog.ShowDialog();

            if (dialog.Remove == false) return;

            MainEditor.RemoveVersion(Version);
            Close();

        }

        private void Cancel(object sender, EventArgs e)
        {
            Close();
        }
    }
}
