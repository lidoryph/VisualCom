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

namespace VisualCom.Forms.Editor
{
    public partial class TrainModel : Form
    {
        public TrainModel()
        {
            InitializeComponent();
            helpButton.Image = SystemIcons.Question.ToBitmap();
            getVersions();
            getGraphicsCards();
        }

        private void epochBar_ValueChanged(object sender, EventArgs e)
        {
            if (epochBar.Value == 0)
            {
                epochNumeric.Value = 1;
            }
            else
            {
                epochNumeric.Value = epochBar.Value;
            }

        }

        private void epochNumeric_ValueChanged(object sender, EventArgs e)
        {
            epochBar.Value = Convert.ToInt32(epochNumeric.Value);
        }

        private void rateBar_ValueChanged(object sender, EventArgs e)
        {
            rateNumeric.Value = rateBar.Value;
        }

        private void rateNumeric_ValueChanged(object sender, EventArgs e)
        {
            rateBar.Value = Convert.ToInt32(rateNumeric.Value);
        }

        private void imagesBar_ValueChanged(object sender, EventArgs e)
        {
            if (imagesBar.Value == 0)
            {
                imagesNumeric.Value = 1;
            }
            else
            {
                imagesNumeric.Value = imagesBar.Value;
            }

        }

        private void imagesNumeric_ValueChanged(object sender, EventArgs e)
        {
            imagesBar.Value = Convert.ToInt32(imagesNumeric.Value);
        }

        private void getGraphicsCards()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DisplayConfiguration");
            string graphicsCards = string.Empty;

            foreach (ManagementObject mo in searcher.Get())
            {
                foreach (PropertyData property in mo.Properties)
                {
                    if (property.Name == "Description")
                    {
                        useDevice.Items.Add(property.Value);
                    }
                }
            }
        }

        private void getVersions()
        {
            foreach (var path in Directory.GetDirectories(Configuration.ProjectVariables.Root.Element("Directories").Element("Versions").Value))
            {
                modelVersion.Items.Add(Path.GetFileName(path));
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            var helptrain = new HelpTrain();
            helptrain.Show();
        }

        private void TrainModOKButton_Click(object sender, EventArgs e)
        {

            string version = modelVersion.SelectedItem.ToString();
            int epoch = Convert.ToInt32(epochNumeric.Value);
            int rate = Convert.ToInt32(rateNumeric.Value);
            int images = Convert.ToInt32(imagesNumeric.Value);
            string device = useDevice.SelectedItem.ToString();
            PythonTrain.Initialize();

            TrainProgress.Enabled = true;
            PythonTrain.startTrain(version, epoch, rate, images, device);

            TrainProgress.Value = PythonTrain.status;
        }
    }
}
