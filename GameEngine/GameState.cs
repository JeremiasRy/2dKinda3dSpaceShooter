using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public static class GameState
{
    static Random _random = new();
    public static bool PlayerAlive { get; set; }

    static List<IGameObject> _gameObjects = new();

    public static int[] CalculateTopLeft(int y, int x, int height, int width)
    {
        return new int[2] { y - height / 2, x - width / 2 };
    }

    public static void AddEnemyObject(int id)
    {
        _gameObjects.Add(new Enemy(
            id,
            Console.WindowHeight / 2,
            Console.WindowWidth / 2,
            1,
            _random.Next(Console.WindowHeight),
            _random.Next(Console.WindowWidth),
            new EnemyGraphics()));
    }

    public static void CheckForObjectsOutOfRange()
    {
    }
    public static void GameTick()
    {
        foreach (var obj in _gameObjects)
        {
            obj.Move();
        }
        CheckForObjectsOutOfRange();
        foreach (var obj in _gameObjects)
            obj.Draw();
    }
}
