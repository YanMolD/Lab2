using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Lab_2
{
    internal class ShapeAccumulator
    {
        public readonly List<IFigure> figures;
        private IFigure MinA, MaxA, MinP, MaxP;
        private double TotalA, TotalP;
        private readonly BinaryFormatter formatter;
        private readonly string path;

        public ShapeAccumulator()
        {
            figures = new List<IFigure>();
            formatter = new BinaryFormatter();
            path = Path.Combine(Environment.CurrentDirectory, "figures");
            if (!File.Exists(Environment.CurrentDirectory))
                Directory.CreateDirectory(path);
            MinA = null;
            MaxA = null;
            MinP = null;
            MaxP = null;
            TotalA = 0;
            TotalP = 0;
        }

        public void Add(IFigure value)
        {
            if (value == null)
                throw new ArgumentException("В функцию передана пустая фигура");
            figures.Add(value);
            TotalA += value.CalcArea();
            TotalP += value.CalcPerimeter();
            if (figures.Count == 1)
            {
                MinA = value;
                MaxA = value;
                MinP = value;
                MaxP = value;
            }
            else
            {
                if (value.CalcArea() < MinA.CalcArea())
                    MinA = value;
                if (value.CalcArea() > MaxA.CalcArea())
                    MaxA = value;
                if (value.CalcArea() < MinP.CalcArea())
                    MinP = value;
                if (value.CalcArea() > MaxP.CalcArea())
                    MaxP = value;
            }
        }

        public void AddAll(IFigure[] fig_array)
        {
            if (fig_array == null)
                throw new ArgumentException("В функцию передана пустая фигура");
            for (int i = 0; i < fig_array.Length; i++)
                Add(fig_array[i]);
        }

        public void AddAll(List<IFigure> fig_list)
        {
            if (fig_list == null)
                throw new ArgumentException("В функцию передана пустая фигура");
            for (int i = 0; i < fig_list.Count; i++)
                Add(fig_list[i]);
        }

        public void AddAll(ShapeAccumulator accum)
        {
            if (accum == null)
                throw new ArgumentException("В функцию передана пустая фигура");
            for (int i = 0; i < accum.figures.Count; i++)
                Add(accum.figures[i]);
        }

        public IFigure MaxAreaShape() => MaxA;

        public IFigure MinAreaShape() => MinA;

        public IFigure MaxPerimeterShape() => MaxP;

        public IFigure MinPerimeterShape() => MinP;

        public double TotalArea() => TotalA;

        public double TotalPerimeter() => TotalP;

        public void Save()
        {
            if (figures.Count == 0)
                throw new ArgumentNullException("Нет элементов, которые возможно сохранить");
            ShapeAccumulator shapeAccumulator = new ShapeAccumulator();
            shapeAccumulator.Load();
            shapeAccumulator.AddAll(this);
            using (FileStream fs = new FileStream(path + $"/figures.shape", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, shapeAccumulator.figures);
            }
        }

        public void Load()
        {
            string[] fileEntries = Directory.GetFiles(path, "*.shape");
            foreach (string item in fileEntries)
            {
                using (FileStream fs = new FileStream(item, FileMode.OpenOrCreate))
                {
                    List<IFigure> fig = (List<IFigure>)formatter.Deserialize(fs);
                    if (fig.Count == 0)
                        throw new ArgumentNullException("Отсутствуют сохранённые фигуры");
                    AddAll(fig);
                }
            }
        }

        public void Delete_Save() => File.Delete(path + $"/figures.shape");

        public override string ToString()
        {
            string buf = "";
            for (int i = 0; i < figures.Count; i++)
            {
                buf += Convert.ToString(i + 1) + ". " + figures[i] + "\n";
            }
            return buf;
        }
    }
}