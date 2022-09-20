using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public class AimCursorGraphics : IGraphics
{
    public int Width { get; set; }
    public int Height { get; set; }
    public char MainSurface { get; set; }

    public char[][] GetGraphic(int level)
    {
        throw new NotImplementedException();
    }
}
