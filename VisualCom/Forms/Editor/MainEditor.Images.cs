using VisualCom.Forms.Errors;

namespace VisualCom.Forms.Editor
{
    public partial class MainEditor
    {
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

            string imagesDirectory = Configuration.ProjectImages;

            // Asignar el ImageList al ListView antes de agregar elementos
            ImagesList.LargeImageList = imagelist;

            // Recorrer los archivos en el directorio de imágenes
            foreach (var imagePath in Directory.GetFiles(imagesDirectory))
            {
                string extension = Path.GetExtension(imagePath).ToLower();
                if (!valid_extensions.Contains(extension)) continue;

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

        

        private async void ImagesList_ItemActivate(object sender, EventArgs e)
        {
            if (ImagesList.FocusedItem == null) return;

            if (Configuration.Online && PreviousImage != "" && Configuration.Connection != null)
                Configuration.Connection.UnlockImage(Configuration.ProjectName, PreviousImage);

            PreviousImage = ImagesList.FocusedItem.Text;

            if (Configuration.Online && Configuration.Connection != null)
            {
                Locked = await Configuration.Connection.CheckLock(Configuration.ProjectName, ImagesList.FocusedItem.Text);
                if (Locked) LockedButton.Visible = true;
                else
                {
                    LockedButton.Visible = false;
                    await Configuration.Connection.LockImage(Configuration.ProjectName, ImagesList.FocusedItem.Text);
                }
            }


            if (Configuration.JsonPath != "" && Noted == false)
            {
                var info = new FileInfo(Configuration.JsonPath);
                if (info.Exists && info.Length == 0)
                    File.Delete(Configuration.JsonPath);
            }

            if (Configuration.Saved == false)
            {
                SaveImageAnnotation dialog = new();
                dialog.ShowDialog();
                if (dialog.Cancel == true) return;
            }

            string imagename = "";

            foreach (ListViewItem item in ImagesList.SelectedItems)
                imagename = item.Text;

            Configuration.CurrentImageJson.Boxes.Clear();
            string AnnotationPath = Path.Join(Configuration.ProjectAnnotations, Path.GetFileNameWithoutExtension(imagename) + ".json");

            if (File.Exists(AnnotationPath))
                ProjectActions.LoadAnnotations(AnnotationPath);
            else
            {
                Configuration.CurrentImageJson.Name = imagename;
                File.Create(AnnotationPath).Dispose();
                Configuration.JsonPath = AnnotationPath;
            }

            ChangedImage = true;
            string imagesPath = Configuration.ProjectImages;
            pictureBox.Image = new Bitmap((string)Path.Join(imagesPath, ImagesList.FocusedItem.Text));
            Noted = false;
        }

        private void AddImages(object sender, EventArgs e)
        {
            dlgOpenFile.Title = "Abrir imagenes...";
            dlgOpenFile.Filter = "Imagenes (\"*.jpg\", \"*.jpeg\", \"*.png\", \"*.bmp\", \"*.gif\", \"*.webp\")|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.webp";
            dlgOpenFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            dlgOpenFile.FileName = "";
            dlgOpenFile.Multiselect = true;

            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                int total = dlgOpenFile.FileNames.Length;
                progressEditor.Enabled = true;
                int current = 0;

                foreach (var file in dlgOpenFile.FileNames)
                {
                    File.Copy(file, Path.Join(Configuration.ProjectImages,
                            (string)DateTime.Now.Ticks.GetHashCode().ToString("x").ToUpper() + Path.GetExtension(file)));
                    current += 1;
                    progressEditor.Value = (current / total) * 100;
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

            string images = Configuration.ProjectImages;

            foreach (ListViewItem image in ImagesList.SelectedItems)
            {
                File.Delete(Path.Join(images, image.Text.ToString()));
                ImagesList.Items.Remove(image);
            }

        }

        private void SelectImages(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (ImagesList.SelectedItems.Count == 0)
            {
                toolStripButton_removeImages.Enabled = false;
                quitarImagenesToolStripMenuItem.Enabled = false;
            }
            else if (ImagesList.SelectedItems.Count > 0)
            {
                toolStripButton_removeImages.Enabled = true;
                quitarImagenesToolStripMenuItem.Enabled = true;
            }
        }
    }
}
