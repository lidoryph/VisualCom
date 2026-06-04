using System.Windows.Forms;

namespace VisualCom.Forms.Online.Extra
{
    public partial class LoadingScreen : Form
    {
        public LoadingScreen(string Message)
        {
            InitializeComponent();
            MessageLabel.Text = Message;
        }
    }
}
