﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_2
{
    internal class ShapeAccumulator
    {
        public readonly List<IFigure> figures;
        private IFigure MinA, MaxA, MinP, MaxP;
        private double TotalA, TotalP;

        public ShapeAccumulator()
        {
            figures = new List<IFigure>();
            MinA = null;
            MaxA = null;
            MinP = null;
            MaxP = null;
            TotalA = 0;
            TotalP = 0;
        }

        public void Add(IFigure value)
        {
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
            for (int i = 0; i < fig_array.Length; i++)
                Add(fig_array[i]);
        }

        public void AddAll(List<IFigure> fig_list)
        {
            for (int i = 0; i < fig_list.Count; i++)
                Add(fig_list[i]);
        }

        public void AddAll(ShapeAccumulator accum)
        {
            for (int i = 0; i < accum.figures.Count; i++)
                Add(accum.figures[i]);
        }

        public IFigure MaxAreaShape() => MaxA;

        public IFigure MinAreaShape() => MinA;

        public IFigure MaxPerimeterShape() => MaxP;

        public IFigure MinPerimeterShape() => MinP;

        public double TotalArea() => TotalA;

        public double TotalPerimeter() => TotalP;
    }
}