using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;


public static class Surfaces
{
    static readonly char[] _shadesParticles = new char[7] { '.', ':', '-', '=', '+', '*', '#', };  //# tummin!!
    static readonly char[] _shadowSurfaces = new char[3] { '\u2591', '\u2592', '\u2593' };
    public static char GetParticleLevel(int level) => _shadesParticles[level];
    public static char GetShadowLevel(int level) => _shadowSurfaces[level];

}
