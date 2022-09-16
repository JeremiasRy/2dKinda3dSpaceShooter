using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public interface IGameObject
{
    public int Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    public bool UserControl { get; set; }

    public IGraphics Graphics { get; set; }

    public void Draw();
    public void Move();
}
