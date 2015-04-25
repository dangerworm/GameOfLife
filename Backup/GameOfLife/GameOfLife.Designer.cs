namespace GameOfLife
{
    partial class frmGame
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
            this.picTile = new System.Windows.Forms.PictureBox();
            this.picInverse = new System.Windows.Forms.PictureBox();
            this.btnGenerateImages = new System.Windows.Forms.Button();
            this.picMain = new System.Windows.Forms.PictureBox();
            this.picLarge = new System.Windows.Forms.PictureBox();
            this.picMainInverse = new System.Windows.Forms.PictureBox();
            this.btnSetPattern = new System.Windows.Forms.Button();
            this.picMassive = new System.Windows.Forms.PictureBox();
            this.picLargeInverse = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInverse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMainInverse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMassive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLargeInverse)).BeginInit();
            this.SuspendLayout();
            // 
            // picTile
            // 
            this.picTile.Location = new System.Drawing.Point(12, 50);
            this.picTile.Name = "picTile";
            this.picTile.Size = new System.Drawing.Size(10, 10);
            this.picTile.TabIndex = 2;
            this.picTile.TabStop = false;
            // 
            // picInverse
            // 
            this.picInverse.Location = new System.Drawing.Point(12, 66);
            this.picInverse.Name = "picInverse";
            this.picInverse.Size = new System.Drawing.Size(10, 10);
            this.picInverse.TabIndex = 3;
            this.picInverse.TabStop = false;
            // 
            // btnGenerateImages
            // 
            this.btnGenerateImages.AutoSize = true;
            this.btnGenerateImages.Location = new System.Drawing.Point(88, 12);
            this.btnGenerateImages.Name = "btnGenerateImages";
            this.btnGenerateImages.Size = new System.Drawing.Size(79, 23);
            this.btnGenerateImages.TabIndex = 4;
            this.btnGenerateImages.Text = "Save Images";
            this.btnGenerateImages.UseVisualStyleBackColor = true;
            this.btnGenerateImages.Click += new System.EventHandler(this.btnGenerateImages_Click);
            // 
            // picMain
            // 
            this.picMain.Location = new System.Drawing.Point(28, 49);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(25, 25);
            this.picMain.TabIndex = 5;
            this.picMain.TabStop = false;
            // 
            // picLarge
            // 
            this.picLarge.Location = new System.Drawing.Point(59, 49);
            this.picLarge.Name = "picLarge";
            this.picLarge.Size = new System.Drawing.Size(125, 125);
            this.picLarge.TabIndex = 6;
            this.picLarge.TabStop = false;
            // 
            // picMainInverse
            // 
            this.picMainInverse.Location = new System.Drawing.Point(28, 80);
            this.picMainInverse.Name = "picMainInverse";
            this.picMainInverse.Size = new System.Drawing.Size(25, 25);
            this.picMainInverse.TabIndex = 7;
            this.picMainInverse.TabStop = false;
            // 
            // btnSetPattern
            // 
            this.btnSetPattern.AutoSize = true;
            this.btnSetPattern.Location = new System.Drawing.Point(12, 12);
            this.btnSetPattern.Name = "btnSetPattern";
            this.btnSetPattern.Size = new System.Drawing.Size(70, 23);
            this.btnSetPattern.TabIndex = 8;
            this.btnSetPattern.Text = "Set Pattern";
            this.btnSetPattern.UseVisualStyleBackColor = true;
            this.btnSetPattern.Click += new System.EventHandler(this.btnSetPattern_Click);
            // 
            // picMassive
            // 
            this.picMassive.Location = new System.Drawing.Point(190, 49);
            this.picMassive.Name = "picMassive";
            this.picMassive.Size = new System.Drawing.Size(250, 250);
            this.picMassive.TabIndex = 9;
            this.picMassive.TabStop = false;
            // 
            // picLargeInverse
            // 
            this.picLargeInverse.Location = new System.Drawing.Point(59, 180);
            this.picLargeInverse.Name = "picLargeInverse";
            this.picLargeInverse.Size = new System.Drawing.Size(125, 125);
            this.picLargeInverse.TabIndex = 10;
            this.picLargeInverse.TabStop = false;
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 46);
            this.Controls.Add(this.picLargeInverse);
            this.Controls.Add(this.picMassive);
            this.Controls.Add(this.btnSetPattern);
            this.Controls.Add(this.picMainInverse);
            this.Controls.Add(this.picLarge);
            this.Controls.Add(this.picMain);
            this.Controls.Add(this.btnGenerateImages);
            this.Controls.Add(this.picInverse);
            this.Controls.Add(this.picTile);
            this.Name = "frmGame";
            this.Text = "Game of Life";
            ((System.ComponentModel.ISupportInitialize)(this.picTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInverse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMainInverse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMassive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLargeInverse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picTile;
        private System.Windows.Forms.PictureBox picInverse;
        private System.Windows.Forms.Button btnGenerateImages;
        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.PictureBox picLarge;
        private System.Windows.Forms.PictureBox picMainInverse;
        private System.Windows.Forms.Button btnSetPattern;
        private System.Windows.Forms.PictureBox picMassive;
        private System.Windows.Forms.PictureBox picLargeInverse;
    }
}

