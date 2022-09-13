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
            var multiplier = Z / 100;
            var sizeCalcWidth = Width * multiplier;
            var sizeCalcHeight = Height * multiplier;

            for (int i = 0; i < sizeCalcWidth; i++)
            {
                for (int j = 0; j < sizeCalcHeight; j++)
                {
                    ScreenBuffer.Draw('@', Y + j, X + i);
                }
            }
        }

        public void Move()
        {
            if (Z + 1 > 100)
                return;
            Z++;


        }
    }
}
