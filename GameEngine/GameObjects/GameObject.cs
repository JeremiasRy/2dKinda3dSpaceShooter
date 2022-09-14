using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public class GameObject : IGameObject
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public IGraphics Graphics;

    public virtual void Draw()
    {
        throw new NotImplementedException();
    }

    public virtual void Move()
    {
        throw new NotImplementedException();
    }

    public GameObject(int y, int x, int z, IGraphics graphics)
    {
        X = x;
        Y = y;
        Z = z;
        Graphics = graphics;
    }
}
