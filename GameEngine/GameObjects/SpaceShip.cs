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

    public void ParseCoordinateInput(int yDirection, int xDirection, int speed)
    {
        if (yDirection == 0)
        {
            _moveToY = Y;
            _moveToX = xDirection < 0 ? X - speed : X + speed;
        }
        else if (xDirection == 0)
        {
            _moveToX = X;
            _moveToY = yDirection < 0 ? Y - speed : Y + speed;
        }
        if (CheckIfOnConsoleWindow(_moveToY - Graphics.Height / 2, _moveToX - Graphics.Width / 2) && CheckIfOnConsoleWindow(_moveToY + Graphics.Height / 2, _moveToX + Graphics.Width / 2))
            Move();
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
                if (CheckIfOnConsoleWindow(Top + i, Left + j))
                    ScreenBuffer.Draw('#', Top + i, Left + j);
            }
        }
        
    }
    public SpaceShip(int id, IGraphics graphics) : base(id, graphics) 
    {
        X = Console.WindowWidth / 2;
        Y = Console.WindowHeight - 10;
        Z = 100;
        UserControl = true;
    }
}
