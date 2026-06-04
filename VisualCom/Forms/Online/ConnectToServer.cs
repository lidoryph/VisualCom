using System.Windows.Forms;
using VisComClient;
using VisualCom.Forms.Online.Extra;

namespace VisualCom.Forms
{
    public partial class ConnectToServer : Form
    {

        new readonly Form Parent;

        public ConnectToServer(Form window)
        {
            Parent = window;
            InitializeComponent();
        }

        private async void ConnectServer(object sender, EventArgs e)
        {
            if(ServerIP_TextBox.Text == "" || User_TextBox.Text == "")
            {
                MessageBox.Show("¡Necesitas rellenar todas las casillas!");
                return;
            }

            if (ServerIP_TextBox.Text.StartsWith("http://") || ServerIP_TextBox.Text.StartsWith("https://"))
            {
                if (ServerPort_Numeric.Text == "")
                    Configuration.ServerAddress = ServerIP_TextBox.Text;
                else
                    Configuration.ServerAddress = ServerIP_TextBox.Text + ":" + ServerPort_Numeric.Text;
            }
            else
            {
                if (ServerPort_Numeric.Text == "")
                    Configuration.ServerAddress = "http://" + ServerIP_TextBox.Text;
                else
                    Configuration.ServerAddress = "http://" + ServerIP_TextBox.Text + ":" + ServerPort_Numeric.Text;
            }

            LoadingScreen loading_dlg = new("Espere mientras se le conecta con el servidor.");
            _ = loading_dlg.ShowDialogAsync();

            Configuration.Connection = new(Configuration.ServerAddress, User_TextBox.Text);
            bool LoginStatus = await Configuration.Connection.LoginAsync();

            if(!LoginStatus)
            {
                loading_dlg.Close();
                MessageBox.Show("No se ha podido iniciar sesión. Intentelo de nuevo.");
                if (Parent.InvokeRequired)
                    Parent.Invoke(new Action(() => Parent.Show()));
                else
                    Parent.Show();
                Close();
                return;
            }

            Configuration.UserName = User_TextBox.Text;
            Configuration.Online = true;

            var Projects = await Configuration.Connection.GetProjects();
            if(Projects.Item1 != 200)
            {
                loading_dlg.Close();
                MessageBox.Show("Ha habido un error recibiendo los proyectos, por favor, intentelo de nuevo mas tarde.");
                Configuration.UserName = "";
                Configuration.Online = false;
                if (Parent.InvokeRequired)
                    Parent.Invoke(new Action(() => Parent.Show()));
                else
                    Parent.Show();

                Close();
                return;
            }

            OnlineProjects onlineprojects_dialog = new(Projects.Item2, Parent);
            loading_dlg.Close();
            onlineprojects_dialog.Show();
            Close();
        }

        private void CloseDialog(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (!Configuration.Online)
            {
                if (Parent.InvokeRequired)
                    Parent.Invoke(new Action(() => Parent.Show()));
                else
                    Parent.Show();
            }

            Close();
        }

    }
}
