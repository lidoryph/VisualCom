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
            TrainModOKButton = new Button();
            TrainModCancelButton = new Button();
            TrainProgress = new ProgressBar();
            modelVersion = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            epochBar = new TrackBar();
            helpButton = new Button();
            label3 = new Label();
            rateNumeric = new NumericUpDown();
            rateBar = new TrackBar();
            label4 = new Label();
            imagesBar = new TrackBar();
            imagesNumeric = new NumericUpDown();
            epochNumeric = new NumericUpDown();
            label5 = new Label();
            useDevice = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)epochBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rateNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rateBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imagesBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imagesNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)epochNumeric).BeginInit();
            SuspendLayout();
            // 
            // TrainModOKButton
            // 
            TrainModOKButton.Location = new Point(120, 361);
            TrainModOKButton.Name = "TrainModOKButton";
            TrainModOKButton.Size = new Size(192, 48);
            TrainModOKButton.TabIndex = 0;
            TrainModOKButton.Text = "Aceptar";
            TrainModOKButton.UseVisualStyleBackColor = true;
            TrainModOKButton.Click += TrainModOKButton_Click;
            // 
            // TrainModCancelButton
            // 
            TrainModCancelButton.Location = new Point(120, 415);
            TrainModCancelButton.Name = "TrainModCancelButton";
            TrainModCancelButton.Size = new Size(192, 48);
            TrainModCancelButton.TabIndex = 1;
            TrainModCancelButton.Text = "Cancelar";
            TrainModCancelButton.UseVisualStyleBackColor = true;
            TrainModCancelButton.Click += TrainModCancelButton_Click;
            // 
            // TrainProgress
            // 
            TrainProgress.Enabled = false;
            TrainProgress.Location = new Point(12, 469);
            TrainProgress.Name = "TrainProgress";
            TrainProgress.Size = new Size(407, 47);
            TrainProgress.TabIndex = 2;
            // 
            // modelVersion
            // 
            modelVersion.FormattingEnabled = true;
            modelVersion.Location = new Point(12, 27);
            modelVersion.Name = "modelVersion";
            modelVersion.Size = new Size(407, 23);
            modelVersion.TabIndex = 3;
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
            // epochBar
            // 
            epochBar.Location = new Point(12, 86);
            epochBar.Maximum = 100;
            epochBar.Name = "epochBar";
            epochBar.Size = new Size(362, 45);
            epochBar.TabIndex = 6;
            epochBar.TickFrequency = 10;
            epochBar.Value = 10;
            epochBar.ValueChanged += epochBar_ValueChanged;
            // 
            // helpButton
            // 
            helpButton.Location = new Point(371, 415);
            helpButton.Name = "helpButton";
            helpButton.Size = new Size(48, 48);
            helpButton.TabIndex = 8;
            helpButton.UseVisualStyleBackColor = true;
            helpButton.Click += helpButton_Click;
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
            // rateNumeric
            // 
            rateNumeric.Location = new Point(380, 152);
            rateNumeric.Name = "rateNumeric";
            rateNumeric.Size = new Size(39, 23);
            rateNumeric.TabIndex = 10;
            rateNumeric.Value = new decimal(new int[] { 50, 0, 0, 0 });
            rateNumeric.ValueChanged += rateNumeric_ValueChanged;
            // 
            // rateBar
            // 
            rateBar.Location = new Point(12, 152);
            rateBar.Maximum = 100;
            rateBar.Name = "rateBar";
            rateBar.Size = new Size(362, 45);
            rateBar.TabIndex = 11;
            rateBar.TickFrequency = 10;
            rateBar.Value = 50;
            rateBar.ValueChanged += rateBar_ValueChanged;
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
            // imagesBar
            // 
            imagesBar.Location = new Point(12, 218);
            imagesBar.Maximum = 100;
            imagesBar.Name = "imagesBar";
            imagesBar.Size = new Size(362, 45);
            imagesBar.TabIndex = 13;
            imagesBar.TickFrequency = 10;
            imagesBar.Value = 16;
            imagesBar.ValueChanged += imagesBar_ValueChanged;
            // 
            // imagesNumeric
            // 
            imagesNumeric.Location = new Point(380, 218);
            imagesNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            imagesNumeric.Name = "imagesNumeric";
            imagesNumeric.Size = new Size(39, 23);
            imagesNumeric.TabIndex = 14;
            imagesNumeric.Value = new decimal(new int[] { 16, 0, 0, 0 });
            imagesNumeric.ValueChanged += imagesNumeric_ValueChanged;
            // 
            // epochNumeric
            // 
            epochNumeric.Location = new Point(380, 86);
            epochNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            epochNumeric.Name = "epochNumeric";
            epochNumeric.Size = new Size(39, 23);
            epochNumeric.TabIndex = 15;
            epochNumeric.Value = new decimal(new int[] { 10, 0, 0, 0 });
            epochNumeric.ValueChanged += epochNumeric_ValueChanged;
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
            // useDevice
            // 
            useDevice.FormattingEnabled = true;
            useDevice.Location = new Point(12, 284);
            useDevice.Name = "useDevice";
            useDevice.Size = new Size(407, 23);
            useDevice.TabIndex = 17;
            // 
            // TrainModel
            // 
            AcceptButton = TrainModOKButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = TrainModCancelButton;
            ClientSize = new Size(431, 528);
            Controls.Add(useDevice);
            Controls.Add(label5);
            Controls.Add(epochNumeric);
            Controls.Add(imagesNumeric);
            Controls.Add(imagesBar);
            Controls.Add(label4);
            Controls.Add(rateBar);
            Controls.Add(rateNumeric);
            Controls.Add(label3);
            Controls.Add(helpButton);
            Controls.Add(epochBar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(modelVersion);
            Controls.Add(TrainProgress);
            Controls.Add(TrainModCancelButton);
            Controls.Add(TrainModOKButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TrainModel";
            ShowInTaskbar = false;
            Text = "Entrenar un modelo...";
            ((System.ComponentModel.ISupportInitialize)epochBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)rateNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)rateBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)imagesBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)imagesNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)epochNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button TrainModOKButton;
        private Button TrainModCancelButton;
        private ProgressBar TrainProgress;
        private ComboBox modelVersion;
        private Label label1;
        private Label label2;
        private TrackBar epochBar;
        private Button helpButton;
        private Label label3;
        private NumericUpDown rateNumeric;
        private TrackBar rateBar;
        private Label label4;
        private TrackBar imagesBar;
        private NumericUpDown imagesNumeric;
        private NumericUpDown epochNumeric;
        private Label label5;
        private ComboBox useDevice;
    }
}