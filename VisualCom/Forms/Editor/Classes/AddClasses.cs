using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using VisualCom.Forms.Errors;
using System.Xml.Linq;

namespace VisualCom.Forms.Editor.Classes
{
    public partial class AddClasses : Form
    {



        string className = "";
        Color classColor;
        Boolean changedcolor = false;
        private readonly MainEditor _editor;

        public AddClasses(MainEditor window)
        {
            InitializeComponent();
            boxClassName.PlaceholderText = "Escriba aqui...";
            _editor = window;

            if (Configuration.ProjectVariables.Root == null)
                Application.Exit();
            else if (Configuration.ProjectVariables.Root.Element("Classes") == null)
                Application.Exit();

        }


        private void SelectColor(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            openClassColor.BackColor = colorDialog.Color;

            if (colorDialog.Color.GetBrightness() > 0.85)
                openClassColor.ForeColor = Color.Black;
            else
                openClassColor.ForeColor = Color.White;

            classColor = colorDialog.Color;
            changedcolor = true;
        }

        private void SetClassName(object sender, EventArgs e)
        {
            className = boxClassName.Text;
        }

        private void AddClassToFile(object sender, EventArgs e)
        {
            className = className.Trim();

            XElement? pv_classes = Configuration.ProjectVariables.Root?.Element("Classes");
            if (pv_classes == null)
            {
                ReadingDocument error = new();
                error.Show();
                return;
            }

            if (changedcolor = true && className.Trim() != "")
            {
                pv_classes.Add(new XElement("Class", new XAttribute("color", ColorTranslator.ToHtml(classColor)), new XAttribute("id", String.Join(className, ColorTranslator.ToHtml(classColor)).GetHashCode().ToString()), className));
                (string, string) classtoadd = (className, ColorTranslator.ToHtml(classColor).ToString());
                _editor.AddExternalClass(classtoadd);

                Configuration.Saved = false;

                boxClassName.Text = "";
                openClassColor.BackColor = Color.White;
                openClassColor.ForeColor = Color.Black;
                changedcolor = false;
            }
            else
                MessageBox.Show("¡No has especificado todos los valores!");
        }

        private void CloseDialog(object sender, EventArgs e)
        {
            Close();
        }

    }
}
