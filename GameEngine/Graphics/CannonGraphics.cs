using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public class CannonGraphics : IGraphics
{
    public int Width => _graphic[0].Length;
    public int Height => _graphic.Length;

    readonly char[][] _graphic;
    public char[][] GetGraphic(int level)
    {
        return Array.Empty<char[]>();
    }
    public CannonGraphics()
    {
        _graphic = Array.Empty<char[]>();
    }
}
