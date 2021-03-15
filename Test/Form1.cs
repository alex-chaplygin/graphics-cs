using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rectangle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Canvas c = new Canvas(200, 200, 8);
            c.Rectangle(10, 10, 50, 50, 255);
            c.Rectangle(0, 0, 150, 150, 128);
            c.Rectangle(-10, -10, 50, 50, 255);
            Bitmap image = new Bitmap(c.width, c.height);
            for (int y = 0; y < c.height; y++)
            {
                for (int x = 0; x < c.width; x++)
                {
                    int h = c.data[x + y * c.width];
                    image.SetPixel(x, y, Color.FromArgb(h, h, h));
                    
                }
            }
            e.Graphics.DrawImage(image, 0, 0);


        }
    }
}
