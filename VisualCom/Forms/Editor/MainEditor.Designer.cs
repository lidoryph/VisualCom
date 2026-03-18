namespace VisualCom
{
    partial class MainEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainEditor));
            editorMenu = new MenuStrip();
            menuitemArchivo = new ToolStripMenuItem();
            nuevoProyectoToolStripMenuItem = new ToolStripMenuItem();
            abrirProyectoToolStripMenuItem = new ToolStripMenuItem();
            editarToolStripMenuItem = new ToolStripMenuItem();
            verToolStripMenuItem = new ToolStripMenuItem();
            proyectoToolStripMenuItem = new ToolStripMenuItem();
            dlgSaveFile = new SaveFileDialog();
            dlgOpenFile = new OpenFileDialog();
            EditorToolStrip = new ToolStrip();
            EditorStatusStrip = new StatusStrip();
            MainContainer = new SplitContainer();
            ListsContainer = new SplitContainer();
            ClassesList = new ListBox();
            ImagesList = new ListView();
            pictureBox = new PictureBox();
            mouseCoordinates = new ToolStripStatusLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            editorMenu.SuspendLayout();
            EditorStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)MainContainer).BeginInit();
            MainContainer.Panel1.SuspendLayout();
            MainContainer.Panel2.SuspendLayout();
            MainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ListsContainer).BeginInit();
            ListsContainer.Panel1.SuspendLayout();
            ListsContainer.Panel2.SuspendLayout();
            ListsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // editorMenu
            // 
            editorMenu.ImageScalingSize = new Size(20, 20);
            editorMenu.Items.AddRange(new ToolStripItem[] { menuitemArchivo, editarToolStripMenuItem, verToolStripMenuItem, proyectoToolStripMenuItem });
            editorMenu.Location = new Point(0, 0);
            editorMenu.Name = "editorMenu";
            editorMenu.Padding = new Padding(5, 2, 0, 2);
            editorMenu.Size = new Size(1264, 24);
            editorMenu.TabIndex = 0;
            editorMenu.Text = "editorMenu";
            // 
            // menuitemArchivo
            // 
            menuitemArchivo.DropDownItems.AddRange(new ToolStripItem[] { nuevoProyectoToolStripMenuItem, abrirProyectoToolStripMenuItem });
            menuitemArchivo.Name = "menuitemArchivo";
            menuitemArchivo.Size = new Size(60, 20);
            menuitemArchivo.Text = "Archivo";
            // 
            // nuevoProyectoToolStripMenuItem
            // 
            nuevoProyectoToolStripMenuItem.Name = "nuevoProyectoToolStripMenuItem";
            nuevoProyectoToolStripMenuItem.Size = new Size(180, 22);
            nuevoProyectoToolStripMenuItem.Text = "Nuevo Proyecto...";
            nuevoProyectoToolStripMenuItem.Click += nuevoProyectoToolStripMenuItem_Click;
            // 
            // abrirProyectoToolStripMenuItem
            // 
            abrirProyectoToolStripMenuItem.Name = "abrirProyectoToolStripMenuItem";
            abrirProyectoToolStripMenuItem.Size = new Size(180, 22);
            abrirProyectoToolStripMenuItem.Text = "Abrir Proyecto...";
            abrirProyectoToolStripMenuItem.Click += abrirProyectoToolStripMenuItem_Click;
            // 
            // editarToolStripMenuItem
            // 
            editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            editarToolStripMenuItem.Size = new Size(49, 20);
            editarToolStripMenuItem.Text = "Editar";
            // 
            // verToolStripMenuItem
            // 
            verToolStripMenuItem.Name = "verToolStripMenuItem";
            verToolStripMenuItem.Size = new Size(35, 20);
            verToolStripMenuItem.Text = "Ver";
            // 
            // proyectoToolStripMenuItem
            // 
            proyectoToolStripMenuItem.Name = "proyectoToolStripMenuItem";
            proyectoToolStripMenuItem.Size = new Size(66, 20);
            proyectoToolStripMenuItem.Text = "Proyecto";
            // 
            // dlgOpenFile
            // 
            dlgOpenFile.FileName = "openFileDialog1";
            // 
            // EditorToolStrip
            // 
            EditorToolStrip.Location = new Point(0, 24);
            EditorToolStrip.Name = "EditorToolStrip";
            EditorToolStrip.Size = new Size(1264, 25);
            EditorToolStrip.TabIndex = 1;
            EditorToolStrip.Text = "toolStrip1";
            // 
            // EditorStatusStrip
            // 
            EditorStatusStrip.Items.AddRange(new ToolStripItem[] { mouseCoordinates, toolStripProgressBar1 });
            EditorStatusStrip.Location = new Point(0, 659);
            EditorStatusStrip.Name = "EditorStatusStrip";
            EditorStatusStrip.RightToLeft = RightToLeft.No;
            EditorStatusStrip.Size = new Size(1264, 22);
            EditorStatusStrip.TabIndex = 2;
            EditorStatusStrip.Text = "statusStrip1";
            // 
            // MainContainer
            // 
            MainContainer.Dock = DockStyle.Fill;
            MainContainer.Location = new Point(0, 49);
            MainContainer.Name = "MainContainer";
            // 
            // MainContainer.Panel1
            // 
            MainContainer.Panel1.Controls.Add(ListsContainer);
            // 
            // MainContainer.Panel2
            // 
            MainContainer.Panel2.Controls.Add(pictureBox);
            MainContainer.Size = new Size(1264, 610);
            MainContainer.SplitterDistance = 421;
            MainContainer.TabIndex = 3;
            // 
            // ListsContainer
            // 
            ListsContainer.Dock = DockStyle.Fill;
            ListsContainer.Location = new Point(0, 0);
            ListsContainer.Name = "ListsContainer";
            ListsContainer.Orientation = Orientation.Horizontal;
            // 
            // ListsContainer.Panel1
            // 
            ListsContainer.Panel1.Controls.Add(ClassesList);
            // 
            // ListsContainer.Panel2
            // 
            ListsContainer.Panel2.Controls.Add(ImagesList);
            ListsContainer.Size = new Size(421, 610);
            ListsContainer.SplitterDistance = 214;
            ListsContainer.TabIndex = 0;
            // 
            // ClassesList
            // 
            ClassesList.Dock = DockStyle.Fill;
            ClassesList.FormattingEnabled = true;
            ClassesList.Location = new Point(0, 0);
            ClassesList.Name = "ClassesList";
            ClassesList.Size = new Size(421, 214);
            ClassesList.TabIndex = 0;
            // 
            // ImagesList
            // 
            ImagesList.Dock = DockStyle.Fill;
            ImagesList.Location = new Point(0, 0);
            ImagesList.Name = "ImagesList";
            ImagesList.Size = new Size(421, 392);
            ImagesList.TabIndex = 0;
            ImagesList.UseCompatibleStateImageBehavior = false;
            ImagesList.ItemActivate += ImagesList_ItemActivate;
            // 
            // pictureBox
            // 
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Image = Properties.Resources.Logo_ASAI_Fondo_Transparente;
            pictureBox.Location = new Point(0, 0);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(839, 610);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.MouseEnter += pictureBox_MouseEnter;
            // 
            // mouseCoordinates
            // 
            mouseCoordinates.Name = "mouseCoordinates";
            mouseCoordinates.Size = new Size(118, 17);
            mouseCoordinates.Text = "toolStripStatusLabel1";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 16);
            // 
            // MainEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(MainContainer);
            Controls.Add(EditorStatusStrip);
            Controls.Add(EditorToolStrip);
            Controls.Add(editorMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = editorMenu;
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(1280, 720);
            Name = "MainEditor";
            Text = "VisualCom - Editor";
            WindowState = FormWindowState.Maximized;
            editorMenu.ResumeLayout(false);
            editorMenu.PerformLayout();
            EditorStatusStrip.ResumeLayout(false);
            EditorStatusStrip.PerformLayout();
            MainContainer.Panel1.ResumeLayout(false);
            MainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)MainContainer).EndInit();
            MainContainer.ResumeLayout(false);
            ListsContainer.Panel1.ResumeLayout(false);
            ListsContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ListsContainer).EndInit();
            ListsContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip editorMenu;
        private ToolStripMenuItem menuitemArchivo;
        private ToolStripMenuItem nuevoProyectoToolStripMenuItem;
        private ToolStripMenuItem editarToolStripMenuItem;
        private ToolStripMenuItem verToolStripMenuItem;
        private ToolStripMenuItem proyectoToolStripMenuItem;
        private SaveFileDialog dlgSaveFile;
        private OpenFileDialog dlgOpenFile;
        private ToolStripMenuItem abrirProyectoToolStripMenuItem;
        private ToolStrip EditorToolStrip;
        private StatusStrip EditorStatusStrip;
        private SplitContainer MainContainer;
        private PictureBox pictureBox;
        private SplitContainer ListsContainer;
        private ListBox ClassesList;
        private ListView ImagesList;
        private ToolStripStatusLabel mouseCoordinates;
        private ToolStripProgressBar toolStripProgressBar1;
    }
}