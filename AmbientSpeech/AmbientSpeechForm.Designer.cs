namespace AmbientSpeech
{
    partial class AmbientSpeechForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AmbientSpeechForm));
            this.txtPartial = new System.Windows.Forms.TextBox();
            this.txtFinal = new System.Windows.Forms.TextBox();
            this.wordOutput = new System.Windows.Forms.TextBox();
            this.listeningIndicator = new System.Windows.Forms.PictureBox();
            this.alwaysListen = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.listeningIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPartial
            // 
            this.txtPartial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPartial.Location = new System.Drawing.Point(12, 12);
            this.txtPartial.Multiline = true;
            this.txtPartial.Name = "txtPartial";
            this.txtPartial.ReadOnly = true;
            this.txtPartial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPartial.Size = new System.Drawing.Size(754, 378);
            this.txtPartial.TabIndex = 0;
            // 
            // txtFinal
            // 
            this.txtFinal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFinal.Location = new System.Drawing.Point(12, 396);
            this.txtFinal.Multiline = true;
            this.txtFinal.Name = "txtFinal";
            this.txtFinal.ReadOnly = true;
            this.txtFinal.Size = new System.Drawing.Size(915, 66);
            this.txtFinal.TabIndex = 1;
            // 
            // wordOutput
            // 
            this.wordOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wordOutput.Location = new System.Drawing.Point(12, 468);
            this.wordOutput.Multiline = true;
            this.wordOutput.Name = "wordOutput";
            this.wordOutput.ReadOnly = true;
            this.wordOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.wordOutput.Size = new System.Drawing.Size(915, 120);
            this.wordOutput.TabIndex = 2;
            // 
            // listeningIndicator
            // 
            this.listeningIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listeningIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listeningIndicator.Image = ((System.Drawing.Image)(resources.GetObject("listeningIndicator.Image")));
            this.listeningIndicator.Location = new System.Drawing.Point(772, 12);
            this.listeningIndicator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listeningIndicator.Name = "listeningIndicator";
            this.listeningIndicator.Size = new System.Drawing.Size(156, 140);
            this.listeningIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.listeningIndicator.TabIndex = 3;
            this.listeningIndicator.TabStop = false;
            // 
            // alwaysListen
            // 
            this.alwaysListen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.alwaysListen.Appearance = System.Windows.Forms.Appearance.Button;
            this.alwaysListen.Location = new System.Drawing.Point(772, 157);
            this.alwaysListen.Name = "alwaysListen";
            this.alwaysListen.Size = new System.Drawing.Size(155, 36);
            this.alwaysListen.TabIndex = 4;
            this.alwaysListen.Text = "Always Listen";
            this.alwaysListen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.alwaysListen.UseVisualStyleBackColor = true;
            this.alwaysListen.CheckedChanged += new System.EventHandler(this.alwaysListen_CheckedChanged);
            // 
            // AmbientSpeechForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 600);
            this.Controls.Add(this.alwaysListen);
            this.Controls.Add(this.listeningIndicator);
            this.Controls.Add(this.wordOutput);
            this.Controls.Add(this.txtFinal);
            this.Controls.Add(this.txtPartial);
            this.MinimumSize = new System.Drawing.Size(957, 645);
            this.Name = "AmbientSpeechForm";
            this.Text = "Ambient Speech";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AmbientSpeechForm_FormClosing);
            this.Load += new System.EventHandler(this.AmbientSpeechForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listeningIndicator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPartial;
        private System.Windows.Forms.TextBox txtFinal;
        private System.Windows.Forms.TextBox wordOutput;
        private System.Windows.Forms.PictureBox listeningIndicator;
        private System.Windows.Forms.CheckBox alwaysListen;
    }
}

