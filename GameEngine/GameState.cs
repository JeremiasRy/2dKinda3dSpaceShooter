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
    static public int EnemiesDestroyed { get; set; } = 0;
    static public int EnemiesEscaped { get; set; } = 0;
    readonly static AimCursor _aimCursor = new (0, new AimCursorGraphics());
    readonly static Cannon _cannonLeft = new(Place.Left, 1, new CannonGraphics(), _aimCursor);
    readonly static Cannon _cannonRight = new(Place.Right, 2, new CannonGraphics(), _aimCursor);
    static bool _leftShot = true;

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
    public static void AddEnemyObject(int id) => _gameObjects.Add(new Enemy(id, new EnemyGraphics()));
    public static void AddIllusionParticle(int id) => _gameObjects.Add(new IllusionParticle(id, new IllusionGraphics()));
    public static void AddHumanPlayer()
    {
        _gameObjects.Add(_aimCursor);
        _gameObjects.Add(_cannonLeft);
        _gameObjects.Add(_cannonRight);
    } 
    public static void MovePlayer(int y, int x, int speed) => _aimCursor.ParseCoordinateInput(y, x, speed);
    public static void AimCursorControlToComputer() => _aimCursor.UserControl = false;
    public static void PlayerShoot(int id)
    {

        if (_leftShot)
        {
            _gameObjects.Add(new UserShot(id, _cannonLeft.Y, _cannonLeft.X, 100, _aimCursor.Y, _aimCursor.X, new UserShotGraphics(CharacterArrays.GetShadow(4))));
            _leftShot = false;
        } else
        {
            _gameObjects.Add(new UserShot(id, _cannonRight.Y, _cannonRight.X, 100, _aimCursor.Y, _aimCursor.X, new UserShotGraphics(CharacterArrays.GetShadow(4))));
            _leftShot = true;
        }

    } 
    public static void CheckForHit()
    {
        var enemys = _gameObjects.Where(obj => obj is Enemy).ToList();
        var shots = _gameObjects.Where(obj => obj is UserShot).ToList();
        List<int> collisions = new List<int>();

        if (shots.Count == 0)
            return;

        foreach (var enemy in enemys)
        {
            if (shots.Any(shot => Math.Abs(shot.Z - enemy.Z) < 75))
            {
                var hits = shots.Where(shot => Math.Abs(shot.Z - enemy.Z) < 75);
                foreach (var hit in hits)
                {
                    foreach (int[] enemyHitBox in enemy.HitBox)
                    {
                        foreach (int[] shotHitBox in hit.HitBox)
                        {
                            if (enemyHitBox[0] == shotHitBox[0] && enemyHitBox[1] == shotHitBox[1])
                            {
                                collisions.Add(enemy.Id);
                                collisions.Add(hit.Id);
                            }

                        }
                    }

                }

            }
        }
        if (collisions.Count > 0)
        {
            _gameObjects = _gameObjects.Where(obj => !collisions.Any(collisionObj => collisionObj == obj.Id)).ToList();
            EnemiesDestroyed++;
        }

    }
    public static void CheckForObjectsOutOfRange()
    {
        List<int> remThese = new();
        foreach(var obj in _gameObjects)
        {
            if (obj.Z == -1 || obj.Z == 101)
                remThese.Add(obj.Id);
        }
        EnemiesEscaped += _gameObjects.Where(obj => obj is Enemy && remThese.Any(remObj => remObj == obj.Id)).Count();
        _gameObjects = _gameObjects.Where(obj => !remThese.Any(remObj => remObj == obj.Id)).ToList();
    }
    public static void GameTick()
    {
        foreach (var obj in _gameObjects)
        {
            if (!obj.UserControl)
                obj.Move();           
        }
        CheckForHit();
        CheckForObjectsOutOfRange();
            
        _gameObjects.Where(x => x is IllusionParticle).ToList().ForEach(obj => obj.Draw());

        _gameObjects.Where(x => x is not IllusionParticle).OrderBy(obj => obj.Z).ToList().ForEach(obj => obj.Draw());
    }
}
