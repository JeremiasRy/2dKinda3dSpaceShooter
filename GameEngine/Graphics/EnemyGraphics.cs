using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public class EnemyGraphics : IGraphics
{
    public int Width { get; set; } = 20;
    public int Height { get; set; } = 10;
    public char[][] GetGraphic(int level)
    {
        int index = level < 13 ? 0 : level / 13;
        return _enemyGraphics[index];
    }
    static char[][] graphic1 = new char[10][];
    static char[][] graphic2 = new char[8][];
    static char[][] graphic3 = new char[6][];
    static char[][] graphic4 = new char[5][];
    static char[][] graphic5 = new char[3][];
    static char[][] graphic6 = new char[3][];
    static char[][] graphic7 = new char[2][];
    static char[][] graphic8 = new char[2][];

    static readonly List<char[][]> _enemyGraphics = new List<char[][]>()
    {
        Graphic8(),
        Graphic7(),
        Graphic6(),
        Graphic5(),
        Graphic4(),
        Graphic3(),
        Graphic2(),
        Graphic1(),
    };



    static char[][] Graphic1()
    {
        graphic1[0] = new char[20] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '/', (char)92, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        graphic1[1] = new char[20] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        graphic1[2] = new char[20] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        graphic1[3] = new char[20] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        graphic1[4] = new char[20] { ' ', '^', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '^', ' ' };
        graphic1[5] = new char[20] { '<', '|', '>', '-', '|', '-', '|', '-', '[', '@', '@', ']', '-', '|', '-', '|', '-', '<', '|', '>' };
        graphic1[6] = new char[20] { ' ', ' ', ' ', ' ', '<', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', '>', ' ', ' ', ' ', ' ' };
        graphic1[7] = new char[20] { ' ', ' ', ' ', ' ', ' ', '<', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', '>', ' ', ' ', ' ', ' ', ' ' };
        graphic1[8] = new char[20] { ' ', ' ', ' ', ' ', ' ', ' ', '<', ' ', ' ', '|', '|', ' ', ' ', '>', ' ', ' ', ' ', ' ', ' ', ' ' };
        graphic1[9] = new char[20] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', '<', ' ', '|', '|', ' ', '>', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        return graphic1;
    }
    static char[][] Graphic2()
    {
        graphic2[0] = new char[18] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '/', (char)92, ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        graphic2[1] = new char[18] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        graphic2[2] = new char[18] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        graphic2[3] = new char[18] { ' ', '^', ' ', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', '^', ' ' };
        graphic2[4] = new char[18] { '<', '|', '>', '-', '|', '-', '|', '[', '@', '@', ']', '|', '-', '|', '-', '<', '|', '>' };
        graphic2[5] = new char[18] { ' ', ' ', ' ', ' ', '<', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', '>', ' ', ' ', ' ', ' ' };
        graphic2[6] = new char[18] { ' ', ' ', ' ', ' ', ' ', '<', ' ', ' ', '|', '|', ' ', ' ', '>', ' ', ' ', ' ', ' ', ' ' };
        graphic2[7] = new char[18] { ' ', ' ', ' ', ' ', ' ', ' ', '<', ' ', '|', '|', ' ', '>', ' ', ' ', ' ', ' ', ' ', ' ' };
        return graphic2;
    }

    static char[][] Graphic3()
    {
        graphic3[0] = new char[16] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', '/', (char)92, ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        graphic3[1] = new char[16] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        graphic3[2] = new char[16] { ' ', '^', ' ', ' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' ', ' ', '^', ' ' };
        graphic3[3] = new char[16] { '<', '|', '>', '-', '|', '-', '[', '@', '@', ']', '-', '|', '-', '<', '|', '>' };
        graphic3[4] = new char[16] { ' ', ' ', ' ', ' ', '<', ' ', ' ', '|', '|', ' ', ' ', '>', ' ', ' ', ' ', ' ' };
        graphic3[5] = new char[16] { ' ', ' ', ' ', ' ', ' ', '<', ' ', '|', '|', ' ', '>', ' ', ' ', ' ', ' ', ' ' };
        return graphic3;
    }
    static char[][] Graphic4()
    {
        graphic4[0] = new char[12] { ' ', ' ', ' ', ' ', ' ', '/', (char)92, ' ', ' ', ' ', ' ', ' '};
        graphic4[1] = new char[12] { ' ', '^', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', '^', ' ' };
        graphic4[2] = new char[12] { '<', '|', '>', '-', '[', '@', '@', ']', '-', '<', '|', '>' };
        graphic4[3] = new char[12] { ' ', ' ', ' ', '<', ' ', '|', '|', ' ', '>', ' ', ' ', ' ' };
        graphic4[4] = new char[12] { ' ', ' ', ' ', ' ', '<', '|', '|', '>', ' ', ' ', ' ', ' ' };
        return graphic4;
    }
    static char[][] Graphic5()
    {
        graphic5[0] = new char[8] { ' ', ' ', ' ', '/', (char)92, ' ', ' ', ' ' };
        graphic5[1] = new char[8] { '<', '>', '[', '@', '@', ']', '<', '>' };
        graphic5[2] = new char[8] { ' ', ' ', '<', '|', '|', '>', ' ', ' ' };
        return graphic5;
    }
    static char[][] Graphic6()
    {
        graphic6[0] = new char[6] { ' ', ' ', '/', (char)92, ' ', ' ' };
        graphic6[1] = new char[6] { '<', '[', '@', '@', ']', '>' };
        graphic6[2] = new char[6] { ' ', ' ', '|', '|', ' ', ' ' };
        return graphic6;
    }
    static char[][] Graphic7()
    {
        graphic7[0] = new char[4] { ' ', '/', (char)92, ' ' };
        graphic7[1] = new char[4] { '[', '@', '@', ']' };
        return graphic7;
    }
    static char[][] Graphic8()
    {
        graphic8[0] = new char[2] { '/', (char)92, };
        graphic8[1] = new char[2] { '@', '@',};
        return graphic8;
    }
}
