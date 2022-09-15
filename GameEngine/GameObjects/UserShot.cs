using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;

namespace GameEngine;

public class UserShot : MovesOnGameTick
{
    public override void Move()
    {
        if (Z - 1 < 0)
        {
            Z = -1;
            return;
        }
        Z--;
    }
    public UserShot(int id, int y, int x, int z, int endY, int endX, IGraphics graphics)
    {
    }
}
