using System.Xml.Linq;
using VisualCom.Forms.Errors;

namespace VisualCom.Forms.Editor.Versions
{
    public partial class NewVersion : Form
    {
        private readonly ReadingDocument error = new();
        private readonly MainEditor _editor;
        private static readonly XElement? pv_name = Configuration.ProjectVariables.Root?.Element("Name");

        public NewVersion(MainEditor window)
        {
            InitializeComponent();
            VersionSuffix.Text = pv_name?.Value;
            _editor = window;
        }

        private void CreateVersion(object sender, EventArgs e)
        {
            var CreateVersionArguments = (First: FirstOctave.Text.Trim(), Second: SecondOctave.Text.Trim(), Third: ThirdOctave.Text.Trim(), Suffix: VersionSuffix.Text);
            var VersionName = String.Join(FirstOctave.Text.Trim(), ".", SecondOctave.Text.Trim(), ".", ThirdOctave.Text.Trim(), "-", VersionSuffix.Text);


            if (System.IO.Directory.Exists(Path.Join(Configuration.ProjectVersions, VersionName)))
            {
                MessageBox.Show("¡La versión que desea crear ya existe!");
                return;
            }

            if (FirstOctave.Text.Trim().Length > 0 && SecondOctave.Text.Trim().Length > 0 && ThirdOctave.Text.Trim().Length > 0)
            {
                _editor.NewVersion(CreateVersionArguments);
                Close();
            }
            else
                MessageBox.Show("¡No has introducido todos los datos!");
        }

        private void Cancel(object sender, EventArgs e)
        {
            Close();
        }
    }
}
