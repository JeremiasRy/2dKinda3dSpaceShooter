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
    public float Z { get; set; }

    public int Width { get; set; }
    public int Height { get; set; }

    public void Draw();
    public void Move();
}
