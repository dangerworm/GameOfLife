namespace GameOfLife
{
    partial class frmPattern
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
            this.picPattern = new System.Windows.Forms.PictureBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPattern)).BeginInit();
            this.SuspendLayout();
            // 
            // picPattern
            // 
            this.picPattern.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPattern.Location = new System.Drawing.Point(12, 32);
            this.picPattern.Name = "picPattern";
            this.picPattern.Size = new System.Drawing.Size(250, 250);
            this.picPattern.TabIndex = 0;
            this.picPattern.TabStop = false;
            this.picPattern.Click += new System.EventHandler(this.picPattern_Click);
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(48, 6);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(23, 20);
            this.txtSize.TabIndex = 3;
            this.txtSize.Text = "5";
            this.txtSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSize_KeyPress);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(12, 9);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(30, 13);
            this.lblSize.TabIndex = 2;
            this.lblSize.Text = "Size:";
            // 
            // btnDone
            // 
            this.btnDone.AutoSize = true;
            this.btnDone.Location = new System.Drawing.Point(77, 4);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(46, 23);
            this.btnDone.TabIndex = 4;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // frmPattern
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 294);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.picPattern);
            this.Name = "frmPattern";
            this.Text = "Set Pattern";
            this.Load += new System.EventHandler(this.frmPattern_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPattern)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPattern;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Button btnDone;
    }
}