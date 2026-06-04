namespace VisualCom.Forms
{
    partial class OnlineProjects
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnlineProjects));
            label1 = new Label();
            UserName_Label = new Label();
            CreateProject_Button = new Button();
            LoadProject_Button = new Button();
            EraseProject_Button = new Button();
            Disconnect_Button = new Button();
            label2 = new Label();
            ProjectsList = new ListView();
            Name_Column = new ColumnHeader();
            Type_Column = new ColumnHeader();
            Created_Column = new ColumnHeader();
            Modified_Column = new ColumnHeader();
            Classes_Column = new ColumnHeader();
            Images_Column = new ColumnHeader();
            DownloadProyect_Button = new Button();
            ImportProyect_Button = new Button();
            openFileDialog = new OpenFileDialog();
            folderBrowserDialog = new FolderBrowserDialog();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Neo Sans Std", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(99, 19);
            label1.TabIndex = 0;
            label1.Text = "¡Bienvenido, ";
            // 
            // UserName_Label
            // 
            UserName_Label.AutoSize = true;
            UserName_Label.Font = new Font("Neo Sans Std", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UserName_Label.ForeColor = Color.White;
            UserName_Label.Location = new Point(102, 8);
            UserName_Label.Name = "UserName_Label";
            UserName_Label.Size = new Size(82, 20);
            UserName_Label.TabIndex = 1;
            UserName_Label.Text = "USUARIO!";
            // 
            // CreateProject_Button
            // 
            CreateProject_Button.BackColor = Color.FromArgb(214, 10, 81);
            CreateProject_Button.Cursor = Cursors.Hand;
            CreateProject_Button.FlatAppearance.BorderSize = 0;
            CreateProject_Button.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 192);
            CreateProject_Button.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 39, 131);
            CreateProject_Button.FlatStyle = FlatStyle.Flat;
            CreateProject_Button.Font = new Font("Neo Sans Std", 9F);
            CreateProject_Button.Location = new Point(12, 66);
            CreateProject_Button.Name = "CreateProject_Button";
            CreateProject_Button.Size = new Size(128, 48);
            CreateProject_Button.TabIndex = 2;
            CreateProject_Button.Text = "Crear Proyecto...";
            CreateProject_Button.UseVisualStyleBackColor = false;
            CreateProject_Button.Click += CreateProject;
            // 
            // LoadProject_Button
            // 
            LoadProject_Button.BackColor = Color.FromArgb(214, 10, 81);
            LoadProject_Button.Cursor = Cursors.Hand;
            LoadProject_Button.Enabled = false;
            LoadProject_Button.FlatAppearance.BorderSize = 0;
            LoadProject_Button.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 192);
            LoadProject_Button.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 39, 131);
            LoadProject_Button.FlatStyle = FlatStyle.Flat;
            LoadProject_Button.Font = new Font("Neo Sans Std", 9F);
            LoadProject_Button.Location = new Point(12, 170);
            LoadProject_Button.Name = "LoadProject_Button";
            LoadProject_Button.Size = new Size(128, 48);
            LoadProject_Button.TabIndex = 3;
            LoadProject_Button.Text = "Cargar Proyecto";
            LoadProject_Button.UseVisualStyleBackColor = false;
            LoadProject_Button.Click += LoadProject;
            // 
            // EraseProject_Button
            // 
            EraseProject_Button.BackColor = Color.FromArgb(214, 10, 81);
            EraseProject_Button.Cursor = Cursors.Hand;
            EraseProject_Button.Enabled = false;
            EraseProject_Button.FlatAppearance.BorderSize = 0;
            EraseProject_Button.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 192);
            EraseProject_Button.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 39, 131);
            EraseProject_Button.FlatStyle = FlatStyle.Flat;
            EraseProject_Button.Font = new Font("Neo Sans Std", 9F);
            EraseProject_Button.Location = new Point(13, 274);
            EraseProject_Button.Name = "EraseProject_Button";
            EraseProject_Button.Size = new Size(128, 48);
            EraseProject_Button.TabIndex = 4;
            EraseProject_Button.Text = "Borrar Proyecto...";
            EraseProject_Button.UseVisualStyleBackColor = false;
            EraseProject_Button.Click += DeleteProject;
            // 
            // Disconnect_Button
            // 
            Disconnect_Button.BackColor = Color.FromArgb(214, 10, 81);
            Disconnect_Button.Cursor = Cursors.Hand;
            Disconnect_Button.FlatAppearance.BorderSize = 0;
            Disconnect_Button.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 192);
            Disconnect_Button.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 39, 131);
            Disconnect_Button.FlatStyle = FlatStyle.Flat;
            Disconnect_Button.Font = new Font("Neo Sans Std", 9F);
            Disconnect_Button.Location = new Point(12, 378);
            Disconnect_Button.Name = "Disconnect_Button";
            Disconnect_Button.Size = new Size(128, 48);
            Disconnect_Button.TabIndex = 5;
            Disconnect_Button.Text = "Desconectarse...";
            Disconnect_Button.UseVisualStyleBackColor = false;
            Disconnect_Button.Click += Disconnect;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Neo Sans Std", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(152, 42);
            label2.Name = "label2";
            label2.Size = new Size(262, 19);
            label2.TabIndex = 6;
            label2.Text = "Estos son los proyectos disponibles:";
            // 
            // ProjectsList
            // 
            ProjectsList.BackColor = Color.FromArgb(33, 32, 32);
            ProjectsList.BorderStyle = BorderStyle.None;
            ProjectsList.Columns.AddRange(new ColumnHeader[] { Name_Column, Type_Column, Created_Column, Modified_Column, Classes_Column, Images_Column });
            ProjectsList.ForeColor = Color.White;
            ProjectsList.FullRowSelect = true;
            ProjectsList.Location = new Point(152, 66);
            ProjectsList.Name = "ProjectsList";
            ProjectsList.Size = new Size(636, 360);
            ProjectsList.TabIndex = 8;
            ProjectsList.UseCompatibleStateImageBehavior = false;
            ProjectsList.View = View.Details;
            ProjectsList.ItemSelectionChanged += ChangedSelectionList;
            // 
            // Name_Column
            // 
            Name_Column.Text = "Nombre";
            Name_Column.Width = 100;
            // 
            // Type_Column
            // 
            Type_Column.Text = "Tipo";
            Type_Column.Width = 150;
            // 
            // Created_Column
            // 
            Created_Column.Text = "Creado";
            Created_Column.Width = 125;
            // 
            // Modified_Column
            // 
            Modified_Column.Text = "Modificado";
            Modified_Column.Width = 125;
            // 
            // Classes_Column
            // 
            Classes_Column.Text = "Clases";
            Classes_Column.TextAlign = HorizontalAlignment.Center;
            // 
            // Images_Column
            // 
            Images_Column.Text = "Imagenes";
            Images_Column.TextAlign = HorizontalAlignment.Center;
            Images_Column.Width = 75;
            // 
            // DownloadProyect_Button
            // 
            DownloadProyect_Button.BackColor = Color.FromArgb(214, 10, 81);
            DownloadProyect_Button.Cursor = Cursors.Hand;
            DownloadProyect_Button.FlatAppearance.BorderSize = 0;
            DownloadProyect_Button.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 192);
            DownloadProyect_Button.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 39, 131);
            DownloadProyect_Button.FlatStyle = FlatStyle.Flat;
            DownloadProyect_Button.Font = new Font("Neo Sans Std", 9F);
            DownloadProyect_Button.Location = new Point(660, 8);
            DownloadProyect_Button.Name = "DownloadProyect_Button";
            DownloadProyect_Button.Size = new Size(128, 48);
            DownloadProyect_Button.TabIndex = 9;
            DownloadProyect_Button.Text = "Descargar Proyecto";
            DownloadProyect_Button.UseVisualStyleBackColor = false;
            DownloadProyect_Button.Click += DownloadProject;
            // 
            // ImportProyect_Button
            // 
            ImportProyect_Button.BackColor = Color.FromArgb(214, 10, 81);
            ImportProyect_Button.Cursor = Cursors.Hand;
            ImportProyect_Button.FlatAppearance.BorderSize = 0;
            ImportProyect_Button.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 192);
            ImportProyect_Button.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 39, 131);
            ImportProyect_Button.FlatStyle = FlatStyle.Flat;
            ImportProyect_Button.Font = new Font("Neo Sans Std", 9F);
            ImportProyect_Button.Location = new Point(508, 8);
            ImportProyect_Button.Name = "ImportProyect_Button";
            ImportProyect_Button.Size = new Size(128, 48);
            ImportProyect_Button.TabIndex = 10;
            ImportProyect_Button.Text = "Importar Proyecto";
            ImportProyect_Button.UseVisualStyleBackColor = false;
            ImportProyect_Button.Click += ImportProject;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "proyecto.asaivc";
            // 
            // OnlineProjects
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(63, 62, 62);
            ClientSize = new Size(800, 450);
            Controls.Add(ImportProyect_Button);
            Controls.Add(DownloadProyect_Button);
            Controls.Add(ProjectsList);
            Controls.Add(label2);
            Controls.Add(Disconnect_Button);
            Controls.Add(EraseProject_Button);
            Controls.Add(LoadProject_Button);
            Controls.Add(CreateProject_Button);
            Controls.Add(UserName_Label);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(816, 489);
            MinimizeBox = false;
            MinimumSize = new Size(816, 489);
            Name = "OnlineProjects";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Proyectos Online";
            FormClosed += OnlineProjects_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label UserName_Label;
        private Button CreateProject_Button;
        private Button LoadProject_Button;
        private Button EraseProject_Button;
        private Button Disconnect_Button;
        private Label label2;
        private ListView ProjectsList;
        private ColumnHeader Name_Column;
        private ColumnHeader Type_Column;
        private ColumnHeader Modified_Column;
        private ColumnHeader Created_Column;
        private ColumnHeader Classes_Column;
        private ColumnHeader Images_Column;
        private Button DownloadProyect_Button;
        private Button ImportProyect_Button;
        private OpenFileDialog openFileDialog;
        private FolderBrowserDialog folderBrowserDialog;
    }
}