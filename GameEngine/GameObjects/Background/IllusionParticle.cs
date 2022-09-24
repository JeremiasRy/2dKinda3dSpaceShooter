using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public class IllusionParticle : GameObject
{
    readonly Random _random = new();
    readonly int _startPointY;
    readonly int _startPointX;
    readonly int _endY;
    readonly int _endX;

    public override void Move(int speed)
    {
        speed += _random.Next(1, 4);
        if (Z + speed > 100)
        {
            Z = 101;
            return;
        }
        Z += speed;
        var positions = GameState.CalculatePosition(_startPointY, _startPointX, _endY, _endX, Z);
        Y = positions[0];
        X = positions[1];
    }

    public override void Draw()
    {
        if (CheckIfOnConsoleWindow(Y, X))
        {
            int grayness = Z < 15 ? 0 : Z / 15;
            ScreenBuffer.Draw(Graphics.GetGraphic(grayness)[0][0], Y, X);
        }
    }
    public IllusionParticle(int id, IGraphics graphics) : base(id, graphics)
    {
        UserControl = false;
        int[] startPos = EmptyCenterLine.ElementAt(_random.Next(EmptyCenterLine.Count - 1));

        Y = startPos[0];
        X = startPos[1];
        Z = 1;
        _startPointY = startPos[0];
        _startPointX = startPos[1];

        if (X == Console.WindowWidth / 2 - 25 && Y >= Console.WindowHeight / 2 - 8 && Y <= Console.WindowHeight / 2 + 7) //Muuta kaikki arvot suhteellisiksi niin voi toimia muillakin koneilla
        {
            _endY = Y < Console.WindowHeight / 2 ? _random.Next(Console.WindowHeight / 2) : _random.Next(Console.WindowHeight / 2, Console.WindowHeight);
            _endX = 0;
        } else if (X == Console.WindowWidth / 2 + 24 && Y >= Console.WindowHeight / 2 - 8 && Y <= Console.WindowHeight / 2 + 7)
        {
            _endY = Y < Console.WindowHeight / 2 ? _random.Next(Console.WindowHeight / 2) : _random.Next(Console.WindowHeight / 2, Console.WindowHeight);
            _endX = Console.WindowWidth;
        } else if (X >= Console.WindowWidth / 2 - 25 && X <= Console.WindowWidth / 2 + 24 && Y == Console.WindowHeight / 2 - 8)
        {
            _endY = 0;
            _endX = X < Console.WindowWidth / 2 ? _random.Next(Console.WindowWidth / 2) : _random.Next(Console.WindowWidth / 2, Console.WindowWidth);
        } else
        {
            _endY = Console.WindowHeight;
            _endX = X < Console.WindowWidth / 2 ? _random.Next(Console.WindowWidth / 2) : _random.Next(Console.WindowWidth / 2, Console.WindowWidth);
        }
    }
}
