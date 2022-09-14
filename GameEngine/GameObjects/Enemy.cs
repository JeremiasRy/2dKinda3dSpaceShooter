using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;

namespace GameEngine;

public class Enemy : MovesOnGameTick
{
    public override void Move()
    {
        if (Z + 1 > 100)
            return;
        Z++;
    }
    public override void Draw()
    {
        float _percent = (float)Z / 100;
        int height = (int)(Graphics.Height * _percent);
        int width = (int)(Graphics.Width * _percent);

        int[] topLeft = GameState.CalculateTopLeft(Y, X, height, width);

        for (int iY = 0; iY < height; iY++)
        {
            for (int iX = 0; iX < width; iX++)
            {
                if (!(topLeft[0] + iY < 0 || topLeft[1] + iX < 0 || topLeft[0] + iY > Console.WindowHeight || topLeft[1] + iX > Console.WindowHeight))
                    continue;
                ScreenBuffer.Draw(Graphics.MainSurface, topLeft[0] + iY, topLeft[1] + iX);
            }
        }
    }
    public Enemy(int id, int y, int x, int z, int endX, int endY, IGraphics graphics) : base(id,y,x,z, endX, endY, graphics)
    {
        
    }
}
