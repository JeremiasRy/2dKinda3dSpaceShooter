using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public class IllusionGraphics : IGraphics
{
    public int Width { get; set; } = 1;
    public int Height { get; set; } = 1;
    public char MainSurface { get; set; }
    public char Shadow { get; set; }

    public char[][] GetGraphic(int level)
    {
        throw new NotImplementedException();

    }
}
