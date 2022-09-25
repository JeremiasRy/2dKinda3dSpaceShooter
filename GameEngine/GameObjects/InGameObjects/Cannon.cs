using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public class Cannon : GameObject
{
    AimCursor _aimCursorRef;
    public Cannon(Place placement, int id, IGraphics graphics, AimCursor aimCursor) : base(id, graphics)
    {
        X = placement == Place.Left ? 0 : Console.WindowWidth - 1;
        Y = Console.WindowHeight / 2;
        _aimCursorRef = aimCursor;
    }
}

public enum Place
{
    Left,Right
}
