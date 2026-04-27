using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VisualCom.Forms
{
    public partial class DeleteProjectConfirmation : Form
    {
        public Boolean Delete = false;

        public DeleteProjectConfirmation()
        {
            InitializeComponent();
        }

        private void DeleteConfirmed(object sender, EventArgs e)
        {
            Delete = true;
            Close();
        }

        private void DeleteCancelled(object sender, EventArgs e)
        {
            Delete = false;
            Close();
        }

    }
}
