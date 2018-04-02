using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public abstract class Field
    {
        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public bool[,] CurrentField { get; protected set; }

        public Field(int x, int y)
        {
            Width = x;
            Height = y;
            CurrentField = new bool[x, y];
            Clear();
        }

        public bool this[int x, int y]
        {
            get { return CurrentField[x, y]; }
        }

        public void Clear()
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                {
                    CurrentField[x, y] = false;
                }
        }

        public void MakeMove()
        {
            bool[,] FieldTMP = new bool[Width, Height];
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                {
                    byte localNubmerOfNeighbors = NumberOfNeighbors(x, y);
                    if (CurrentField[x, y])
                    {
                        if (localNubmerOfNeighbors < 2 || localNubmerOfNeighbors > 3)
                        {
                            //Если клетка жива и имеет меньше двух или больше трех живых соседей, она становится мертвой
                            FieldTMP[x, y] = false;
                        }
                        else
                        {
                            FieldTMP[x, y] = CurrentField[x, y];
                        }
                    }
                    else
                    {
                        if (localNubmerOfNeighbors == 3)
                        {
                            //Если клетка мертва и имеет трех живых соседей, она становится живой
                            FieldTMP[x, y] = true;
                        }
                        else
                        {
                            FieldTMP[x, y] = CurrentField[x, y];
                        }
                    }
                }

            CurrentField = FieldTMP;
        }

        public void ChangeCell(int x, int y)
        {
            CurrentField[x, y] = !CurrentField[x, y];
        }

        public void SetPlaner()
        {
            if (Width < 3 || Height < 3)
                return;

            Clear();
            CurrentField[1, 0] = true;
            CurrentField[2, 1] = true;
            CurrentField[0, 2] = true;
            CurrentField[1, 2] = true;
            CurrentField[2, 2] = true;
        }

        protected abstract byte NumberOfNeighbors(int x, int y);

    }
}
