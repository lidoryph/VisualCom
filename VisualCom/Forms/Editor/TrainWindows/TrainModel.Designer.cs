namespace VisualCom.Forms.Editor
{
    partial class TrainModel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrainModel));
            TrainModelButton = new Button();
            CancelButton = new Button();
            TrainProgress = new ProgressBar();
            VersionSelector = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            EpochBar = new TrackBar();
            HelpButton = new Button();
            label3 = new Label();
            RateNumeric = new NumericUpDown();
            RateBar = new TrackBar();
            label4 = new Label();
            ImagesBar = new TrackBar();
            ImagesNumeric = new NumericUpDown();
            EpochNumeric = new NumericUpDown();
            label5 = new Label();
            DeviceSelector = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)EpochBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RateNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RateBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ImagesBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ImagesNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EpochNumeric).BeginInit();
            SuspendLayout();
            // 
            // TrainModelButton
            // 
            TrainModelButton.Image = Properties.Resources.train_model;
            TrainModelButton.ImageAlign = ContentAlignment.MiddleLeft;
            TrainModelButton.Location = new Point(120, 361);
            TrainModelButton.Name = "TrainModelButton";
            TrainModelButton.Padding = new Padding(10, 0, 0, 0);
            TrainModelButton.Size = new Size(192, 48);
            TrainModelButton.TabIndex = 0;
            TrainModelButton.Text = "Aceptar";
            TrainModelButton.UseVisualStyleBackColor = true;
            TrainModelButton.Click += InitTrainModel;
            // 
            // CancelButton
            // 
            CancelButton.Image = Properties.Resources.go_back;
            CancelButton.ImageAlign = ContentAlignment.MiddleLeft;
            CancelButton.Location = new Point(120, 415);
            CancelButton.Name = "CancelButton";
            CancelButton.Padding = new Padding(10, 0, 0, 0);
            CancelButton.Size = new Size(192, 48);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "Cancelar";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += TrainModCancelButton_Click;
            // 
            // TrainProgress
            // 
            TrainProgress.Enabled = false;
            TrainProgress.Location = new Point(12, 469);
            TrainProgress.Name = "TrainProgress";
            TrainProgress.Size = new Size(407, 47);
            TrainProgress.TabIndex = 2;
            // 
            // VersionSelector
            // 
            VersionSelector.FormattingEnabled = true;
            VersionSelector.Location = new Point(12, 27);
            VersionSelector.Name = "VersionSelector";
            VersionSelector.Size = new Size(407, 23);
            VersionSelector.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(127, 15);
            label1.TabIndex = 4;
            label1.Text = "Seleccione una version";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 68);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 5;
            label2.Text = "Ciclos";
            // 
            // EpochBar
            // 
            EpochBar.Location = new Point(12, 86);
            EpochBar.Maximum = 100;
            EpochBar.Name = "EpochBar";
            EpochBar.Size = new Size(362, 45);
            EpochBar.TabIndex = 6;
            EpochBar.TickFrequency = 10;
            EpochBar.Value = 10;
            EpochBar.ValueChanged += EpochBar_ValueChanged;
            // 
            // HelpButton
            // 
            HelpButton.Location = new Point(371, 415);
            HelpButton.Name = "HelpButton";
            HelpButton.Size = new Size(48, 48);
            HelpButton.TabIndex = 8;
            HelpButton.UseVisualStyleBackColor = true;
            HelpButton.Click += ShowHelpDlg;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 134);
            label3.Name = "label3";
            label3.Size = new Size(146, 15);
            label3.TabIndex = 9;
            label3.Text = "Corrección de Aprendizaje";
            // 
            // RateNumeric
            // 
            RateNumeric.Location = new Point(380, 152);
            RateNumeric.Name = "RateNumeric";
            RateNumeric.Size = new Size(39, 23);
            RateNumeric.TabIndex = 10;
            RateNumeric.Value = new decimal(new int[] { 50, 0, 0, 0 });
            RateNumeric.ValueChanged += RateNumeric_ValueChanged;
            // 
            // RateBar
            // 
            RateBar.Location = new Point(12, 152);
            RateBar.Maximum = 100;
            RateBar.Name = "RateBar";
            RateBar.Size = new Size(362, 45);
            RateBar.TabIndex = 11;
            RateBar.TickFrequency = 10;
            RateBar.Value = 50;
            RateBar.ValueChanged += RateBar_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 200);
            label4.Name = "label4";
            label4.Size = new Size(111, 15);
            label4.TabIndex = 12;
            label4.Text = "Imagenes a mostrar";
            // 
            // ImagesBar
            // 
            ImagesBar.Location = new Point(12, 218);
            ImagesBar.Maximum = 100;
            ImagesBar.Name = "ImagesBar";
            ImagesBar.Size = new Size(362, 45);
            ImagesBar.TabIndex = 13;
            ImagesBar.TickFrequency = 10;
            ImagesBar.Value = 16;
            ImagesBar.ValueChanged += ImagesBar_ValueChanged;
            // 
            // ImagesNumeric
            // 
            ImagesNumeric.Location = new Point(380, 218);
            ImagesNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ImagesNumeric.Name = "ImagesNumeric";
            ImagesNumeric.Size = new Size(39, 23);
            ImagesNumeric.TabIndex = 14;
            ImagesNumeric.Value = new decimal(new int[] { 16, 0, 0, 0 });
            ImagesNumeric.ValueChanged += ImagesNumeric_ValueChanged;
            // 
            // EpochNumeric
            // 
            EpochNumeric.Location = new Point(380, 86);
            EpochNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            EpochNumeric.Name = "EpochNumeric";
            EpochNumeric.Size = new Size(39, 23);
            EpochNumeric.TabIndex = 15;
            EpochNumeric.Value = new decimal(new int[] { 10, 0, 0, 0 });
            EpochNumeric.ValueChanged += EpochNumeric_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 266);
            label5.Name = "label5";
            label5.Size = new Size(99, 15);
            label5.TabIndex = 16;
            label5.Text = "Dispositivo a usar";
            // 
            // DeviceSelector
            // 
            DeviceSelector.FormattingEnabled = true;
            DeviceSelector.Location = new Point(12, 284);
            DeviceSelector.Name = "DeviceSelector";
            DeviceSelector.Size = new Size(407, 23);
            DeviceSelector.TabIndex = 17;
            // 
            // TrainModel
            // 
            AcceptButton = TrainModelButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 528);
            Controls.Add(DeviceSelector);
            Controls.Add(label5);
            Controls.Add(EpochNumeric);
            Controls.Add(ImagesNumeric);
            Controls.Add(ImagesBar);
            Controls.Add(label4);
            Controls.Add(RateBar);
            Controls.Add(RateNumeric);
            Controls.Add(label3);
            Controls.Add(HelpButton);
            Controls.Add(EpochBar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(VersionSelector);
            Controls.Add(TrainProgress);
            Controls.Add(CancelButton);
            Controls.Add(TrainModelButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TrainModel";
            ShowInTaskbar = false;
            Text = "Entrenar un modelo...";
            ((System.ComponentModel.ISupportInitialize)EpochBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)RateNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)RateBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)ImagesBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)ImagesNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)EpochNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button TrainModelButton;
        private Button CancelButton;
        private ProgressBar TrainProgress;
        private ComboBox VersionSelector;
        private Label label1;
        private Label label2;
        private TrackBar EpochBar;
        private Button HelpButton;
        private Label label3;
        private NumericUpDown RateNumeric;
        private TrackBar RateBar;
        private Label label4;
        private TrackBar ImagesBar;
        private NumericUpDown ImagesNumeric;
        private NumericUpDown EpochNumeric;
        private Label label5;
        private ComboBox DeviceSelector;
    }
}