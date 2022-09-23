using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public class GameObject : IGameObject
{
    public int Id { get; set; }
    public int Y { get; set; }
    public int X { get; set; }
    public int Z { get; set; }
    public IGraphics Graphics { get; set; }

    public bool UserControl { get; set; }
    public static bool CheckIfOnConsoleWindow(int y, int x) => y > 0 && x > 0 && y < Console.WindowHeight - 1 && x < Console.WindowWidth - 1;
    public int Top => Y - Graphics.Height / 2;
    public int Left => X - Graphics.Width / 2;
    
    public List<int[]> HitBox = new();

    public static List<int[]> EmptyCenterLine { get
        {
            List<int[]> _emptyCenterLine = new();
            int startY = Console.WindowHeight / 2 - 8;
            int startX = Console.WindowWidth / 2 - 25;

            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    if (i == 0)
                        _emptyCenterLine.Add(new int[2] { startY + i, startX + j });
                    else if (i != 0 && i != 15 && (j == 0 || j == 49))
                        _emptyCenterLine.Add(new int[2] { startY + i, startX + j });
                    else if (i == 15)
                        _emptyCenterLine.Add(new int[2] { startY + i, startX + j });
                }
            }
            return _emptyCenterLine;
        } }

    public virtual void Draw()
    {

    }
    public virtual void Move(int speed = 1)
    {

    }

    public GameObject(int id, IGraphics graphics)
    {
        Id = id;
        Graphics = graphics;
    }
}
