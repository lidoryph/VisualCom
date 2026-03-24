using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace VisualCom.Forms.Editor.TrainWindows
{
    public partial class ExportToYolo : Form
    {

        private readonly XElement? pv_versions = Configuration.ProjectVariables.Root?.Element("Directories")?.Element("Versions");
        private readonly XElement? pv_models = Configuration.ProjectVariables.Root?.Element("Directories")?.Element("Models");
        string ModelPath = "";

        public ExportToYolo()
        {
            InitializeComponent();

            if (pv_versions != null)
            {
                foreach (string version in Directory.GetDirectories(pv_versions.Value))
                    VersionSelector.Items.Add(Path.GetFileName(version));
            }
        }

        private void Export(object sender, EventArgs e)
        {
            if (pv_models == null || pv_versions == null)
                return;

            if (VersionSelector.SelectedItem == null)
            {
                MessageBox.Show("¡Tienes que seleccionar una versión para exportar!");
                return;
            }

            ModelPath = Path.Join(pv_models.Value, YOLOName.Text);

            if (Directory.Exists(ModelPath))
            {
                MessageBox.Show("¡El modelo ya existe!\nEscoge otro nombre.");
                return;
            }

            ModelPath = Path.Join(pv_models.Value, YOLOName.Text);
            string VersionPath = Path.Join(pv_versions.Value, VersionSelector?.SelectedItem?.ToString());

            ProjectActions.ExportToYOLO(VersionPath, ModelPath);
            OpenLocation.Enabled = true;
            ExportButton.Enabled = false;
        }

        private void Cancel(object sender, EventArgs e)
        {
            Close();
        }

        private void OpenFolder(object sender, EventArgs e)
        {
            Process.Start("explorer", ModelPath);
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

    }
}
