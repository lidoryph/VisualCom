using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VisualCom.Forms;

namespace VisualCom
{
    public partial class WelcomeWindow : Form
    {

        public WelcomeWindow()
        {
            InitializeComponent();
            btnNewProject.BackColor = Color.FromArgb(214, 10, 81);
            btnLoadProject.BackColor = Color.FromArgb(214, 10, 81);
        }

        private void btnLoadProject_Click(object sender, EventArgs e)
        {
            dlgOpenFile.Title = "Abrir proyecto...";
            dlgOpenFile.Filter = "Archivos de proyecto (*.xml)|*.xml";
            dlgOpenFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dlgOpenFile.FileName = "proyecto.xml";

            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                Configuration.ProjectFile = dlgOpenFile.FileName;
                ProjectActions.LoadProject();
                var editorWindow = new MainEditor();
                editorWindow.Show();
                this.Hide();
            }
        }

        private void btnNewProject_Click(object sender, EventArgs e)
        {

            var projecttype = new ProjectType();
            projecttype.ShowDialog();

            if (Configuration.ProjectVariables.Root.Element("Type").Value != "")
            {
                dlgSaveFile.Title = "Crea un proyecto...";
                dlgSaveFile.Filter = "Archivos de proyecto (*.xml)|*.xml";
                dlgSaveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dlgSaveFile.FileName = "proyecto.xml";

                if (dlgSaveFile.ShowDialog() == DialogResult.OK)
                {
                    Configuration.ProjectFile = dlgSaveFile.FileName;
                    ProjectActions.NewProject();
                    var editorWindow = new MainEditor();
                    this.Hide();
                    editorWindow.Show();
                }
            }

        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }

        private void btnNewProject_MouseEnter(object sender, EventArgs e)
        {
            btnNewProject.BackColor = Color.FromArgb(48, 39, 131);
        }

        private void btnNewProject_MouseLeave(object sender, EventArgs e)
        {
            btnNewProject.BackColor = Color.FromArgb(214, 10, 81);
        }

        private void btnLoadProject_MouseEnter(object sender, EventArgs e)
        {
            btnLoadProject.BackColor = Color.FromArgb(48, 39, 131);
        }

        private void btnLoadProject_MouseLeave(object sender, EventArgs e)
        {
            btnLoadProject.BackColor = Color.FromArgb(214, 10, 81);
        }
    }
}
