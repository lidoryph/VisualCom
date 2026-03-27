using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Reflection;
using VisualCom.Forms.Editor.TrainWindows;
using System.Xml.Linq;

namespace VisualCom.Forms.Editor
{
    public partial class TrainModel : Form
    {

        private readonly XElement? pv_d_versions = Configuration.ProjectVariables.Root?.Element("Directories")?.Element("Versions");
        private Boolean c_ps = Configuration.PythonStarted;

        public TrainModel()
        {
            InitializeComponent();
            HelpButton.Image = SystemIcons.Question.ToBitmap();
            GetVersions();
            GetGraphicsCards();
        }

        private void GetVersions()
        {
            if (pv_d_versions == null)
                return;

            foreach (var path in Directory.GetDirectories(pv_d_versions.Value))
                VersionSelector.Items.Add(Path.GetFileName(path));
        }
        private void GetGraphicsCards()
        {
            ManagementObjectSearcher searcher = new("SELECT * FROM Win32_DisplayConfiguration");

            foreach (ManagementObject mo in searcher.Get().Cast<ManagementObject>())
            {
                foreach (PropertyData property in mo.Properties)
                {
                    if (property.Name == "Description")
                    {
                        DeviceSelector.Items.Add(property.Value);
                    }
                }
            }
        }

        private async void InitTrainModel(object sender, EventArgs e)
        {
            TrainModelButton.Enabled = false;
            TrainProgress.Enabled = true;

            string? Version = VersionSelector.SelectedItem?.ToString();
            string? Device = DeviceSelector.SelectedItem?.ToString();

            if (Version == null || Device == null)
            {
                MessageBox.Show("Ha habido un error recogiendo información.");
                return;
            }

            var PythonArguments = (version: Version, epoch: Convert.ToInt32(EpochNumeric.Value),
                rate: Convert.ToInt32(RateNumeric.Value), images: Convert.ToInt32(ImagesNumeric.Value), device: Device);

            dynamic? result = await Task.Run(() =>
                PythonTrain.StartTrain(PythonArguments)
            );

            if (result == null) return;

            TrainProgress.Value = (int)result;
            TrainModelButton.Enabled = true;
            TrainProgress.Enabled = false;

        }
        private void ShowHelpDlg(object sender, EventArgs e)
        {
            HelpTrain dialog = new();
            dialog.ShowDialog();
        }

        private async void TrainModCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EpochBar_ValueChanged(object sender, EventArgs e)
        {
            if (EpochBar.Value == 0)
                EpochNumeric.Value = 1;
            else
                EpochNumeric.Value = EpochBar.Value;
        }

        private void EpochNumeric_ValueChanged(object sender, EventArgs e)
        {
            EpochBar.Value = Convert.ToInt32(EpochNumeric.Value);
        }

        private void RateBar_ValueChanged(object sender, EventArgs e)
        {
            RateNumeric.Value = RateBar.Value;
        }

        private void RateNumeric_ValueChanged(object sender, EventArgs e)
        {
            RateBar.Value = Convert.ToInt32(RateNumeric.Value);
        }

        private void ImagesBar_ValueChanged(object sender, EventArgs e)
        {
            if (ImagesBar.Value == 0)
                ImagesNumeric.Value = 1;
            else
                ImagesNumeric.Value = ImagesBar.Value;

        }

        private void ImagesNumeric_ValueChanged(object sender, EventArgs e)
        {
            ImagesBar.Value = Convert.ToInt32(ImagesNumeric.Value);
        }
    }
}
