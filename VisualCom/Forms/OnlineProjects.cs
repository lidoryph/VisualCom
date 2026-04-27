using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VisualCom.Forms
{
    public partial class OnlineProjects : Form
    {
        public OnlineProjects()
        {
            InitializeComponent();
            dynamic projectsnet = NetActions.GetProjects();
            int _scode = projectsnet[0];
            string _stext = projectsnet[1];

            if(_stext != "No projects to serve.") {
                _stext = _stext.Trim().Replace("[", "").Replace("]", "");
                var contents = _stext.Split();

                foreach (var project in contents)
                    ProjectsList.Items.Add(project.Replace(",", ""));
            }
        }

        private void CreateProject(object sender, EventArgs e)
        {

        }

        private void DeleteProject(object sender, EventArgs e)
        {
            if (ProjectsList.SelectedItem == null)
                return;

            DeleteProjectConfirmation deleteProject_dialog = new();
            deleteProject_dialog.ShowDialog();

            if (!deleteProject_dialog.Delete)
                return;


            var netargs = (Configuration.ServerAddress, ProjectsList.SelectedItem.ToString(), Configuration.UserName);

            dynamic response = NetActions.DeleteProject(netargs);
            int scode = response[0];
            string stext = response[1];
            if(scode == 200) {
                ProjectsList.Items.Remove(ProjectsList.SelectedItem);
                MessageBox.Show("¡Proyecto Borrado!");
            } else
                MessageBox.Show("Un error ha ocurrido y el proyecto no ha podido ser eliminado.");

            

        }

        private void Disconnect(object sender, EventArgs e)
        {
            DisconnectConfirmation disconnect = new();
            disconnect.ShowDialog();

            if (!disconnect.Disconnect)
                return;

            Configuration.Online = false;
            Configuration.ServerAddress = "";
            Configuration.UserName = "";
            Close();
        }

        private void ChangedSelectionList(object sender, EventArgs e)
        {
            if(ProjectsList.SelectedItems.Count == 0)
            {
                LoadProject_Button.Enabled = false;
                EraseProject_Button.Enabled = false;
                EraseProject_Button.Text = "Borrar proyecto...";
            } else if (ProjectsList.SelectedItems.Count == 1)
            {
                LoadProject_Button.Enabled = true;
                EraseProject_Button.Enabled = true;
                EraseProject_Button.Text = "Borrar proyecto...";
            } else
            {
                LoadProject_Button.Enabled = false;
                EraseProject_Button.Enabled = true;
                EraseProject_Button.Text = "Borrar proyectos...";
            }
        }

    }
}
