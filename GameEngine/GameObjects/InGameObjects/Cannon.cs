using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;

namespace GameEngine;

public class Cannon : GameObject
{
    AimCursor _aimCursorRef;
    public Cannon(Vertical y, Horizontal x, int id, IGraphics graphics, AimCursor aimCursor) : base(id, graphics)
    {
        _aimCursorRef = aimCursor;
        X = x == Horizontal.Left ? 0 : Console.WindowWidth - 1;
        Y = y == Vertical.Top ? 0 : Console.WindowHeight - 1;
    }
}

public enum Horizontal
{
    Left,Right
}
public enum Vertical
{
    Top,Bottom
}
