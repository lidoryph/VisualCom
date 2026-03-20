using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices.Swift;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace VisualCom.Forms
{
    public partial class ProjectType : Form
    {

        XElement? pv_type = Configuration.ProjectVariables.Root?.Element("Type");

        public ProjectType()
        {
            InitializeComponent();
        }

        private void OIbutton_Click(object sender, EventArgs e)
        {
            if (pv_type == null)
                return;

            pv_type.Value = "OI";
            Close();

        }

        private void Cbutton_Click(object sender, EventArgs e)
        {
            if (pv_type == null)
                return;

            pv_type.Value = "C";
            Close();
        }

        private void ProjectType_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

    }
}
