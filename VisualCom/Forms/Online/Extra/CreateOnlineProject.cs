using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VisComClient;

namespace VisualCom.Forms
{
    public partial class CreateOnlineProject : Form
    {

        public string ProjectName = "";

        public CreateOnlineProject()
        {
            InitializeComponent();
        }

        private async void CreateProjectAsync(object sender, EventArgs e)
        {
            if (ProjectName_TextBox.Text == "")
                return;

            string type = "";

            if (OI_Radio.Checked == true)
                type = "OI";
            else if (C_Radio.Checked == true)
                type = "C";
            else
                return;


            var Response = await Configuration.Connection.CreateProject(ProjectName_TextBox.Text, type);


            if(Response.Item1 == 200)
            {
                MessageBox.Show("¡Proyecto creado!");
                Close();
            } else
            {
                MessageBox.Show("Ha habido un error y el proyecto no ha sido creado.");
                Close();
            }

        }
    }
}
