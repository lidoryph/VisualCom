using VisualCom.Forms.Editor.Classes;

namespace VisualCom.Forms.Editor
{
    public partial class MainEditor
    {
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
                if (classes == null) return;

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

        private void AddClass(object sender, EventArgs e)
        {
            AddClasses classwindow = new(this);
            classwindow.ShowDialog();
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

        public void ModifyExternalClass(string id, string name, string color)
        {
            if (pv_classes == null)
            {
                error.ShowDialog();
                return;
            }

            pv_classes.Elements("Class").FirstOrDefault(c => string.Equals(c.Attribute("id").Value, id, StringComparison.Ordinal)).Value = name;
            pv_classes.Elements("Class").FirstOrDefault(c => string.Equals(c.Attribute("id").Value, id, StringComparison.Ordinal)).Attribute("color").Value = color ?? "#FFFFFF";
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

        private void ResizeClassesList(object sender, EventArgs e)
        {
            ClassesList.Resize += (s, e) => ClassesList.Columns[0].Width = ClassesList.ClientSize.Width;
        }
    }
}
