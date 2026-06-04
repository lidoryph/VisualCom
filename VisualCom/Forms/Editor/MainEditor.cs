using System.Diagnostics;
using System.Xml.Linq;
using VisualCom.Forms.Errors;
using Application = System.Windows.Forms.Application;

/*
*   This is the main editor window, it's divided in 8 files, 7 complementing this one.
*   Each core of this window is separated in another file.
*/


namespace VisualCom.Forms.Editor
{
    public partial class MainEditor : Form
    {
        private readonly ReadingDocument error = new();

        private readonly XElement? pv_name = Configuration.ProjectVariables.Root?.Element("Name");
        private readonly XElement? pv_version = Configuration.ProjectVariables.Root?.Element("Version");
        private readonly XElement? pv_type = Configuration.ProjectVariables.Root?.Element("Type");
        private readonly XElement? pv_classes = Configuration.ProjectVariables.Root?.Element("Classes");

        private string PreviousImage = string.Empty;
        private Boolean ChangedImage = false;
        private Boolean Noted = true;
        private bool Locked = false;

        private Boolean _isDragging = false;
        private Point _dragStartBox = Point.Empty;
        private Point _dragCurrentBox = Point.Empty;
        private int _lastMouseCoordX = int.MinValue;
        private int _lastMouseCoordY = int.MinValue;
        private PointF _selectionBottomLeft = PointF.Empty;
        private PointF _selectionTopRight = PointF.Empty;

        public MainEditor()
        {
            InitializeComponent();

            if (pv_type == null || pv_name == null || pv_version == null)
            {
                error.Show();
                return;
            }

            if (pv_type.Value == "OI")
                this.Text = "VisualCom - Editando proyecto \"" + pv_name.Value + "\" de tipo Identificación de Objetos. Versión: " + pv_version.Value;
            else if (pv_type.Value == "C")
                this.Text = "VisualCom - Editando proyecto \"" + pv_name.Value + "\" de tipo Clasificación. Versión: " + pv_version.Value;

            ClassesList.Resize += (s, e) => ClassesList.Columns[0].Width = ClassesList.ClientSize.Width;

            LoadClassesToList();
            LoadImagesToList();
            LockedButton.Visible = false;

            var connection = Configuration.Connection;
            connection?.OnImageUnlocked += OnImageUnlocked;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (Configuration.Saved == true)
            {
                base.OnFormClosing(e);
                return;
            }

            ExitWithoutSave leaving = new();
            leaving.ShowDialog();

            if (leaving.left == true)
                base.OnFormClosing(e);
            else
            {
                e.Cancel = true;
                return;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
            Application.ExitThread();
            var connection = Configuration.Connection;
            connection?.OnImageUnlocked -= OnImageUnlocked;
        }

        private void MainEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ImagesList.FocusedItem != null && Configuration.Online && Configuration.Connection != null)
                Configuration.Connection.UnlockImage(Configuration.ProjectName, ImagesList.FocusedItem.Text);
        }

        private async void Exit(object sender, EventArgs e)
        {
            if (ImagesList.FocusedItem != null && Configuration.Connection != null)
                Configuration.Connection.UnlockImage(Configuration.ProjectName, ImagesList.FocusedItem.Text);

            Close();
            Application.Exit();
        }

        private void OpenASAIWeb(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.asai.es") { UseShellExecute = true });
        }
    }
}
