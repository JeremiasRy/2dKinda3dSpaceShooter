using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class FlyingObject
    {
        public int X { get; set; } = Console.WindowWidth / 2;
        public int Y { get; set; } = Console.WindowHeight / 2;
        public float Z { get; set; } = 1;

        public int Width { get; set; } = 20;
        public int Height { get; set; } = 20;


        public void Draw()
        {
            var _multiplier = Z / 100;
            var _sizeCalcWidth = Width * _multiplier;
            var _sizeCalcHeight = Height * _multiplier;

        }

        public void Move()
        {
            if (Z + 1 > 100)
                return;
            Z++;


        }
    }
}
