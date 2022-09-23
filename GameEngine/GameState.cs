using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public static class GameState
{
    
    static public readonly int CenterHeight = Console.WindowHeight / 2;
    static public readonly int CenterWidth = Console.WindowWidth / 2;
    static public int Tick { get; set; }
    public static bool PlayerAlive { get; set; }
    readonly static SpaceShip _humanPlayer = new(0, new SpaceShipGraphics());
    readonly static AimCursor _aimCursor = new (1, new AimCursorGraphics(), _humanPlayer);

    static List<GameObject> _gameObjects = new();
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
        _gameObjects.Add(new Enemy(id, new EnemyGraphics()));
    }
    public static void AddIllusionParticle(int id)
    {
        _gameObjects.Add(new IllusionParticle(id, new IllusionGraphics()));
    }
    public static void AddHumanPlayer()
    {
        _gameObjects.Add(_humanPlayer);
        _gameObjects.Add(_aimCursor);
        _humanPlayer.AddAimCursorRef(_aimCursor);
    }
    public static void MovePlayer(int y, int x, int speed)
    {
        _aimCursor.UserControl = true;
        _humanPlayer.ParseCoordinateInput(y, x, speed);
    }
    public static void AimCursorControlToComputer() => _aimCursor.UserControl = false;
    public static void PlayerShoot(int id)
    {
        _gameObjects.Add(new UserShot(id, _humanPlayer.Y, _humanPlayer.X, 100, _aimCursor.Y, _aimCursor.X, new UserShotGraphics()));
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
            
        _gameObjects.Where(x => x is IllusionParticle).ToList().ForEach(obj => obj.Draw());

        _gameObjects.Where(x => x is not IllusionParticle).OrderBy(obj => obj.Z).ToList().ForEach(obj => obj.Draw());
    }
}
