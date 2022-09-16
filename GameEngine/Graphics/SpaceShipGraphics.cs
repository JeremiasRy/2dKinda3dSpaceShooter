using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;
public class SpaceShipGraphics : IGraphics
{
    public int Width { get; set; } = 5;
    public int Height { get; set; } = 3;
    public char MainSurface { get; set; } = '#';
    public char Shadow { get ; set; }
}
