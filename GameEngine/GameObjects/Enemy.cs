using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;

namespace GameEngine;

public class Enemy : GameObject
{
    readonly int _startPointY;
    readonly int _startPointX;
    readonly int _endPointY;
    readonly int _endPointX;
    public override void Move()
    {
        if (Z + 1 > 100)
        {
            Z = 101;
            return;
        }
        Z++;
        var positions = GameState.CalculatePosition(_startPointY, _startPointX, _endPointY, _endPointX, Z);
        Y = positions[0];
        X = positions[1];
    }
    public override void Draw()
    {
        float depth = (float)Z / 100;
        int height = (int)(Graphics.Height * depth);
        int width = (int)(Graphics.Width * depth);

        for (int iY = 0; iY < height; iY++)
        {
            for (int iX = 0; iX < width; iX++)
            {
                if (CheckIfOnConsoleWindow(Top+ iY, Left+ iX))
                    ScreenBuffer.Draw(Graphics.MainSurface, Top+ iY, Left+ iX);
            }
        }
    }
    public Enemy(int id, int y, int x, int z, int endY, int endX, IGraphics graphics) : base(graphics)
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
