using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class LoopbackField : Field
    {
        public LoopbackField(int x, int y) : base(x, y)
        {
            isBordered = false;
        }

        protected override byte NumberOfNeighbors(int x, int y)
        {
            byte n = 0;
            //считаем соседей
            //три слева
            int x1 = (x == 0) ? base.Width - 1 : x - 1;
            int y1 = (y == 0) ? Height - 1 : y - 1;
            if (CurrentField[x1, y1])
            {
                n++;
            }
            y1 = y;
            if (CurrentField[x1, y1])
            {
                n++;
            }
            y1 = (y == Height - 1) ? 0 : y + 1;
            if (CurrentField[x1, y1])
            {
                n++;
            }
            //два по центру
            x1 = x;
            y1 = (y == 0) ? Height - 1 : y - 1;
            if (CurrentField[x1, y1])
            {
                n++;
            }
            y1 = (y == Height - 1) ? 0 : y + 1;
            if (CurrentField[x1, y1])
            {
                n++;
            }
            //три справа
            x1 = (x == Width - 1) ? 0 : x + 1;
            y1 = (y == 0) ? Height - 1 : y - 1;
            if (CurrentField[x1, y1])
            {
                n++;
            }
            y1 = y;
            if (CurrentField[x1, y1])
            {
                n++;
            }
            y1 = (y == Height - 1) ? 0 : y + 1;
            if (CurrentField[x1, y1])
            {
                n++;
            }
            return n;
        }
    }
}
