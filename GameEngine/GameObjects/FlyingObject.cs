using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class FlyingObject : IGameObject
    {
        static Random random = new Random();

        int _y;
        int _x;
        int _z;

        readonly int _endY;
        readonly int _endX;

        readonly Dictionary<int, int[]> trajectory = new(); //Key Z coordinate, Value Y and Z points;

        public int Id { get; set; }
        public int Width { get; set; } = 20;
        public int Height { get; set; } = 10;
        public int Y { get => _y; set => _y = value; }
        public int X { get => _x; set => _x = value; }
        public int Z { get => _z; set => _z = value; }

        public FlyingObject()
        {
            Y = Console.WindowHeight / 2;
            X = Console.WindowWidth / 2;
            Z = 1;

            _endY = random.Next(Console.WindowHeight);
            _endX = random.Next(Console.WindowWidth);

            Id = Y + X + _endY + _endX * random.Next(1000);

            bool _yUp = Y > _endY;
            bool _xLeft = X > _endX;
            int _yDifference = _yUp ? Y - _endY : _endY - Y;
            int _xDifference = _xLeft ? X - _endX : _endX - X;

            for (int i = 1; i <= 100 ; i++) 
            {
                float _percent = (float)i / 100;
                int yPoint;
                int xPoint;
                if (_yUp)
                    yPoint = (int)(Y - _yDifference * _percent);
                else
                    yPoint = (int)(Y + _xDifference * _percent);
                if (_xLeft)
                    xPoint = (int)(X - _xDifference * _percent);
                else
                    xPoint = (int)(X + _xDifference * _percent);

                trajectory.Add(i, new int[2] {yPoint, xPoint});
            }
        }


        public void Draw()
        {
            float _multiplier = (float)Z / 100;
            int _sizeCalcWidth = (int)(Width * _multiplier);
            int _sizeCalcHeight = (int)(Height * _multiplier);
            int _left = X - _sizeCalcWidth / 2;
            int _top = Y - _sizeCalcHeight / 2;
            List<int[]> _positions= new();

            for (int iY = 0; iY < _sizeCalcHeight; iY++)
            {
                for (int iX = 0; iX < _sizeCalcWidth; iX++)
                {
                    if (!(iY + _top >= Console.WindowHeight || iX + _left >= Console.WindowWidth || iY + _top < 0 || iX + _left <0))
                        _positions.Add(new int[] {iY + _top, iX + _left});      
                }
            }
            foreach (int[] pos in _positions)
                ScreenBuffer.Draw('!', pos[0], pos[1]);
        }
        public void Move()
        {
            if (Z + 1 > 100)
                return;
            Z++;
            Y = trajectory[Z][0];
            X = trajectory[Z][1];
        }


    }
}
