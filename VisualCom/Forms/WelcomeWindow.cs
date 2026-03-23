using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using VisualCom.Forms;

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
                SaveFileDlg.Filter = "Archivos de proyecto (*.xml)|*.xml";
                SaveFileDlg.InitialDirectory = UserDocuments;
                SaveFileDlg.FileName = "proyecto.xml";

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
            OpenFileDlg.Filter = "Archivos de proyecto (*.xml)|*.xml";
            OpenFileDlg.InitialDirectory = UserDocuments;
            OpenFileDlg.FileName = "proyecto.xml";

            if (OpenFileDlg.ShowDialog() == DialogResult.OK)
            {
                Configuration.ProjectFile = OpenFileDlg.FileName;
                ProjectActions.LoadProject();
                MainEditor editor = new();
                this.Hide();
                editor.Show();
            }
        }


        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }
    }
}
