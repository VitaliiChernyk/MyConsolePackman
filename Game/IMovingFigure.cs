using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface IMovingFigure
    {
        char getFigure { get; }
        int XFigure { get; set; }
        int YFigure { get; set; }
        int XFigurePrevious { get; set; }
        int YFigurePrevious { get; set; }
    }
}
