using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public class ExplosionGraphics : IGraphics
{
    public int Width => 1;
    public int Height => 1;
    static readonly GraphicPulse _pulse = new(5, 4);
    char _element => CharacterArrays.GetShadow(_pulse.Index());
    char[][] _graphic = Array.Empty<char[]>();

    public char[][] GetGraphic(int level)
    {
        _graphic = new char[1][];
        _graphic[0] = new char[1] { _element };
        return _graphic;
    }
}
