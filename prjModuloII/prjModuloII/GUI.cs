using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace prjModuloII
{
    class GUI
    {
        public static Bitmap CriaMapa(List<Point> nos, List<Point> pontosArcos)
        {
            Bitmap b = new Bitmap(502, 502);
            Graphics g = Graphics.FromImage(b);
            // Desenhando espaços do labirinto
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    g.DrawRectangle(new Pen(Brushes.Black), i * 25, j * 25, 25, 25);
                    g.FillRectangle(Brushes.Black, i * 25, j * 25, 25, 25);
                }
            }

            foreach (Point p in nos)
            {
                g.FillRectangle(Brushes.OrangeRed, p.X * 25 + 1, p.Y * 25 + 1, 24, 24);
            }
            foreach (Point p in pontosArcos)
            {
                g.FillRectangle(Brushes.Gray, p.X * 25 + 1, p.Y * 25 + 1, 24, 24);
            }
            // Retorna o bitmap
            return b;
        }
    }
}
