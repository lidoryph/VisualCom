using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VisualCom.Forms
{
    public partial class CreateOnlineProject : Form
    {
        public CreateOnlineProject()
        {
            InitializeComponent();
        }

        private void ObjectIdentification(object sender, EventArgs e)
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

            var netargs = (Configuration.ServerAddress, ProjectName_TextBox.Text, type, Configuration.UserName);
            dynamic result = NetActions.CreateProject(netargs);

            int scode = result[0];

            if(scode == 200)
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
