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
    readonly int _speed;

    Random _random = new();
    public override void Move()
    {
        if (Z + _speed > 100)
        {
            Z = 101;
            return;
        }
        Z += _speed;
        var positions = GameState.CalculatePosition(_startPointY, _startPointX, _endPointY, _endPointX, Z);
        Y = positions[0];
        X = positions[1];
    }
    public override void Draw()
    {
        char[][] graphic = Graphics.GetGraphic(Z);
        for(int i = 0; i < graphic.Length; i++)
        {
            for(int j = 0; j < graphic[i].Length; j++)
            {
                if (CheckIfOnConsoleWindow(Top + i, Left + j))
                    ScreenBuffer.Draw(graphic[i][j], Top + i, Left + j);
            }
        }

    }
    public Enemy(int id, IGraphics graphics) : base(id, graphics)
    {
        Id = id;
        Y = GameState._centerHeight;
        X = GameState._centerWidth;
        Z = 1;
        _startPointY = GameState._centerHeight;
        _startPointX = GameState._centerWidth;
        _endPointY = _random.Next(Console.WindowHeight);
        _endPointX = _random.Next(Console.WindowWidth);
        UserControl = false;
        _speed = _random.Next(1, 3);
    }
}
