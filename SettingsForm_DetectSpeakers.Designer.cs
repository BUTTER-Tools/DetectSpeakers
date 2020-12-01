namespace DetectSpeakers
{
    partial class SettingsForm_DetectSpeakers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm_DetectSpeakers));
            this.OKButton = new System.Windows.Forms.Button();
            this.SpeakerDelimiterTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RegexTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MaxSpeakerLenUpDown = new System.Windows.Forms.NumericUpDown();
            this.UniqueTagsCheckbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSpeakerLenUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(160, 210);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(118, 40);
            this.OKButton.TabIndex = 6;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // SpeakerDelimiterTextBox
            // 
            this.SpeakerDelimiterTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpeakerDelimiterTextBox.Location = new System.Drawing.Point(197, 26);
            this.SpeakerDelimiterTextBox.MaxLength = 999999999;
            this.SpeakerDelimiterTextBox.Name = "SpeakerDelimiterTextBox";
            this.SpeakerDelimiterTextBox.Size = new System.Drawing.Size(227, 22);
            this.SpeakerDelimiterTextBox.TabIndex = 23;
            this.SpeakerDelimiterTextBox.TextChanged += new System.EventHandler(this.RegexTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Speaker Tag Delimiter:";
            // 
            // RegexTextBox
            // 
            this.RegexTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegexTextBox.Location = new System.Drawing.Point(142, 110);
            this.RegexTextBox.MaxLength = 999999999;
            this.RegexTextBox.Name = "RegexTextBox";
            this.RegexTextBox.Size = new System.Drawing.Size(282, 22);
            this.RegexTextBox.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "RegEx Removal:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "Max Speaker Tag Length:";
            // 
            // MaxSpeakerLenUpDown
            // 
            this.MaxSpeakerLenUpDown.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxSpeakerLenUpDown.Location = new System.Drawing.Point(197, 69);
            this.MaxSpeakerLenUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.MaxSpeakerLenUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxSpeakerLenUpDown.Name = "MaxSpeakerLenUpDown";
            this.MaxSpeakerLenUpDown.Size = new System.Drawing.Size(227, 23);
            this.MaxSpeakerLenUpDown.TabIndex = 27;
            this.MaxSpeakerLenUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MaxSpeakerLenUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // UniqueTagsCheckbox
            // 
            this.UniqueTagsCheckbox.AutoSize = true;
            this.UniqueTagsCheckbox.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UniqueTagsCheckbox.Location = new System.Drawing.Point(15, 155);
            this.UniqueTagsCheckbox.Name = "UniqueTagsCheckbox";
            this.UniqueTagsCheckbox.Size = new System.Drawing.Size(251, 20);
            this.UniqueTagsCheckbox.TabIndex = 28;
            this.UniqueTagsCheckbox.Text = "Output Only Unique Speaker Tags";
            this.UniqueTagsCheckbox.UseVisualStyleBackColor = true;
            // 
            // SettingsForm_DetectSpeakers
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 262);
            this.Controls.Add(this.UniqueTagsCheckbox);
            this.Controls.Add(this.MaxSpeakerLenUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RegexTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SpeakerDelimiterTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OKButton);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm_DetectSpeakers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plugin Name";
            ((System.ComponentModel.ISupportInitialize)(this.MaxSpeakerLenUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.TextBox SpeakerDelimiterTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox RegexTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown MaxSpeakerLenUpDown;
        private System.Windows.Forms.CheckBox UniqueTagsCheckbox;
    }
}