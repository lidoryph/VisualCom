using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VisualCom.Forms.Errors
{
    public partial class ReadingDocument : Form
    {

        public Boolean errorAccepted = false;

        public ReadingDocument()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorAccepted = true;
            Application.Exit();
        }

        private void ReadingDocument_FormClosed(object sender, FormClosedEventArgs e)
        {
            errorAccepted = true;
            Application.Exit();
        }
    }
}
