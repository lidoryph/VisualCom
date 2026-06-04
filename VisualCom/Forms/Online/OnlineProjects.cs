using System.Formats.Tar;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using VisualCom.Forms.Online;

namespace VisualCom.Forms
{
    public partial class OnlineProjects : Form
    {

        bool _disconnect = false;
        new readonly Form Parent;
        private readonly XElement? ov_root = Configuration.OnlineVariables.Root;
        public OnlineProjects(List<String> Projects, Form window)
        {
            InitializeComponent();

            Parent = window;

            foreach (string element in Projects)
            {
                if (string.IsNullOrWhiteSpace(element)) return;

                var parts = element.Split([';'], 6);

                string name = parts.Length > 0 ? parts[0] : string.Empty;
                string typeRaw = parts.Length > 1 ? parts[1] : string.Empty;
                string createdRaw = parts.Length > 2 ? parts[2] : string.Empty;
                string modifiedRaw = parts.Length > 3 ? parts[3] : string.Empty;
                string classesRaw = parts.Length > 4 ? parts[4] : "0";
                string imagesRaw = parts.Length > 5 ? parts[5] : "0";

                var item = new ListViewItem(name);

                DateTime created = DateTimeOffset.FromUnixTimeSeconds(long.Parse(createdRaw)).UtcDateTime;
                DateTime modified = DateTimeOffset.FromUnixTimeSeconds(long.Parse(modifiedRaw)).UtcDateTime;

                string type = "";

                if (typeRaw == "OI") type = "Identificación de Objetos";
                else if (typeRaw == "C") type = "Clasificación de Imágenes";

                item.SubItems.Add(type);
                item.SubItems.Add(modified.ToString());
                item.SubItems.Add(created.ToString());
                item.SubItems.Add(classesRaw);
                item.SubItems.Add(imagesRaw);

                item.Tag = name;
                ProjectsList.Items.Add(item);
            }

            UserName_Label.Text = Configuration.UserName + "!";
        }

        private void CreateProject(object sender, EventArgs e)
        {
            CreateOnlineProject createproject_dialog = new();
            createproject_dialog.ShowDialog();

            bool ProjectMade = createproject_dialog.Made;
            string ProjectName = createproject_dialog.ProjectName;
            string ProjectType = createproject_dialog.Type;

            string type = "";

            if (!ProjectMade) return;
            if (ProjectType == "OI") type = "Identificación de Objetos";
            else if (ProjectType == "C") type = "Clasificación de Imágenes";

            var item = ProjectsList.Items.Add(ProjectName);
            item.SubItems.Add(type);
            item.SubItems.Add(DateTime.Now.ToString());
            item.SubItems.Add(DateTime.Now.ToString());
            item.SubItems.Add("0");
            item.SubItems.Add("0");
            item.BackColor = Color.FromArgb(33, 32, 32);
            item.ForeColor = Color.White;
            ProjectsList.Refresh();
            item.Selected = true;
        }

        private async void LoadProject(object sender, EventArgs e)
        {
            if (ProjectsList.SelectedItems.Count != 1 || ProjectsList.SelectedItems.Count == 0 || Configuration.Connection == null) 
                return;

            var selectedItem = ProjectsList.SelectedItems[0];
            string? projectIdOrName = selectedItem.Tag != null ? selectedItem.Tag.ToString() : selectedItem.Text;

            if (projectIdOrName == null) return;

            var Content = await Configuration.Connection.GetProject(projectIdOrName);
            int ResponseCode = Content.Item1;
            string ProjectFile = Content.Item2;

            if (ResponseCode != 200)
            {
                MessageBox.Show("Ha ocurrido un error y no se ha podido cargar el proyecto.");
                return;
            }

            Configuration.ProjectVariables = XDocument.Parse(ProjectFile);
            MessageBox.Show(Configuration.ProjectVariables.ToString());
            var ImagesListRequest = await Configuration.Connection.GetImagesList(projectIdOrName);
            if (ImagesListRequest.Item1 != 200)
            {
                MessageBox.Show("Ha ocurrido un error y no se han podido cargar las imágenes del proyecto.");
                return;
            }

            string ImagesList = ImagesListRequest.Item2;
            ImagesList = ImagesList.Replace("[", "").Replace("]", "").Trim().Replace(" ", "");
            var Image = ImagesList.Split(',');
            Configuration.OnlinePath = Path.Join(Configuration.ProgramPath, projectIdOrName);

            if (!Directory.Exists(Configuration.OnlinePath))
                Directory.CreateDirectory(Configuration.OnlinePath);

            List<String> _necessary_directories = ["images", "annotations"];

            foreach (string directory in _necessary_directories)
                if (!Directory.Exists(Path.Join(Configuration.OnlinePath, directory))) Directory.CreateDirectory(Path.Join(Configuration.OnlinePath, directory));

            string? proj_name = Configuration.ProjectVariables.Root?.Element("Name")?.Value;
            string? proj_type = Configuration.ProjectVariables.Root?.Element("Type")?.Value;
            if (proj_name == null || proj_type == null) return;

            Configuration.ProjectName = proj_name;
            Configuration.ProjectType = proj_type;
            Configuration.ProjectDir = Configuration.OnlinePath;
            Configuration.ProjectImages = Path.Join(Configuration.ProjectDir, "images");
            Configuration.ProjectAnnotations = Path.Join(Configuration.ProjectDir, "annotations");

            foreach (string element in Image)
            {
                if (File.Exists(Path.Join(Configuration.ProjectImages, element))) continue;
                var ImageContent = await Configuration.Connection.GetImage(projectIdOrName, element);
                File.WriteAllBytes(Path.Join(Configuration.ProjectImages, element), ImageContent);
            }

            await Configuration.Connection.ConnectEventsAsync(projectIdOrName, message =>
            {
                if (InvokeRequired)
                    BeginInvoke(new Action(() => HandleRealtimeMessage(message)));
                else
                    HandleRealtimeMessage(message);
            });

            MainEditor editor_window = new();
            editor_window.Show();
        }

        private async void DeleteProject(object sender, EventArgs e)
        {
            if (ProjectsList.SelectedItems.Count == 0)
                return;

            var selectedItem = ProjectsList.SelectedItems[0];

            DeleteProjectConfirmation deleteProject_dialog = new();
            deleteProject_dialog.ShowDialog();

            if (!deleteProject_dialog.Delete)
                return;

            string? projectIdOrName = selectedItem.Tag != null ? selectedItem.Tag.ToString() : selectedItem.Text;

            if (Configuration.Connection == null || projectIdOrName == null) return;

            int DeleteResponse = await Configuration.Connection.DeleteProject(projectIdOrName);

            if (DeleteResponse == 200)
            {
                ProjectsList.Items.Remove(ProjectsList.SelectedItems[0]);
                MessageBox.Show("¡Proyecto Borrado!");
            }
            else
                MessageBox.Show("Un error ha ocurrido y el proyecto no ha podido ser eliminado.");

        }

        private void Disconnect(object sender, EventArgs e)
        {
            DisconnectConfirmation disconnect = new();
            disconnect.ShowDialog();

            _disconnect = disconnect.Disconnect;

            if (!disconnect.Disconnect || Configuration.Connection == null)
                return;

            _ = Configuration.Connection.LogoutAsync();
            Configuration.Online = false;
            Configuration.ServerAddress = "";
            Configuration.UserName = "";
            Parent.ShowAsync();

            Close();
        }

        private void ChangedSelectionList(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (ProjectsList.SelectedItems.Count == 0)
            {
                LoadProject_Button.Enabled = false;
                EraseProject_Button.Enabled = false;
                EraseProject_Button.Text = "Borrar proyecto...";
            }
            else if (ProjectsList.SelectedItems.Count == 1)
            {
                LoadProject_Button.Enabled = true;
                EraseProject_Button.Enabled = true;
                EraseProject_Button.Text = "Borrar proyecto...";
            }
            else
            {
                LoadProject_Button.Enabled = false;
                EraseProject_Button.Enabled = true;
                EraseProject_Button.Text = "Borrar proyectos...";
            }
        }

        private async void ImportProject(object sender, EventArgs e)
        {
            string UserDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            openFileDialog.Title = "Abrir proyecto...";
            openFileDialog.Filter = "Archivos de proyecto (*.asaivc)|*.asaivc";
            openFileDialog.InitialDirectory = UserDocuments;
            openFileDialog.FileName = "proyecto.asaivc";
                 
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                string noextension = Path.GetFileNameWithoutExtension(filename);
                string fileback = Path.Combine(Configuration.ProgramPath, noextension + ".bak");
                string? path = Path.GetDirectoryName(filename);
                if (path == null)
                    return;
                string tarpath = Path.Combine(path, noextension + ".tar");


                File.Copy(filename, fileback, true);

                var server = Configuration.ServerAddress.Split(":");
                int serverport = int.Parse(server[2]);
                string serveraddress = server[1];

                Configuration.ProjectVariables = XDocument.Load(filename);

                string? created = Configuration.ProjectVariables.Root?.Element("Created")?.Value;

                Configuration.OnlineVariables = new(
                    new XElement("Online",
                        new XComment("NEVER CHANGE DATA HERE, ALWAYS CHANGE IT FROM THE PROGRAM"),
                        new XElement("Address", serveraddress),
                        new XElement("Port", serverport),
                        new XElement("Created", created)
                    )
                );

                IEnumerable<XElement>? classes = Configuration.ProjectVariables.Root?.Elements("Classes");

                if (classes == null || ov_root == null ||Configuration.Connection == null) return;

                foreach (var c in classes)
                    ov_root.Add(c);

                ov_root.Add(new XComment("NEVER CHANGE DATA HERE, ALWAYS CHANGE IT FROM THE PROGRAM"));

                Configuration.OnlineVariables.Save(filename);

                try
                {
                    await TarFile.CreateFromDirectoryAsync(path, tarpath, true);
                } catch { }
                
                await Configuration.Connection.ImportProject(tarpath);

                Configuration.ProjectVariables.Save(filename);

                MessageBox.Show("Project compressed.");
            }
        }

        private async void DownloadProject(object sender, EventArgs e)
        {
            if (Configuration.Connection == null) return;

            string path = await Configuration.Connection.DownloadProject("C:\\Users\\ivan\\AppData\\Roaming\\VisualCom\\proyecto.tar");
            string toextract;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) { toextract = folderBrowserDialog.SelectedPath; }
            else return;

            TarFile.ExtractToDirectory(path, toextract, false);
            File.Delete(path);
        }

        private void OnlineProjects_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void HandleRealtimeMessage(string message)
        {
            // SockTest already subscribes to typed events on Configuration.Connection.
            // This callback is here to keep the socket alive and to provide a single place
            // to inspect raw JSON if you want to log or debug messages.
        }

        /*private void EraseProject_Button_EnabledChanged(object sender, EventArgs e)
        {
            if (!EraseProject_Button.Enabled) EraseProject_Button.BackColor = Color.FromArgb(128, 5, 40);
            else EraseProject_Button.BackColor = Color.FromArgb(214, 10, 81);
        }

        private void LoadProject_Button_EnabledChanged(object sender, EventArgs e)
        {
            if (!LoadProject_Button.Enabled) LoadProject_Button.BackColor = Color.FromArgb(128, 5, 40);
            else LoadProject_Button.BackColor = Color.FromArgb(214, 10, 81);
        }*/

    }
}
