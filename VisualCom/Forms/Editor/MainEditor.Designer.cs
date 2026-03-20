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
            guardarProyectoToolStripMenuItem = new ToolStripMenuItem();
            editarToolStripMenuItem = new ToolStripMenuItem();
            verToolStripMenuItem = new ToolStripMenuItem();
            proyectoToolStripMenuItem = new ToolStripMenuItem();
            imagenesToolStripMenuItem = new ToolStripMenuItem();
            añadirImagenesToolStripMenuItem = new ToolStripMenuItem();
            quitarImagenesToolStripMenuItem = new ToolStripMenuItem();
            clasesToolStripMenuItem = new ToolStripMenuItem();
            añadirClaseToolStripMenuItem = new ToolStripMenuItem();
            quitarClaseToolStripMenuItem = new ToolStripMenuItem();
            editarClaseToolStripMenuItem = new ToolStripMenuItem();
            versionesToolStripMenuItem = new ToolStripMenuItem();
            añadirVersiónToolStripMenuItem = new ToolStripMenuItem();
            quitarVersiónToolStripMenuItem = new ToolStripMenuItem();
            editarVersiónToolStripMenuItem = new ToolStripMenuItem();
            modeloToolStripMenuItem = new ToolStripMenuItem();
            entrenarToolStripMenuItem = new ToolStripMenuItem();
            exportarToolStripMenuItem = new ToolStripMenuItem();
            dlgSaveFile = new SaveFileDialog();
            dlgOpenFile = new OpenFileDialog();
            EditorToolStrip = new ToolStrip();
            toolStripButton_newProject = new ToolStripButton();
            toolStripButton_saveProject = new ToolStripButton();
            toolStripButton_loadProject = new ToolStripButton();
            toolStripButton_Exit = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButton_addImages = new ToolStripButton();
            toolStripButton_removeImages = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButton_addClass = new ToolStripButton();
            toolStripButton_removeClass = new ToolStripButton();
            toolStripButton_editClass = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            toolStripButton_newVersion = new ToolStripButton();
            toolStripButton_removeVersion = new ToolStripButton();
            toolStripButton_editVersion = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripButton_trainModel = new ToolStripButton();
            toolStripButton9 = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripButton_ASAIWeb = new ToolStripButton();
            EditorStatusStrip = new StatusStrip();
            mouseCoordinates = new ToolStripStatusLabel();
            progressEditor = new ToolStripProgressBar();
            MainContainer = new SplitContainer();
            ListsContainer = new SplitContainer();
            ClassesList = new ListView();
            columnHeader1 = new ColumnHeader();
            ImagesList = new ListView();
            pictureBox = new PictureBox();
            editorMenu.SuspendLayout();
            EditorToolStrip.SuspendLayout();
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
            editorMenu.Items.AddRange(new ToolStripItem[] { menuitemArchivo, editarToolStripMenuItem, verToolStripMenuItem, proyectoToolStripMenuItem, modeloToolStripMenuItem });
            editorMenu.Location = new Point(0, 0);
            editorMenu.Name = "editorMenu";
            editorMenu.Padding = new Padding(5, 2, 0, 2);
            editorMenu.Size = new Size(1264, 24);
            editorMenu.TabIndex = 0;
            editorMenu.Text = "editorMenu";
            // 
            // menuitemArchivo
            // 
            menuitemArchivo.DropDownItems.AddRange(new ToolStripItem[] { nuevoProyectoToolStripMenuItem, abrirProyectoToolStripMenuItem, guardarProyectoToolStripMenuItem });
            menuitemArchivo.Name = "menuitemArchivo";
            menuitemArchivo.Size = new Size(60, 20);
            menuitemArchivo.Text = "Archivo";
            // 
            // nuevoProyectoToolStripMenuItem
            // 
            nuevoProyectoToolStripMenuItem.Image = Properties.Resources.new_document;
            nuevoProyectoToolStripMenuItem.Name = "nuevoProyectoToolStripMenuItem";
            nuevoProyectoToolStripMenuItem.Size = new Size(168, 22);
            nuevoProyectoToolStripMenuItem.Text = "Nuevo Proyecto...";
            nuevoProyectoToolStripMenuItem.Click += NewProject;
            // 
            // abrirProyectoToolStripMenuItem
            // 
            abrirProyectoToolStripMenuItem.Image = Properties.Resources.open_document;
            abrirProyectoToolStripMenuItem.Name = "abrirProyectoToolStripMenuItem";
            abrirProyectoToolStripMenuItem.Size = new Size(168, 22);
            abrirProyectoToolStripMenuItem.Text = "Abrir Proyecto...";
            abrirProyectoToolStripMenuItem.Click += OpenProject;
            // 
            // guardarProyectoToolStripMenuItem
            // 
            guardarProyectoToolStripMenuItem.Image = Properties.Resources.save_document;
            guardarProyectoToolStripMenuItem.Name = "guardarProyectoToolStripMenuItem";
            guardarProyectoToolStripMenuItem.Size = new Size(168, 22);
            guardarProyectoToolStripMenuItem.Text = "Guardar Proyecto";
            guardarProyectoToolStripMenuItem.Click += SaveProject;
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
            proyectoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { imagenesToolStripMenuItem, clasesToolStripMenuItem, versionesToolStripMenuItem });
            proyectoToolStripMenuItem.Name = "proyectoToolStripMenuItem";
            proyectoToolStripMenuItem.Size = new Size(66, 20);
            proyectoToolStripMenuItem.Text = "Proyecto";
            // 
            // imagenesToolStripMenuItem
            // 
            imagenesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { añadirImagenesToolStripMenuItem, quitarImagenesToolStripMenuItem });
            imagenesToolStripMenuItem.Image = Properties.Resources.image;
            imagenesToolStripMenuItem.Name = "imagenesToolStripMenuItem";
            imagenesToolStripMenuItem.Size = new Size(125, 22);
            imagenesToolStripMenuItem.Text = "Imagenes";
            // 
            // añadirImagenesToolStripMenuItem
            // 
            añadirImagenesToolStripMenuItem.Image = Properties.Resources.add_images;
            añadirImagenesToolStripMenuItem.Name = "añadirImagenesToolStripMenuItem";
            añadirImagenesToolStripMenuItem.Size = new Size(172, 22);
            añadirImagenesToolStripMenuItem.Text = "Añadir Imagenes...";
            añadirImagenesToolStripMenuItem.Click += AddImages;
            // 
            // quitarImagenesToolStripMenuItem
            // 
            quitarImagenesToolStripMenuItem.Image = Properties.Resources.remove_images;
            quitarImagenesToolStripMenuItem.Name = "quitarImagenesToolStripMenuItem";
            quitarImagenesToolStripMenuItem.Size = new Size(172, 22);
            quitarImagenesToolStripMenuItem.Text = "Quitar Imagenes...";
            quitarImagenesToolStripMenuItem.Click += RemoveImages;
            // 
            // clasesToolStripMenuItem
            // 
            clasesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { añadirClaseToolStripMenuItem, quitarClaseToolStripMenuItem, editarClaseToolStripMenuItem });
            clasesToolStripMenuItem.Image = Properties.Resources._class;
            clasesToolStripMenuItem.Name = "clasesToolStripMenuItem";
            clasesToolStripMenuItem.Size = new Size(125, 22);
            clasesToolStripMenuItem.Text = "Clases";
            // 
            // añadirClaseToolStripMenuItem
            // 
            añadirClaseToolStripMenuItem.Image = Properties.Resources.add_class;
            añadirClaseToolStripMenuItem.Name = "añadirClaseToolStripMenuItem";
            añadirClaseToolStripMenuItem.Size = new Size(147, 22);
            añadirClaseToolStripMenuItem.Text = "Añadir clase...";
            añadirClaseToolStripMenuItem.Click += AddClass;
            // 
            // quitarClaseToolStripMenuItem
            // 
            quitarClaseToolStripMenuItem.Image = Properties.Resources.remove_class;
            quitarClaseToolStripMenuItem.Name = "quitarClaseToolStripMenuItem";
            quitarClaseToolStripMenuItem.Size = new Size(147, 22);
            quitarClaseToolStripMenuItem.Text = "Quitar clase...";
            // 
            // editarClaseToolStripMenuItem
            // 
            editarClaseToolStripMenuItem.Image = Properties.Resources.edit_class;
            editarClaseToolStripMenuItem.Name = "editarClaseToolStripMenuItem";
            editarClaseToolStripMenuItem.Size = new Size(147, 22);
            editarClaseToolStripMenuItem.Text = "Editar clase...";
            // 
            // versionesToolStripMenuItem
            // 
            versionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { añadirVersiónToolStripMenuItem, quitarVersiónToolStripMenuItem, editarVersiónToolStripMenuItem });
            versionesToolStripMenuItem.Image = Properties.Resources.version;
            versionesToolStripMenuItem.Name = "versionesToolStripMenuItem";
            versionesToolStripMenuItem.Size = new Size(125, 22);
            versionesToolStripMenuItem.Text = "Versiones";
            // 
            // añadirVersiónToolStripMenuItem
            // 
            añadirVersiónToolStripMenuItem.Image = Properties.Resources.new_version;
            añadirVersiónToolStripMenuItem.Name = "añadirVersiónToolStripMenuItem";
            añadirVersiónToolStripMenuItem.Size = new Size(159, 22);
            añadirVersiónToolStripMenuItem.Text = "Añadir versión...";
            // 
            // quitarVersiónToolStripMenuItem
            // 
            quitarVersiónToolStripMenuItem.Image = Properties.Resources.remove_version;
            quitarVersiónToolStripMenuItem.Name = "quitarVersiónToolStripMenuItem";
            quitarVersiónToolStripMenuItem.Size = new Size(159, 22);
            quitarVersiónToolStripMenuItem.Text = "Quitar versión...";
            // 
            // editarVersiónToolStripMenuItem
            // 
            editarVersiónToolStripMenuItem.Image = Properties.Resources.edit_version;
            editarVersiónToolStripMenuItem.Name = "editarVersiónToolStripMenuItem";
            editarVersiónToolStripMenuItem.Size = new Size(159, 22);
            editarVersiónToolStripMenuItem.Text = "Editar versión...";
            // 
            // modeloToolStripMenuItem
            // 
            modeloToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { entrenarToolStripMenuItem, exportarToolStripMenuItem });
            modeloToolStripMenuItem.Name = "modeloToolStripMenuItem";
            modeloToolStripMenuItem.Size = new Size(60, 20);
            modeloToolStripMenuItem.Text = "Modelo";
            // 
            // entrenarToolStripMenuItem
            // 
            entrenarToolStripMenuItem.Image = Properties.Resources.train_model;
            entrenarToolStripMenuItem.Name = "entrenarToolStripMenuItem";
            entrenarToolStripMenuItem.Size = new Size(127, 22);
            entrenarToolStripMenuItem.Text = "Entrenar...";
            entrenarToolStripMenuItem.Click += TrainModel;
            // 
            // exportarToolStripMenuItem
            // 
            exportarToolStripMenuItem.Image = Properties.Resources.export_model;
            exportarToolStripMenuItem.Name = "exportarToolStripMenuItem";
            exportarToolStripMenuItem.Size = new Size(127, 22);
            exportarToolStripMenuItem.Text = "Exportar...";
            // 
            // dlgOpenFile
            // 
            dlgOpenFile.FileName = "openFileDialog1";
            // 
            // EditorToolStrip
            // 
            EditorToolStrip.Items.AddRange(new ToolStripItem[] { toolStripButton_newProject, toolStripButton_saveProject, toolStripButton_loadProject, toolStripButton_Exit, toolStripSeparator1, toolStripButton_addImages, toolStripButton_removeImages, toolStripSeparator2, toolStripButton_addClass, toolStripButton_removeClass, toolStripButton_editClass, toolStripSeparator5, toolStripButton_newVersion, toolStripButton_removeVersion, toolStripButton_editVersion, toolStripSeparator3, toolStripButton_trainModel, toolStripButton9, toolStripSeparator4, toolStripButton_ASAIWeb });
            EditorToolStrip.Location = new Point(0, 24);
            EditorToolStrip.Name = "EditorToolStrip";
            EditorToolStrip.Size = new Size(1264, 25);
            EditorToolStrip.TabIndex = 1;
            EditorToolStrip.Text = "toolStrip1";
            // 
            // toolStripButton_newProject
            // 
            toolStripButton_newProject.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_newProject.Image = Properties.Resources.new_document;
            toolStripButton_newProject.ImageTransparentColor = Color.Magenta;
            toolStripButton_newProject.Name = "toolStripButton_newProject";
            toolStripButton_newProject.Size = new Size(23, 22);
            toolStripButton_newProject.Text = "toolStripButton1";
            toolStripButton_newProject.Click += NewProject;
            // 
            // toolStripButton_saveProject
            // 
            toolStripButton_saveProject.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_saveProject.Image = Properties.Resources.save_document;
            toolStripButton_saveProject.ImageTransparentColor = Color.Magenta;
            toolStripButton_saveProject.Name = "toolStripButton_saveProject";
            toolStripButton_saveProject.Size = new Size(23, 22);
            toolStripButton_saveProject.Text = "toolStripButton_saveProject";
            toolStripButton_saveProject.Click += SaveProject;
            // 
            // toolStripButton_loadProject
            // 
            toolStripButton_loadProject.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_loadProject.Image = Properties.Resources.open_document;
            toolStripButton_loadProject.ImageTransparentColor = Color.Magenta;
            toolStripButton_loadProject.Name = "toolStripButton_loadProject";
            toolStripButton_loadProject.Size = new Size(23, 22);
            toolStripButton_loadProject.Text = "toolStripButton_loadProject";
            toolStripButton_loadProject.Click += OpenProject;
            // 
            // toolStripButton_Exit
            // 
            toolStripButton_Exit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_Exit.Image = Properties.Resources.exit;
            toolStripButton_Exit.ImageTransparentColor = Color.Magenta;
            toolStripButton_Exit.Name = "toolStripButton_Exit";
            toolStripButton_Exit.Size = new Size(23, 22);
            toolStripButton_Exit.Text = "toolStripButton_Exit";
            toolStripButton_Exit.Click += Exit;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // toolStripButton_addImages
            // 
            toolStripButton_addImages.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_addImages.Image = Properties.Resources.add_images;
            toolStripButton_addImages.ImageTransparentColor = Color.Magenta;
            toolStripButton_addImages.Name = "toolStripButton_addImages";
            toolStripButton_addImages.Size = new Size(23, 22);
            toolStripButton_addImages.Text = "toolStripButton4";
            toolStripButton_addImages.Click += AddImages;
            // 
            // toolStripButton_removeImages
            // 
            toolStripButton_removeImages.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_removeImages.Enabled = false;
            toolStripButton_removeImages.Image = Properties.Resources.remove_images;
            toolStripButton_removeImages.ImageTransparentColor = Color.Magenta;
            toolStripButton_removeImages.Name = "toolStripButton_removeImages";
            toolStripButton_removeImages.Size = new Size(23, 22);
            toolStripButton_removeImages.Text = "toolStripButton5";
            toolStripButton_removeImages.Click += RemoveImages;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // toolStripButton_addClass
            // 
            toolStripButton_addClass.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_addClass.Image = Properties.Resources.add_class;
            toolStripButton_addClass.ImageTransparentColor = Color.Magenta;
            toolStripButton_addClass.Name = "toolStripButton_addClass";
            toolStripButton_addClass.Size = new Size(23, 22);
            toolStripButton_addClass.Text = "toolStripButton6";
            toolStripButton_addClass.Click += AddClass;
            // 
            // toolStripButton_removeClass
            // 
            toolStripButton_removeClass.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_removeClass.Enabled = false;
            toolStripButton_removeClass.Image = Properties.Resources.remove_class;
            toolStripButton_removeClass.ImageTransparentColor = Color.Magenta;
            toolStripButton_removeClass.Name = "toolStripButton_removeClass";
            toolStripButton_removeClass.Size = new Size(23, 22);
            toolStripButton_removeClass.Text = "toolStripButton7";
            toolStripButton_removeClass.Click += EraseClassDialog;
            // 
            // toolStripButton_editClass
            // 
            toolStripButton_editClass.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_editClass.Enabled = false;
            toolStripButton_editClass.Image = Properties.Resources.edit_class;
            toolStripButton_editClass.ImageTransparentColor = Color.Magenta;
            toolStripButton_editClass.Name = "toolStripButton_editClass";
            toolStripButton_editClass.Size = new Size(23, 22);
            toolStripButton_editClass.Text = "toolStripButton8";
            toolStripButton_editClass.Click += ModifyClass;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 25);
            // 
            // toolStripButton_newVersion
            // 
            toolStripButton_newVersion.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_newVersion.Image = Properties.Resources.new_version;
            toolStripButton_newVersion.ImageTransparentColor = Color.Magenta;
            toolStripButton_newVersion.Name = "toolStripButton_newVersion";
            toolStripButton_newVersion.Size = new Size(23, 22);
            toolStripButton_newVersion.Text = "toolStripButton1";
            // 
            // toolStripButton_removeVersion
            // 
            toolStripButton_removeVersion.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_removeVersion.Image = Properties.Resources.remove_version;
            toolStripButton_removeVersion.ImageTransparentColor = Color.Magenta;
            toolStripButton_removeVersion.Name = "toolStripButton_removeVersion";
            toolStripButton_removeVersion.Size = new Size(23, 22);
            toolStripButton_removeVersion.Text = "toolStripButton2";
            // 
            // toolStripButton_editVersion
            // 
            toolStripButton_editVersion.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_editVersion.Image = Properties.Resources.edit_version;
            toolStripButton_editVersion.ImageTransparentColor = Color.Magenta;
            toolStripButton_editVersion.Name = "toolStripButton_editVersion";
            toolStripButton_editVersion.Size = new Size(23, 22);
            toolStripButton_editVersion.Text = "toolStripButton3";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // toolStripButton_trainModel
            // 
            toolStripButton_trainModel.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_trainModel.Image = Properties.Resources.train_model;
            toolStripButton_trainModel.ImageTransparentColor = Color.Magenta;
            toolStripButton_trainModel.Name = "toolStripButton_trainModel";
            toolStripButton_trainModel.Size = new Size(23, 22);
            toolStripButton_trainModel.Text = "toolStripButton1";
            toolStripButton_trainModel.Click += TrainModel;
            // 
            // toolStripButton9
            // 
            toolStripButton9.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton9.Image = Properties.Resources.export_model;
            toolStripButton9.ImageTransparentColor = Color.Magenta;
            toolStripButton9.Name = "toolStripButton9";
            toolStripButton9.Size = new Size(23, 22);
            toolStripButton9.Text = "toolStripButton9";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 25);
            // 
            // toolStripButton_ASAIWeb
            // 
            toolStripButton_ASAIWeb.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_ASAIWeb.Image = Properties.Resources.logo;
            toolStripButton_ASAIWeb.ImageTransparentColor = Color.Magenta;
            toolStripButton_ASAIWeb.Name = "toolStripButton_ASAIWeb";
            toolStripButton_ASAIWeb.Size = new Size(23, 22);
            toolStripButton_ASAIWeb.Text = "Abrir web ASAI";
            toolStripButton_ASAIWeb.Click += OpenASAIWeb;
            // 
            // EditorStatusStrip
            // 
            EditorStatusStrip.Items.AddRange(new ToolStripItem[] { mouseCoordinates, progressEditor });
            EditorStatusStrip.Location = new Point(0, 659);
            EditorStatusStrip.Name = "EditorStatusStrip";
            EditorStatusStrip.RightToLeft = RightToLeft.No;
            EditorStatusStrip.Size = new Size(1264, 22);
            EditorStatusStrip.TabIndex = 2;
            EditorStatusStrip.Text = "statusStrip1";
            // 
            // mouseCoordinates
            // 
            mouseCoordinates.Name = "mouseCoordinates";
            mouseCoordinates.Size = new Size(48, 17);
            mouseCoordinates.Text = "x: 0, y: 0";
            // 
            // progressEditor
            // 
            progressEditor.Enabled = false;
            progressEditor.Name = "progressEditor";
            progressEditor.Size = new Size(100, 16);
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
            MainContainer.Panel1MinSize = 256;
            // 
            // MainContainer.Panel2
            // 
            MainContainer.Panel2.Controls.Add(pictureBox);
            MainContainer.Panel2MinSize = 512;
            MainContainer.Size = new Size(1264, 610);
            MainContainer.SplitterDistance = 256;
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
            ListsContainer.Size = new Size(256, 610);
            ListsContainer.SplitterDistance = 214;
            ListsContainer.TabIndex = 0;
            // 
            // ClassesList
            // 
            ClassesList.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            ClassesList.Dock = DockStyle.Fill;
            ClassesList.Font = new Font("Segoe UI", 12F);
            ClassesList.FullRowSelect = true;
            ClassesList.Location = new Point(0, 0);
            ClassesList.Name = "ClassesList";
            ClassesList.Size = new Size(256, 214);
            ClassesList.TabIndex = 0;
            ClassesList.UseCompatibleStateImageBehavior = false;
            ClassesList.View = View.Details;
            ClassesList.ItemSelectionChanged += SelectClass;
            ClassesList.Resize += ResizeClassesList;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Nombre";
            columnHeader1.Width = 250;
            // 
            // ImagesList
            // 
            ImagesList.Dock = DockStyle.Fill;
            ImagesList.Location = new Point(0, 0);
            ImagesList.Name = "ImagesList";
            ImagesList.Size = new Size(256, 392);
            ImagesList.TabIndex = 0;
            ImagesList.UseCompatibleStateImageBehavior = false;
            ImagesList.ItemActivate += ImagesList_ItemActivate;
            ImagesList.ItemSelectionChanged += SelectImages;
            // 
            // pictureBox
            // 
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Image = Properties.Resources.Logo_ASAI_Fondo_Transparente;
            pictureBox.Location = new Point(0, 0);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(1004, 610);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.MouseMove += PictureBox_MouseMove;
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
            EditorToolStrip.ResumeLayout(false);
            EditorToolStrip.PerformLayout();
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
        private SplitContainer ListsContainer;
        private ListView ImagesList;
        private ToolStripStatusLabel mouseCoordinates;
        private ToolStripProgressBar progressEditor;
        private ToolStripButton toolStripButton_newProject;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton_ASAIWeb;
        private ToolStripMenuItem modeloToolStripMenuItem;
        private ToolStripMenuItem entrenarToolStripMenuItem;
        private ToolStripMenuItem guardarProyectoToolStripMenuItem;
        private ToolStripButton toolStripButton_Exit;
        private ToolStripButton toolStripButton_loadProject;
        private ToolStripButton toolStripButton_saveProject;
        private ToolStripButton toolStripButton_addImages;
        private ToolStripButton toolStripButton_removeImages;
        private ToolStripButton toolStripButton_addClass;
        private ToolStripButton toolStripButton_removeClass;
        private ToolStripButton toolStripButton_editClass;
        private ToolStripButton toolStripButton9;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButton_trainModel;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton toolStripButton_newVersion;
        private ToolStripButton toolStripButton_removeVersion;
        private ToolStripButton toolStripButton_editVersion;
        private ToolStripMenuItem imagenesToolStripMenuItem;
        private ToolStripMenuItem añadirImagenesToolStripMenuItem;
        private ToolStripMenuItem quitarImagenesToolStripMenuItem;
        private ToolStripMenuItem clasesToolStripMenuItem;
        private ToolStripMenuItem añadirClaseToolStripMenuItem;
        private ToolStripMenuItem quitarClaseToolStripMenuItem;
        private ToolStripMenuItem editarClaseToolStripMenuItem;
        private ToolStripMenuItem versionesToolStripMenuItem;
        private ToolStripMenuItem añadirVersiónToolStripMenuItem;
        private ToolStripMenuItem quitarVersiónToolStripMenuItem;
        private ToolStripMenuItem editarVersiónToolStripMenuItem;
        private ToolStripMenuItem exportarToolStripMenuItem;
        private PictureBox pictureBox;
        private ListView ClassesList;
        private ColumnHeader columnHeader1;
    }
}