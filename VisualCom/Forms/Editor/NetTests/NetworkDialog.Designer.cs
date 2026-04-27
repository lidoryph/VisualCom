namespace VisualCom.Forms.Editor.NetTests
{
    partial class NetworkDialog
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
            PingButton = new Button();
            ServerURL = new TextBox();
            PortNumber = new NumericUpDown();
            CreateButton = new Button();
            ProjectName = new TextBox();
            ProjectType = new ComboBox();
            GetProjectsButton = new Button();
            EraseProject = new Button();
            SendPicButton = new Button();
            ErasePicButton = new Button();
            LockImageButton = new Button();
            GetImagesButton = new Button();
            groupBox1 = new GroupBox();
            ImagesList = new ComboBox();
            groupBox2 = new GroupBox();
            ProjectsList = new ComboBox();
            LoadProjectButton = new Button();
            groupBox3 = new GroupBox();
            ClassesList = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            GetClassesButton = new Button();
            groupBox4 = new GroupBox();
            VersionsList = new ComboBox();
            EraseVersionButton = new Button();
            AddVersionButton = new Button();
            groupBox5 = new GroupBox();
            TrainLists = new ComboBox();
            EraseModelButton = new Button();
            TrainModelButton = new Button();
            button3 = new Button();
            button4 = new Button();
            groupBox6 = new GroupBox();
            RightTopText = new TextBox();
            LeftBotText = new TextBox();
            AddAnotationButton = new Button();
            EraseAnotationButton = new Button();
            OpenFileDialog = new OpenFileDialog();
            user = new TextBox();
            ((System.ComponentModel.ISupportInitialize)PortNumber).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // PingButton
            // 
            PingButton.Location = new Point(12, 12);
            PingButton.Name = "PingButton";
            PingButton.Size = new Size(75, 23);
            PingButton.TabIndex = 0;
            PingButton.Text = "Ping";
            PingButton.UseVisualStyleBackColor = true;
            PingButton.Click += PingServer;
            // 
            // ServerURL
            // 
            ServerURL.Location = new Point(93, 12);
            ServerURL.Name = "ServerURL";
            ServerURL.Size = new Size(232, 23);
            ServerURL.TabIndex = 1;
            ServerURL.Text = "127.0.0.1";
            // 
            // PortNumber
            // 
            PortNumber.Location = new Point(331, 12);
            PortNumber.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            PortNumber.Name = "PortNumber";
            PortNumber.Size = new Size(87, 23);
            PortNumber.TabIndex = 2;
            PortNumber.Value = new decimal(new int[] { 4541, 0, 0, 0 });
            // 
            // CreateButton
            // 
            CreateButton.Location = new Point(218, 41);
            CreateButton.Name = "CreateButton";
            CreateButton.Size = new Size(200, 23);
            CreateButton.TabIndex = 3;
            CreateButton.Text = "Crear Proyecto";
            CreateButton.UseVisualStyleBackColor = true;
            CreateButton.Click += NewProject;
            // 
            // ProjectName
            // 
            ProjectName.Location = new Point(424, 42);
            ProjectName.Name = "ProjectName";
            ProjectName.Size = new Size(129, 23);
            ProjectName.TabIndex = 4;
            // 
            // ProjectType
            // 
            ProjectType.FormattingEnabled = true;
            ProjectType.Items.AddRange(new object[] { "OI", "C" });
            ProjectType.Location = new Point(559, 41);
            ProjectType.Name = "ProjectType";
            ProjectType.Size = new Size(65, 23);
            ProjectType.TabIndex = 5;
            // 
            // GetProjectsButton
            // 
            GetProjectsButton.Location = new Point(218, 70);
            GetProjectsButton.Name = "GetProjectsButton";
            GetProjectsButton.Size = new Size(200, 23);
            GetProjectsButton.TabIndex = 6;
            GetProjectsButton.Text = "Leer Proyectos";
            GetProjectsButton.UseVisualStyleBackColor = true;
            GetProjectsButton.Click += GetProjects;
            // 
            // EraseProject
            // 
            EraseProject.Location = new Point(16, 51);
            EraseProject.Name = "EraseProject";
            EraseProject.Size = new Size(164, 23);
            EraseProject.TabIndex = 7;
            EraseProject.Text = "Borrar Proyecto";
            EraseProject.UseVisualStyleBackColor = true;
            // 
            // SendPicButton
            // 
            SendPicButton.Location = new Point(12, 41);
            SendPicButton.Name = "SendPicButton";
            SendPicButton.Size = new Size(200, 23);
            SendPicButton.TabIndex = 8;
            SendPicButton.Text = "Mandar Foto";
            SendPicButton.UseVisualStyleBackColor = true;
            // 
            // ErasePicButton
            // 
            ErasePicButton.Location = new Point(16, 51);
            ErasePicButton.Name = "ErasePicButton";
            ErasePicButton.Size = new Size(164, 23);
            ErasePicButton.TabIndex = 9;
            ErasePicButton.Text = "Borrar Foto";
            ErasePicButton.UseVisualStyleBackColor = true;
            // 
            // LockImageButton
            // 
            LockImageButton.Location = new Point(16, 80);
            LockImageButton.Name = "LockImageButton";
            LockImageButton.Size = new Size(164, 23);
            LockImageButton.TabIndex = 10;
            LockImageButton.Text = "Bloquear Imagen";
            LockImageButton.UseVisualStyleBackColor = true;
            // 
            // GetImagesButton
            // 
            GetImagesButton.Location = new Point(12, 70);
            GetImagesButton.Name = "GetImagesButton";
            GetImagesButton.Size = new Size(200, 23);
            GetImagesButton.TabIndex = 11;
            GetImagesButton.Text = "Leer Imagenes";
            GetImagesButton.UseVisualStyleBackColor = true;
            GetImagesButton.Click += GetImages;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ImagesList);
            groupBox1.Controls.Add(ErasePicButton);
            groupBox1.Controls.Add(LockImageButton);
            groupBox1.Location = new Point(12, 99);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 115);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Imagenes";
            // 
            // ImagesList
            // 
            ImagesList.FormattingEnabled = true;
            ImagesList.Location = new Point(16, 22);
            ImagesList.Name = "ImagesList";
            ImagesList.Size = new Size(164, 23);
            ImagesList.TabIndex = 11;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ProjectsList);
            groupBox2.Controls.Add(LoadProjectButton);
            groupBox2.Controls.Add(EraseProject);
            groupBox2.Location = new Point(218, 99);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 115);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            groupBox2.Text = "Proyectos";
            // 
            // ProjectsList
            // 
            ProjectsList.FormattingEnabled = true;
            ProjectsList.Location = new Point(16, 22);
            ProjectsList.Name = "ProjectsList";
            ProjectsList.Size = new Size(164, 23);
            ProjectsList.TabIndex = 11;
            // 
            // LoadProjectButton
            // 
            LoadProjectButton.Location = new Point(16, 80);
            LoadProjectButton.Name = "LoadProjectButton";
            LoadProjectButton.Size = new Size(164, 23);
            LoadProjectButton.TabIndex = 10;
            LoadProjectButton.Text = "Cargar Proyecto";
            LoadProjectButton.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(ClassesList);
            groupBox3.Controls.Add(button1);
            groupBox3.Controls.Add(button2);
            groupBox3.Location = new Point(424, 99);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(200, 115);
            groupBox3.TabIndex = 15;
            groupBox3.TabStop = false;
            groupBox3.Text = "Clases";
            // 
            // ClassesList
            // 
            ClassesList.FormattingEnabled = true;
            ClassesList.Location = new Point(16, 22);
            ClassesList.Name = "ClassesList";
            ClassesList.Size = new Size(164, 23);
            ClassesList.TabIndex = 11;
            // 
            // button1
            // 
            button1.Location = new Point(16, 80);
            button1.Name = "button1";
            button1.Size = new Size(164, 23);
            button1.TabIndex = 10;
            button1.Text = "Añadir Clase";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(16, 51);
            button2.Name = "button2";
            button2.Size = new Size(164, 23);
            button2.TabIndex = 7;
            button2.Text = "Borrar Clase";
            button2.UseVisualStyleBackColor = true;
            // 
            // GetClassesButton
            // 
            GetClassesButton.Location = new Point(424, 70);
            GetClassesButton.Name = "GetClassesButton";
            GetClassesButton.Size = new Size(200, 23);
            GetClassesButton.TabIndex = 14;
            GetClassesButton.Text = "Leer Clases";
            GetClassesButton.UseVisualStyleBackColor = true;
            GetClassesButton.Click += GetClasses;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(VersionsList);
            groupBox4.Controls.Add(EraseVersionButton);
            groupBox4.Controls.Add(AddVersionButton);
            groupBox4.Location = new Point(12, 249);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(200, 115);
            groupBox4.TabIndex = 13;
            groupBox4.TabStop = false;
            groupBox4.Text = "Versiones";
            // 
            // VersionsList
            // 
            VersionsList.FormattingEnabled = true;
            VersionsList.Location = new Point(16, 22);
            VersionsList.Name = "VersionsList";
            VersionsList.Size = new Size(164, 23);
            VersionsList.TabIndex = 11;
            // 
            // EraseVersionButton
            // 
            EraseVersionButton.Location = new Point(16, 51);
            EraseVersionButton.Name = "EraseVersionButton";
            EraseVersionButton.Size = new Size(164, 23);
            EraseVersionButton.TabIndex = 9;
            EraseVersionButton.Text = "Borrar Versión";
            EraseVersionButton.UseVisualStyleBackColor = true;
            // 
            // AddVersionButton
            // 
            AddVersionButton.Location = new Point(16, 80);
            AddVersionButton.Name = "AddVersionButton";
            AddVersionButton.Size = new Size(164, 23);
            AddVersionButton.TabIndex = 10;
            AddVersionButton.Text = "Añadir Versión";
            AddVersionButton.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(TrainLists);
            groupBox5.Controls.Add(EraseModelButton);
            groupBox5.Controls.Add(TrainModelButton);
            groupBox5.Location = new Point(218, 249);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(200, 115);
            groupBox5.TabIndex = 14;
            groupBox5.TabStop = false;
            groupBox5.Text = "Entrenar";
            // 
            // TrainLists
            // 
            TrainLists.FormattingEnabled = true;
            TrainLists.Location = new Point(16, 22);
            TrainLists.Name = "TrainLists";
            TrainLists.Size = new Size(164, 23);
            TrainLists.TabIndex = 11;
            // 
            // EraseModelButton
            // 
            EraseModelButton.Location = new Point(16, 51);
            EraseModelButton.Name = "EraseModelButton";
            EraseModelButton.Size = new Size(164, 23);
            EraseModelButton.TabIndex = 9;
            EraseModelButton.Text = "Borrar Modelo";
            EraseModelButton.UseVisualStyleBackColor = true;
            // 
            // TrainModelButton
            // 
            TrainModelButton.Location = new Point(16, 80);
            TrainModelButton.Name = "TrainModelButton";
            TrainModelButton.Size = new Size(164, 23);
            TrainModelButton.TabIndex = 10;
            TrainModelButton.Text = "Entrenar Modelo";
            TrainModelButton.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(110, 220);
            button3.Name = "button3";
            button3.Size = new Size(200, 23);
            button3.TabIndex = 16;
            button3.Text = "Leer Versiones";
            button3.UseVisualStyleBackColor = true;
            button3.Click += GetVersions;
            // 
            // button4
            // 
            button4.Location = new Point(424, 220);
            button4.Name = "button4";
            button4.Size = new Size(200, 23);
            button4.TabIndex = 17;
            button4.Text = "Leer Clases";
            button4.UseVisualStyleBackColor = true;
            button4.Click += GetClasses;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(RightTopText);
            groupBox6.Controls.Add(LeftBotText);
            groupBox6.Controls.Add(AddAnotationButton);
            groupBox6.Controls.Add(EraseAnotationButton);
            groupBox6.Location = new Point(424, 249);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(200, 115);
            groupBox6.TabIndex = 15;
            groupBox6.TabStop = false;
            groupBox6.Text = "Etiqueta";
            // 
            // RightTopText
            // 
            RightTopText.Location = new Point(105, 22);
            RightTopText.Name = "RightTopText";
            RightTopText.Size = new Size(89, 23);
            RightTopText.TabIndex = 12;
            // 
            // LeftBotText
            // 
            LeftBotText.Location = new Point(6, 22);
            LeftBotText.Name = "LeftBotText";
            LeftBotText.Size = new Size(93, 23);
            LeftBotText.TabIndex = 11;
            // 
            // AddAnotationButton
            // 
            AddAnotationButton.Location = new Point(16, 51);
            AddAnotationButton.Name = "AddAnotationButton";
            AddAnotationButton.Size = new Size(164, 23);
            AddAnotationButton.TabIndex = 9;
            AddAnotationButton.Text = "Añadir Etiqueta";
            AddAnotationButton.UseVisualStyleBackColor = true;
            // 
            // EraseAnotationButton
            // 
            EraseAnotationButton.Location = new Point(16, 80);
            EraseAnotationButton.Name = "EraseAnotationButton";
            EraseAnotationButton.Size = new Size(164, 23);
            EraseAnotationButton.TabIndex = 10;
            EraseAnotationButton.Text = "Borrar Etiqueta";
            EraseAnotationButton.UseVisualStyleBackColor = true;
            // 
            // OpenFileDialog
            // 
            OpenFileDialog.FileName = "OpenFileDialog";
            // 
            // user
            // 
            user.Location = new Point(423, 11);
            user.Name = "user";
            user.PlaceholderText = "Usuario";
            user.Size = new Size(200, 23);
            user.TabIndex = 18;
            user.TextChanged += UsernameChanged;
            // 
            // NetworkDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(635, 374);
            Controls.Add(user);
            Controls.Add(groupBox6);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(GetClassesButton);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(GetImagesButton);
            Controls.Add(SendPicButton);
            Controls.Add(GetProjectsButton);
            Controls.Add(ProjectType);
            Controls.Add(ProjectName);
            Controls.Add(CreateButton);
            Controls.Add(PortNumber);
            Controls.Add(ServerURL);
            Controls.Add(PingButton);
            Name = "NetworkDialog";
            Text = "NetworkDialog";
            ((System.ComponentModel.ISupportInitialize)PortNumber).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button PingButton;
        private TextBox ServerURL;
        private NumericUpDown PortNumber;
        private Button CreateButton;
        private TextBox ProjectName;
        private ComboBox ProjectType;
        private Button GetProjectsButton;
        private Button EraseProject;
        private Button SendPicButton;
        private Button ErasePicButton;
        private Button LockImageButton;
        private Button GetImagesButton;
        private GroupBox groupBox1;
        private ComboBox ImagesList;
        private GroupBox groupBox2;
        private ComboBox ProjectsList;
        private Button LoadProjectButton;
        private GroupBox groupBox3;
        private ComboBox ClassesList;
        private Button button1;
        private Button button2;
        private Button GetClassesButton;
        private GroupBox groupBox4;
        private ComboBox VersionsList;
        private Button EraseVersionButton;
        private Button AddVersionButton;
        private GroupBox groupBox5;
        private ComboBox TrainLists;
        private Button EraseModelButton;
        private Button TrainModelButton;
        private Button button3;
        private Button button4;
        private GroupBox groupBox6;
        private Button AddAnotationButton;
        private Button EraseAnotationButton;
        private TextBox RightTopText;
        private TextBox LeftBotText;
        private OpenFileDialog OpenFileDialog;
        private TextBox user;
    }
}