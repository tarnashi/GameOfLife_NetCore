using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class BorderedField : Field
    {
        public BorderedField(int x, int y) : base(x, y)
        {
            isBordered = true;
        }

        protected override byte NumberOfNeighbors(int x, int y)
        {
            byte n = 0;
            //считаем соседей
            //три слева
            if (x != 0)
            {
                if (y != 0)
                {
                    if (CurrentField[x - 1, y - 1])
                    {
                        n++;
                    }
                }
                if (CurrentField[x - 1, y])
                {
                    n++;
                }
                if (y != Height - 1)
                {
                    if (CurrentField[x - 1, y + 1])
                    {
                        n++;
                    }
                }
            }
            //два по центру
            if (y != 0)
            {
                if (CurrentField[x, y - 1])
                {
                    n++;
                }
            }
            if (y != Height - 1)
            {
                if (CurrentField[x, y + 1])
                {
                    n++;
                }
            }
            //три справа
            if (x != Width - 1)
            {
                if (y != 0)
                {
                    if (CurrentField[x + 1, y - 1])
                    {
                        n++;
                    }
                }
                if (CurrentField[x + 1, y])
                {
                    n++;
                }
                if (y != Height - 1)
                {
                    if (CurrentField[x + 1, y + 1])
                    {
                        n++;
                    }
                }
            }
            return n;
        }
    }
}
