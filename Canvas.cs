using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsLibrary
{
    public class Canvas
    {
        public int width;
        public int height;
        public int bpp;
        public int[] data;

        public Canvas(int width, int height, int bpp)
        {
            this.width = width;
            this.height = height;
            this.bpp = bpp;
            data = new int[width * height];
        }

        public void DrawPixel(int x, int y, int color)
        {
            if (0 <= x && x < width)
                if (0 <= y && y < height)
                    data[x + y * width] = color;
        }

	public void DrawCanvas(int a_x, int a_y, Canvas a_canvas)
        {
            if (a_canvas is null)
            {
                throw new ArgumentNullException(paramName: nameof(a_canvas));
            }

            for (int x = a_x; x < a_x + a_canvas.width; x++)
                for (int y = a_y; y < a_y + a_canvas.height; y++)
                    DrawPixel(x, y, a_canvas.pixels[x - a_x + ((y - a_y) * a_canvas.width)]);
	}

        public void DrawLine(int x1, int y1, int x2, int y2, int color)
        {
            float error = 0;
            float deltaerr = 0;
            int dir = 0;
            int st = 0;
            int end = 0;
            int c2 = 0;
            int deltax = Math.Abs(x2 - x1);
            int deltay = Math.Abs(y2 - y1);
            if (deltax > deltay)
            {
                deltaerr = (float)(deltay + 1) / (float)(deltax + 1);
                dir = y2 - y1;
                st = (x1 > x2) ? x2 : x1;
                end = (x1 > x2) ? x1 : x2;
                c2 = (y1 > y2) ? y2 : y1;
            }
            else
            {
                deltaerr = (float)(deltax + 1) / (float)(deltay + 1);
                dir = x2 - x1;
                st = (y1 > y2) ? y2 : y1;
                end = (y1 > y2) ? y1 : y2;
                c2 = (x1 > x2) ? x2 : x1;
            }
            dir = (dir > 0) ? dir = 1 : dir = -1;
            for (int c1 = st; c1 < end; c1++)
            {
                if (deltax > deltay) DrawPixel(c1, c2, color);
                else DrawPixel(c2, c1, color);
                error += deltaerr;
                if (error >= 1)
                {
                    c2 += dir;
                    error -= 1;
                }
            }
        }

	public void Rectangle(int x1, int y1, int x2, int y2, int color)
        {
            for (int x = x1; x <= x2; x++)
            {
                Point(x, y1, color);
                Point(x, y2, color);
            }
            for (int y = y1; y <= y2; y++)
            {
                Point(x1, y, color);
                Point(x2, y, color);
            }
        }
    }
}

