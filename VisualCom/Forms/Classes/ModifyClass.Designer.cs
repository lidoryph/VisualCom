namespace VisualCom.Forms.Editor.Classes
{
    partial class ModifyClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifyClass));
            OpenClassSelector = new Button();
            ClassRenamer = new TextBox();
            label1 = new Label();
            CancelButton = new Button();
            ModifyClassButton = new Button();
            colorDialog = new ColorDialog();
            SuspendLayout();
            // 
            // OpenClassSelector
            // 
            OpenClassSelector.BackColor = Color.White;
            OpenClassSelector.ForeColor = Color.Black;
            OpenClassSelector.Image = Properties.Resources.color;
            OpenClassSelector.ImageAlign = ContentAlignment.MiddleLeft;
            OpenClassSelector.Location = new Point(56, 88);
            OpenClassSelector.Name = "OpenClassSelector";
            OpenClassSelector.Padding = new Padding(10, 0, 0, 0);
            OpenClassSelector.Size = new Size(384, 24);
            OpenClassSelector.TabIndex = 9;
            OpenClassSelector.Text = "Seleccione un Color";
            OpenClassSelector.UseVisualStyleBackColor = false;
            OpenClassSelector.Click += SelectColor;
            // 
            // ClassRenamer
            // 
            ClassRenamer.Location = new Point(56, 59);
            ClassRenamer.MaxLength = 32;
            ClassRenamer.Name = "ClassRenamer";
            ClassRenamer.Size = new Size(384, 23);
            ClassRenamer.TabIndex = 8;
            ClassRenamer.TextAlign = HorizontalAlignment.Center;
            ClassRenamer.TextChanged += SetClassName;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(151, 29);
            label1.Name = "label1";
            label1.Size = new Size(194, 15);
            label1.TabIndex = 7;
            label1.Text = "Escribe el nuevo nombre de la clase";
            // 
            // CancelButton
            // 
            CancelButton.Image = Properties.Resources.go_back;
            CancelButton.ImageAlign = ContentAlignment.MiddleLeft;
            CancelButton.Location = new Point(280, 139);
            CancelButton.Name = "CancelButton";
            CancelButton.Padding = new Padding(10, 0, 0, 0);
            CancelButton.Size = new Size(160, 48);
            CancelButton.TabIndex = 6;
            CancelButton.Text = "Cancelar";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CloseDialog;
            // 
            // ModifyClassButton
            // 
            ModifyClassButton.Image = Properties.Resources.add_class;
            ModifyClassButton.ImageAlign = ContentAlignment.MiddleLeft;
            ModifyClassButton.Location = new Point(56, 139);
            ModifyClassButton.Name = "ModifyClassButton";
            ModifyClassButton.Padding = new Padding(10, 0, 0, 0);
            ModifyClassButton.Size = new Size(160, 48);
            ModifyClassButton.TabIndex = 5;
            ModifyClassButton.Text = "Modificar Clase";
            ModifyClassButton.UseVisualStyleBackColor = true;
            ModifyClassButton.Click += Modify;
            // 
            // ModifyClass
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 217);
            Controls.Add(OpenClassSelector);
            Controls.Add(ClassRenamer);
            Controls.Add(label1);
            Controls.Add(CancelButton);
            Controls.Add(ModifyClassButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ModifyClass";
            Text = "Modificar clase";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button OpenClassSelector;
        private TextBox ClassRenamer;
        private Label label1;
        private Button CancelButton;
        private Button ModifyClassButton;
        private ColorDialog colorDialog;
    }
}