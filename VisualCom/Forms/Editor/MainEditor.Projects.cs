namespace VisualCom.Forms.Editor
{
    public partial class MainEditor : Form
    {
        private void NewProject(object sender, EventArgs e)
        {
            var projecttype = new ProjectType();
            projecttype.ShowDialog();

            if (pv_type == null)
            {
                error.Show();
                return;
            }

            if (pv_type.Value != "")
            {
                dlgSaveFile.Title = "Crea un proyecto...";
                dlgSaveFile.Filter = "Archivos de proyecto (*.asaivc)|*.asaivc";
                dlgSaveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dlgSaveFile.FileName = "proyecto.asaivc";

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

        private void OpenProject(object sender, EventArgs e)
        {
            dlgOpenFile.Title = "Abrir proyecto...";
            dlgOpenFile.Filter = "Archivos de proyecto (*.asaivc)|*.asaivc";
            dlgOpenFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dlgOpenFile.FileName = "proyecto.asaivc";

            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                Configuration.ProjectFile = dlgOpenFile.FileName;
                ProjectActions.LoadProject();
                var editorWindow = new MainEditor();
                editorWindow.Show();
                this.Hide();
            }
        }

        private void SaveProject(object sender, EventArgs e)
        {
            progressEditor.Enabled = true;
            progressEditor.Value = 0;
            if (ChangedImage)
                ProjectActions.SaveProject(notes: true);
            else
                ProjectActions.SaveProject(notes: false);
            progressEditor.Value = 100;
            progressEditor.Enabled = false;
            Configuration.Saved = true;
        }

    }
}
