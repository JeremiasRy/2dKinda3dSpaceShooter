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
    readonly static SpaceShip _humanPlayer = new(new SpaceShipGraphics());

    static List<IGameObject> _gameObjects = new();
    public static int[] CalculatePosition(int startPointY, int startPointX, int endPointY, int endPointX, int z)
    {
        bool yUp = startPointY > endPointY;
        bool xLeft = startPointX > endPointX;
        int yDifference = yUp ? startPointY - endPointY : endPointY - startPointY;
        int xDifference = xLeft ? startPointX - endPointX : endPointX - startPointX;

        float _percent = (float)z / 100;

        return new int[2] { 
            yUp ? (int)(startPointY - yDifference * _percent) : (int)(startPointY + yDifference * _percent), 
            xLeft ? (int)(startPointX - xDifference * _percent) : (int)(startPointX + xDifference * _percent)  };
    }
    public static void AddEnemyObject(int id)
    {
        _gameObjects.Add(new Enemy(id,_centerHeight,_centerWidth,1,_random.Next(Console.WindowHeight), _random.Next(Console.WindowWidth), new EnemyGraphics(1)));
    }
    public static void AddHumanPlayer()
    {
        _gameObjects.Add(_humanPlayer);
    }
    public static void MovePlayer(int y, int x)
    {
        _humanPlayer.ParseCoordinateInput(y, x);
    }
    public static void PlayerShoot(int id)
    {
        _gameObjects.Add(new UserShot(id, _humanPlayer.Y, _humanPlayer.X, 100, _centerHeight, _centerWidth, new UserShotGraphics()));
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
            if (!obj.UserControl)
                obj.Move();           
        }
        CheckForObjectsOutOfRange();
        _gameObjects.OrderBy(obj => obj.Z).ToList().ForEach(obj => obj.Draw());
    }
}
