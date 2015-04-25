using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class frmGame : Form
    {
        public bool[,] pattern;
        public int size;

        private frmPattern patternSettings;

        private Bitmap tileImage;
        private Bitmap inverseImage;
        private Bitmap mainImage;
        private Bitmap mainInverseImage;
        private Bitmap largeImage;
        private Bitmap largeInverseImage;
        private Bitmap massiveImage;
        private Bitmap massiveInverseImage;

        private Graphics tileGraphics;
        private Graphics inverseGraphics;
        private Graphics mainGraphics;
        private Graphics mainInverseGraphics;
        private Graphics largeGraphics;
        private Graphics largeInverseGraphics;
        private Graphics massiveGraphics;
        private Graphics massiveInverseGraphics;

        private Brush black;
        private Brush white;
        private Brush transparent;
        private Color transparentColor;

        private int blockWidth;
        private int blockHeight;

        public frmGame()
        {
            InitializeComponent();
            
            black = new SolidBrush(Color.Black);
            white = new SolidBrush(Color.White);
            transparentColor = Color.Gray;
            transparent = new SolidBrush(transparentColor);
            size = 5;
        }

        public void ClosePatternSettings(bool[,] newPattern)
        {
            patternSettings.Close();
            patternSettings.Dispose();

            pattern = newPattern;
            PositionPictureBoxes();
            RedrawPatterns(false);
        }

        private void LoadPatternSettings()
        {
            patternSettings = new frmPattern(this, size);
            patternSettings.Show();
        }

        private void PositionPictureBoxes()
        {
            int spacing = 6;

            picTile.Width = size;
            picTile.Height = size;

            picInverse.Width = size;
            picInverse.Height = size;
            picInverse.Top = picTile.Top + picTile.Height + spacing;

            picMain.Width = size * size;
            picMain.Height = size * size;
            picMain.Left = picTile.Left + picTile.Width + spacing;

            picMainInverse.Width = size * size;
            picMainInverse.Height = size * size;
            picMainInverse.Left = picInverse.Left + picInverse.Width + spacing;
            picMainInverse.Top = picMain.Top + picMain.Height + spacing;

            picLarge.Width = size * size * size;
            picLarge.Height = size * size * size;
            picLarge.Left = picMain.Left + picMain.Width + spacing;

            picLargeInverse.Width = size * size * size;
            picLargeInverse.Height = size * size * size;
            picLargeInverse.Left = picMainInverse.Left + picMainInverse.Width + spacing;
            picLargeInverse.Top = picLarge.Top + picLarge.Height + spacing;

            picMassive.Width = size * size * size * size;
            picMassive.Height = size * size * size * size;
            picMassive.Left = picLarge.Left + picLarge.Width + spacing;

            int newWidth = picTile.Left + picTile.Width + spacing + picMain.Width + spacing + picLarge.Width + spacing + picMassive.Width + spacing + 12;
            int newHeight = 32 + picMassive.Top + picMassive.Height + 12;

            if (newWidth > SystemInformation.WorkingArea.Width || newHeight > SystemInformation.WorkingArea.Height)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                Width = newWidth;
                Height = newHeight;
            }
        }

        private void RedrawPatterns(bool writeFile)
        {
            ResetAllImages();
            string guid = Guid.NewGuid().ToString();

            for (int x = 0; x < picTile.Width; x++)
            {
                for (int y = 0; y < picTile.Height; y++)
                {
                    if (pattern[x, y])
                    {
                        tileImage.SetPixel(x, y, Color.Black);
                        inverseImage.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        tileImage.SetPixel(x, y, Color.White);
                        inverseImage.SetPixel(x, y, Color.Black);
                    }
                }
            }

            if (!writeFile)
            {
                tileImage.MakeTransparent(transparentColor);
                inverseImage.MakeTransparent(transparentColor);
            }
            picTile.Image = tileImage;
            picInverse.Image = inverseImage;

            mainGraphics = Graphics.FromImage(mainImage);
            mainInverseGraphics = Graphics.FromImage(mainInverseImage);

            for (int x = 0; x < picMain.Width; x += size)
            {
                for (int y = 0; y < picMain.Height; y += size)
                {
                    if (pattern[x / size, y / size])
                    {
                        mainGraphics.DrawImage(tileImage, x, y, mainImage.Width / size, mainImage.Width / size);
                        mainInverseGraphics.DrawImage(inverseImage, x, y, mainInverseImage.Width / size, mainInverseImage.Width / size);
                    }
                    else
                    {
                        mainGraphics.DrawImage(inverseImage, x, y, mainImage.Height / size, mainImage.Height / size);
                        mainInverseGraphics.DrawImage(tileImage, x, y, mainInverseImage.Width / size, mainInverseImage.Width / size);
                    }
                }
            }

            picMain.Image = mainImage;
            picMainInverse.Image = mainInverseImage;

            int tileWidth = size * size;
            int tileHeight = size * size;

            largeGraphics = Graphics.FromImage(largeImage);
            largeInverseGraphics = Graphics.FromImage(largeInverseImage);

            for (int x = 0; x < picLarge.Width; x += tileWidth)
            {
                for (int y = 0; y < picLarge.Height; y += tileHeight)
                {
                    if (pattern[x / tileWidth, y / tileHeight])
                    {
                        largeGraphics.DrawImage(mainImage, x, y, largeImage.Width / size, largeImage.Width / size);
                        largeInverseGraphics.DrawImage(mainInverseImage, x, y, largeInverseImage.Width / size, largeInverseImage.Width / size);
                    }
                    else
                    {
                        largeGraphics.DrawImage(mainInverseImage, x, y, largeImage.Height / size, largeImage.Height / size);
                        largeInverseGraphics.DrawImage(mainImage, x, y, largeInverseImage.Height / size, largeInverseImage.Height / size);
                    }
                }
            }

            picLarge.Image = largeImage;
            picLargeInverse.Image = largeInverseImage;

            if (writeFile)
            {
                largeImage.Save("C:\\Documents and Settings\\" + Environment.UserName + "\\Desktop\\GoL-small-" + guid + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            }

            tileWidth *= size;
            tileHeight *= size;

            massiveGraphics = Graphics.FromImage(massiveImage);
            largeInverseGraphics = Graphics.FromImage(massiveInverseImage);

            try
            {
                for (int x = 0; x < massiveImage.Width; x += tileWidth)
                {
                    for (int y = 0; y < massiveImage.Height; y += tileHeight)
                    {
                        if (pattern[x / tileWidth, y / tileHeight])
                        {
                            massiveGraphics.DrawImage(largeImage, x, y, massiveImage.Width / size, massiveImage.Width / size);
                        }
                        else
                        {
                            massiveGraphics.DrawImage(largeInverseImage, x, y, massiveImage.Height / size, massiveImage.Height / size);
                        }
                    }
                }

                if (writeFile)
                {
                    massiveImage.Save("C:\\Documents and Settings\\" + Environment.UserName + "\\Desktop\\GoL-large-" + guid + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                }
            }
            catch (ArgumentException ae)
            { }
        }

        private void ResetAllImages()
        {
            tileImage = new Bitmap(picTile.Width, picTile.Height);
            inverseImage = new Bitmap(picInverse.Width, picInverse.Height);
            mainImage = new Bitmap(picMain.Width, picMain.Height);
            mainInverseImage = new Bitmap(picMainInverse.Width, picMainInverse.Height);
            largeImage = new Bitmap(picLarge.Width, picLarge.Height);
            largeInverseImage = new Bitmap(picLargeInverse.Width, picLargeInverse.Height);
            massiveImage = new Bitmap(picMassive.Width, picMassive.Height);
            massiveInverseImage = new Bitmap(picMassive.Width, picMassive.Height);

            tileGraphics = Graphics.FromImage(tileImage);
            inverseGraphics = Graphics.FromImage(inverseImage);
            mainGraphics = Graphics.FromImage(mainImage);
            mainInverseGraphics = Graphics.FromImage(mainInverseImage);
            largeGraphics = Graphics.FromImage(largeImage);
            largeInverseGraphics = Graphics.FromImage(largeInverseImage);
            massiveGraphics = Graphics.FromImage(massiveImage);
            massiveInverseGraphics = Graphics.FromImage(massiveInverseImage);

            tileGraphics.Clear(transparentColor);
            inverseGraphics.Clear(transparentColor);
            mainGraphics.Clear(transparentColor);
            mainInverseGraphics.Clear(transparentColor);
            largeGraphics.Clear(transparentColor);
            largeInverseGraphics.Clear(transparentColor);
            massiveGraphics.Clear(transparentColor);
            massiveInverseGraphics.Clear(transparentColor);

            tileImage.MakeTransparent(transparentColor);
            inverseImage.MakeTransparent(transparentColor);
            mainImage.MakeTransparent(transparentColor);
            mainInverseImage.MakeTransparent(transparentColor);
            largeImage.MakeTransparent(transparentColor);
            largeInverseImage.MakeTransparent(transparentColor);
            massiveImage.MakeTransparent(transparentColor);
            massiveInverseImage.MakeTransparent(transparentColor);

            picTile.Image = tileImage;
            picInverse.Image = inverseImage;
            picMain.Image = mainImage;
            picMainInverse.Image = mainInverseImage;
            picLarge.Image = largeImage;
            picLargeInverse.Image = largeInverseImage;
            picMassive.Image = massiveImage;
        }

        private void btnGenerateImages_Click(object sender, EventArgs e)
        {
            RedrawPatterns(true);
        }

        private void btnSetPattern_Click(object sender, EventArgs e)
        {
            LoadPatternSettings();
        }
    }
}