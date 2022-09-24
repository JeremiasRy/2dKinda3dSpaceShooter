﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public class EnemyGraphics : IGraphics
{
    static readonly GraphicPulse MiddleTick = new(12, 4);
    static readonly GraphicPulse RotateTick = new(15, 3);
    public int Width => _graphic[0].Length;
    public int Height => _graphic.Length;

    static char[][] _graphic = Array.Empty<char[]>();
    static char Middle => CharacterArrays.GetShadow(MiddleTick.Index());
    static char Rotate => CharacterArrays.GetEnemyRotating(RotateTick.Index());
    public char[][] GetGraphic(int level)
    {
        int index = level < 13 ? 0 : level / 13;
        _graphics.ElementAt(index).Invoke();
        return _graphic;
    }
    static readonly List<Action> _graphics = new()
    {
        () => Graphic8(),
        () => Graphic7(),
        () => Graphic6(),
        () => Graphic5(),
        () => Graphic4(),
        () => Graphic3(),
        () => Graphic2(),
        () => Graphic1(),
    };
    static void Graphic1()
    {
        _graphic = new char[10][];
        _graphic[0] = new char[20] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '/', (char)92, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        _graphic[1] = new char[20] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        _graphic[2] = new char[20] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        _graphic[3] = new char[20] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        _graphic[4] = new char[20] { ' ', Rotate, ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', Rotate, ' ' };
        _graphic[5] = new char[20] { '<', '|', '>', '-', '|', '-', '|', '-', '[', Middle, Middle, ']', '-', '|', '-', '|', '-', '<', '|', '>' };
        _graphic[6] = new char[20] { ' ', ' ', ' ', ' ', '<', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', '>', ' ', ' ', ' ', ' ' };
        _graphic[7] = new char[20] { ' ', ' ', ' ', ' ', ' ', '<', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', '>', ' ', ' ', ' ', ' ', ' ' };
        _graphic[8] = new char[20] { ' ', ' ', ' ', ' ', ' ', ' ', '<', ' ', ' ', '|', '|', ' ', ' ', '>', ' ', ' ', ' ', ' ', ' ', ' ' };
        _graphic[9] = new char[20] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', '<', ' ', '|', '|', ' ', '>', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
    }
    static void Graphic2()
    {
        _graphic = new char[8][];
        _graphic[0] = new char[18] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '/', (char)92, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        _graphic[1] = new char[18] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        _graphic[2] = new char[18] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        _graphic[3] = new char[18] { ' ', Rotate, ' ', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', Rotate, ' ' };
        _graphic[4] = new char[18] { '<', '|', '>', '-', '|', '-', '|', '[', Middle, Middle, ']', '|', '-', '|', '-', '<', '|', '>' };
        _graphic[5] = new char[18] { ' ', ' ', ' ', ' ', '<', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', '>', ' ', ' ', ' ', ' ' };
        _graphic[6] = new char[18] { ' ', ' ', ' ', ' ', ' ', '<', ' ', ' ', '|', '|', ' ', ' ', '>', ' ', ' ', ' ', ' ', ' ' };
        _graphic[7] = new char[18] { ' ', ' ', ' ', ' ', ' ', ' ', '<', ' ', '|', '|', ' ', '>', ' ', ' ', ' ', ' ', ' ', ' ' };
    }
    static void Graphic3()
    {
        _graphic = new char[6][];
        _graphic[0] = new char[16] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', '/', (char)92, ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        _graphic[1] = new char[16] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        _graphic[2] = new char[16] { ' ', Rotate, ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', Rotate, ' ' };
        _graphic[3] = new char[16] { '<', '|', '>', '-', '|', '-', '[', Middle, Middle, ']', '-', '|', '-', '<', '|', '>' };
        _graphic[4] = new char[16] { ' ', ' ', ' ', ' ', '<', ' ', ' ', '|', '|', ' ', ' ', '>', ' ', ' ', ' ', ' ' };
        _graphic[5] = new char[16] { ' ', ' ', ' ', ' ', ' ', '<', ' ', '|', '|', ' ', '>', ' ', ' ', ' ', ' ', ' ' };
    }
    static void Graphic4()
    {
        _graphic = new char[5][];
        _graphic[0] = new char[12] { ' ', ' ', ' ', ' ', ' ', '/', (char)92, ' ', ' ', ' ', ' ', ' ' };
        _graphic[1] = new char[12] { ' ', Rotate, ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', Rotate, ' ' };
        _graphic[2] = new char[12] { '<', '|', '>', '-', '[', Middle, Middle, ']', '-', '<', '|', '>' };
        _graphic[3] = new char[12] { ' ', ' ', ' ', '<', ' ', '|', '|', ' ', '>', ' ', ' ', ' ' };
        _graphic[4] = new char[12] { ' ', ' ', ' ', ' ', '<', '|', '|', '>', ' ', ' ', ' ', ' ' };
    }
    static void Graphic5()
    {
        _graphic = new char[3][];
        _graphic[0] = new char[8] { ' ', Rotate, ' ', '/', (char)92, ' ', Rotate, ' ' };
        _graphic[1] = new char[8] { '<', '>', '[', Middle, Middle, ']', '<', '>' };
        _graphic[2] = new char[8] { ' ', ' ', '<', '|', '|', '>', ' ', ' ' };
    }
    static void Graphic6()
    {
        _graphic = new char[3][];
        _graphic[0] = new char[6] { ' ', ' ', '/', (char)92, ' ', ' ' };
        _graphic[1] = new char[6] { '<', '[', Middle, Middle, ']', '>' };
        _graphic[2] = new char[6] { ' ', ' ', '|', '|', ' ', ' ' };
    }
    static void Graphic7()
    {
        _graphic = new char[2][];
        _graphic[0] = new char[4] { ' ', '/', (char)92, ' ' };
        _graphic[1] = new char[4] { '[', Middle, Middle, ']' };
    }
    static void Graphic8()
    {
        _graphic = new char[2][];
        _graphic[0] = new char[2] { '/', (char)92, };
        _graphic[1] = new char[2] { Middle, Middle, };
    }
}
