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

    int ShadowTop(int y) => y - Graphics.Height / 2;
    int ShadowLeft(int x) => x - Graphics.Width / 2;
    public override void Move(int speed)
    {
        speed += 4;
        if (Z - speed < 0)
        {
            Z = -1;
            return;
        }
        Z -= speed;
        var positions = GameState.CalculatePosition(_endPointY, _endPointX, _startPointY, _startPointX, Z);
        Y = positions[0];
        X = positions[1];
    }
    public override void Draw()
    {
        char[][] graphic = Graphics.GetGraphic(Z);
        for (int i = 0; i < Graphics.Height; i++)
        {
            for (int j = 0; j < Graphics.Width; j++)
            {
                if (CheckIfOnConsoleWindow(Top + i, Left + j))
                    ScreenBuffer.Draw(graphic[i][j], Top + i, Left + j);
            }
        }
        int tempZ = Z + 5;

        for (int shadow = 3; shadow >= 0; shadow--)
        {
            var positions = GameState.CalculatePosition(_endPointY, _endPointX, _startPointY, _startPointX, tempZ);
            for (int i = 0; i < Graphics.Height; i++)
            {
                for(int j = 0; j < Graphics.Width; j++)
                {
                    if (CheckIfOnConsoleWindow(ShadowTop(positions[0] + i), ShadowLeft(positions[1] + j)))
                        ScreenBuffer.Draw(CharacterArrays.GetShadow(shadow), ShadowTop(positions[0]) + i, ShadowLeft(positions[1]) + j);
                }
            }
            tempZ += 5;
        }

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
