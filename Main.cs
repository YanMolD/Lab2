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
        switch_1:
            Console.WriteLine("Выберите лабораторную (2 или 5)\n");
            switch (Console.ReadLine())
            {
                case "2":
                Square_goto:
                    Console.WriteLine("Квадрат\n");
                    Square square;
                    try
                    {
                        square = new Square(Points_for_Square());
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
                Rectangle_goto:
                    Console.WriteLine("Прямоугольник\n");
                    Rectangle rectangle;
                    try
                    {
                        rectangle = new Rectangle(Points_for_Rectangle());
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}, пожалуйста, повторите попытку\n");
                        goto Rectangle_goto;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка: данный формат не преобразован в integer, пожалуйста, повторите попытку\n");
                        goto Rectangle_goto;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Ошибка: данное число слишком велико, пожалуйста, повторите попытку\n");
                        goto Rectangle_goto;
                    }
                Circle_goto:
                    Console.WriteLine("Круг\n");
                    Circle circle;
                    try
                    {
                        circle = new Circle(Points_for_Circle());
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
                Triangle_goto:
                    Console.WriteLine("Треугольник\n");
                    Triangle triangle;
                    try
                    {
                        triangle = new Triangle(Points_for_Triangle());
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
                    figures.Add(circle);
                    Console.Write("Площадь круга равна {0}, периметр равен {1}\n", circle.CalcArea(), circle.CalcPerimeter());
                    figures.Add(rectangle);
                    Console.Write("Площадь прямоугольника равна {0}, периметр равен {1}\n", rectangle.CalcArea(), rectangle.CalcPerimeter());
                    figures.Add(square);
                    Console.Write("Площадь квадрата равна {0}, периметр равен {1}\n", square.CalcArea(), square.CalcPerimeter());
                    figures.Add(triangle);
                    Console.Write(triangle);
                    Console.WriteLine();
                    Console.Write("Фигура с максимальным периметром- {0}\n", Calc_Max_P(figures));
                    Console.Write("Фигура с максимальной площадью- {0}\n", Calc_Max_A(figures));
                    Console.Write("Фигура с минимальным периметром- {0}\n", Calc_Min_P(figures));
                    Console.Write("Фигура с минимальной площадью- {0}\n", Calc_Min_A(figures));
                    Console.Write("Сумма всех площадей равна: {0}\n", Calc_All_Areas(figures));
                    Console.Write("Сумма всех периметров равна: {0}\n", Calc_All_Perimeterms(figures));
                    break;

                case "5":
                    int user_choice = 0;
                    int counter = 0;
                    List<IFigure> FiguresList = new List<IFigure>();
                    IFigure[] FiguresArray = null;
                    ShapeAccumulator MainAcc = new ShapeAccumulator();
                    ShapeAccumulator SideAcc = new ShapeAccumulator();
                    int ArraySize = 0;
                Add_Figure:
                    Console.WriteLine("Выберите, что вы хотите создать:\n1.Квадрат\n2.Круг\n3.Прямоугольник\n4.Треугольник\n\n5.Перейти к работе с основным ShapeAccumulator\n");
                    IFigure figure;
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            Console.WriteLine("Квадрат\n");

                            try
                            {
                                figure = new Square(Points_for_Square());
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine($"Ошибка: {ex.Message}, пожалуйста, повторите попытку\n");
                                goto case 1;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Ошибка: данный формат не преобразован в integer, пожалуйста, повторите попытку\n");
                                goto case 1;
                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("Ошибка: данное число слишком велико, пожалуйста, повторите попытку\n");
                                goto case 1;
                            }
                            break;

                        case 2:
                            Console.WriteLine("Круг\n");
                            try
                            {
                                figure = new Circle(Points_for_Circle());
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine($"Ошибка: {ex.Message}, пожалуйста, повторите попытку\n");
                                goto case 2;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine($"Ошибка: данный формат не преобразован в integer, пожалуйста, повторите попытку\n");
                                goto case 2;
                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("Ошибка: данное число слишком велико, пожалуйста, повторите попытку\n");
                                goto case 2;
                            }
                            break;

                        case 3:
                            Console.WriteLine("Прямоугольник\n");
                            try
                            {
                                figure = new Rectangle(Points_for_Rectangle());
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine($"Ошибка: {ex.Message}, пожалуйста, повторите попытку\n");
                                goto case 3;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Ошибка: данный формат не преобразован в integer, пожалуйста, повторите попытку\n");
                                goto case 3;
                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("Ошибка: данное число слишком велико, пожалуйста, повторите попытку\n");
                                goto case 3;
                            }
                            break;

                        case 4:
                            Console.WriteLine("Треугольник\n");
                            try
                            {
                                figure = new Triangle(Points_for_Triangle());
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine($"Ошибка: {ex.Message}, пожалуйста, повторите попытку\n");
                                goto case 4;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine($"Ошибка: данный формат не преобразован в integer, пожалуйста, повторите попытку\n");
                                goto case 4;
                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("Ошибка: данное число слишком велико, пожалуйста, повторите попытку\n");
                                goto case 4;
                            }
                            break;

                        case 5:
                            Console.WriteLine("Если хотите соханить фигуры, находящиеся в ShapeAccumulator, введите 1, если хотите загрузить уже сохранённые, введите 2.\nЕсли хотите очистить файл с сохранёнными фигурами, нажмите 3\n");
                        SwitchSaveLoad:
                            switch (Console.ReadLine())
                            {
                                case "1":
                                    try
                                    {
                                        MainAcc.Save();
                                    }
                                    catch (ArgumentNullException ex)
                                    {
                                        Console.WriteLine($"Ошибка: {ex.Message}\n");
                                    }
                                    catch (FileNotFoundException)
                                    {
                                        Console.WriteLine("Ошибка: файла не существует\n");
                                    }
                                    break;

                                case "2":
                                    int save = MainAcc.figures.Count;
                                    try
                                    {
                                        MainAcc.Load();
                                    }
                                    catch (FileNotFoundException)
                                    {
                                        Console.WriteLine("Ошибка: файла не существует\n");
                                    }
                                    Console.WriteLine($"Из файла загружено {MainAcc.figures.Count - save} фигур\n");
                                    Console.WriteLine(MainAcc);
                                    Console.WriteLine("Желаете сохранить этот список фигур?\n1. Да\n2. Нет\n");
                                SwitchNewSave:
                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            MainAcc.Delete_Save();
                                            MainAcc.Save();
                                            break;

                                        case "2":
                                            break;

                                        default:
                                            Console.WriteLine("Нет такого варианта, попробуйте ещё раз\n");
                                            goto SwitchNewSave;
                                    }
                                    break;

                                case "3":
                                    MainAcc.Delete_Save();
                                    break;

                                default:
                                    Console.WriteLine("Нет такого варианта, попробуйте ещё раз\n");
                                    goto SwitchSaveLoad;
                            }
                            Console.WriteLine($"Количество фигур в ShapeAccumulator: {MainAcc.figures.Count}\n");
                            Console.WriteLine($"Фигура с наибольшей площадью: { MainAcc.MaxAreaShape()}\n");
                            Console.WriteLine($"Фигура с наибольшим периметром: { MainAcc.MaxPerimeterShape()}\n");
                            Console.WriteLine($"Фигура с наименьшей площадью: { MainAcc.MinAreaShape()}\n");
                            Console.WriteLine($"Фигура с наименьим периметром: { MainAcc.MinPerimeterShape()}\n");
                            Console.WriteLine($"Сумма всех площадей: { MainAcc.TotalArea()}\n");
                            Console.WriteLine($"Сумма всех периметров: { MainAcc.TotalPerimeter()}\n");
                            goto EndOfProg;

                        default:
                            Console.WriteLine("В меню не было такого варианта, повторите попытку\n");
                            goto Add_Figure;
                    }
                    counter++;
                switch_2:
                    if (counter == 1)
                    {
                        Console.WriteLine("Хотите добавить эту фигуру:\n1.В список\n2.В массив\n3.В отдельный ShapeAccumulator\n4.Cразу в основной ShapeAccumulator?\n");
                        user_choice = Convert.ToInt32(Console.ReadLine());
                    }

                    switch (user_choice)
                    {
                        case 1:
                            FiguresList.Add(figure);
                            Console.WriteLine("Хотите добавить ещё фигур в дополнительный ShapeAccumulator?\n1.Да\n2.Нет\n");
                            switch (Convert.ToInt32(Console.ReadLine()))
                            {
                                case 1:
                                    goto Add_Figure;
                                case 2:
                                    MainAcc.AddAll(FiguresList);
                                    FiguresList = new List<IFigure>();
                                    counter = 0;
                                    goto Add_Figure;
                                default:
                                    break;
                            }
                            goto Add_Figure;

                        case 2:
                            if (counter == 1)
                            {
                                Console.WriteLine("Введите размер массива\n");
                                ArraySize = Convert.ToInt32(Console.ReadLine());
                                FiguresArray = new IFigure[ArraySize];
                            }
                            FiguresArray[counter - 1] = figure;
                            if (counter == ArraySize)
                            {
                                MainAcc.AddAll(FiguresArray);
                                FiguresArray = null;
                                counter = 0;
                                goto Add_Figure;
                            }

                            goto Add_Figure;

                        case 3:
                            SideAcc.Add(figure);
                        switch_3:
                            Console.WriteLine("Хотите добавить ещё фигур в дополнительный ShapeAccumulator?\n1.Да\n2.Нет\n");
                            switch (Convert.ToInt32(Console.ReadLine()))
                            {
                                case 1:
                                    goto Add_Figure;
                                case 2:
                                    MainAcc.AddAll(SideAcc);
                                    SideAcc = new ShapeAccumulator();
                                    counter = 0;
                                    goto Add_Figure;
                                default:
                                    Console.WriteLine("В меню не было такого варианта, повторите попытку\n");
                                    goto switch_3;
                            }
                        case 4:
                            MainAcc.Add(figure);
                            counter = 0;
                            goto Add_Figure;
                        default:
                            Console.WriteLine("В меню не было такого варианта, повторите попытку\n");
                            goto switch_2;
                    }

                default:
                    Console.WriteLine("В меню не было такого варианта, повторите попытку\n");
                    goto switch_1;
            }
        EndOfProg: { }
        }
    }
}