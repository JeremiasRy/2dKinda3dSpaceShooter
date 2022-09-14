using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public interface IGraphics
{
    public int Width { get; set; }
    public int Height { get; set; }

    public char MainSurface { get; set; }
    public char Shadow { get; set; }
}
