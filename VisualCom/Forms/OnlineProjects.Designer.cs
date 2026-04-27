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
            ProjectsList = new ListBox();
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
            CreateProject_Button.Font = new Font("Neo Sans Std", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CreateProject_Button.Location = new Point(12, 66);
            CreateProject_Button.Name = "CreateProject_Button";
            CreateProject_Button.Size = new Size(128, 48);
            CreateProject_Button.TabIndex = 2;
            CreateProject_Button.Text = "Crear Proyecto...";
            CreateProject_Button.UseVisualStyleBackColor = false;
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
            ProjectsList.ForeColor = Color.White;
            ProjectsList.FormattingEnabled = true;
            ProjectsList.Location = new Point(152, 66);
            ProjectsList.Name = "ProjectsList";
            ProjectsList.Size = new Size(620, 360);
            ProjectsList.TabIndex = 7;
            ProjectsList.SelectedIndexChanged += ChangedSelectionList;
            // 
            // OnlineProjects
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(63, 62, 62);
            ClientSize = new Size(800, 450);
            Controls.Add(ProjectsList);
            Controls.Add(label2);
            Controls.Add(Disconnect_Button);
            Controls.Add(EraseProject_Button);
            Controls.Add(LoadProject_Button);
            Controls.Add(CreateProject_Button);
            Controls.Add(UserName_Label);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "OnlineProjects";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Proyectos Online";
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
        private ListBox ProjectsList;
    }
}