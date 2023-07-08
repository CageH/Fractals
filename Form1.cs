using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cursach
{
    public partial class Form1 : Form
    {
        static Pen pen1;
        static Graphics g;
        public Brush br;
        public Bitmap map;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;

            var CenterX = pictureBox1.Width / 2;
            var CenterY = pictureBox1.Height / 2;
            var Iter = 5;
            var sizeBord = 150;
            double sizeR = (Math.Sqrt(Math.Pow(sizeBord, 2) - Math.Pow((sizeBord / 2), 2)));

            map = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pen1 = new Pen(Color.Black, 1);
            g = Graphics.FromImage(map);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            var point1 = new PointF(CenterX - sizeBord, CenterY - (int)(sizeR));
            var point2 = new PointF(CenterX + sizeBord, CenterY - (int)(sizeR));
            var point3 = new PointF(CenterX, CenterY + (int)(sizeR));

            g.DrawLine(pen1, point1, point2);
            g.DrawLine(pen1, point2, point3);
            g.DrawLine(pen1, point3, point1);

            Fractal(point1, point2, point3, Iter);
            Fractal(point2, point3, point1, Iter);
            Fractal(point3, point1, point2, Iter);

            pictureBox1.BackgroundImage = map;
        }//1а кнопка трикутника
        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;

            var CenterX = pictureBox1.Width / 2;
            var CenterY = pictureBox1.Height / 2;
            int qsize = 100;

            map = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(map);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            br = new SolidBrush(Color.Red);
            g.Clear(Color.White);

            PointF A = new PointF(CenterX - (qsize/ 2), CenterY - (qsize/2));
            drawTSquare(A, qsize, 10);

            pictureBox1.BackgroundImage = map;
        }//1а конпка чотирикутника
        private void button3_Click(object sender, EventArgs e)

        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;

            var CenterX = pictureBox1.Width / 2;
            var CenterY = pictureBox1.Height / 2;

            map = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(map);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen1 = new Pen(Color.Black, 1);
            g.Clear(Color.White);

            Tree(CenterX, 0, 200, 0, 5);

            pictureBox1.BackgroundImage = map;
        }//1а конпка дерева
        private void button8_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;

            map = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(map);
            pen1 = new Pen(Color.Blue, 1);
            g.Clear(Color.White);

            var CenterX = pictureBox1.Width / 2;
            var CenterY = pictureBox1.Height / 2;

            dragon_func(CenterX + 100, CenterY + 100, CenterX - 100, CenterY - 100, 15);

            pictureBox1.BackgroundImage = map;
        }// 1а конпка дракона

        private void button5_Click(object sender, EventArgs e)
        {
            var CenterX = pictureBox1.Width / 2;
            var CenterY = pictureBox1.Height / 2;
            var Iter = int.Parse(textBox1.Text);
            var sizeBord = trackBar1.Value * 15;
            double sizeR = (Math.Sqrt(Math.Pow(sizeBord, 2) - Math.Pow((sizeBord/2), 2)));

            map = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pen1 = new Pen(Color.Black, 1);
            g = Graphics.FromImage(map);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            var point1 = new PointF(CenterX - sizeBord, CenterY - (int)(sizeR));
            var point2 = new PointF(CenterX + sizeBord, CenterY - (int)(sizeR));
            var point3 = new PointF(CenterX, CenterY + (int)(sizeR));

            g.DrawLine(pen1, point1, point2);
            g.DrawLine(pen1, point2, point3);
            g.DrawLine(pen1, point3, point1);

            Fractal(point1, point2, point3, Iter);
            Fractal(point2, point3, point1, Iter);
            Fractal(point3, point1, point2, Iter);

            pictureBox1.BackgroundImage = map;
        }//2а кнопка трикутника
        private void button6_Click(object sender, EventArgs e)
        {
            var CenterX = pictureBox1.Width / 2;
            var CenterY = pictureBox1.Height / 2;
            var iter = int.Parse(textBox2.Text);
            var qsize = trackBar2.Value * 15;

            map = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(map);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            br = new SolidBrush(Color.Red);
            g.Clear(Color.White);

            PointF A = new PointF(CenterX - (qsize / 2), CenterY - (qsize / 2));
            drawTSquare(A, qsize, iter);

            pictureBox1.BackgroundImage = map;
        }//2а кнопка чотирикутника
        private void button7_Click(object sender, EventArgs e)
        {
            var CenterX = pictureBox1.Width / 2;
            var CenterY = pictureBox1.Height / 2;
            var qsize = trackBar3.Value * 30;
            var iter = int.Parse(textBox4.Text);

            map = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(map);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen1 = new Pen(Color.Black, 1);
            g.Clear(Color.White);

            Tree(CenterX, 0, qsize, 0, iter);

            pictureBox1.BackgroundImage = map;
        }//2а кнопка дерева
        private void button9_Click_1(object sender, EventArgs e)
        {
            var CenterX = pictureBox1.Width / 2;
            var CenterY = pictureBox1.Height / 2;
            var iter = int.Parse(textBox6.Text);
            var qsize = trackBar4.Value * 10;

            map = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(map);
            pen1 = new Pen(Color.Blue, 1);
            g.Clear(Color.White);

            dragon_func(CenterX + qsize, CenterY + qsize, CenterX - qsize, CenterY - qsize, iter);

            pictureBox1.BackgroundImage = map;
        }// 2а конпка дракона


        static int Fractal(PointF p1, PointF p2, PointF p3, int iter)
        {
            if (iter > 0)
            {
                var p4 = new PointF((p2.X + 2 * p1.X) / 3, (p2.Y + 2 * p1.Y) / 3);
                var p5 = new PointF((2 * p2.X + p1.X) / 3, (p1.Y + 2 * p2.Y) / 3);
                var ps = new PointF((p2.X + p1.X) / 2, (p2.Y + p1.Y) / 2);
                var pn = new PointF((4 * ps.X - p3.X) / 3, (4 * ps.Y - p3.Y) / 3);
                g.DrawLine(pen1, p4, pn);
                g.DrawLine(pen1, p5, pn);
                g.DrawLine(pen1, p4, p5);


                //Рекурсивно викликаємо функцию
                Fractal(p4, pn, p5, iter - 1);
                Fractal(pn, p5, p4, iter - 1);
                Fractal(p1, p4, new PointF((2 * p1.X + p3.X) / 3, (2 * p1.Y + p3.Y) / 3), iter - 1);
                Fractal(p5, p2, new PointF((2 * p2.X + p3.X) / 3, (2 * p2.Y + p3.Y) / 3), iter - 1);

            }
            return iter;
        }//Трикутник
        public int drawTSquare(PointF A, int size, int iter)
        {
            if (iter == 1)
            {
                g.FillRectangle(br, A.X, A.Y, size, size);
                return 0;
            }

            int d = size / 4;
            PointF[] M = new PointF[4];

            for (int i = 0; i < 4; i++)
            {
                M[i] = new PointF();
            }

            //Чотирикутники
            M[0].X = A.X - d;
            M[0].Y = A.Y - d;

            M[1].X = A.X - d;
            M[1].Y = A.Y + size - d;

            M[2].X = A.X + size - d;
            M[2].Y = A.Y - d;

            M[3].X = A.X + size - d;
            M[3].Y = A.Y + size - d;

            //Викликаємо рекурсивно для кожного чотирикутника
            for (int i = 0; i < 4; i++)
            {
                drawTSquare(M[i], size / 2, iter - 1);
            }

            g.FillRectangle(br, A.X, A.Y, size, size);

            return 0;
        }//Чотирикутник
        public void Tree(int x, int y, int leng, double angle, int iter)
        {
            double x1, y1;
            int rotate = 30;
            rotate = int.Parse(textBox3.Text);
            x1 = x + leng * Math.Sin(angle * Math.PI * 2 / 360.0);
            y1 = y + leng * Math.Cos(angle * Math.PI * 2 / 360.0);
            g.DrawLine(pen1, x, Height - y, (int)x1, Height - (int)y1);
            if (iter > 0) //Рекурсивний виклик
            {
                Tree((int)x1, (int)y1, (int)(leng / 2), angle - rotate, iter - 1);
                Tree((int)x1, (int)y1, (int)(leng / 2), angle + rotate, iter - 1);
            }
        }//Дерево
        void dragon_func(int x1, int y1, int x2, int y2, int n)
        {
            int xn, yn;

            if (n > 0)
            {
                xn = (x1 + x2) / 2 + (y2 - y1) / 2;
                yn = (y1 + y2) / 2 - (x2 - x1) / 2;

                dragon_func(x2, y2, xn, yn, n - 1);
                dragon_func(x1, y1, xn, yn, n - 1);
            }

            var point1 = new Point(x1, y1);
            var point2 = new Point(x2, y2);
            g.DrawLine(pen1, point1, point2);

        }//Дракон


        private void button4_Click(object sender, EventArgs e)
        {
        }
        private void SaveAsTool_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPG(*.JPG)|*.jpg|PNG(*.PNG)|*.png|GIF(*.GIF)|*.gif";
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                map.Save(saveFileDialog1.FileName);
            }
        }//Збереження малюнка.
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }//Інфо о фракталах
    }
}
