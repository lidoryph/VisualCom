using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using VisualCom.Forms.Editor.Versions.Dialogs;

namespace VisualCom.Forms.Editor.Versions
{
    public partial class RemoveVersion : Form
    {

        private readonly MainEditor _editor;
        private readonly XElement? pv_versions = Configuration.ProjectVariables.Root?.Element("Directories")?.Element("Versions");

        public RemoveVersion(MainEditor window)
        {
            InitializeComponent();
            _editor = window;

            if (pv_versions?.Value != null && Directory.Exists(pv_versions.Value))
            {
                foreach (string version in Directory.GetDirectories(pv_versions.Value))
                    VersionSelector.Items.Add(Path.GetFileName(version));
            }

        }

        private void LocalRemoveVersion(object sender, EventArgs e)
        {
            string? Version = VersionSelector.SelectedItem?.ToString();
            if (Version == null)
                return;

            RemoveVersionOptions dialog = new(Version);
            dialog.ShowDialog();

            if (dialog.Remove == false)
            {
                return;
            }
            
            _editor.RemoveVersion(Version);
            Close();

        }

        private void Cancel(object sender, EventArgs e)
        {
            Close();
        }
    }
}
