using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public class MovesOnGameTick : GameObject, IMovesOnGameTick
{
    readonly public Dictionary<int, int[]> Trajectory = new(); //Key Z coordinate, Value Y and X points;
    public void CalculateTrajectory(int endPointY, int endPointX)
    {
        bool _yUp = Y > endPointY;
        bool _xLeft = X > endPointX;
        int _yDifference = _yUp ? Y - endPointY : endPointY - Y;
        int _xDifference = _xLeft ? X - endPointX : endPointX - X;

        for (int i = 1; i <= 100; i++)
        {
            float _percent = (float)i / 100;
            int yPoint;
            int xPoint;
            if (_yUp)
                yPoint = (int)(Y - _yDifference * _percent);
            else
                yPoint = (int)(Y + _yDifference * _percent);
            if (_xLeft)
                xPoint = (int)(X - _xDifference * _percent);
            else
                xPoint = (int)(X + _xDifference * _percent);

            Trajectory.Add(i, new int[2] { yPoint, xPoint });
        }
    }



}
