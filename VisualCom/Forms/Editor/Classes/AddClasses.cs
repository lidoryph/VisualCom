using System.Xml.Linq;
using VisualCom.Forms.Errors;

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
            ClassNamer.PlaceholderText = "Escriba aqui...";
            _editor = window;
        }

        private void SetClassName(object sender, EventArgs e)
        {
            className = ClassNamer.Text;
        }

        private void SelectColor(object sender, EventArgs e)
        {
            ColorDialog.ShowDialog();
            OpenColorSelector.BackColor = ColorDialog.Color;

            if (ColorDialog.Color.GetBrightness() > 0.85)
                OpenColorSelector.ForeColor = Color.Black;
            else
                OpenColorSelector.ForeColor = Color.White;

            classColor = ColorDialog.Color;
            changedcolor = true;
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

                ClassNamer.Text = "";
                OpenColorSelector.BackColor = Color.White;
                OpenColorSelector.ForeColor = Color.Black;
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
