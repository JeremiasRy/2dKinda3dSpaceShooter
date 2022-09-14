﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public interface IGameObject
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public void Draw();
    public void Move();
}
