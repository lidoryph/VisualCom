using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VisComClient;
using VisualCom.Forms.Online.Extra;

namespace VisualCom.Forms
{
    public partial class ConnectToServer : Form
    {

        public ConnectToServer()
        {
            InitializeComponent();
        }

        private async void ConnectServer(object sender, EventArgs e)
        {
            if(ServerIP_TextBox.Text == "" || User_TextBox.Text == "")
            {
                MessageBox.Show("¡Necesitas rellenar todas las casillas!");
                return;
            }

            if (ServerIP_TextBox.Text.StartsWith("http://") || ServerIP_TextBox.Text.StartsWith("https://"))
            {
                if (ServerPort_TextBox.Text == "")
                    Configuration.ServerAddress = ServerIP_TextBox.Text;
                else
                    Configuration.ServerAddress = ServerIP_TextBox.Text + ":" + ServerPort_TextBox.Text;
            }
            else
            {
                if (ServerPort_TextBox.Text == "")
                    Configuration.ServerAddress = "http://" + ServerIP_TextBox.Text;
                else
                    Configuration.ServerAddress = "http://" + ServerIP_TextBox.Text + ":" + ServerPort_TextBox.Text;
            }

            LoadingScreen loading_dlg = new("Espere mientras se le conecta con el servidor.");
            _ = loading_dlg.ShowDialogAsync();

            Configuration.Connection = new(Configuration.ServerAddress, User_TextBox.Text);
            int LoginStatus = await Configuration.Connection.LoginAsync();

            if(LoginStatus != 200)
            {
                MessageBox.Show("No se ha podido iniciar sesión. Intentelo de nuevo.");
                Close();
                return;
            }

            int PingStatus = await Configuration.Connection.PingServer();

            if(PingStatus != 200)
            {
                loading_dlg.Close();
                MessageBox.Show("No se ha podido comunicar con el servidor, por favor, compruebe sus datos.");
                Close();
                return;
            }

            Configuration.UserName = User_TextBox.Text;
            Configuration.Online = true;

            var Projects = await Configuration.Connection.GetProjects();
            if(Projects.Item1 != 200)
            {
                loading_dlg.Close();
                MessageBox.Show("Ha habido un error recibiendo los proyectos, por favor, intentelo de nuevo mas tarde.");
                Configuration.UserName = "";
                Configuration.Online = false;
                Close();
                return;
            }

            OnlineProjects onlineprojects_dialog = new(Projects.Item2);
            loading_dlg.Close();
            onlineprojects_dialog.Show();
            Close();
        }

        private void CloaseDialog(object sender, EventArgs e)
        {
            Close();
        }


    }
}
