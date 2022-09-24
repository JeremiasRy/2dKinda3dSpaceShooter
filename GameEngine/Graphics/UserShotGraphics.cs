using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public class UserShotGraphics : IGraphics
{
    public int Width => _graphic[0].Length;
    public int Height => _graphic.Length;

    static char[][] _graphic = Array.Empty<char[]>();
    public static char Element { get; set; }

    readonly List<Action> actions = new()
    {
        () => Graphic4(),
        () => Graphic3(),
        () => Graphic2(),
        () => Graphic1(),

    };
    public char[][] GetGraphic(int level)
    {
        int index = level < 25 ? 0 : level / 25;
        actions[index].Invoke();
        return _graphic;
    }

    static void Graphic1()
    {
        _graphic = new char[3][];
        _graphic[0] = new char[2] { Element, Element, };
        _graphic[1] = new char[2] { Element, Element, };
        _graphic[2] = new char[2] { Element, Element, };

    }
    static void Graphic2()
    {
        _graphic = new char[2][];
        _graphic[0] = new char[2] { Element, Element, };
        _graphic[1] = new char[2] { Element, Element, };
    }
    static void Graphic3()
    {
        _graphic = new char[1][];
        _graphic[0] = new char[2] { Element, Element, };
    }
    static void Graphic4()
    {
        _graphic = new char[1][];
        _graphic[0] = new char[1] { Element, };
    }
    public UserShotGraphics(char el)
    {
        Element = el;
    }
}
