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
            openClassColor = new Button();
            boxClassName = new TextBox();
            label1 = new Label();
            returnButton = new Button();
            modifyClassButton = new Button();
            colorDialog = new ColorDialog();
            SuspendLayout();
            // 
            // openClassColor
            // 
            openClassColor.BackColor = Color.White;
            openClassColor.ForeColor = Color.Black;
            openClassColor.Image = Properties.Resources.color;
            openClassColor.ImageAlign = ContentAlignment.MiddleLeft;
            openClassColor.Location = new Point(56, 88);
            openClassColor.Name = "openClassColor";
            openClassColor.Padding = new Padding(10, 0, 0, 0);
            openClassColor.Size = new Size(384, 24);
            openClassColor.TabIndex = 9;
            openClassColor.Text = "Seleccione un Color";
            openClassColor.UseVisualStyleBackColor = false;
            openClassColor.Click += SelectColor;
            // 
            // boxClassName
            // 
            boxClassName.Location = new Point(56, 59);
            boxClassName.MaxLength = 32;
            boxClassName.Name = "boxClassName";
            boxClassName.Size = new Size(384, 23);
            boxClassName.TabIndex = 8;
            boxClassName.TextAlign = HorizontalAlignment.Center;
            boxClassName.TextChanged += SetClassName;
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
            // returnButton
            // 
            returnButton.Image = Properties.Resources.go_back;
            returnButton.ImageAlign = ContentAlignment.MiddleLeft;
            returnButton.Location = new Point(280, 139);
            returnButton.Name = "returnButton";
            returnButton.Padding = new Padding(10, 0, 0, 0);
            returnButton.Size = new Size(160, 48);
            returnButton.TabIndex = 6;
            returnButton.Text = "Cancelar";
            returnButton.UseVisualStyleBackColor = true;
            returnButton.Click += CloseDialog;
            // 
            // modifyClassButton
            // 
            modifyClassButton.Image = Properties.Resources.add_class;
            modifyClassButton.ImageAlign = ContentAlignment.MiddleLeft;
            modifyClassButton.Location = new Point(56, 139);
            modifyClassButton.Name = "modifyClassButton";
            modifyClassButton.Padding = new Padding(10, 0, 0, 0);
            modifyClassButton.Size = new Size(160, 48);
            modifyClassButton.TabIndex = 5;
            modifyClassButton.Text = "Modificar Clase";
            modifyClassButton.UseVisualStyleBackColor = true;
            modifyClassButton.Click += Modify;
            // 
            // ModifyClass
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 217);
            Controls.Add(openClassColor);
            Controls.Add(boxClassName);
            Controls.Add(label1);
            Controls.Add(returnButton);
            Controls.Add(modifyClassButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ModifyClass";
            Text = "Modificar clase";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button openClassColor;
        private TextBox boxClassName;
        private Label label1;
        private Button returnButton;
        private Button modifyClassButton;
        private ColorDialog colorDialog;
    }
}