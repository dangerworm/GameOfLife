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
    public partial class frmPattern : Form
    {
        private Bitmap patternImage;
        private Graphics patternGraphics;

        private Brush black;
        private Brush transparent;
        private Color transparentColor;

        private bool[,] pattern;

        private int blockWidth;
        private int blockHeight;
        private int size;

        public frmPattern(Form parent, int patternSize)
        {
            InitializeComponent();

            Tag = parent;
            size = patternSize;
        }

        private void frmPattern_Load(object sender, EventArgs e)
        {
            black = new SolidBrush(Color.Black);
            transparentColor = Color.Gray;
            transparent = new SolidBrush(transparentColor);

            size = ((frmGame)Tag).size;
            txtSize.Text = size.ToString();
            PositionPictureBox();
            patternImage = new Bitmap(picPattern.Width, picPattern.Height);
            
            pattern = ((frmGame)Tag).pattern;
            SetImage();
        }

        private void PositionPictureBox()
        {
            blockWidth = size * 10;
            blockHeight = size * 10;

            picPattern.Width = blockWidth * size;
            picPattern.Height = size * size * 10;
            
            Width = picPattern.Left + picPattern.Width + 20;
            Height = 32 + picPattern.Top + picPattern.Height + 14;
        }

        private void ResetImage()
        {
            patternImage = new Bitmap(picPattern.Width, picPattern.Height);
            patternGraphics = Graphics.FromImage(patternImage);

            patternGraphics.FillRectangle(transparent, 0, 0, patternImage.Width, patternImage.Height);
            patternImage.MakeTransparent(transparentColor);

            picPattern.Image = patternImage;
        }

        private void SetImage()
        {
            ResetImage();

            if (pattern != null)
            {
                patternGraphics = Graphics.FromImage(patternImage);

                for (int x = 0; x < size; x++)
                {
                    for (int y = 0; y < size; y++)
                    {
                        if (pattern[x, y])
                        {
                            patternGraphics.FillRectangle(black, x * blockWidth, y * blockHeight, blockWidth, blockHeight);
                        }
                        else
                        {
                            patternGraphics.FillRectangle(transparent, x * blockWidth, y * blockHeight, blockWidth, blockHeight);
                        }
                    }
                }

                patternImage.MakeTransparent(transparentColor);
                picPattern.Image = patternImage;
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            ((frmGame)Tag).size = size;

            int halfX = picPattern.Width / size / 2;
            int halfY = picPattern.Height / size / 2;

            bool[,] pattern = new bool[size, size];

            for (int x = 0; x < picPattern.Width; x += blockWidth)
            {
                for (int y = 0; y < picPattern.Height; y += blockHeight)
                {
                    try
                    {
                        if (patternImage.GetPixel(x + halfX, y + halfY).A == 0)
                        {
                            pattern[x / blockWidth, y / blockHeight] = false;
                        }
                        else
                        {
                            pattern[x / blockWidth, y / blockHeight] = true;
                        }
                    }
                    catch (ArgumentOutOfRangeException aoore)
                    { }
                }
            }

            ((frmGame)Tag).ClosePatternSettings(pattern);
        }

        private void picPattern_Click(object sender, EventArgs e)
        {
            MouseEventArgs args = e as MouseEventArgs;
            blockWidth = picPattern.Width / size;
            blockHeight = picPattern.Height / size;
            int paintX = 0;
            int paintY = 0;

            patternGraphics = Graphics.FromImage(patternImage);

            for (int x = 0; x < picPattern.Width; x += blockWidth)
            {
                if (args.X >= x && args.X < x + blockWidth)
                {
                    paintX = x;
                    break;
                }
            }

            for (int y = 0; y < picPattern.Height; y += blockHeight)
            {
                if (args.Y >= y && args.Y < y + blockHeight)
                {
                    paintY = y;
                    break;
                }
            }

            if (patternImage.GetPixel(args.X, args.Y).A == 0)
            {
                patternGraphics.FillRectangle(black, paintX, paintY, blockWidth, blockHeight);
            }
            else
            {
                patternGraphics.FillRectangle(transparent, paintX, paintY, blockWidth, blockHeight);
            }

            patternImage.MakeTransparent(transparentColor);
            picPattern.Image = patternImage;
        }

        private void txtSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtSize.Text == "")
                {
                    MessageBox.Show("Size cannot be blank. Using 5 as default");
                    txtSize.Text = "5";
                }
                else if (txtSize.Text != size.ToString())
                {
                    size = Int32.Parse(txtSize.Text);
                    PositionPictureBox();

                    pattern = new bool[size, size];

                    for (int x = 0; x < size; x++)
                    {
                        for (int y = 0; y < size; y++)
                        {
                            pattern[x, y] = false;
                        }
                    }

                    SetImage();
                }
            }
        }
    }
}
