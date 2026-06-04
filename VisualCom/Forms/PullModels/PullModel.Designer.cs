namespace VisualCom.Forms.Editor.PullModels
{
    partial class PullModel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PullModel));
            ListModelButton = new RadioButton();
            InternetModelButton = new RadioButton();
            label1 = new Label();
            ModelsList = new ComboBox();
            InternetModelURL = new TextBox();
            PullModelButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // ListModelButton
            // 
            ListModelButton.AutoSize = true;
            ListModelButton.Checked = true;
            ListModelButton.Location = new Point(12, 40);
            ListModelButton.Name = "ListModelButton";
            ListModelButton.Size = new Size(159, 19);
            ListModelButton.TabIndex = 0;
            ListModelButton.TabStop = true;
            ListModelButton.Text = "Añadir modelo de la lista:";
            ListModelButton.UseVisualStyleBackColor = true;
            ListModelButton.CheckedChanged += ListModel;
            // 
            // InternetModelButton
            // 
            InternetModelButton.AutoSize = true;
            InternetModelButton.Location = new Point(12, 68);
            InternetModelButton.Name = "InternetModelButton";
            InternetModelButton.Size = new Size(167, 19);
            InternetModelButton.TabIndex = 1;
            InternetModelButton.Text = "Añadir modelo de internet:";
            InternetModelButton.UseVisualStyleBackColor = true;
            InternetModelButton.CheckedChanged += InternetModel;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(104, 9);
            label1.Name = "label1";
            label1.Size = new Size(254, 15);
            label1.TabIndex = 3;
            label1.Text = "Selecciona una opción para extraer un modelo:";
            // 
            // ModelsList
            // 
            ModelsList.FormattingEnabled = true;
            ModelsList.Location = new Point(202, 39);
            ModelsList.Name = "ModelsList";
            ModelsList.Size = new Size(238, 23);
            ModelsList.TabIndex = 4;
            ModelsList.Text = "Selecciona un Modelo...";
            // 
            // InternetModelURL
            // 
            InternetModelURL.Enabled = false;
            InternetModelURL.Location = new Point(202, 68);
            InternetModelURL.Name = "InternetModelURL";
            InternetModelURL.PlaceholderText = "https://www.website.com";
            InternetModelURL.ReadOnly = true;
            InternetModelURL.Size = new Size(238, 23);
            InternetModelURL.TabIndex = 5;
            // 
            // PullModelButton
            // 
            PullModelButton.Image = Properties.Resources.globe_network;
            PullModelButton.ImageAlign = ContentAlignment.MiddleLeft;
            PullModelButton.Location = new Point(68, 103);
            PullModelButton.Name = "PullModelButton";
            PullModelButton.Padding = new Padding(10, 0, 0, 0);
            PullModelButton.Size = new Size(128, 47);
            PullModelButton.TabIndex = 7;
            PullModelButton.Text = "Añadir";
            PullModelButton.UseVisualStyleBackColor = true;
            PullModelButton.Click += GetListModel;
            // 
            // CancelButton
            // 
            CancelButton.Image = Properties.Resources.go_back;
            CancelButton.ImageAlign = ContentAlignment.MiddleLeft;
            CancelButton.Location = new Point(266, 103);
            CancelButton.Name = "CancelButton";
            CancelButton.Padding = new Padding(10, 0, 0, 0);
            CancelButton.Size = new Size(128, 47);
            CancelButton.TabIndex = 8;
            CancelButton.Text = "Cancelar";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += GoBack;
            // 
            // PullModel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 162);
            Controls.Add(CancelButton);
            Controls.Add(PullModelButton);
            Controls.Add(InternetModelURL);
            Controls.Add(ModelsList);
            Controls.Add(label1);
            Controls.Add(InternetModelButton);
            Controls.Add(ListModelButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PullModel";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Extraer un modelo de internet";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton ListModelButton;
        private RadioButton InternetModelButton;
        private Label label1;
        private ComboBox ModelsList;
        private TextBox InternetModelURL;
        private Button PullModelButton;
        private Button CancelButton;
    }
}