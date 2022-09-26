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
        speed += 3;
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
        HitBox.Clear();
        char[][] graphic = Graphics.GetGraphic(Z);
        List<int[]> points = new()
        {
        GameState.CalculatePosition(_endPointY, _endPointX, _startPointY, _startPointX, Z + 12),
        GameState.CalculatePosition(_endPointY, _endPointX, _startPointY, _startPointX, Z + 8),
        GameState.CalculatePosition(_endPointY, _endPointX, _startPointY, _startPointX, Z + 4),
        };
        for (int i = 0; i < Graphics.Height; i++)
        {
            for (int j = 0; j < Graphics.Width; j++)
            {
                if (!CheckIfOnConsoleWindow(Top + i, Left + j))
                    return;

                ScreenBuffer.Draw(graphic[i][j], Top + i, Left + j);
                HitBox.Add(new int[2] { Top + i, Left + j });

                for (int shadow = 2; shadow >= 0; shadow--)
                {
                    int[] coordinatePoints = points.ElementAt(shadow);
                    if (CheckIfOnConsoleWindow(ShadowTop(coordinatePoints[0]) - i, ShadowLeft(coordinatePoints[1]) + j))
                        ScreenBuffer.Draw(CharacterArrays.GetShadow(shadow), coordinatePoints[0] - i, coordinatePoints[1] + j);   
                }
            }
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
