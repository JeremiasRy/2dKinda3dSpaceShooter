using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public class SpaceShip : GameObject
{
    int _moveToX;
    int _moveToY;

    public void ParseCoordinateInput(int yChange, int xChange)
    {
        if(CheckIfOnConsoleWindow(yChange + Y, xChange + X))
        {
            _moveToX = xChange + X;
            _moveToY = yChange + Y;
            Move();
        };
    }
    public override void Move()
    {
        Y = _moveToY;
        X = _moveToX;
    }
    public override void Draw()
    {
        for (int i = 0; i < Graphics.Height; i++)
        {
            for (int j = 0; j < Graphics.Width; j++)
            {
                if (CheckIfOnConsoleWindow(Y + i, X + j))
                    ScreenBuffer.Draw(Graphics.MainSurface, Y + i, X + j);
            }
        }
        
    }
    public SpaceShip(IGraphics graphics) : base(graphics) 
    {
        X = Console.WindowWidth / 2;
        Y = Console.WindowHeight - 10;
        Z = 100;
        UserControl = true;
    }
}
