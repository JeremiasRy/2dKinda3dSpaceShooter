using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;

namespace GameEngine;

public class UserShot : GameObject
{
    readonly int _startPointY;
    readonly int _startPointX;
    readonly int _endPointY;
    readonly int _endPointX;
    public override void Move()
    {
        if (Z - 2 < 0)
        {
            Z = -1;
            return;
        }
        Z -= 2;
    }
    public override void Draw()
    {
        var positions = GameState.CalculatePosition(_endPointY, _endPointX, _startPointY, _startPointX, Z);
        Y = positions[0];
        X = positions[1];
        ScreenBuffer.Draw('a', Y, X);
    }
    public UserShot(int id, int y, int x, int z, int endY, int endX, IGraphics graphics) : base(id, graphics)
    {
        Id = id;
        Y = y;
        X = x;
        Z = z;
        _startPointY = y;
        _startPointX = x;
        _endPointY = endY;
        _endPointX = endX;
        UserControl = false;
    }
}
