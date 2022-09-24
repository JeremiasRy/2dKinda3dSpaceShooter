using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public class AimCursor : GameObject
{
    int _moveToX;
    int _moveToY;

    public void ParseCoordinateInput(int yDirection, int xDirection, int speed)
    {
        if (yDirection == 0)
        {
            _moveToY = Y;
            switch (xDirection)
            {
                case < 0: _moveToX = X - speed;
                    break;
                case > 0: _moveToX = X + speed;
                    break;
            }
        }
        else if (xDirection == 0)
        {
            _moveToX = X;
            switch (yDirection)
            {
                case < 0: _moveToY = Y - speed;
                    break;
                case > 0: _moveToY = Y + speed;
                    break;
            }
        }
        if (CheckIfOnConsoleWindow(_moveToY - Graphics.Height / 2, _moveToX - Graphics.Width / 2) && CheckIfOnConsoleWindow(_moveToY + Graphics.Height / 2, _moveToX + Graphics.Width / 2))
            Move(speed);
    }
    public override void Move(int speed)
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
                    ScreenBuffer.Draw(Graphics.GetGraphic(1)[i][j], Top + i, Left + j);
            }
        }
    }
    public AimCursor(int id, IGraphics graphics) : base(id, graphics) 
    {
        X = Console.WindowWidth / 2;
        Y = Console.WindowHeight / 2;
        Z = 100;
        UserControl = true;
    }
}
