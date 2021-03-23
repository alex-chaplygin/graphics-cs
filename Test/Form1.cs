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
	    Screen s = new Screen(Width, Height, 8);
            Canvas c = new Canvas(Width, Height, 8); ;
            s.SetWindow(-1.5, 1.5, -1.5, 1.5);
            //s.FillRectangle(0, 0, Width, Height, Color.Gold.ToArgb());
            //s.DrawLine(0, 0, Width, Height, Color.Black.ToArgb());
            double centerX = 0 / 2;
            double centerY = 0 / 2;
            double radius = 1;
            double angle = 0;
            double step = 1.0;
            Model m = new Model(Color.Red.ToArgb());

            while (angle < 360.0)
            {
                m.AddVertex(Convert.ToSingle(centerX + radius * Math.Cos(angle * Math.PI / 180)), Convert.ToSingle(centerY + radius * Math.Sin(angle * Math.PI / 180)));
                
                    s.DrawLine(centerX, centerY, Convert.ToSingle(centerX + radius * Math.Cos(angle * Math.PI / 180)),
                    Convert.ToSingle(centerY + radius * Math.Sin(angle * Math.PI / 180)), Color.Black.ToArgb());
                angle += step;
            }
            s.DrawModel(m);
            m.Translate(0.2, 0.1);
            s.DrawModel(m);
            s.DrawLine(0.0, 0.0, 1.5, 1.5, Color.Blue.ToArgb());
            m.Scale(0.5, 0.3);
            s.DrawModel(m);
            angle = 0;
            while (angle < 360.0)
            {
                m.Rotate(angle * Math.PI / 180);
                s.DrawModel(m);
                angle += step;
            }

            //c.DrawLine(0, 600, 100, 100, Color.Black.ToArgb());
//            c.DrawLine(0, 0, 400, 300, Color.Black.ToArgb());
            Bitmap image = new Bitmap(s.width, s.height);
            for (int y = 0; y < s.height; y++)
                for (int x = 0; x < s.width; x++)
                {
                    int h = s.data[x + y * s.width];
                    image.SetPixel(x, y, Color.FromArgb(h));
                }
            e.Graphics.DrawImage(image, 0, 0);
        }
    }
}
