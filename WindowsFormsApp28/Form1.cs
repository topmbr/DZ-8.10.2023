using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp28
{
    public partial class Form1 : Form
    {
        private int bearX = 50;
        private int bearY = 50;
        public Form1()
        {
            InitializeComponent();
            panel1.Paint += new PaintEventHandler(panel1_Paint);
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawBear(g, bearX, bearY);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            bearX += 5;
            if (bearX > panel1.Width)
            {
                bearX = -100;
            }
            panel1.Invalidate();
        }

        private void DrawBear(Graphics g, int x, int y)
        {
            // Тело медведя (эллипс)
            g.FillEllipse(Brushes.Brown, x + 20, y + 60, 60, 100);

            // Голова медведя (эллипс)
            g.FillEllipse(Brushes.Brown, x + 40, y, 40, 60);

            // Глаза медведя (круги)
            g.FillEllipse(Brushes.White, x + 50, y + 20, 10, 15);
            g.FillEllipse(Brushes.White, x + 70, y + 20, 10, 15);
            g.FillEllipse(Brushes.Black, x + 55, y + 25, 5, 5);
            g.FillEllipse(Brushes.Black, x + 75, y + 25, 5, 5);

            // Нос медведя (эллипс)
            g.FillEllipse(Brushes.Black, x + 65, y + 35, 10, 10);

            // Рот медведя (линия)
            g.DrawLine(Pens.Black, x + 65, y + 45, x + 75, y + 45);

            // Уши медведя (треугольники)
            Point[] leftEar = { new Point(x + 40, y + 20), new Point(x + 35, y + 10), new Point(x + 25, y + 20) };
            Point[] rightEar = { new Point(x + 80, y + 20), new Point(x + 85, y + 10), new Point(x + 95, y + 20) };
            g.FillPolygon(Brushes.Brown, leftEar);
            g.FillPolygon(Brushes.Brown, rightEar);
        }
    }
}
