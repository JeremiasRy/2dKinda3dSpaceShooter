using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;

namespace GameEngine;

public class Cannon : GameObject
{
    readonly AimCursor _aimCursorRef;
    readonly Horizontal horizontal;
    readonly Vertical vertical;
    char _drawMe;
    List<int[]> LineToAimCursor()
    {
        List<int[]> line = new();
        var yDifference = Math.Abs(Y - _aimCursorRef.Y);
        var xDistance = Math.Abs(X - _aimCursorRef.X);
        for (int xI = 0; xI < xDistance; xI++)
        {
            int[] pos = new int[2];
            pos[0] = vertical == Vertical.Top ? yDifference * Math.Abs(X + xI - X) / xDistance + Y : Math.Abs(yDifference * Math.Abs(X + xI - X) / xDistance - Y);
            pos[1] = horizontal == Horizontal.Left ? xI + X : X - xI;
            line.Add(pos);
        }
        return line;    
    }

    public override void Draw()
    {
        var positions = LineToAimCursor();
        var percentCount = (int)positions.Count * 0.1;
        ScreenBuffer.Draw(_drawMe, Y, X);
        for (int i = 0; i < percentCount; i++)
        {
            var pos = positions[i];
            if (CheckIfOnConsoleWindow(pos[0] - 1, pos[1]) && CheckIfOnConsoleWindow(pos[0] + 1, pos[1]))
            {
                ScreenBuffer.Draw(_drawMe, pos[0] - 1, pos[1]);
                ScreenBuffer.Draw(_drawMe, pos[0] + 1, pos[1]);
            }
            else
            {
                ScreenBuffer.Draw(_drawMe, pos[0], pos[1]);
            }

        }
            
    }
    public Cannon(Vertical y, Horizontal x, int id, IGraphics graphics, AimCursor aimCursor) : base(id, graphics)
    {
        _aimCursorRef = aimCursor;
        X = x == Horizontal.Left ? 0 : Console.WindowWidth - 1;
        Y = y == Vertical.Top ? 0 : Console.WindowHeight - 1;
        if ((x == Horizontal.Left && y == Vertical.Top) || (x == Horizontal.Right && y == Vertical.Bottom))
            _drawMe = (char)92;
        else
            _drawMe = '/';
        vertical = y;
        horizontal = x;
        UserControl = true;
    }
}

public enum Horizontal
{
    Left,Right
}
public enum Vertical
{
    Top,Bottom
}
