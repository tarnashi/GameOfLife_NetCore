using Core.Abstract;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class GameService : IGameService
    {
        public Field GetEmptyField(int x, int y, bool isBordered)
        {
            Field field;
            if (isBordered == true)
            {
                field = new BorderedField(x, y);
            }
            else
            {
                field = new LoopbackField(x, y);
            }
            return field;
        }
    }
}
