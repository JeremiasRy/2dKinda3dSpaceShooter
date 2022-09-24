using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public class GraphicPulse
{
    int _tickCount = 0;
    int _indexInt = 0;
    readonly int _speed;
    readonly int _arraySize;
    public int Index()
    {
        _tickCount++;
        if (_tickCount == _speed)
        {
            _indexInt++;
            _tickCount = 0;
        }
        if (_indexInt > _arraySize)
            _indexInt = 0;
        return _indexInt;
    }

    public GraphicPulse(int speed, int arraySize)
    {
        _speed = speed;
        _arraySize = arraySize;
    }
}
