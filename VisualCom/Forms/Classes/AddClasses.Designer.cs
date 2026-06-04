namespace VisualCom.Forms.Editor.Classes
{
    partial class AddClasses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddClasses));
            AddClassButton = new Button();
            CancelButton = new Button();
            label1 = new Label();
            ClassNamer = new TextBox();
            ColorDialog = new ColorDialog();
            OpenColorSelector = new Button();
            SuspendLayout();
            // 
            // AddClassButton
            // 
            AddClassButton.Image = Properties.Resources.add_class;
            AddClassButton.ImageAlign = ContentAlignment.MiddleLeft;
            AddClassButton.Location = new Point(56, 139);
            AddClassButton.Name = "AddClassButton";
            AddClassButton.Padding = new Padding(10, 0, 0, 0);
            AddClassButton.Size = new Size(160, 48);
            AddClassButton.TabIndex = 0;
            AddClassButton.Text = "Añadir Clase";
            AddClassButton.UseVisualStyleBackColor = true;
            AddClassButton.Click += AddClassToFile;
            // 
            // CancelButton
            // 
            CancelButton.Image = Properties.Resources.go_back;
            CancelButton.ImageAlign = ContentAlignment.MiddleLeft;
            CancelButton.Location = new Point(280, 139);
            CancelButton.Name = "CancelButton";
            CancelButton.Padding = new Padding(10, 0, 0, 0);
            CancelButton.Size = new Size(160, 48);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "Cancelar";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CloseDialog;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(170, 29);
            label1.Name = "label1";
            label1.Size = new Size(158, 15);
            label1.TabIndex = 2;
            label1.Text = "Escribe el nombre de la clase";
            // 
            // ClassNamer
            // 
            ClassNamer.Location = new Point(56, 59);
            ClassNamer.MaxLength = 32;
            ClassNamer.Name = "ClassNamer";
            ClassNamer.Size = new Size(384, 23);
            ClassNamer.TabIndex = 3;
            ClassNamer.TextAlign = HorizontalAlignment.Center;
            ClassNamer.TextChanged += SetClassName;
            // 
            // ColorDialog
            // 
            ColorDialog.AnyColor = true;
            // 
            // OpenColorSelector
            // 
            OpenColorSelector.BackColor = Color.White;
            OpenColorSelector.ForeColor = Color.Black;
            OpenColorSelector.Image = Properties.Resources.color;
            OpenColorSelector.ImageAlign = ContentAlignment.MiddleLeft;
            OpenColorSelector.Location = new Point(56, 88);
            OpenColorSelector.Name = "OpenColorSelector";
            OpenColorSelector.Padding = new Padding(10, 0, 0, 0);
            OpenColorSelector.Size = new Size(384, 24);
            OpenColorSelector.TabIndex = 4;
            OpenColorSelector.Text = "Seleccione un Color";
            OpenColorSelector.UseVisualStyleBackColor = false;
            OpenColorSelector.Click += SelectColor;
            // 
            // AddClasses
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 217);
            Controls.Add(OpenColorSelector);
            Controls.Add(ClassNamer);
            Controls.Add(label1);
            Controls.Add(CancelButton);
            Controls.Add(AddClassButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddClasses";
            ShowInTaskbar = false;
            Text = "Añadir una Clase";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddClassButton;
        private Button CancelButton;
        private Label label1;
        private TextBox ClassNamer;
        private ColorDialog ColorDialog;
        private Button OpenColorSelector;
    }
}