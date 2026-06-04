namespace VisualCom.Forms.Editor.Classes
{
    public partial class RemoveClasses : Form
    {

        private readonly MainEditor _editor;
        public RemoveClasses(MainEditor window, int selected)
        {
            InitializeComponent();

            if (selected == 1)
                label1.Text = "¿Seguro que quieres borrar " + selected.ToString() + " clase?";
            else
                label1.Text = "¿Seguro que quieres borrar " + selected.ToString() + " clases?";

            _editor = window;
        }

        private void Accept(object sender, EventArgs e)
        {
            _editor.EraseClass();
            Close();
        }

        private void Deny(object sender, EventArgs e)
        {
            Close();
        }
    }
}
