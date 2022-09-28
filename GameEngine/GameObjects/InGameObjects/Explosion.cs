using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public class Explosion : GameObject
{
    readonly List<int[]> _areaOfExplosion;
    public override void Draw()
    {
        foreach (var pos in _areaOfExplosion)
            ScreenBuffer.Draw(Graphics.GetGraphic(0)[0][0], pos[0], pos[1]);
    }
    public Explosion(List<int[]> area, IGraphics graphics, int id, int z) : base(id, graphics)
    {
        _areaOfExplosion = area;
        Z = z;
        UserControl = true;
    }
}
