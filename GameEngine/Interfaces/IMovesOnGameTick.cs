﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public interface IMovesOnGameTick
{
    public int Id { get; set; }
    public void CalculateTrajectory(int endPointY, int endPointX);
}
