namespace HttpFrontendWindowsFormsExample
{
    partial class MainForm
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
            this.textboxUrl = new System.Windows.Forms.TextBox();
            this.labelUrl = new System.Windows.Forms.Label();
            this.textBoxSource = new System.Windows.Forms.RichTextBox();
            this.buttonUnthreaded = new System.Windows.Forms.Button();
            this.buttonThreaded = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textboxUrl
            // 
            this.textboxUrl.Location = new System.Drawing.Point(41, 13);
            this.textboxUrl.Name = "textboxUrl";
            this.textboxUrl.Size = new System.Drawing.Size(571, 20);
            this.textboxUrl.TabIndex = 0;
            // 
            // labelUrl
            // 
            this.labelUrl.AutoSize = true;
            this.labelUrl.Location = new System.Drawing.Point(12, 16);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(23, 13);
            this.labelUrl.TabIndex = 1;
            this.labelUrl.Text = "Url:";
            // 
            // textBoxSource
            // 
            this.textBoxSource.Location = new System.Drawing.Point(12, 39);
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.ReadOnly = true;
            this.textBoxSource.Size = new System.Drawing.Size(600, 361);
            this.textBoxSource.TabIndex = 2;
            this.textBoxSource.Text = "";
            // 
            // buttonUnthreaded
            // 
            this.buttonUnthreaded.Location = new System.Drawing.Point(12, 406);
            this.buttonUnthreaded.Name = "buttonUnthreaded";
            this.buttonUnthreaded.Size = new System.Drawing.Size(289, 23);
            this.buttonUnthreaded.TabIndex = 3;
            this.buttonUnthreaded.Text = "Unthreaded GET";
            this.buttonUnthreaded.UseVisualStyleBackColor = true;
            this.buttonUnthreaded.Click += new System.EventHandler(this.buttonUnthreaded_Click);
            // 
            // buttonThreaded
            // 
            this.buttonThreaded.Location = new System.Drawing.Point(307, 406);
            this.buttonThreaded.Name = "buttonThreaded";
            this.buttonThreaded.Size = new System.Drawing.Size(305, 23);
            this.buttonThreaded.TabIndex = 4;
            this.buttonThreaded.Text = "Threaded GET";
            this.buttonThreaded.UseVisualStyleBackColor = true;
            this.buttonThreaded.Click += new System.EventHandler(this.buttonThreaded_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.buttonThreaded);
            this.Controls.Add(this.buttonUnthreaded);
            this.Controls.Add(this.textBoxSource);
            this.Controls.Add(this.labelUrl);
            this.Controls.Add(this.textboxUrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Download HTML";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textboxUrl;
        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.RichTextBox textBoxSource;
        private System.Windows.Forms.Button buttonUnthreaded;
        private System.Windows.Forms.Button buttonThreaded;
    }
}

