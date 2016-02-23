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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listeningIndicator = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.listeningIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPartial
            // 
            this.txtPartial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPartial.Location = new System.Drawing.Point(14, 15);
            this.txtPartial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPartial.Multiline = true;
            this.txtPartial.Name = "txtPartial";
            this.txtPartial.ReadOnly = true;
            this.txtPartial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPartial.Size = new System.Drawing.Size(848, 472);
            this.txtPartial.TabIndex = 0;
            // 
            // txtFinal
            // 
            this.txtFinal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFinal.Location = new System.Drawing.Point(14, 495);
            this.txtFinal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFinal.Multiline = true;
            this.txtFinal.Name = "txtFinal";
            this.txtFinal.ReadOnly = true;
            this.txtFinal.Size = new System.Drawing.Size(1029, 94);
            this.txtFinal.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(14, 598);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(1029, 136);
            this.textBox1.TabIndex = 2;
            // 
            // listeningIndicator
            // 
            this.listeningIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listeningIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listeningIndicator.Image = ((System.Drawing.Image)(resources.GetObject("listeningIndicator.Image")));
            this.listeningIndicator.Location = new System.Drawing.Point(868, 15);
            this.listeningIndicator.Name = "listeningIndicator";
            this.listeningIndicator.Size = new System.Drawing.Size(175, 175);
            this.listeningIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.listeningIndicator.TabIndex = 3;
            this.listeningIndicator.TabStop = false;
            // 
            // AmbientSpeechForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 750);
            this.Controls.Add(this.listeningIndicator);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtFinal);
            this.Controls.Add(this.txtPartial);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1074, 795);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox listeningIndicator;
    }
}

