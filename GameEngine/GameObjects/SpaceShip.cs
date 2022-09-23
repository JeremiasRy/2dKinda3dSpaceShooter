using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public class SpaceShip : GameObject
{
    AimCursor? _aimCursorRef;
    int _moveToX;
    int _moveToY;

    public void ParseCoordinateInput(int yDirection, int xDirection, int speed)
    {
        if (yDirection == 0)
        {
            _moveToY = Y;
            switch (xDirection)
            {
                case < 0:
                    {
                        _moveToX = X - speed;
                        if (_aimCursorRef is not null)
                        {
                            _aimCursorRef.ChangeDirection(Direction.Left);
                            _aimCursorRef.Move(speed + 1);

                        }
                    }
                    break;
                case > 0:
                    {
                        _moveToX = X + speed;
                        if (_aimCursorRef is not null)
                        {
                            _aimCursorRef.ChangeDirection(Direction.Right);
                            _aimCursorRef.Move(speed + 1);
                        }
                            
                    }
                    break;
            }
        }
        else if (xDirection == 0)
        {
            _moveToX = X;
            switch (yDirection)
            {
                case < 0:
                    {
                        _moveToY = Y - speed;
                        if (_aimCursorRef is not null)
                        {
                            _aimCursorRef.ChangeDirection(Direction.Up);
                            _aimCursorRef.Move(speed + 1);
                        }
                            
                    }
                    break;
                case > 0:
                    {
                        _moveToY = Y + speed;
                        if (_aimCursorRef is not null)
                        {
                            _aimCursorRef.ChangeDirection(Direction.Down);
                            _aimCursorRef.Move(speed +1);
                        }
                            
                    }
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
                    ScreenBuffer.Draw('#', Top + i, Left + j);
            }
        }
    }
    public void AddAimCursorRef(AimCursor aimCursor) => _aimCursorRef = aimCursor;
    public SpaceShip(int id, IGraphics graphics) : base(id, graphics) 
    {
        X = Console.WindowWidth / 2;
        Y = Console.WindowHeight - 10;
        Z = 100;
        UserControl = true;
    }
}
