using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public class UserShotGraphics : IGraphics
{
    public int Width { get; set; } = 3;
    public int Height { get; set; } = 3;
    public char MainSurface { get; set; } = '\u2588';
    public char Shadow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public char[][] GetGraphic(int level)
    {
        throw new NotImplementedException();
    }
}
