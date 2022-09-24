using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public static class ScreenBuffer
    {
        static readonly char[][] _screenBufferArray = new char[Console.WindowHeight][];
        static readonly char _whiteSpace = ' ';
        public static void Initialize()
        {
            for (int i = 0; i < _screenBufferArray.Length; i++)
            {
                _screenBufferArray[i] = new char[Console.WindowWidth];
                for (int j = 0; j < _screenBufferArray[i].Length; j++)
                {
                    _screenBufferArray[i][j] = _whiteSpace;
                }
            }
        }
        public static void Draw(char block, int y, int x)
        {
              _screenBufferArray[y][x] = block;
        }
        public static void DrawText(string text, int y, int x)
        {
            char[] chars = text.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                _screenBufferArray[y][x + i] = chars[i];
            }
        }

        public static void DrawScreen()
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < _screenBufferArray.Length; y++)
            {
                Console.WriteLine(_screenBufferArray[y]);
            }
            Clear();
        }
        static void Clear()
        {
            for (int y = 0; y < _screenBufferArray.Length; y++)
            {
                for (int x = 0; x < _screenBufferArray[y].Length; x++)
                {
                    _screenBufferArray[y][x] = _whiteSpace;
                }
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}
