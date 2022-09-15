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
        {
            Z = 101;
            return;
        }
        Z++;
        Y = Trajectory[Z][0];
        X = Trajectory[Z][1];
    }
    public override void Draw()
    {
        float depth = (float)Z / 100;
        int height = (int)(Graphics.Height * depth);
        int width = (int)(Graphics.Width * depth);

        for (int iY = 0; iY < height; iY++)
        {
            for (int iX = 0; iX < width; iX++)
            {
                if (CheckIfOnConsoleWindow(Top+ iY, Left+ iX))
                    ScreenBuffer.Draw(Graphics.MainSurface, Top+ iY, Left+ iX);
            }
        }
    }
    public Enemy(int id, int y, int x, int z, int endY, int endX)
    {
        Id = id;
        Y = y;
        X = x;
        Z = z;
        CalculateTrajectory(endY, endX);
        Graphics = new EnemyGraphics(1);
    }
}
