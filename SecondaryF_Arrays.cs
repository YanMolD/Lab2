using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Lab_2
{
    partial class Program
    {
        public static double Calc_All_Areas(List<IFigure> figures)
        {
            double sum = 0;
            for (int i = 0; i < 4; i++)
                sum += figures[i].CalcArea();
            return sum;
        }

        public static double Calc_All_Perimeterms(List<IFigure> figures)
        {
            double sum = 0;
            for (int i = 0; i < 4; i++)
                sum += figures[i].CalcPerimeter();
            return sum;
        }

        public static IFigure Calc_Max_P(List<IFigure> figures)
        {
            double max = 0;
            int save_pos = 0;
            for (int i = 0; i < 4; i++)
                if (figures[i].CalcPerimeter() > max)
                {
                    max = figures[i].CalcPerimeter();
                    save_pos = i;
                }
            return figures[save_pos];
        }

        public static IFigure Calc_Max_A(List<IFigure> figures)
        {
            double max = 0;
            int save_pos = 0;
            for (int i = 0; i < 4; i++)
                if (figures[i].CalcArea() > max)
                {
                    max = figures[i].CalcArea();
                    save_pos = i;
                }
            return figures[save_pos];
        }

        public static IFigure Calc_Min_P(List<IFigure> figures)
        {
            double min = figures[0].CalcPerimeter();
            int save_pos = 0;
            for (int i = 0; i < 4; i++)
                if (figures[i].CalcPerimeter() < min)
                {
                    min = figures[i].CalcPerimeter();
                    save_pos = i;
                }
            return figures[save_pos];
        }

        public static IFigure Calc_Min_A(List<IFigure> figures)
        {
            double min = figures[0].CalcArea();
            int save_pos = 0;
            for (int i = 0; i < 4; i++)
                if (figures[i].CalcArea() < min)
                {
                    min = figures[i].CalcArea();
                    save_pos = i;
                }
            return figures[save_pos];
        }

        public static double Calc_dist(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
        }

        public static Point[] Points_for_Square()
        {
            Point[] array = new Point[4];
            for (int i = 0; i < 4; i++)
            {
                Console.Write("Введите координату X точки {0}: ", i + 1);
                array[i].X = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Введите координату Y точки {0}: ", i + 1);
                array[i].Y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
            }
            return array;
        }

        public static Point[] Points_for_Rectangle()
        {
            Point[] array = new Point[4];
            for (int i = 0; i < 4; i++)
            {
                Console.Write("Введите координату X точки {0}: ", i + 1);
                array[i].X = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Введите координату Y точки {0}: ", i + 1);
                array[i].Y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
            }
            return array;
        }

        public static Point[] Points_for_Triangle()
        {
            Point[] array = new Point[3];
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Введите координату X точки {0}: ", i + 1);
                array[i].X = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Введите координату Y точки {0}: ", i + 1);
                array[i].Y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
            }
            return array;
        }

        public static Point[] Points_for_Circle()
        {
            Point[] array = new Point[2];
            Console.Write("Введите координату X: ");
            array[0].X = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Введите координату Y: ");
            array[0].Y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Введите радиус R: ");

            array[1].X = Convert.ToInt32(Console.ReadLine()) + array[0].X;
            array[1].Y = array[0].Y;
            Console.WriteLine();
            return array;
        }
    }
}