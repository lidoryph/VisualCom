using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices.Swift;
using System.Text;
using System.Windows.Forms;

namespace VisualCom.Forms
{
    public partial class ProjectType : Form
    {
        public ProjectType()
        {
            InitializeComponent();
            OIbutton.BackColor = Color.FromArgb(214, 10, 81);
            Cbutton.BackColor = Color.FromArgb(214, 10, 81);
        }

        private void OIbutton_Click(object sender, EventArgs e)
        {
            Configuration.ProjectVariables.Root.Element("Type").Value = "OI";
            Close();

        }

        private void Cbutton_Click(object sender, EventArgs e)
        {
            Configuration.ProjectVariables.Root.Element("Type").Value = "C";
            Close();
        }

        private void ProjectType_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void OIbutton_MouseEnter(object sender, EventArgs e)
        {
            OIbutton.BackColor = Color.FromArgb(48, 39, 131);
        }

        private void OIbutton_MouseLeave(object sender, EventArgs e)
        {
            OIbutton.BackColor = Color.FromArgb(214, 10, 81);
        }

        private void Cbutton_MouseEnter(object sender, EventArgs e)
        {
            Cbutton.BackColor = Color.FromArgb(48, 39, 131);
        }

        private void Cbutton_MouseLeave(object sender, EventArgs e)
        {
            Cbutton.BackColor = Color.FromArgb(214, 10, 81);
        }
    }
}
