using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hilbert
{
    public partial class Form1 : Form
    {
        int p = 6; //порядок кривой
        int lx = 5, ly = 5; //определяем значения, дающие направление,в котором должна рисоваться кривая
        int i;

        //Графический курсор устанавливаем в начальную точку
        int X = 190, Y = 75;

        public Form1()
        {
            InitializeComponent();
        }

        // Функция DrawPart рисует линию из точки (X,Y) к новой точке и сохраняет координаты точки в переменных X и Y.
        private void DrawPart(Graphics g, int lx, int ly)
        {
            g.DrawLine(Pens.Black, X, Y, X + lx, Y + ly);
            X = X + lx;
            Y = Y + ly;
        }

        //  Кривую Гильберта можно получить путем
        //  соединения элементов а,b,с и d.
        //  Каждый элемент строит
        //  соответствующая функция.

        // Рекурсивно берем четыре маленькие кривые Гильберта и соединяем их линиями.
        // Процедуры рисования четырех разновидностей кривых Гильберта(направленных в разные стороны)
        void a(int i, Graphics g)
        {
            if (i > 0)
            {
                d(i - 1, g);
                //От последней точки проводится вправо отрезок длиной 5 пикселей
                DrawPart(g, +lx, 0);
                a(i - 1, g);
                //От последней точки (на нее указывает графический курсор) проводится вниз отрезок длиной 5 пикселей
                DrawPart(g, 0, ly);
                a(i - 1, g);
                //От последней точки проводится влево отрезок длиной 5 пикселей
                DrawPart(g, -lx, 0);
                c(i - 1, g);
            }
        }


        void b(int i, Graphics g)
        {
            if (i > 0)
            {
                c(i - 1, g);
                //От последней точки проводится влево отрезок длиной 5 пикселей
                DrawPart(g, -lx, 0);
                b(i - 1, g);
                //От последней точки проводится вверх отрезок длиной 5 пикселей
                DrawPart(g, 0, -ly);
                b(i - 1, g);
                //От последней точки проводится вправо отрезок длиной 5 пикселей  
                DrawPart(g, lx, 0);
                d(i - 1, g);
            }
        }

        void c(int i, Graphics g)
        {
            if (i > 0)
            {

                b(i - 1, g);
                //От последней точки проводится вверх отрезок длиной 5 пикселей  
                DrawPart(g, 0, -ly);
                c(i - 1, g);
                //От последней точки проводится влево отрезок длиной 5 пикселей  
                DrawPart(g, -lx, 0);
                c(i - 1, g);
                //От последней точки проводится вниз отрезок длиной 5 пикселей  
                DrawPart(g, 0, ly);
                a(i - 1, g);
            }
        }

        void d(int i, Graphics g)
        {
            if (i > 0)
            {
                a(i - 1, g);
                //От последней точки проводится вниз отрезок длиной 5 пикселей  
                DrawPart(g, 0, ly);
                d(i - 1, g);
                //От последней точки проводится вправо отрезок длиной 5 пикселей  
                DrawPart(g, lx, 0);
                d(i - 1, g);
                //От последней точки проводится вверх отрезок длиной 5 пикселей  
                DrawPart(g, 0, -ly);
                b(i - 1, g);
            }
        }
        // по нажатию кнопики Draw будут рисоваться кривые
        private void Draw(object sender, EventArgs e)
        {
            //Объявляем объект "g" класса Graphics и предоставляем
            //ему возможность рисования на pictureBox1:
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            //вызываем функцию рисования фрактала
            a(p, g);
        }
    }
}
