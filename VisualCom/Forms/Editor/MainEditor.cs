using System.Diagnostics;
using System.Xml.Linq;
using VisualCom.Forms;
using VisualCom.Forms.Editor;
using VisualCom.Forms.Editor.Classes;
using VisualCom.Forms.Editor.PullModels;
using VisualCom.Forms.Editor.TrainWindows;
using VisualCom.Forms.Editor.Versions;
using VisualCom.Forms.Errors;

namespace VisualCom
{
    public partial class MainEditor : Form
    {

        private readonly ReadingDocument error = new();
        private readonly XElement? pv_type = Configuration.ProjectVariables.Root?.Element("Type");
        private readonly XElement? pv_name = Configuration.ProjectVariables.Root?.Element("Name");
        private readonly XElement? pv_version = Configuration.ProjectVariables.Root?.Element("Version");

        private readonly XElement? pv_images = Configuration.ProjectVariables.Root?.Element("Directories")?.Element("Images");
        private readonly XElement? pv_versions = Configuration.ProjectVariables.Root?.Element("Directories")?.Element("Versions");
        private readonly XElement? pv_notes = Configuration.ProjectVariables.Root?.Element("Directories")?.Element("Annotations");

        private readonly XElement? pv_classes = Configuration.ProjectVariables.Root?.Element("Classes");

        private Boolean _isDragging = false;
        private Point _dragStartBox = Point.Empty;
        private Point _dragCurrentBox = Point.Empty;

        private PointF _selectionBottomLeft = PointF.Empty;
        private PointF _selectionTopRight = PointF.Empty;

        private Boolean ChangedImage = false;
        private Boolean Noted = true;

        public MainEditor()
        {
            InitializeComponent();

            if (pv_type == null || pv_name == null || pv_version == null)
            {
                error.Show();
                return;
            }

            if (pv_type.Value == "OI")
            {
                this.Text = "VisualCom - Editando proyecto \"" + pv_name.Value + "\" de tipo Identificación de Objetos. Versión: " + pv_version.Value;
            }
            else if (pv_type.Value == "C")
            {
                this.Text = "VisualCom - Editando proyecto \"" + pv_name.Value + "\" de tipo Clasificación. Versión: " + pv_version.Value;

            }

            ClassesList.Resize += (s, e) => ClassesList.Columns[0].Width = ClassesList.ClientSize.Width;

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
        }

        private void NewProject(object sender, EventArgs e)
        {
            var projecttype = new ProjectType();
            projecttype.ShowDialog();

            if (pv_type == null)
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

            if (pv_images == null)
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
            if (pv_images == null || pv_notes == null)
            {
                error.Show();
                return;
            }

            if (ImagesList.FocusedItem == null)
                return;

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
                if (dialog.Cancel == true)
                    return;
            }

            string imagename = "";

            foreach (ListViewItem item in ImagesList.SelectedItems)
                imagename = item.Text;

            Configuration.CurrentImageJson.Boxes.Clear();
            string AnnotationPath = Path.Join(pv_notes.Value, Path.GetFileNameWithoutExtension(imagename) + ".json");

            if (File.Exists(AnnotationPath))
                ProjectActions.LoadAnnotations(AnnotationPath);
            else
            {
                Configuration.CurrentImageJson.Name = imagename;
                File.Create(AnnotationPath).Dispose();
                Configuration.JsonPath = AnnotationPath;
            }

            ChangedImage = true;
            string imagesPath = pv_images.Value;
            pictureBox.Image = new Bitmap((string)Path.Join(imagesPath, ImagesList.FocusedItem.Text));
            Noted = false;
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            PointF? imgCoords = GetImageCoordinates(e.Location);

            if (imgCoords.HasValue)
                mouseCoordinates.Text = $"x: {(int)imgCoords.Value.X}, y: {(int)imgCoords.Value.Y}";
            else return;

            if (_isDragging)
            {
                _dragCurrentBox = e.Location;
                pictureBox.Invalidate();
            }
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

            if (pv_images == null)
            {
                error.Show();
                return;
            }

            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                int total = dlgOpenFile.FileNames.Length;
                progressEditor.Enabled = true;
                int current = 0;

                foreach (var file in dlgOpenFile.FileNames)
                {
                    File.Copy(file, Path.Join(pv_images.Value,
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
            if (ChangedImage)
                ProjectActions.SaveProject(notes: true);
            else
                ProjectActions.SaveProject(notes: false);
            progressEditor.Value = 100;
            progressEditor.Enabled = false;
            Configuration.Saved = true;
        }

        private void LoadClassesToList()
        {
            ListViewItem item;
            string classname;

            if (pv_classes == null)
            {
                error.Show();
                return;
            }

            foreach (var classes in pv_classes.Elements("Class"))
            {
                if (classes == null)
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

            if (ClassesList.SelectedItems.Count == 0)
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
            if (pv_classes == null)
            {
                error.ShowDialog();
                return;
            }


            pv_classes.Elements("Class").FirstOrDefault(c => string.Equals(c.Attribute("id")?.Value, id, StringComparison.Ordinal))?.Value = name;
            pv_classes.Elements("Class").FirstOrDefault(c => string.Equals(c.Attribute("id")?.Value, id, StringComparison.Ordinal))?.Attribute("color")?.Value = color ?? "#FFFFFF";
            foreach (ListViewItem item in ClassesList.Items)
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

            foreach (ListViewItem item in ClassesList.SelectedItems)
            {
                id = item.Name;
                name = item.Text;
                color = ColorTranslator.ToHtml(item.BackColor);
            }

            ModifyClass dialog = new(this, id, name, color);
            dialog.ShowDialog();
        }

        private void SelectClass(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (ClassesList.SelectedItems.Count == 0)
            {
                toolStripButton_editClass.Enabled = false;
                toolStripButton_removeClass.Enabled = false;
                quitarClaseToolStripMenuItem.Enabled = false;
                editarClaseToolStripMenuItem.Enabled = false;
            }
            else if (ClassesList.SelectedItems.Count > 0)
            {
                toolStripButton_editClass.Enabled = true;
                toolStripButton_removeClass.Enabled = true;
                quitarClaseToolStripMenuItem.Enabled = true;
                editarClaseToolStripMenuItem.Enabled = true;
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

        private void ResizeClassesList(object sender, EventArgs e)
        {
            ClassesList.Resize += (s, e) => ClassesList.Columns[0].Width = ClassesList.ClientSize.Width;
        }


        private void DialogNewVersion(object sender, EventArgs e)
        {
            NewVersion dialog = new(this);
            dialog.ShowDialog();
        }

        private void DialogRemoveVersion(object sender, EventArgs e)
        {
            RemoveVersion dialog = new(this);
            dialog.ShowDialog();
        }

        public void NewVersion((string, string, string, string) VersionArguments)
        {
            if (pv_versions == null || pv_images == null || pv_notes == null || pv_version == null || pv_classes == null)
            {
                error.ShowDialog();
                return;
            }

            string FirstOctave = VersionArguments.Item1;
            string SecondOctave = VersionArguments.Item2;
            string ThirdOctave = VersionArguments.Item3;
            string VersionSuffix = VersionArguments.Item4;

            string VersionName = FirstOctave + "." + SecondOctave + "." + ThirdOctave + "-" + VersionSuffix;
            string VersionPath = Path.Join(pv_versions.Value, VersionName);
            string VersionImages = Path.Join(VersionPath, "images");
            string VersionAnnotations = Path.Join(VersionPath, "annotations");

            XDocument VersionDoc = new(
                new XElement("Version",
                    new XElement("Name", VersionName),
                    new XElement("Directories",
                        new XElement("Images", VersionImages),
                        new XElement("Annotations", VersionAnnotations)
                    ),
                    new XElement("Classes")
                )
            );

            foreach(XElement Class in pv_classes.Elements("Class"))
                VersionDoc.Root?.Element("Classes")?.Add(Class);

            System.IO.Directory.CreateDirectory(VersionPath);
            System.IO.Directory.CreateDirectory(VersionImages);
            System.IO.Directory.CreateDirectory(VersionAnnotations);

            foreach (var image in System.IO.Directory.GetFiles(pv_images.Value))
                System.IO.File.Copy(image, Path.Join(VersionImages, Path.GetFileName(image)));
            foreach (var note in System.IO.Directory.GetFiles(pv_notes.Value))
                System.IO.File.Copy(note, Path.Join(VersionAnnotations, Path.GetFileName(note)));

            VersionDoc.Save(Path.Join(VersionPath, VersionName + ".xml"));

            pv_version.Value = VersionName;
            ProjectActions.SaveProject(notes:false);
        }

        public void RemoveVersion(string version)
        {
            if (pv_versions == null)
                return;

            string VersionPath = Path.Join(pv_versions.Value, version);
            System.IO.Directory.Delete(VersionPath, true);
        }

        private RectangleF GetRenderedImageRect()
        {
            if (pictureBox.Image == null) return RectangleF.Empty;

            float imgAspect = (float)pictureBox.Image.Width / pictureBox.Image.Height;
            float boxAspect = (float)pictureBox.Width / pictureBox.Height;

            float drawWidth, drawHeight;
            if (imgAspect > boxAspect)
            {
                drawWidth = pictureBox.Width;
                drawHeight = pictureBox.Width / imgAspect;
            }
            else
            {
                drawHeight = pictureBox.Height;
                drawWidth = pictureBox.Height * imgAspect;
            }

            float offsetX = (pictureBox.Width - drawWidth) / 2f;
            float offsetY = (pictureBox.Height - drawHeight) / 2f;

            return new RectangleF(offsetX, offsetY, drawWidth, drawHeight);
        }

        private PointF? GetImageCoordinates(Point mousePos)
        {
            if (pictureBox.Image == null) return null;

            RectangleF imgRect = GetRenderedImageRect();
            if (!imgRect.Contains(mousePos)) return null;

            float imgX = (mousePos.X - imgRect.X) / imgRect.Width * pictureBox.Image.Width;
            float imgY = (mousePos.Y - imgRect.Y) / imgRect.Height * pictureBox.Image.Height;

            return new PointF(imgX, imgY);
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (ChangedImage == false)
                return;

            if (ClassesList.SelectedItems.Count == 0)
            {
                MessageBox.Show("¡Tienes que seleccionar una clase para hacer anotaciones!");
                return;
            }
            else if (ClassesList.SelectedItems.Count > 1)
            {
                MessageBox.Show("¡Solo puedes seleccionar una clase para hacer anotaciones!");
                return;
            }

            if (e.Button != MouseButtons.Left || pictureBox.Image == null) return;

            _isDragging = true;
            _dragStartBox = e.Location;
            _dragCurrentBox = e.Location;
            pictureBox.Invalidate();
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_isDragging || e.Button != MouseButtons.Left) return;

            _isDragging = false;
            _dragCurrentBox = e.Location;

            // Convertir ambos extremos a coordenadas de imagen
            PointF? start = GetImageCoordinates(_dragStartBox);
            PointF? end = GetImageCoordinates(_dragCurrentBox);

            if (start.HasValue && end.HasValue)
            {
                // Esquina inferior izquierda (X mín, Y máx) y superior derecha (X máx, Y mín)
                _selectionBottomLeft = new PointF(
                    Math.Min(start.Value.X, end.Value.X),
                    Math.Max(start.Value.Y, end.Value.Y)   // Y mayor = más abajo en imagen
                );
                _selectionTopRight = new PointF(
                    Math.Max(start.Value.X, end.Value.X),
                    Math.Min(start.Value.Y, end.Value.Y)   // Y menor = más arriba en imagen
                );

                string classname = "";

                foreach (ListViewItem item in ClassesList.SelectedItems)
                    classname = item.Text;

                Configuration.CurrentImageCoordinates.Add(new Tuple<PointF, PointF>(_selectionBottomLeft, _selectionTopRight));
                Configuration.CurrentImageJson.Boxes.Add(new BoundingBox
                {
                    Class = classname,
                    BL = new float[] { _selectionBottomLeft.X, _selectionBottomLeft.Y },
                    TR = new float[] { _selectionTopRight.X, _selectionTopRight.Y }
                });
            }
            Configuration.Saved = false;
            pictureBox.Invalidate();
            Noted = true;
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            RectangleF imgRect = GetRenderedImageRect();
            if (imgRect == RectangleF.Empty || pictureBox.Image == null) return;

            float scaleX = imgRect.Width / pictureBox.Image.Width;
            float scaleY = imgRect.Height / pictureBox.Image.Height;

            // Dibujar todas las anotaciones guardadas
            foreach (BoundingBox box in Configuration.CurrentImageJson.Boxes)
            {
                // BL[0] = minX, TR[1] = minY → esquina superior izquierda del rectángulo
                int x = (int)(imgRect.X + box.BL[0] * scaleX);
                int y = (int)(imgRect.Y + box.TR[1] * scaleY);
                int w = (int)((box.TR[0] - box.BL[0]) * scaleX);
                int h = (int)((box.BL[1] - box.TR[1]) * scaleY);

                if (w < 2 || h < 2) continue;

                Color boxColor = Color.Red;
                foreach (ListViewItem item in ClassesList.Items)
                {
                    if (item.Text == box.Class)
                    {
                        boxColor = item.BackColor;
                        break;
                    }
                }

                using SolidBrush fill = new(Color.FromArgb(0, 0, 0, 0));
                using Pen border = new(boxColor, 2);
                e.Graphics.FillRectangle(fill, x, y, w, h);
                e.Graphics.DrawRectangle(border, x, y, w, h);
            }

            // Dibujar el rectángulo que se está arrastrando ahora mismo
            if (_isDragging && _dragStartBox != Point.Empty && _dragCurrentBox != Point.Empty)
            {
                int x = Math.Min(_dragStartBox.X, _dragCurrentBox.X);
                int y = Math.Min(_dragStartBox.Y, _dragCurrentBox.Y);
                int w = Math.Abs(_dragStartBox.X - _dragCurrentBox.X);
                int h = Math.Abs(_dragStartBox.Y - _dragCurrentBox.Y);

                if (w >= 2 && h >= 2)
                {
                    Color dragColor = Color.Red;
                    foreach (ListViewItem item in ClassesList.SelectedItems)
                        dragColor = item.BackColor;

                    using SolidBrush fill = new(Color.FromArgb(40, dragColor.R, dragColor.G, dragColor.B));
                    using Pen border = new(dragColor, 2);
                    e.Graphics.FillRectangle(fill, x, y, w, h);
                    e.Graphics.DrawRectangle(border, x, y, w, h);
                }
            }
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            if (pictureBox.Image == null) return;

            PointF? click = GetImageCoordinates(e.Location);
            if (!click.HasValue) return;

            float cx = click.Value.X;
            float cy = click.Value.Y;

            // Buscar la primera caja que contenga el punto del click
            BoundingBox? toRemove = null;
            foreach (BoundingBox box in Configuration.CurrentImageJson.Boxes)
            {
                float minX = box.BL[0];
                float maxX = box.TR[0];
                float minY = box.TR[1];
                float maxY = box.BL[1];

                if (cx >= minX && cx <= maxX && cy >= minY && cy <= maxY)
                {
                    toRemove = box;
                    break;
                }
            }

            if (toRemove == null) return;

            // Borrar de ambas listas
            Configuration.CurrentImageJson.Boxes.Remove(toRemove);
            Configuration.CurrentImageCoordinates.RemoveAll(t =>
                t.Item1.X == toRemove.BL[0] && t.Item1.Y == toRemove.BL[1] &&
                t.Item2.X == toRemove.TR[0] && t.Item2.Y == toRemove.TR[1]
            );

            // Guardar el JSON actualizado
            ProjectActions.SaveProject(notes:true);

            pictureBox.Invalidate();
        }

        private void Export(object sender, EventArgs e)
        {
            ExportToYolo dialog = new();
            dialog.ShowDialog();
        }

        private void PullModel(object sender, EventArgs e)
        {
            PullModel dialog = new();
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
