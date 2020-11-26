using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Lab_2
{
    partial class Program
    {
        public interface IFigure    //Абстрактный класс
        {
            public double CalcArea();

            public double CalcPerimeter();
        }

        public class Circle : IFigure
        {
            private readonly Point[] array;

            public double CalcArea()
            {
                double Avalue = Math.PI * (Math.Pow(Calc_dist(array[0], array[1]), 2));
                if (Avalue == 0)
                    throw new ArgumentException("Неверно заданы точки фигуры");
                return Avalue;
            }

            public double CalcPerimeter()
            {
                double Pvalue = 2 * Math.PI * Math.Sqrt(Math.Pow(Calc_dist(array[0], array[1]), 2));
                if (Pvalue == 0)
                    throw new ArgumentException("Неверно заданы точки фигуры");
                return Pvalue;
            }

            public Circle(Point[] array)
            {
                this.array = array;
            }

            public override string ToString()
            {
                return "Круг";
            }
        }

        public class Square : IFigure
        {
            private readonly Point[] array;

            public double CalcArea()
            {
                double Avalue = Math.Pow(Calc_dist(array[0], array[1]), 2);
                if (Avalue == 0)
                    throw new ArgumentException("Неверно заданы точки фигуры");
                return Avalue;
            }

            public double CalcPerimeter()
            {
                double Pvalue = 4 * Calc_dist(array[0], array[1]);
                if (Pvalue == 0)
                    throw new ArgumentException("Неверно заданы точки фигуры");
                return Pvalue;
            }

            public Square(Point[] array)
            {
                this.array = array;
            }

            public override string ToString()
            {
                return "Квадрат";
            }
        }

        public class Rectangle : IFigure
        {
            private readonly Point[] array;

            public double CalcArea()
            {
                double Avalue = Calc_dist(array[0], array[1]) * Calc_dist(array[1], array[2]);
                if (Avalue == 0)
                    throw new ArgumentException("Неверно заданы точки фигуры");
                return Avalue;
            }

            public double CalcPerimeter()
            {
                double Pvalue = Calc_dist(array[0], array[1]) * 2 + Calc_dist(array[1], array[2]) * 2;
                if (Pvalue == 0)
                    throw new ArgumentException("Неверно заданы точки фигуры");
                return Pvalue;
            }

            public Rectangle(Point[] array)
            {
                this.array = array;
            }

            public override string ToString()
            {
                return "Прямоугольник";
            }
        }

        public class Triangle : IFigure
        {
            private readonly Point[] array;

            public double CalcArea()
            {
                double Avalue = Math.Sqrt(CalcPerimeter() / 2 *
                    (CalcPerimeter() / 2 - Calc_dist(array[0], array[1])) *
                    (CalcPerimeter() / 2 - Calc_dist(array[1], array[2])) *
                    (CalcPerimeter() / 2 - Calc_dist(array[2], array[0])));
                if (Avalue == 0)
                    throw new ArgumentException("Неверно заданы точки фигуры");
                return Avalue;
            }

            public double CalcPerimeter()
            {
                double Pvalue = Calc_dist(array[0], array[1]) + Calc_dist(array[1], array[2]) + Calc_dist(array[2], array[0]);
                if (Pvalue == 0)
                    throw new ArgumentException("Неверно заданы точки фигуры");
                return Pvalue;
            }

            public Triangle(Point[] array)
            {
                this.array = array;
            }

            public override string ToString()
            {
                return "Треугольник";
            }
        }
    }
}