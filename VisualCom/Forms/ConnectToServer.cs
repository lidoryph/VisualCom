using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VisualCom.Forms
{
    public partial class ConnectToServer : Form
    {

        public ConnectToServer()
        {
            InitializeComponent();
        }

        private void ConnectServer(object sender, EventArgs e)
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

            PythonTrain.Initialize();
            dynamic server_status = NetActions.pingServer();
            int scode = server_status[0];
            string stext = server_status[1];

            if(scode != 200)
            {
                MessageBox.Show("No se ha podido comunicar con el servidor, por favor, compruebe sus datos.");
                return;
            }

            Configuration.UserName = User_TextBox.Text;
            Configuration.Online = true;


            OnlineProjects onlineprojects_dialog = new();
            onlineprojects_dialog.Show();
            Close();
        }

        private void CloaseDialog(object sender, EventArgs e)
        {
            Close();
        }


    }
}
