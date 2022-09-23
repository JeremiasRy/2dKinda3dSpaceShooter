using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public class AimCursor : GameObject
{
    readonly SpaceShip _userRef;
    Direction _direction;

    readonly int _maxYDistFromShip = 15;
    readonly int _maxXDistFromShip = 40;
    int _endPointY;
    int _endPointX;
    int? _origPosX;
    int? _origPosY;


    public override void Move(int speed)
    {
        int posMoveY = Y;
        int posMoveX = X;
        if (UserControl)
        {
            _origPosX = X;
            _origPosY = Y;
            switch (_direction)
            {
                case Direction.Up:
                    if (Math.Abs(_userRef.Y - Y) >= _maxYDistFromShip)
                        return;
                    posMoveY = Y - speed;
                    break;
                case Direction.Down:
                    if (Math.Abs(_userRef.Y - Y) >= _maxYDistFromShip)
                        return;
                    posMoveY = Y + speed;
                    break;
                case Direction.Left:
                    if (Math.Abs(_userRef.X - X) >= _maxXDistFromShip)
                        return;
                    posMoveX = X - speed++;
                    break;
                case Direction.Right:
                    if (Math.Abs(_userRef.X - X) >= _maxXDistFromShip)
                        return;
                    posMoveX = X + speed++;
                    break;
            }
            if (posMoveY < 2 || posMoveY > Console.WindowHeight - 2 || posMoveX < 1 || posMoveX > Console.WindowWidth - 2)
                return;
            else
            {
                Y = posMoveY;
                X = posMoveX;
            }
        } else
        {
            switch (_direction)
            {
                case Direction.Up:
                    _endPointX = _userRef.X;
                    _endPointY = _userRef.Y - 4 < 0 ? _userRef.Y + 4 : _userRef.Y - 4;
                    break;
                case Direction.Down:
                    _endPointX = _userRef.X;
                    _endPointY = _userRef.Y + 4 > Console.WindowHeight ? _userRef.Y - 4 : _userRef.Y + 4;
                    break;
                case Direction.Left:
                    _endPointX = _userRef.X - 4 <= 0 ? _userRef.X + 4 : _userRef.X - 4;
                    _endPointY = _userRef.Y;
                    break;
                case Direction.Right:
                    _endPointX = _userRef.X + 4 >= Console.WindowWidth - 1 ? _userRef.X - 4 : _userRef.X + 4;
                    _endPointY = _userRef.Y;
                    break;
            }
            if (_endPointX < X)
                X -= 2;
            else if (_endPointX > X)
                X += 2;
            else
                X = _endPointX;
            if (_endPointY < Y)
                Y -= 1;
            else if (_endPointY > Y)
                Y += 1;
            else
                Y = _endPointY;
        }

    }
    public void ChangeDirection(Direction direction)
    {
        if (_direction == direction) 
            return;
        _direction = direction;

        switch (direction)
        {
            case Direction.Up:
                if (Y == _userRef.Y || Y < _userRef.Y)
                    return;
                Y -= 4;
                break;
            case Direction.Down:
                if (Y == _userRef.Y || Y > _userRef.Y)
                    return;
                Y += 4;
                break;
            case Direction.Left:
                if (X == _userRef.X || X < _userRef.X)
                    return;
                X -= 4;
                break;
            case Direction.Right:
                if (X == _userRef.X || X > _userRef.X)
                    return;
                X += 4;
                break;
        }
        
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

    public AimCursor(int id, IGraphics graphics, SpaceShip userReference) : base(id, graphics)
    {
        _userRef = userReference;
        _direction = Direction.Up;
        X = Console.WindowWidth / 2;
        Y = Console.WindowHeight - 15;
        Z = 75;
        UserControl = false;
        Graphics = graphics;
    }
}

public enum Direction
{
    Up,
    Left,
    Down,
    Right,
}

