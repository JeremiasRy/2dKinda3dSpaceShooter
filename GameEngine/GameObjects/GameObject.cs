using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public class GameObject : IGameObject
{
    public int Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    public IGraphics Graphics { get; set; }

    public bool UserControl { get; set; }

    public static bool CheckIfOnConsoleWindow(int y, int x) => y > 0 && x > 0 && y < Console.WindowHeight - 1 && x < Console.WindowWidth - 1;
    public int Top => Y - Graphics.Height / 2;
    public int Left => X - Graphics.Width / 2;
    public virtual void Draw()
    {

    }
    public virtual void Move()
    {

    }

    public GameObject(IGraphics graphics)
    {
        Graphics = graphics;
    }
}
