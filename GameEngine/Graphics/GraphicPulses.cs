using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Graphics;

public static class GraphicPulses
{
    static int _fastCount = 0;
    static int _fastPulseCount = 0;
    static int _mediumCount = 0;
    static int _mediumPulseCount = 0;
    static int _slowCount = 0;
    static int _slowPulseCount = 0;
    static public int PulseFast { get
        {
            _fastCount++;
            if (_fastCount == 2)
            {
                _fastPulseCount++;
                _fastCount = 0;
            }
            if (_fastPulseCount > 3)
                _fastPulseCount = 0;
            return _fastPulseCount;
        } }
    static public int PulseMedium { get; set; }
    static public int PulseSlow { get; set; }
}
