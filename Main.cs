using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Lab_2
{
    partial class Program
    {
        private static void Main(string[] args)
        {
            Point[] ArraySquare;
        Square_goto:
            Console.WriteLine("Квадрат\n");
            try
            {
                ArraySquare = Points_for_Square();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}, пожалуйста, повторите попытку\n");
                goto Square_goto;
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: данный формат не преобразован в integer, пожалуйста, повторите попытку\n");
                goto Square_goto;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка: данное число слишком велико, пожалуйста, повторите попытку\n");
                goto Square_goto;
            }
            Point[] ArrayRectangle;
        Rectangle_goto:
            Console.WriteLine("Прямоугольник\n");
            try
            {
                ArrayRectangle = Points_for_Rectangle();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}, пожалуйста, повторите попытку\n");
                goto Rectangle_goto;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Ошибка: данный формат не преобразован в integer, пожалуйста, повторите попытку\n");
                goto Rectangle_goto;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка: данное число слишком велико, пожалуйста, повторите попытку\n");
                goto Rectangle_goto;
            }
            Point[] ArrayCircle;
        Circle_goto:
            Console.WriteLine("Круг\n");
            try
            {
                ArrayCircle = Points_for_Circle();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}, пожалуйста, повторите попытку\n");
                goto Circle_goto;
            }
            catch (FormatException)
            {
                Console.WriteLine($"Ошибка: данный формат не преобразован в integer, пожалуйста, повторите попытку\n");
                goto Circle_goto;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка: данное число слишком велико, пожалуйста, повторите попытку\n");
                goto Circle_goto;
            }
            Point[] ArrayTriangle;
        Triangle_goto:
            Console.WriteLine("Треугольник\n");
            try
            {
                ArrayTriangle = Points_for_Triangle();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}, пожалуйста, повторите попытку\n");
                goto Triangle_goto;
            }
            catch (FormatException)
            {
                Console.WriteLine($"Ошибка: данный формат не преобразован в integer, пожалуйста, повторите попытку\n");
                goto Triangle_goto;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка: данное число слишком велико, пожалуйста, повторите попытку\n");
                goto Triangle_goto;
            }
            List<IFigure> figures = new List<IFigure>(4);
            Circle circle = new Circle(ArrayCircle);
            Rectangle rectangle = new Rectangle(ArrayRectangle);
            Square square = new Square(ArraySquare);
            Triangle triangle = new Triangle(ArrayTriangle);
            figures.Add(circle);
            Console.Write("Площадь круга равна {0}, периметр равен {1}\n", circle.CalcArea(), circle.CalcPerimeter());
            figures.Add(rectangle);
            Console.Write("Площадь прямоугольника равна {0}, периметр равен {1}\n", rectangle.CalcArea(), rectangle.CalcPerimeter());
            figures.Add(square);
            Console.Write("Площадь квадрата равна {0}, периметр равен {1}\n", square.CalcArea(), square.CalcPerimeter());
            figures.Add(triangle);
            Console.Write("Площадь треугольника равна {0}, периметр равен {1}\n", triangle.CalcArea(), triangle.CalcPerimeter());
            Console.Write("Фигура с максимальным периметром- {0}, её периметр- {1}\n", Calc_Max_P(figures), Calc_Max_P(figures).CalcPerimeter());
            Console.Write("Фигура с максимальной площадью- {0}, её площадь- {1}\n", Calc_Max_A(figures), Calc_Max_A(figures).CalcArea());
            Console.Write("Фигура с минимальным периметром- {0}, её периметр- {1}\n", Calc_Min_P(figures), Calc_Min_P(figures).CalcPerimeter());
            Console.Write("Фигура с минимальной площадью- {0}, её площадь- {1}\n", Calc_Min_A(figures), Calc_Min_A(figures).CalcArea());
            Console.Write("Сумма всех площадей равна: {0}\n", Calc_All_Areas(figures));
            Console.Write("Сумма всех периметров равна: {0}\n", Calc_All_Perimeterms(figures));
        }
    }
}