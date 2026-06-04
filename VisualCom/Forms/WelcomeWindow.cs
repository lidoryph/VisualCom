using System.Xml.Linq;
using VisualCom.Forms;
using VisualCom.Forms.Editor;

namespace VisualCom
{
    public partial class WelcomeWindow : Form
    {

        private readonly XElement? pv_type = Configuration.ProjectVariables.Root?.Element("Type");

        public WelcomeWindow()
        {
            InitializeComponent();
        }

        private void NewProject(object sender, EventArgs e)
        {
            if (pv_type == null)
                return;

            var projecttype = new ProjectType();
            projecttype.ShowDialog();

            if (pv_type.Value != "")
            {
                string UserDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                SaveFileDlg.Title = "Crea un proyecto...";
                SaveFileDlg.Filter = "Archivos de proyecto (*.asaivc)|*.asaivc";
                SaveFileDlg.InitialDirectory = UserDocuments;
                SaveFileDlg.FileName = "proyecto.asaivc";

                if (SaveFileDlg.ShowDialog() == DialogResult.OK)
                {
                    Configuration.ProjectFile = SaveFileDlg.FileName;
                    ProjectActions.NewProject();
                    MainEditor editor = new();
                    this.Hide();
                    editor.Show();
                }
            }
        }

        private void LoadProject(object sender, EventArgs e)
        {
            string UserDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            OpenFileDlg.Title = "Abrir proyecto...";
            OpenFileDlg.Filter = "Archivos de proyecto (*.asaivc)|*.asaivc";
            OpenFileDlg.InitialDirectory = UserDocuments;
            OpenFileDlg.FileName = "proyecto.asaivc";

            if (OpenFileDlg.ShowDialog() == DialogResult.OK)
            {
                Configuration.ProjectFile = OpenFileDlg.FileName;
                ProjectActions.LoadProject();
                MainEditor editor = new();
                Hide();
                editor.Show();
            }
        }

        private void ConnectServer(object sender, EventArgs e)
        {
            Hide();
            using var server_dialog = new ConnectToServer(this);
            server_dialog.ShowDialog(this);

        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }
    }
}
