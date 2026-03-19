using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Swift;
using System.Text;
using System.Windows.Forms;
using VisualCom.Forms;
using VisualCom.Forms.Editor;
using VisualCom.Properties;

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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            ExitWithoutSave leaving = new ExitWithoutSave();
            leaving.ShowDialog();
            if( leaving.left == true)
            {
                base.OnFormClosing(e);
                //Application.Exit();
            } else
            {
                e.Cancel = true;
                return;
            }

            
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }

        private void newProject(object sender, EventArgs e)
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

        private void openProject(object sender, EventArgs e)
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
            // Crear un nuevo ImageList
            ImageList imagelist = new ImageList();
            imagelist.ImageSize = GetIconSize();
            imagelist.ColorDepth = ColorDepth.Depth32Bit;

            // Limpiar la lista de imágenes y los elementos del ListView
            ImagesList.Items.Clear();
            imagelist.Images.Clear();

            // Definir extensiones válidas para las imágenes
            string[] valid_extensions = { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".webp" };
            string imagesDirectory = Configuration.ProjectVariables.Root.Element("Directories").Element("Images").Value;

            // Asignar el ImageList al ListView antes de agregar elementos
            ImagesList.LargeImageList = imagelist;

            // Recorrer los archivos en el directorio de imágenes
            foreach (var imagePath in Directory.GetFiles(imagesDirectory))
            {
                string extension = Path.GetExtension(imagePath).ToLower();
                if (!valid_extensions.Contains(extension))
                    continue;

                // Verificar si la imagen ya está en la lista
                if (!ImagesList.Items.ContainsKey(imagePath))
                {
                    try
                    {
                        using (Image original = Image.FromFile(imagePath))
                        {
                            Bitmap thumbnail = ResizeWithAspectRatio(original, imagelist.ImageSize);
                            imagelist.Images.Add(imagePath, thumbnail);

                            // Crear un nuevo ListViewItem
                            ListViewItem item = new ListViewItem();
                            item.Text = Path.GetFileName(imagePath);
                            item.Name = imagePath;
                            item.ImageKey = imagePath;

                            // Agregar el elemento al ListView
                            ImagesList.Items.Add(item);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Manejar excepciones si ocurren mientras se carga una imagen
                        MessageBox.Show($"Error loading image {imagePath}: {ex.Message}");
                    }
                }
            }

            // Establecer la vista del ListView como LargeIcon
            ImagesList.View = View.LargeIcon;
        }

        private void ImagesList_ItemActivate(object sender, EventArgs e)
        {
            string imagesPath = Configuration.ProjectVariables.Root.Element("Directories").Element("Images").Value;
            pictureBox.Image = new Bitmap((string)Path.Join(imagesPath, ImagesList.FocusedItem.Text));
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            int xCoordinate = e.X;
            int yCoordinate = e.Y;

            mouseCoordinates.Text = "x: " + xCoordinate + ", y: " + yCoordinate;
        }

        private void openASAIWeb(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.asai.es") { UseShellExecute = true });
        }

        private void addImages(object sender, EventArgs e)
        {
            dlgOpenFile.Title = "Abrir imagenes...";
            dlgOpenFile.Filter = "Imagenes (\"*.jpg\", \"*.jpeg\", \"*.png\", \"*.bmp\", \"*.gif\", \"*.webp\")|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.webp";
            dlgOpenFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            dlgOpenFile.FileName = "";
            dlgOpenFile.Multiselect = true;

            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in dlgOpenFile.FileNames)
                {
                    File.Copy(file, Path.Join(Configuration.ProjectVariables.Root.Element("Directories").Element("Images").Value,
                            (string)DateTime.Now.Ticks.GetHashCode().ToString("x").ToUpper() + Path.GetExtension(file)));
                }

                ImagesList.Items.Clear();
                LoadImagesToList();
            }
        }

        private void removeImages(object sender, EventArgs e)
        {
            if (ImagesList.SelectedItems.Count == 0)
            {
                MessageBox.Show("¡No has seleccionado ninguna imagen!");
                return;
            }

            string images = Configuration.ProjectVariables.Root.Element("Directories").Element("Images").Value;

            foreach (ListViewItem image in ImagesList.SelectedItems)
            {
                File.Delete(Path.Join(images, image.Text.ToString()));
                ImagesList.Items.Remove(image);
            }

        }

        private void trainModel(object sender, EventArgs e)
        {
            TrainModel trainmodel = new TrainModel();
            trainmodel.Show();
        }

        private void saveProject(object sender, EventArgs e)
        {
            progressEditor.Enabled = true;
            progressEditor.Value = 0;
            ProjectActions.SaveProject();
            progressEditor.Value = 100;
            progressEditor.Enabled = false;
            Configuration.Saved = true;
        }

        private void exit(object sender, EventArgs e)
        {
            this.Close();
            Close();
            Application.Exit();
        }
    }
}
