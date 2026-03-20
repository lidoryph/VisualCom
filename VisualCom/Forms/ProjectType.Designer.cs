namespace VisualCom.Forms
{
    partial class ProjectType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectType));
            OIbutton = new Button();
            Cbutton = new Button();
            Label = new Label();
            SuspendLayout();
            // 
            // OIbutton
            // 
            OIbutton.ForeColor = SystemColors.ControlText;
            OIbutton.Image = Properties.Resources.magnifier;
            OIbutton.ImageAlign = ContentAlignment.MiddleLeft;
            OIbutton.Location = new Point(32, 80);
            OIbutton.Margin = new Padding(3, 2, 3, 2);
            OIbutton.Name = "OIbutton";
            OIbutton.Padding = new Padding(10, 0, 0, 0);
            OIbutton.Size = new Size(192, 48);
            OIbutton.TabIndex = 0;
            OIbutton.Text = "Identificación de Objetos";
            OIbutton.UseVisualStyleBackColor = true;
            OIbutton.Click += OIbutton_Click;
            // 
            // Cbutton
            // 
            Cbutton.ForeColor = SystemColors.ControlText;
            Cbutton.Image = Properties.Resources.tag;
            Cbutton.ImageAlign = ContentAlignment.MiddleLeft;
            Cbutton.Location = new Point(274, 80);
            Cbutton.Margin = new Padding(3, 2, 3, 2);
            Cbutton.Name = "Cbutton";
            Cbutton.Padding = new Padding(10, 0, 0, 0);
            Cbutton.Size = new Size(192, 48);
            Cbutton.TabIndex = 1;
            Cbutton.Text = "Clasificación";
            Cbutton.UseVisualStyleBackColor = true;
            Cbutton.Click += Cbutton_Click;
            // 
            // Label
            // 
            Label.AutoSize = true;
            Label.ForeColor = SystemColors.ControlText;
            Label.Location = new Point(145, 24);
            Label.Name = "Label";
            Label.Size = new Size(199, 15);
            Label.TabIndex = 2;
            Label.Text = "¿Que tipo de proyecto quieres crear?";
            // 
            // ProjectType
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(496, 153);
            Controls.Add(Label);
            Controls.Add(Cbutton);
            Controls.Add(OIbutton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MaximumSize = new Size(512, 192);
            MinimizeBox = false;
            MinimumSize = new Size(512, 192);
            Name = "ProjectType";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Seleccione el tipo de proyecto:";
            FormClosing += ProjectType_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button OIbutton;
        private Button Cbutton;
        private Label Label;
    }
}