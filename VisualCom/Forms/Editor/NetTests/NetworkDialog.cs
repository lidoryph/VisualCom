using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VisualCom.Forms.Editor.NetTests
{
    public partial class NetworkDialog : Form
    {
        public NetworkDialog()
        {
            InitializeComponent();
        }    
        private void PingServer(object sender, EventArgs e) 
        {
            string url = "http://" + ServerURL.Text + ":" + PortNumber.Value;
            PythonTrain.Initialize();
            bool pinged = NetActions.pingServer(url);
            if (pinged)
                MessageBox.Show("Pong!");
            else
                MessageBox.Show("Couldn't ping");
        }

        private void NewProject(object sender, EventArgs e)
        {
            string url = "http://" + ServerURL.Text + ":" + PortNumber.Value;
            string projectname = ProjectName.Text;
            PythonTrain.Initialize();
            bool created;
        }

    }



}
