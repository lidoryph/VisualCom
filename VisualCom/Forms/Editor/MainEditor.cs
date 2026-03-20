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
using VisualCom.Forms.Errors;
using VisualCom.Properties;
using VisualCom.Forms.Editor.Classes;
using System.Xml.Linq;

namespace VisualCom
{
    public partial class MainEditor : Form
    {

        private readonly ReadingDocument error = new();
        private readonly XElement? pv_type = Configuration.ProjectVariables.Root?.Element("Type");
        private readonly XElement? pv_name = Configuration.ProjectVariables.Root?.Element("Name");
        private readonly XElement? pv_images = Configuration.ProjectVariables.Root?.Element("Directories")?.Element("Images");
        private readonly XElement? pv_classes = Configuration.ProjectVariables.Root?.Element("Classes");

        public MainEditor()
        {
            InitializeComponent();
            
            if(pv_type == null)
            {
                error.Show();
                return;
            }

            if(pv_name == null)
            {
                error.Show();
                return;
            }

            if (pv_type.Value == "OI")
            {
                this.Text = "VisualCom - Editando proyecto \"" + pv_name.Value + "\" de tipo Identificación de Objetos.";
            }
            else if (pv_type.Value == "C")
            {
                this.Text = "VisualCom - Editando proyecto \"" + pv_name.Value + "\" de tipo Clasificación.";

            }

            LoadClassesToList();
            LoadImagesToList();

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

            if( leaving.left == true)
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
        }

        private void NewProject(object sender, EventArgs e)
        {
            var projecttype = new ProjectType();
            projecttype.ShowDialog();

            if(pv_type == null)
            {
                error.Show();
                return;
            }

            if (pv_type.Value != "")
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

        private void OpenProject(object sender, EventArgs e)
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

        private static Bitmap ResizeWithAspectRatio(Image original, Size maxSize)
        {
            float ratioX = (float)maxSize.Width / original.Width;
            float ratioY = (float)maxSize.Height / original.Height;
            float ratio = Math.Min(ratioX, ratioY); // Usamos el ratio más pequeño para que quepa

            int newWidth = (int)(original.Width * ratio);
            int newHeight = (int)(original.Height * ratio);

            // Creamos un bitmap del tamaño máximo con fondo transparente
            Bitmap result = new(maxSize.Width, maxSize.Height);
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
            ImageList imagelist = new()
            {
                ImageSize = GetIconSize(),
                ColorDepth = ColorDepth.Depth32Bit
            };

            // Limpiar la lista de imágenes y los elementos del ListView
            ImagesList.Items.Clear();
            imagelist.Images.Clear();

            // Definir extensiones válidas para las imágenes
            string[] valid_extensions = [".jpg", ".jpeg", ".png", ".bmp", ".gif", ".webp"];

            if(pv_images == null)
            {
                error.Show();
                return;
            }

            string imagesDirectory = pv_images.Value;

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
                        using Image original = Image.FromFile(imagePath);
                        Bitmap thumbnail = ResizeWithAspectRatio(original, imagelist.ImageSize);
                        imagelist.Images.Add(imagePath, thumbnail);

                        // Crear un nuevo ListViewItem
                        ListViewItem item = new()
                        {
                            Text = Path.GetFileName(imagePath),
                            Name = imagePath,
                            ImageKey = imagePath
                        };

                        // Agregar el elemento al ListView
                        ImagesList.Items.Add(item);
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
            if (pv_images == null)
            {
                error.Show();
                return;
            }

            if(ImagesList.FocusedItem == null)
            {
                return;
            }

            string imagesPath = pv_images.Value;
            pictureBox.Image = new Bitmap((string)Path.Join(imagesPath, ImagesList.FocusedItem.Text));
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            int xCoordinate = e.X;
            int yCoordinate = e.Y;

            mouseCoordinates.Text = "x: " + xCoordinate + ", y: " + yCoordinate;
        }

        private void OpenASAIWeb(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.asai.es") { UseShellExecute = true });
        }

        private void AddImages(object sender, EventArgs e)
        {
            dlgOpenFile.Title = "Abrir imagenes...";
            dlgOpenFile.Filter = "Imagenes (\"*.jpg\", \"*.jpeg\", \"*.png\", \"*.bmp\", \"*.gif\", \"*.webp\")|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.webp";
            dlgOpenFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            dlgOpenFile.FileName = "";
            dlgOpenFile.Multiselect = true;

            if(pv_images == null)
            {
                error.Show();
                return;
            }

            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in dlgOpenFile.FileNames)
                {
                    File.Copy(file, Path.Join(pv_images.Value,
                            (string)DateTime.Now.Ticks.GetHashCode().ToString("x").ToUpper() + Path.GetExtension(file)));
                }

                ImagesList.Items.Clear();
                LoadImagesToList();
            }
        }

        private void RemoveImages(object sender, EventArgs e)
        {
            if (ImagesList.SelectedItems.Count == 0)
            {
                MessageBox.Show("¡No has seleccionado ninguna imagen!");
                return;
            }

            if (pv_images == null)
            {
                error.Show();
                return;
            }

            string images = pv_images.Value;

            foreach (ListViewItem image in ImagesList.SelectedItems)
            {
                File.Delete(Path.Join(images, image.Text.ToString()));
                ImagesList.Items.Remove(image);
            }

        }

        private void TrainModel(object sender, EventArgs e)
        {
            TrainModel trainmodel = new();
            trainmodel.ShowDialog();
        }

        private void SaveProject(object sender, EventArgs e)
        {
            progressEditor.Enabled = true;
            progressEditor.Value = 0;
            ProjectActions.SaveProject();
            progressEditor.Value = 100;
            progressEditor.Enabled = false;
            Configuration.Saved = true;
        }

        private void LoadClassesToList()
        {
            ListViewItem item;
            string classname;

            if(pv_classes == null)
            {
                error.Show();
                return;
            }

            foreach(var classes in pv_classes.Elements("Class"))
            {
                if(classes == null)
                {
                    return;
                }

                classname = classes.Value.ToString();
                item = new ListViewItem
                {
                    Name = classes.Attribute("id")?.Value,
                    Text = classname,
                    BackColor = ColorTranslator.FromHtml(classes.Attribute("color")?.Value ?? "#FFFFFF")
                };

                if (item.BackColor.GetBrightness() > 0.85)
                    item.ForeColor = Color.Black;
                else
                    item.ForeColor = Color.White;

                ClassesList.Items.Add(item);
            }
        }

        public void AddExternalClass((string, string) classtoadd)
        {
            ListViewItem item = new()
            {
                Text = classtoadd.Item1.ToString(),
                BackColor = ColorTranslator.FromHtml(classtoadd.Item2.ToString()),
                Name = String.Join(classtoadd.Item1.ToString(), classtoadd.Item2.ToString()).GetHashCode().ToString()
            };

            if (item.BackColor.GetBrightness() > 0.85)
                item.ForeColor = Color.Black;
            else
                item.ForeColor = Color.White;


            ClassesList.Items.Add(item);
            ListsContainer.Panel1.Refresh();
            ClassesList.Refresh();
            ClassesList.Show();
        }

        private void AddClass(object sender, EventArgs e)
        {
            AddClasses classwindow = new(this);
            classwindow.ShowDialog();
        }

        private void EraseClassDialog(object sender, EventArgs e)
        {

            if(ClassesList.SelectedItems.Count == 0)
            {
                MessageBox.Show("¡No has seleccionado ninguna clase!");
                return;
            }

            RemoveClasses dialog = new(this, ClassesList.SelectedItems.Count);
            dialog.ShowDialog();
        }
        public void EraseClass()
        {

            string id;

            foreach (ListViewItem selected in ClassesList.SelectedItems)
            {
                if (pv_classes == null)
                {
                    error.ShowDialog();
                    return;
                }

                id = selected.Name;

                pv_classes.Elements("Class").FirstOrDefault(c => string.Equals(c.Attribute("id")?.Value, id, StringComparison.Ordinal))?.Remove();
                ClassesList.Items.Remove(selected);
            }
        }


        public void ModifyExternalClass(string id, string name, string color)
        {
            if(pv_classes == null)
            {
                error.ShowDialog();
                return;
            }
            

            pv_classes.Elements("Class").FirstOrDefault(c => string.Equals(c.Attribute("id")?.Value, id, StringComparison.Ordinal))?.Value = name;
            pv_classes.Elements("Class").FirstOrDefault(c => string.Equals(c.Attribute("id")?.Value, id, StringComparison.Ordinal))?.Attribute("color")?.Value = color ?? "#FFFFFF";
            foreach(ListViewItem item in ClassesList.Items)
            {
                if (color == null)
                    return;

                if (String.Join(item.Text, ColorTranslator.ToHtml(item.BackColor).ToString()).GetHashCode().ToString() == id)
                {
                    item.Text = name;
                    item.BackColor = ColorTranslator.FromHtml(color);
                }
            }
        }

        private void ModifyClass(object sender, EventArgs e)
        {

            if (ClassesList.SelectedItems.Count == 0)
                return;
            if (ClassesList.SelectedItems.Count > 1)
                return;

            string id = "";
            string name = "";
            string color = "";

            foreach(ListViewItem item in ClassesList.SelectedItems)
            {
                id = item.Name;
                name = item.Text;
                color = ColorTranslator.ToHtml(item.BackColor);
            }

            ModifyClass dialog = new(this, id, name, color);
            dialog.ShowDialog();
        }

        private void Exit(object sender, EventArgs e)
        {
            this.Close();
            Close();
            Application.Exit();
        }
    }
}
