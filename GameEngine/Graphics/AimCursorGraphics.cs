using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public class AimCursorGraphics : IGraphics
{
    static GraphicPulse _fastPulse = new (20, 4);
    static readonly GraphicPulse _slowPulse = new(15, 2);

    static char[][] _graphic = Array.Empty<char[]>();
    public int Width => _graphic[0].Length;
    public int Height => _graphic.Length;

    static char Rotating => CharacterArrays.GetEnemyRotating(_slowPulse.Index());
    static char OnTarget => CharacterArrays.GetShadow(_fastPulse.Index());

    public char[][] GetGraphic(int level)
    {

        if (level == 0)
        {
            if (GameState.ShotsFired)
                actions.ElementAt(4).Invoke();
            else
                actions.ElementAt(level).Invoke();
        }
        else
        {
            actions.ElementAt(_slowPulse.Index() +1).Invoke();
        }
        return _graphic;
    }

    public List<Action> actions = new List<Action>()
    {
        () => Graphic1(),
        () => Graphic2(),
        () => Graphic3(),
        () => Graphic4(),
        () => Graphic5(),

    };


    static void Graphic1()
    {
        _graphic = new char[5][];
        _graphic[0] = new char[5] { ' ', ' ', ' ', ' ', ' ' };
        _graphic[1] = new char[5] { ' ', ' ', '@', ' ', ' ' };
        _graphic[2] = new char[5] { ' ', '@', ' ', '@', ' ' };
        _graphic[3] = new char[5] { ' ', ' ', '@', ' ', ' ' };
        _graphic[4] = new char[5] { ' ', ' ', ' ', ' ', ' ' };
    }
    static void Graphic2()
    {
        _graphic = new char[5][];
        _graphic[0] = new char[5] { ' ', ' ', '@', ' ', ' ' };
        _graphic[1] = new char[5] { ' ', (char)92, ' ', '/', ' ' };
        _graphic[2] = new char[5] { '@', ' ', ' ', ' ', '@' };
        _graphic[3] = new char[5] { ' ', '/', ' ', (char)92, ' ' };
        _graphic[4] = new char[5] { ' ', ' ', '@', ' ', ' ' };
    }
    static void Graphic3()
    {
        _graphic = new char[7][];
        _graphic[0] = new char[7] { ' ', ' ', ' ', '@', ' ', ' ', ' ' };
        _graphic[1] = new char[7] { ' ', (char)92, ' ', ' ', '/', ' ', ' ' };
        _graphic[2] = new char[7] { ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        _graphic[3] = new char[7] { '@', ' ', ' ', ' ', ' ', ' ', '@' };
        _graphic[4] = new char[7] { ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        _graphic[5] = new char[7] { ' ', '/', ' ', ' ', ' ', (char)92, ' ' };
        _graphic[6] = new char[7] { ' ', ' ', ' ', '@', ' ', ' ', ' ' };
    }
    static void Graphic4()
    {
        _graphic = new char[9][];
        _graphic[0] = new char[9] { ' ', ' ', ' ', ' ', '@', ' ', ' ', ' ', ' ' };
        _graphic[1] = new char[9] { ' ', (char)92, ' ', ' ', ' ', ' ', ' ', '/', ' ' };
        _graphic[2] = new char[9] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        _graphic[3] = new char[9] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        _graphic[4] = new char[9] { '@', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '@' };
        _graphic[5] = new char[9] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        _graphic[6] = new char[9] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        _graphic[7] = new char[9] { ' ', '/', ' ', ' ', ' ', ' ', ' ', (char)92, ' ' };
        _graphic[8] = new char[9] { ' ', ' ', ' ', ' ', '@', ' ', ' ', ' ', ' ' };
    }
    static void Graphic5()
    {
        _graphic = new char[5][];
        _graphic[0] = new char[5] { ' ', ' ', '@', ' ', ' ' };
        _graphic[1] = new char[5] { ' ', ' ', ' ', ' ', ' ' };
        _graphic[2] = new char[5] { '@', ' ', ' ', ' ', '@' };
        _graphic[3] = new char[5] { ' ', ' ', ' ', ' ', ' ' };
        _graphic[4] = new char[5] { ' ', ' ', '@', ' ', ' ' };
    }
}
