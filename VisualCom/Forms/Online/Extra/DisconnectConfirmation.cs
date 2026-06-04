using System.Windows.Forms;

namespace VisualCom.Forms
{
    public partial class DisconnectConfirmation : Form
    {

        public Boolean Disconnect = false;

        public DisconnectConfirmation()
        {
            InitializeComponent();
        }

        private void AcceptButton_Clicked(object sender, EventArgs e)
        {
            Disconnect = true;
            Close();
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            Disconnect = false;
            Close();
        }

    }
}
