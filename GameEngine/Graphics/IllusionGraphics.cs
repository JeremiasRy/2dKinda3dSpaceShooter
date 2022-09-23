using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public class IllusionGraphics : IGraphics
{
    public int Width => _graphic[0].Length;
    public int Height => _graphic.Length;

    readonly char[][] _graphic;
    public char[][] GetGraphic(int level)
    {
        _graphic[0][0] = CharacterArrays.GetParticle(level);
        return _graphic;
    }

    public IllusionGraphics()
    {
        _graphic = new char[1][];
        _graphic[0] = new char[1];
    }
}
