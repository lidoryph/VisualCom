using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VisualCom.Forms.Editor
{
    public partial class ExitWithoutSave : Form
    {

        public Boolean left = false;
        public ExitWithoutSave()
        {
            InitializeComponent();
        }

        private void WriteChanges(object sender, EventArgs e)
        {
            ProjectActions.SaveProject();
            left = true;
            Close();
        }

        private void DiscardChanges(object sender, EventArgs e)
        {
            left = true;
            Close();
        }

        private void Returnback(object sender, EventArgs e)
        {
            left = false;
            Close();
        }

    }
}
