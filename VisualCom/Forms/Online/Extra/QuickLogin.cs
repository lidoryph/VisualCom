using System.Windows.Forms;
using System.Xml.Linq;

namespace VisualCom.Forms.Online.Extra
{
    public partial class QuickLogin : Form
    {
        public QuickLogin()
        {
            InitializeComponent();
        }

        private void QuickLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!Configuration.Online)
                Application.Exit();
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            string? address = Configuration.OnlineVariables.Root?.Element("Address")?.Value;
            string? port = Configuration.OnlineVariables.Root?.Element("Port")?.Value;
            string? name = Configuration.OnlineVariables.Root?.Element("Name")?.Value;
            string? type = Configuration.OnlineVariables.Root?.Element("Type")?.Value;

            if (address == null || port == null || name == null || type == null) return;

            if (address.StartsWith("http://") || address.StartsWith("https://"))
            {
                if (port == "" || port == null)
                    Configuration.ServerAddress = address;
                else
                    Configuration.ServerAddress = address + ":" + port;
            }
            else
            {
                if (port == "" || port == null)
                    Configuration.ServerAddress = "http://" + address;
                else
                    Configuration.ServerAddress = "http://" + address + ":" + port;
            }

            LoadingScreen loading_dlg = new("Espere mientras se le conecta con el servidor.");
            _ = loading_dlg.ShowDialogAsync();

            Configuration.Connection = new(Configuration.ServerAddress, username.Text);
            bool LoginStatus = await Configuration.Connection.LoginAsync();

            if (!LoginStatus || name == null)
            {
                loading_dlg.Close();
                MessageBox.Show("No se ha podido iniciar sesión. Intentelo de nuevo.");
                Close();
                return;
            }

            Configuration.UserName = username.Text;
            Configuration.Online = true;

            var Content = await Configuration.Connection.GetProject(name);
            int ResponseCode = Content.Item1;
            string ProjectFile = Content.Item2;

            if (ResponseCode != 200)
            {
                MessageBox.Show("Ha ocurrido un error y no se ha podido cargar el proyecto.");
                return;
            }

            Configuration.ProjectVariables = XDocument.Parse(ProjectFile);
            MessageBox.Show(Configuration.ProjectVariables.ToString());
            var ImagesListRequest = await Configuration.Connection.GetImagesList(name);
            if (ImagesListRequest.Item1 != 200)
            {
                MessageBox.Show("Ha ocurrido un error y no se han podido cargar las imágenes del proyecto.");
                return;
            }

            string ImagesList = ImagesListRequest.Item2;
            ImagesList = ImagesList.Replace("[", "").Replace("]", "").Trim().Replace(" ", "");
            var Image = ImagesList.Split(',');
            Configuration.OnlinePath = Path.Join(Configuration.ProgramPath, name);

            if (!Directory.Exists(Configuration.OnlinePath))
                Directory.CreateDirectory(Configuration.OnlinePath);

            List<String> _necessary_directories = ["images", "annotations"];

            foreach (string directory in _necessary_directories)
                if (!Directory.Exists(Path.Join(Configuration.OnlinePath, directory))) Directory.CreateDirectory(Path.Join(Configuration.OnlinePath, directory));



            Configuration.ProjectName = name;
            Configuration.ProjectType = type;
            Configuration.ProjectDir = Configuration.OnlinePath;
            Configuration.ProjectImages = Path.Join(Configuration.ProjectDir, "images");
            Configuration.ProjectAnnotations = Path.Join(Configuration.ProjectDir, "annotations");

            foreach (string element in Image)
            {
                if (File.Exists(Path.Join(Configuration.ProjectImages, element))) continue;
                var ImageContent = await Configuration.Connection.GetImage(name, element);
                File.WriteAllBytes(Path.Join(Configuration.ProjectImages, element), ImageContent);
            }

            loading_dlg.Close();
            MainEditor editor_window = new();
            editor_window.Show();
            Close();
        }
    }
}
