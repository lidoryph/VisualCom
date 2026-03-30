using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VisualCom.Forms.Editor.PullModels
{
    public partial class PullModel : Form
    {

        private string Mode = "LIST";

        public PullModel()
        {
            InitializeComponent();
            List<string> AvailableModels = ["YOLO26 Nano", "YOLO26 Small", "YOLO26 Medium", "YOLO26 Large", "YOLO26 Extra", "YOLO11 Medium", "YOLO11 Extra"];
            foreach (string model in AvailableModels)
                ModelsList.Items.Add(model);
        }

        private async void GetListModel(object sender, EventArgs e)
        {
            WaitingRoom dlg = new();
            _ = dlg.ShowDialogAsync();
            string model = "";
            int result = -100;

            if (Mode == "LIST")
            {
                model = ModelsList.Text.ToString();

                PythonTrain.Initialize();

                result = await Task.Run(() =>
                    PythonTrain.GetListModel(model)
                );

                while (result == -100) { }
                dlg.Close();
                if (result == 0)
                {
                    Close();
                } else if (result == -1)
                {
                    MessageBox.Show("Ha ocurrido un error fatal.\nSe va a cerrar el programa.");
                    Application.Exit();
                } else if (result == -2)
                    MessageBox.Show("¡Este modelo ya existe!");

            } else if (Mode == "ONLINE")
            {
                model = InternetModelURL.Text.ToString();

                PythonTrain.Initialize();

                result = await Task.Run(() =>
                    PythonTrain.PullModel(model)
                );

                while (result == -100) { }
                dlg.Close();
                if (result == 0)
                    Close();
                else if (result == -1)
                    MessageBox.Show("No se ha encontrado el modelo.\nIntentelo de nuevo.");
                else if (result == -2)
                    MessageBox.Show("¡Este modelo ya existe!");
                else if (result == -3)
                    MessageBox.Show("Ha habido un error conectandose al sitio.\nIntentelo de nuevo mas tarde.");
            }
        }

        private void GoBack(object sender, EventArgs e)
        {
            Close();
        }

        // +++ CHANGE ELEMENTS STATUS +++
        private void ListModel(object sender, EventArgs e)
        {
            ModelsList.Enabled = true;
            InternetModelURL.Enabled = false;
            InternetModelURL.ReadOnly = true;
            PullModelButton.Enabled = true;
            Mode = "LIST";
        }

        private void InternetModel(object sender, EventArgs e)
        {
            ModelsList.Enabled = false;
            InternetModelURL.Enabled = true;
            InternetModelURL.ReadOnly = false;
            PullModelButton.Enabled = true;
            Mode = "ONLINE";
        }

        // --- CHANGE ELEMENTS STAUTS ---


    }
}
