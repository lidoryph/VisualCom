namespace VisualCom.Forms
{
    partial class CreateOnlineProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateOnlineProject));
            label1 = new Label();
            ProjectName_TextBox = new TextBox();
            label2 = new Label();
            Cancel_Button = new Button();
            Create_Button = new Button();
            OI_Radio = new RadioButton();
            C_Radio = new RadioButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Neo Sans Std", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(62, 9);
            label1.Name = "label1";
            label1.Size = new Size(230, 19);
            label1.TabIndex = 0;
            label1.Text = "Escriba el nombre del proyecto:";
            // 
            // ProjectName_TextBox
            // 
            ProjectName_TextBox.BackColor = Color.FromArgb(33, 32, 32);
            ProjectName_TextBox.BorderStyle = BorderStyle.None;
            ProjectName_TextBox.ForeColor = Color.White;
            ProjectName_TextBox.Location = new Point(12, 45);
            ProjectName_TextBox.MaximumSize = new Size(99999999, 99999999);
            ProjectName_TextBox.Name = "ProjectName_TextBox";
            ProjectName_TextBox.PlaceholderText = "Nombre del Proyecto";
            ProjectName_TextBox.Size = new Size(351, 16);
            ProjectName_TextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Neo Sans Std", 11.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(73, 79);
            label2.Name = "label2";
            label2.Size = new Size(231, 19);
            label2.TabIndex = 2;
            label2.Text = "Seleccione el tipo del Proyecto:";
            // 
            // Cancel_Button
            // 
            Cancel_Button.BackColor = Color.FromArgb(214, 10, 81);
            Cancel_Button.Cursor = Cursors.Hand;
            Cancel_Button.FlatAppearance.BorderSize = 0;
            Cancel_Button.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 192);
            Cancel_Button.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 39, 131);
            Cancel_Button.FlatStyle = FlatStyle.Flat;
            Cancel_Button.Font = new Font("Neo Sans Std", 9F);
            Cancel_Button.Location = new Point(250, 152);
            Cancel_Button.Name = "Cancel_Button";
            Cancel_Button.Size = new Size(128, 48);
            Cancel_Button.TabIndex = 4;
            Cancel_Button.Text = "Cancelar";
            Cancel_Button.UseVisualStyleBackColor = false;
            // 
            // Create_Button
            // 
            Create_Button.BackColor = Color.FromArgb(214, 10, 81);
            Create_Button.Cursor = Cursors.Hand;
            Create_Button.FlatAppearance.BorderSize = 0;
            Create_Button.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 192);
            Create_Button.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 39, 131);
            Create_Button.FlatStyle = FlatStyle.Flat;
            Create_Button.Font = new Font("Neo Sans Std", 9F);
            Create_Button.Location = new Point(12, 152);
            Create_Button.Name = "Create_Button";
            Create_Button.Size = new Size(128, 48);
            Create_Button.TabIndex = 5;
            Create_Button.Text = "Crear Proyecto";
            Create_Button.UseVisualStyleBackColor = false;
            Create_Button.Click += CreateProjectAsync;
            // 
            // OI_Radio
            // 
            OI_Radio.AutoSize = true;
            OI_Radio.Font = new Font("Neo Sans Std", 11.9999981F, FontStyle.Bold);
            OI_Radio.ForeColor = Color.White;
            OI_Radio.Location = new Point(12, 110);
            OI_Radio.Name = "OI_Radio";
            OI_Radio.Size = new Size(219, 24);
            OI_Radio.TabIndex = 6;
            OI_Radio.TabStop = true;
            OI_Radio.Text = "Identificación de Objetos";
            OI_Radio.UseVisualStyleBackColor = true;
            // 
            // C_Radio
            // 
            C_Radio.AutoSize = true;
            C_Radio.Font = new Font("Neo Sans Std", 11.9999981F, FontStyle.Bold);
            C_Radio.ForeColor = Color.White;
            C_Radio.Location = new Point(250, 110);
            C_Radio.Name = "C_Radio";
            C_Radio.Size = new Size(123, 24);
            C_Radio.TabIndex = 7;
            C_Radio.TabStop = true;
            C_Radio.Text = "Clasificación";
            C_Radio.UseVisualStyleBackColor = true;
            // 
            // CreateOnlineProject
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(63, 62, 62);
            ClientSize = new Size(393, 217);
            ControlBox = false;
            Controls.Add(C_Radio);
            Controls.Add(OI_Radio);
            Controls.Add(Create_Button);
            Controls.Add(Cancel_Button);
            Controls.Add(label2);
            Controls.Add(ProjectName_TextBox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(409, 256);
            MinimizeBox = false;
            MinimumSize = new Size(409, 256);
            Name = "CreateOnlineProject";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Crear Proyecto";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox ProjectName_TextBox;
        private Label label2;
        private Button Cancel_Button;
        private Button Create_Button;
        private RadioButton OI_Radio;
        private RadioButton C_Radio;
    }
}