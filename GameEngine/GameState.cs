using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public static class GameState
{
    public static bool PlayerAlive { get; set; }

    public static List<FlyingObject> FlyingObjects = new List<FlyingObject>();

    public static void AddFlyingObject()
    {
        FlyingObjects.Add(new FlyingObject());
    }

    public static void CheckForObjectsOutOfRange()
    {
        List<int> removeThese = new();
        foreach (FlyingObject obj in FlyingObjects)
        {
            if (obj.Z == 100)
                removeThese.Add(obj.Id);
        }
        foreach(int id in removeThese)
            FlyingObjects = FlyingObjects.Where(obj => obj.Id != id).ToList();
    }
    public static void GameTick()
    {
        foreach (FlyingObject obj in FlyingObjects)
            obj.Move();
        CheckForObjectsOutOfRange();
        foreach (FlyingObject obj in FlyingObjects)
            obj.Draw();
    }
}
