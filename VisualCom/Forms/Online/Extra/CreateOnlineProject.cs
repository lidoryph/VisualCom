using System.Windows.Forms;
using VisComClient;

namespace VisualCom.Forms
{
    public partial class CreateOnlineProject : Form
    {

        public string ProjectName = "";
        public bool Made = false;
        public string Type = "";

        public CreateOnlineProject()
        {
            InitializeComponent();
        }

        private async void CreateProjectAsync(object sender, EventArgs e)
        {
            if (ProjectName_TextBox.Text == "" || Configuration.Connection == null) return;

            ProjectName = ProjectName_TextBox.Text.Trim().Replace(" ", "_");

            if (OI_Radio.Checked == true)
                Type = "OI";
            else if (C_Radio.Checked == true)
                Type = "C";
            else
                return;

            var Response = await Configuration.Connection.CreateProject(ProjectName, Type);

            if(Response.Item1 == 200)
            {
                MessageBox.Show("¡Proyecto creado!");
                Made = true;
                Close();
            } else
            {
                MessageBox.Show("Ha habido un error y el proyecto no ha sido creado.");
                Made = false;
                Close();
            }

        }
    }
}
