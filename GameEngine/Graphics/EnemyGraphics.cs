using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public class EnemyGraphics : IGraphics
{
    public int Width { get; set; } = 20;
    public int Height { get; set; } = 10;
    public char MainSurface { get; set; } = '\u2591';
    public char Shadow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
