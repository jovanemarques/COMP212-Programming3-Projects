namespace JoinQueries
{
    partial class JoinQueries
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
            this.outputTxtBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // outputTxtBox
            // 
            this.outputTxtBox.Location = new System.Drawing.Point(12, 12);
            this.outputTxtBox.Multiline = true;
            this.outputTxtBox.Name = "outputTxtBox";
            this.outputTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputTxtBox.Size = new System.Drawing.Size(718, 426);
            this.outputTxtBox.TabIndex = 0;
            // 
            // JoinQueries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 451);
            this.Controls.Add(this.outputTxtBox);
            this.Name = "JoinQueries";
            this.Text = "Join Tables";
            this.Load += new System.EventHandler(this.JoinQueries_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox outputTxtBox;
    }
}

