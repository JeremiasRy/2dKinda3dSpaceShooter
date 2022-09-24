using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public class AimCursorGraphics : IGraphics
{
    public int Width => _graphic[0].Length;
    public int Height => _graphic[1].Length;

    readonly char[][] _graphic;

    public char[][] GetGraphic(int level) => _graphic;

    public AimCursorGraphics()
    {
        _graphic = new char[3][];
        _graphic[0] = new char[3] { ' ', '|', ' ' };
        _graphic[1] = new char[3] { '<', ' ', '>' };
        _graphic[2] = new char[3] { ' ', '|', ' ' };
    }
}
