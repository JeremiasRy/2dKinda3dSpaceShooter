using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public interface IGraphics
{
    public int Width { get; }
    public int Height { get; }
    public char[][] GetGraphic(int level);
}
