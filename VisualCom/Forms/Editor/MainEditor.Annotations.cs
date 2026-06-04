using VisualCom.DataTypes;

namespace VisualCom.Forms.Editor
{
    public partial class MainEditor
    {
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

            if (Locked)
            {
                MessageBox.Show("La imagen ya está siendo editada por otro usuario.");
                return;
            }

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

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            PointF? imgCoords = GetImageCoordinates(e.Location);
            if (!imgCoords.HasValue)
                return;

            int currentX = (int)imgCoords.Value.X;
            int currentY = (int)imgCoords.Value.Y;

            if (currentX != _lastMouseCoordX || currentY != _lastMouseCoordY)
            {
                mouseCoordinates.Text = $"x: {currentX}, y: {currentY}";
                _lastMouseCoordX = currentX;
                _lastMouseCoordY = currentY;
            }

            if (_isDragging)
            {
                _dragCurrentBox = e.Location;
                pictureBox.Invalidate();
            }
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
                    BL = [_selectionBottomLeft.X, _selectionBottomLeft.Y],
                    TR = [_selectionTopRight.X, _selectionTopRight.Y]
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
            ProjectActions.SaveProject(notes: true);

            pictureBox.Invalidate();
        }
    }
}
