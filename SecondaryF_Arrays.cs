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
            Point[] points = new Point[4];
            for (int i = 0; i < 4; i++)
            {
                Console.Write("Введите координату X точки {0}: ", i + 1);
                points[i].X = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Введите координату Y точки {0}: ", i + 1);
                points[i].Y = Convert.ToInt32(Console.ReadLine());          //диагонали, а также расстояние между любыми двумя парами точек отличаются, то исключение
                Console.WriteLine();
            }
            if ((Calc_dist(points[0], points[2]) != Calc_dist(points[1], points[3])) || //стороны не равны
                ((Calc_dist(points[0], points[1]) != Calc_dist(points[1], points[2])) ||
                (Calc_dist(points[1], points[2]) != Calc_dist(points[2], points[3])) ||
                (Calc_dist(points[1], points[2]) != Calc_dist(points[2], points[3]))) ||
                (Calc_dist(points[0], points[1]) == 0)) //если все точки одинаковые
                throw new ArgumentException("Неправильные значения точек");
            return points;
        }

        public static Point[] Points_for_Rectangle()
        {
            Point[] points = new Point[4];
            for (int i = 0; i < 4; i++)
            {
                Console.Write("Введите координату X точки {0}: ", i + 1);
                points[i].X = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Введите координату Y точки {0}: ", i + 1);
                points[i].Y = Convert.ToInt32(Console.ReadLine());  //если точки 1 3 и 2 4 не образуют 2 равных диагонали, а стороны не равны попарно, то исключение
                Console.WriteLine();
            }
            if ((Calc_dist(points[0], points[2]) != Calc_dist(points[1], points[3])) || //диагонали не равны
                ((Calc_dist(points[0], points[1]) != Calc_dist(points[2], points[3])) ||
                (Calc_dist(points[1], points[2]) != Calc_dist(points[3], points[0]))) || //стороны не равны попарно
                (Calc_dist(points[0], points[1]) == 0) || //стороны равны 0
                (Calc_dist(points[0], points[3]) > Calc_dist(points[0], points[2]) ||
                Calc_dist(points[0], points[1]) > Calc_dist(points[0], points[2]))) //неправильный порядок ввода точек
                throw new ArgumentException("Неправильные значения точек");
            if (Calc_dist(points[0], points[1]) == Calc_dist(points[1], points[2])) //введён квадрат
                throw new ArgumentException("Это квадрат");
            return points;
        }

        public static Point[] Points_for_Triangle()
        {
            Point[] points = new Point[3];
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Введите координату X точки {0}: ", i + 1);
                points[i].X = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Введите координату Y точки {0}: ", i + 1);
                points[i].Y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();// если 2 точки совпадают по координатам, то исключение
            }
            if (((points[0].X == points[1].X) && (points[0].Y == points[1].Y)) ||
               ((points[1].X == points[2].X) && (points[1].Y == points[2].Y)) ||
               ((points[0].X == points[2].X) && (points[0].Y == points[2].Y)))
                throw new ArgumentException("Неправильные значения точек");
            if ((points[0].X - points[2].X) * (points[1].Y - points[2].Y) == (points[1].X - points[2].X) * (points[0].Y - points[2].Y))
                throw new ArgumentException("Точки лежат на одной прямой");
            return points;
        }

        public static Point[] Points_for_Circle()           //Первый элемент массива- центр, второй- радиус
        {
            Point[] points = new Point[4];
            Console.Write("Введите координату X: ");
            points[0].X = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Введите координату Y: ");
            points[0].Y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Введите радиус R: ");    //Если равен 0, то исключение

            points[1].X = Convert.ToInt32(Console.ReadLine()) + points[0].X;
            points[1].Y = points[0].Y;
            Console.WriteLine();
            if (points[1].X == points[0].X)
                throw new ArgumentException("Неправильный радиус");
            return points;
        }
    }
}