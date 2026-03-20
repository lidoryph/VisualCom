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
            addClassButton = new Button();
            returnButton = new Button();
            label1 = new Label();
            boxClassName = new TextBox();
            colorDialog = new ColorDialog();
            openClassColor = new Button();
            SuspendLayout();
            // 
            // addClassButton
            // 
            addClassButton.Image = Properties.Resources.add_class;
            addClassButton.ImageAlign = ContentAlignment.MiddleLeft;
            addClassButton.Location = new Point(52, 143);
            addClassButton.Name = "addClassButton";
            addClassButton.Padding = new Padding(10, 0, 0, 0);
            addClassButton.Size = new Size(128, 48);
            addClassButton.TabIndex = 0;
            addClassButton.Text = "Añadir Clase";
            addClassButton.UseVisualStyleBackColor = true;
            addClassButton.Click += AddClassToFile;
            // 
            // returnButton
            // 
            returnButton.Image = Properties.Resources.go_back;
            returnButton.ImageAlign = ContentAlignment.MiddleLeft;
            returnButton.Location = new Point(301, 143);
            returnButton.Name = "returnButton";
            returnButton.Padding = new Padding(10, 0, 0, 0);
            returnButton.Size = new Size(128, 48);
            returnButton.TabIndex = 1;
            returnButton.Text = "Cancelar";
            returnButton.UseVisualStyleBackColor = true;
            returnButton.Click += CloseDialog;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(166, 33);
            label1.Name = "label1";
            label1.Size = new Size(158, 15);
            label1.TabIndex = 2;
            label1.Text = "Escribe el nombre de la clase";
            // 
            // boxClassName
            // 
            boxClassName.Location = new Point(52, 63);
            boxClassName.MaxLength = 32;
            boxClassName.Name = "boxClassName";
            boxClassName.Size = new Size(384, 23);
            boxClassName.TabIndex = 3;
            boxClassName.TextAlign = HorizontalAlignment.Center;
            boxClassName.TextChanged += SetClassName;
            // 
            // colorDialog
            // 
            colorDialog.AnyColor = true;
            // 
            // openClassColor
            // 
            openClassColor.BackColor = Color.White;
            openClassColor.ForeColor = Color.Black;
            openClassColor.Image = Properties.Resources.color;
            openClassColor.ImageAlign = ContentAlignment.MiddleLeft;
            openClassColor.Location = new Point(52, 92);
            openClassColor.Name = "openClassColor";
            openClassColor.Padding = new Padding(10, 0, 0, 0);
            openClassColor.Size = new Size(384, 24);
            openClassColor.TabIndex = 4;
            openClassColor.Text = "Seleccione un Color";
            openClassColor.UseVisualStyleBackColor = false;
            openClassColor.Click += SelectColor;
            // 
            // AddClasses
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 217);
            Controls.Add(openClassColor);
            Controls.Add(boxClassName);
            Controls.Add(label1);
            Controls.Add(returnButton);
            Controls.Add(addClassButton);
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

        private Button addClassButton;
        private Button returnButton;
        private Label label1;
        private TextBox boxClassName;
        private ColorDialog colorDialog;
        private Button openClassColor;
    }
}