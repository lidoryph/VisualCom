namespace VisualCom.Forms.Editor.NetTests
{
    public partial class NetworkDialog : Form
    {

        public NetworkDialog()
        {
            InitializeComponent();
        }

        private void UsernameChanged(object sender, EventArgs e)
        {
            Configuration.UserName = user.Text;
        }

        private void PingServer(object sender, EventArgs e)
        {
            string url = "http://" + ServerURL.Text + ":" + PortNumber.Value;
            PythonTrain.Initialize();
            dynamic pinged = NetActions.pingServer();
            if (pinged[0] == 200)
                MessageBox.Show("Pong!");
            else
                MessageBox.Show("Couldn't ping");
        }

        private void NewProject(object sender, EventArgs e)
        {
            if(Configuration.UserName == "" || user.Text == "")
            {
                MessageBox.Show("Tienes que usar un nombre de usuario!");
                return;
            }

            string url = "http://" + ServerURL.Text + ":" + PortNumber.Value;
            string projectname = ProjectName.Text;
            string projecttype = ProjectType.Text;
            string username = user.Text;

            (string, string, string, string) netArgs = (url, projectname, projecttype, username);

            PythonTrain.Initialize();
            dynamic created = NetActions.CreateProject(netArgs);
            int? scode = created[0];
            string? message = created[1];
            
            if (scode == 200)
                MessageBox.Show("Project made!");
            else
                MessageBox.Show("Couldn't make");
        }

        private void GetProjects(object sender, EventArgs e)
        {
            string url = "http://" + ServerURL.Text + ":" + PortNumber.Value;

            PythonTrain.Initialize();
            dynamic result = NetActions.GetProjects();
            int? scode = result[0];
            string? rawprojects = result[1];


            if (scode != 200)
            {
                MessageBox.Show("There was an error.");
                return;
            }

            if (rawprojects == null)
            {
                MessageBox.Show("Couldn't get projects.");
                return;
            }

            rawprojects = rawprojects.Replace("[", "").Replace("]", "").Replace(" ", "");

            if (rawprojects == "No projects to serve.")
            {
                MessageBox.Show("Currently there are no projects to serve. Please make one.");
                return;
            }

            ProjectsList.Items.Clear();

            string[] projects = rawprojects.Split(',');

            foreach (string project in projects)
                ProjectsList.Items.Add(project);

        }

        private void GetClasses(object sender, EventArgs e)
        {
            if (ProjectsList.SelectedItem == null)
            {
                MessageBox.Show("There must be a project selected!");
                return;
            }

            string url = "http://" + ServerURL.Text + ":" + PortNumber.Value;
            string project = ProjectsList.SelectedItem.ToString();
            (string, string) NetArgs = (url, project);

            PythonTrain.Initialize();
            dynamic result = NetActions.GetClasses(NetArgs);
            int? scode = result[0];
            string? rawoutput = result[1];
            rawoutput = rawoutput.Replace("[", "").Replace("]", "").Replace(" ", "");

            ClassesList.Items.Clear();

            string[] classes = rawoutput.Split(",");
            foreach (string element in classes)
                ClassesList.Items.Add(element);


            MessageBox.Show(scode.ToString(), rawoutput);
        }

        private void GetVersions(object sender, EventArgs e)
        {
            if (ProjectsList.SelectedItem == null)
            {
                MessageBox.Show("There must be a project selected!");
                return;
            }

            string url = "http://" + ServerURL.Text + ":" + PortNumber.Value;
            string project = ProjectsList.SelectedItem.ToString();
            (string, string) NetArgs = (url, project);

            PythonTrain.Initialize();
            dynamic result = NetActions.GetVersions(NetArgs);

            int? scode = result[0];
            string? rawoutput = result[1];
            rawoutput = rawoutput.Replace("[", "").Replace("]", "").Replace(" ", "");
            VersionsList.Items.Clear();
            string[] versions = rawoutput.Split(",");

            foreach (string version in versions)
                VersionsList.Items.Add(version);
        }

        private void GetImages(object sender, EventArgs e)
        {
            if (ProjectsList.SelectedItem == null)
            {
                MessageBox.Show("There must be a project selected!");
                return;
            }

            string url = "http://" + ServerURL.Text + ":" + PortNumber.Value;
            string project = ProjectsList.SelectedItem.ToString();
            (string, string) NetArgs = (url, project);

            PythonTrain.Initialize();
            dynamic result = NetActions.GetImages(NetArgs);

            int? scode = result[0];
            string? rawoutput = result[1];
            rawoutput = rawoutput.Replace("[", "").Replace("]", "").Replace(" ", "");

            string[] images = rawoutput.Split(",");

            foreach (string image in images)
                ImagesList.Items.Add(image);

        }

    }
}
