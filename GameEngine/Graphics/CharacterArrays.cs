using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;
public static class CharacterArrays
{
    static readonly char[] _shadesParticles = new char[7] { '.', ':', '-', '=', '+', '*', '#', };  
    static readonly char[] _enemyMidlle = new char[5] { ' ', '\u2591', '\u2592', '\u2593', '\u2588' }; // Can be also used as shadow 0 --> 4
    static readonly char[] _enemyRotating = new char[] { '-', (char)92, '|', '/',};
    public static char GetParticle(int level) => _shadesParticles[level];
    public static char GetEnemyMiddle(int level) => _enemyMidlle[level];
    public static char GetEnemyRotating(int level) => _enemyRotating[level];
}
