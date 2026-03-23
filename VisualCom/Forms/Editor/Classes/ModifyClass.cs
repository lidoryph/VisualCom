using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using VisualCom.Forms.Errors;

namespace VisualCom.Forms.Editor.Classes
{
    public partial class ModifyClass : Form
    {
        private readonly MainEditor _editor;
        private readonly string _id;
        private readonly string _name;
        private readonly string _color;
        string className = "";
        Color classColor;
        Boolean changedcolor = false;

        private readonly XElement? pv_classes = Configuration.ProjectVariables.Root?.Element("Classes");

        public ModifyClass(MainEditor window, string id, string classname, string color)
        {
            InitializeComponent();
            _editor = window;
            _id = id;
            _name = classname;
            _color = color;
            className = classname;
            classColor = ColorTranslator.FromHtml(color);
            ClassRenamer.Text = classname;
            OpenClassSelector.BackColor = ColorTranslator.FromHtml(color);
        }
        private void SetClassName(object sender, EventArgs e)
        {
            className = ClassRenamer.Text;
        }

        private void SelectColor(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            OpenClassSelector.BackColor = colorDialog.Color;

            if (colorDialog.Color.GetBrightness() > 0.85)
                OpenClassSelector.ForeColor = Color.Black;
            else
                OpenClassSelector.ForeColor = Color.White;

            classColor = colorDialog.Color;
            changedcolor = true;
        }

        private void Modify(object sender, EventArgs e)
        {
            className = className.Trim();
            
            if (pv_classes == null)
            {
                ReadingDocument error = new();
                error.Show();
                return;
            }

            if (changedcolor = true || className.Trim() != _name)
            {
                _editor.ModifyExternalClass(_id, className, ColorTranslator.ToHtml(classColor));

                Configuration.Saved = false;
                Close();
            }
            else
                Close();
        }
        private void CloseDialog(object sender, EventArgs e)
        {
            Close();
        }
    }
}
