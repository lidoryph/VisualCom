using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VisualCom.Forms.Errors
{
    public partial class SaveImageAnnotation : Form
    {

        public bool Cancel = true;

        public SaveImageAnnotation()
        {
            InitializeComponent();
        }

        private void SaveAnnotation(object sender, EventArgs e)
        {
            ProjectActions.SaveProject(notes:true);
            Configuration.Saved = true;
            Cancel = false;
            Close();
        }

        private void DiscardAnnotation(object sender, EventArgs e)
        {
            string filecontent = File.ReadAllText(Configuration.JsonPath);

            if(filecontent == "")
                File.Delete(Configuration.JsonPath);

            Configuration.Saved = true;
            Cancel = false;
            Close();
        }

        private void CloseForm(object sender, FormClosedEventArgs e)
        {
            Cancel = true;
            Close();
        }
    }
}
