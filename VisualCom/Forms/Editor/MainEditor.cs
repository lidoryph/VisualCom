using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using VisualCom.Forms;

namespace VisualCom
{
    public partial class MainEditor : Form
    {
        public MainEditor()
        {
            InitializeComponent();

            if (Configuration.ProjectVariables.Root.Element("Type").Value == "OI")
            {
                this.Text = "VisualCom - Editando proyecto \"" + Configuration.ProjectVariables.Root.Element("Name").Value + "\" de tipo Identificación de Objetos.";
            }
            else if (Configuration.ProjectVariables.Root.Element("Type").Value == "C")
            {
                this.Text = "VisualCom - Editando proyecto \"" + Configuration.ProjectVariables.Root.Element("Name").Value + "\" de tipo Clasificación.";

            }

            LoadImagesToList();

        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }

        private void nuevoProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var projecttype = new ProjectType();
            projecttype.ShowDialog();

            if (Configuration.ProjectVariables.Root.Element("Type").Value != "")
            {
                dlgSaveFile.Title = "Crea un proyecto...";
                dlgSaveFile.Filter = "Archivos de proyecto (*.xml)|*.xml";
                dlgSaveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dlgSaveFile.FileName = "proyecto.xml";

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

        private void abrirProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgOpenFile.Title = "Abrir proyecto...";
            dlgOpenFile.Filter = "Archivos de proyecto (*.xml)|*.xml";
            dlgOpenFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dlgOpenFile.FileName = "proyecto.xml";

            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                Configuration.ProjectFile = dlgOpenFile.FileName;
                ProjectActions.LoadProject();
                var editorWindow = new MainEditor();
                editorWindow.Show();
                this.Hide();
            }
        }

        private Size GetIconSize()
        {
            int columns = 4; // Cuántos iconos quieres por fila aproximadamente
            int size = (ImagesList.ClientSize.Width / columns) - 10; // -10 de margen
            size = Math.Max(50, size); // Tamaño mínimo de 50px
            return new Size(size, size);
        }

        private Bitmap ResizeWithAspectRatio(Image original, Size maxSize)
        {
            float ratioX = (float)maxSize.Width / original.Width;
            float ratioY = (float)maxSize.Height / original.Height;
            float ratio = Math.Min(ratioX, ratioY); // Usamos el ratio más pequeño para que quepa

            int newWidth = (int)(original.Width * ratio);
            int newHeight = (int)(original.Height * ratio);

            // Creamos un bitmap del tamaño máximo con fondo transparente
            Bitmap result = new Bitmap(maxSize.Width, maxSize.Height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.Clear(Color.Transparent);

                // Centramos la imagen dentro del espacio del icono
                int offsetX = (maxSize.Width - newWidth) / 2;
                int offsetY = (maxSize.Height - newHeight) / 2;

                g.DrawImage(original, offsetX, offsetY, newWidth, newHeight);
            }
            return result;
        }
        private void LoadImagesToList()
        {

            ImageList imagelist = new ImageList();
            imagelist.ImageSize = GetIconSize();
            imagelist.ColorDepth = ColorDepth.Depth32Bit;

            ImagesList.Items.Clear();
            imagelist.Images.Clear();

            string[] valid_extensions = { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".webp" };
            string imagesDirectory = Configuration.ProjectVariables.Root.Element("Directories").Element("Images").Value;

            foreach (var imagePath in Directory.GetFiles(imagesDirectory))
            {
                if (!valid_extensions.Contains(Path.GetExtension(imagePath).ToLower()))
                    continue;

                if (!ImagesList.Items.ContainsKey(imagePath))
                {
                    using (Image original = Image.FromFile(imagePath))
                    {
                        Bitmap thumbnail = ResizeWithAspectRatio(original, imagelist.ImageSize);
                        imagelist.Images.Add(imagePath, thumbnail);
                    }

                    ListViewItem item = new ListViewItem();
                    item.Text = Path.GetFileName(imagePath);
                    item.Name = imagePath;
                    item.ImageKey = imagePath;

                    ImagesList.Items.Add(item);
                }
            }

            ImagesList.LargeImageList = imagelist;
            ImagesList.View = View.LargeIcon;

        }

        private void ImagesList_ItemActivate(object sender, EventArgs e)
        {
            string imagesPath = Configuration.ProjectVariables.Root.Element("Directories").Element("Images").Value;
            pictureBox.Image = new Bitmap((string)Path.Join(imagesPath, ImagesList.FocusedItem.Text));
        }

        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            mouseCoordinates.Text = coordinates.ToString();
        }
    }
}
