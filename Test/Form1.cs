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
	    Canvas c = new Canvas(Width, Height, 8);
            c.Rectangle(10, 10, 50, 50, Color.DarkMagenta.ToArgb());
            c.Rectangle(0, 0, 550, 550, Color.ForestGreen.ToArgb());
            c.Rectangle(-10, -10, 250, 250, Color.Gold.ToArgb());
            c.FillRectangle(0, 0, Width,Height, Color.Gold.ToArgb());
            /*c.DrawLine(300, 300, 300, 500, Color.Red.ToArgb());
            c.DrawLine(300, 300, 300, 100, Color.Blue.ToArgb());
            c.DrawLine(300, 300, 100, 300, Color.Blue.ToArgb());
            c.DrawLine(300, 300, 400, 400, Color.Blue.ToArgb());
            c.DrawLine(300, 300, 200, 200, Color.Blue.ToArgb());*/
            int centerX = Width / 2;
            int centerY = Height / 2;
            int radius = 200;
            float angle = 0;
            float step = 1.0f;
            while (angle < 360.0f)
            {
                c.DrawLine(centerX, centerY, Convert.ToInt32(centerX + radius * Math.Cos(angle * Math.PI / 180)), 
                    Convert.ToInt32(centerY + radius * Math.Sin(angle * Math.PI / 180)), Color.Black.ToArgb());
                angle += step;
            }

            Bitmap image = new Bitmap(c.width, c.height);
            for (int y = 0; y < c.height; y++)
                for (int x = 0; x < c.width; x++)
                {
                    int h = c.data[x + y * c.width];
                    image.SetPixel(x, y, Color.FromArgb(h));
                }
            e.Graphics.DrawImage(image, 0, 0);
        }
    }
}
