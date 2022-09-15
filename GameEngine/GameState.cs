using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public static class GameState
{
    static readonly int _centerHeight = Console.WindowHeight / 2;
    static readonly int _centerWidth = Console.WindowWidth / 2;

    static Random _random = new();
    public static bool PlayerAlive { get; set; }

    static List<IGameObject> _gameObjects = new();
    public static void AddEnemyObject(int id)
    {
        _gameObjects.Add(new Enemy(id,_centerHeight,_centerWidth,1,_random.Next(Console.WindowHeight), _random.Next(Console.WindowWidth)));
    }
    public static void CheckForObjectsOutOfRange()
    {
        List<int> remThese = new();
        foreach(var obj in _gameObjects)
        {
            if (obj.Z == -1 || obj.Z == 101)
                remThese.Add(obj.Id);
        }
        _gameObjects = _gameObjects.Where(obj => !remThese.Any(remObj => remObj == obj.Id)).ToList();
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
