using System.Xml.Linq;

namespace VisualCom.Forms
{
    public partial class ProjectType : Form
    {

        readonly XElement? pv_type = Configuration.ProjectVariables.Root?.Element("Type");

        public ProjectType()
        {
            InitializeComponent();
        }

        private void ObjectIdentification(object sender, EventArgs e)
        {
            if (pv_type == null) return;

            pv_type.Value = "OI";
            Close();
        }

        private void Classification(object sender, EventArgs e)
        {
            if (pv_type == null) return;

            pv_type.Value = "C";
            Close();
        }
    }
}
