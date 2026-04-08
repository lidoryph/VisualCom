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
            string projecttype = ProjectType.Text;

            (string, string, string) netArgs = (url, projectname, projecttype);

            PythonTrain.Initialize();
            bool created = NetActions.createProject(netArgs);
            if (created)
                MessageBox.Show("Project made!");
            else
                MessageBox.Show("Couldn't make");
        }

        private void GetProjects(object sender, EventArgs e)
        {
            string url = "http://" + ServerURL.Text + ":" + PortNumber.Value;

            PythonTrain.Initialize();
            dynamic result = NetActions.GetProjects(url);
            int? scode = result[0];
            string? rawprojects = result[1];


            if(scode != 200)
            {
                MessageBox.Show("There was an error.");
                return;
            }

            if(rawprojects == null)
            {
                MessageBox.Show("Couldn't get projects.");
                return;
            }

            rawprojects = rawprojects.Replace("[", "").Replace("]", "");

            if(rawprojects == "No projects to serve.")
            {
                MessageBox.Show("Currently there are no projects to serve. Please make one.");
                return;
            }

            string[] projects = rawprojects.Split(',');

            foreach(string project in projects)
                ProjectsList.Items.Add(project);

        }
        
        private void GetClasses(object sender, EventArgs e)
        {
            string url = "http://" + ServerURL.Text + ":" + PortNumber.Value;

            PythonTrain.Initialize();
            dynamic result = NetActions.GetProjects(url);
            int? scode = result[0];
            string? rawprojects = result[1];
        }
    }
}
