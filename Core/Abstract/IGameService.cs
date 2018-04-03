using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstract
{
    public interface IGameService
    {
        Field GetEmptyField(int x, int y, bool flagBordered);
    }
}
