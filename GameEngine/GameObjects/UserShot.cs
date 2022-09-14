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
            return;
        Z--;
    }
    public UserShot(int id, int y, int x, int z, IGraphics graphics, int endY, int endX) : base(id, y, x, z, endY, endX, graphics)
    {
    }
}
