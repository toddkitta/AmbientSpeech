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
            this.txtPartial = new System.Windows.Forms.TextBox();
            this.txtFinal = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.txtPartial.Size = new System.Drawing.Size(915, 378);
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
            this.txtFinal.Size = new System.Drawing.Size(915, 76);
            this.txtFinal.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 478);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(915, 110);
            this.textBox1.TabIndex = 2;
            // 
            // AmbientSpeechForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 600);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtFinal);
            this.Controls.Add(this.txtPartial);
            this.MinimumSize = new System.Drawing.Size(957, 647);
            this.Name = "AmbientSpeechForm";
            this.Text = "Ambient Speech";
            this.Load += new System.EventHandler(this.AmbientSpeechForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPartial;
        private System.Windows.Forms.TextBox txtFinal;
        private System.Windows.Forms.TextBox textBox1;
    }
}

