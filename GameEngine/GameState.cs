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

    static public bool OnTarget => EnemiesOnMap.Any(enemy => enemy.HitBox.Any(ehbYX => _aimCursor.HitBox.Any(cursorYX => ehbYX[0] == cursorYX[0] && ehbYX[1] == cursorYX[1])));
    static public int Tick { get; set; }
    public static bool PlayerAlive { get; set; }
    private static int _shotTick;
    public static bool ShotsFired => Tick - _shotTick < 5;
    static public int EnemiesDestroyed { get; set; } = 0;
    static public int EnemiesEscaped { get; set; } = 0;
    readonly static AimCursor _aimCursor = new (0, new AimCursorGraphics());
    readonly static Cannon _cannonTopLeft = new(Vertical.Top, Horizontal.Left, 1, new CannonGraphics(), _aimCursor);
    readonly static Cannon _cannonTopRight = new(Vertical.Top, Horizontal.Right, 2, new CannonGraphics(), _aimCursor);
    readonly static Cannon _cannonBottomLeft = new(Vertical.Bottom, Horizontal.Left, 3, new CannonGraphics(), _aimCursor);
    readonly static Cannon _cannonBottomRight = new(Vertical.Bottom, Horizontal.Right, 4, new CannonGraphics(), _aimCursor);
    static int _shot = 0;

    static List<GameObject> _gameObjects = new();
    static List<GameObject> _cannons = new();
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
    public static IEnumerable<GameObject>EnemiesOnMap => _gameObjects.Where(x => x is Enemy);
    public static void AddEnemyObject(int id) => _gameObjects.Add(new Enemy(id, new EnemyGraphics()));
    public static void AddIllusionParticle(int id) => _gameObjects.Add(new IllusionParticle(id, new IllusionGraphics()));
    public static void AddHumanPlayer()
    {
        _gameObjects.Add(_aimCursor);
        _gameObjects.Add(_cannonTopLeft);
        _gameObjects.Add(_cannonTopRight);
        _gameObjects.Add(_cannonBottomLeft);
        _gameObjects.Add(_cannonBottomRight);
        _cannons = _gameObjects.Where(x => x is Cannon).ToList();
    } 
    public static void MoveCursor(int y, int x, int speed) => _aimCursor.ParseCoordinateInput(y, x, speed);
    public static void PlayerShoot(int id)
    {
        _shotTick = Tick;
        _shot = _shot > 3 ? 0 : _shot;
        var cannonToShoot = _cannons.ElementAt(_shot);
        _gameObjects.Add(new UserShot(id, cannonToShoot.Y, cannonToShoot.X, 100, _aimCursor.Y, _aimCursor.X, new UserShotGraphics()));
        _shot++;
    } 
    public static void CheckForHit()
    {
        List<GameObject> enemys = _gameObjects.Where(obj => obj is Enemy).ToList();
        List<GameObject> shots = _gameObjects.Where(obj => obj is UserShot).ToList();
        List<int> collisions = new();

        if (shots.Count == 0)
            return;

        foreach (var enemy in enemys)
        {
            if (enemy.HitBox.Count == 0)
                continue;
            var hits = shots.Where(shot => OnTarget ? Math.Abs(shot.Z - enemy.Z) < 100 : Math.Abs(shot.Z - enemy.Z) < 70).ToList();
            if (hits.Count == 0)
                continue;
            foreach (var hit in hits)
            {
                if (!enemy.HitBox.Any(positions => hit.HitBox.Any(hitPositions => positions[0] == hitPositions[0] && positions[1] == hitPositions[1])))
                    continue;
                collisions.Add(hit.Id);
                collisions.Add(enemy.Id);
                AddExplosion(Tick, enemy.Z, enemy.HitBox);
            }
        }
        if (collisions.Count > 0)
        {
            _gameObjects = _gameObjects.Where(obj => !collisions.Any(collisionObj => collisionObj == obj.Id)).ToList();
            EnemiesDestroyed++;
        }

    }
    static void AddExplosion(int id, int z, List<int[]> area) => _gameObjects.Add(new Explosion(area, new ExplosionGraphics(), id, z));
    public static void CheckForObjectsOutOfRange()
    {
        List<int> remThese = new();
        foreach(var obj in _gameObjects)
        {
            if (obj.Z == -1 || obj.Z == 101 || (obj is Explosion && Tick - obj.Id > 20))
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
