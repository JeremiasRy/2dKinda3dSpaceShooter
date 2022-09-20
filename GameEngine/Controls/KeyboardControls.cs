using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine;

public static class KeyboardControls
{
    [DllImport("user32.dll")]
    static extern bool GetKeyboardState(byte[] lpKeyState);

    [DllImport("user32.dll")]
    static extern short GetKeyState();

    public static bool CheckKeyPress(ConsoleKey key)
    {
        GetKeyState();
        byte[] array = new byte[256];
        GetKeyboardState(array);
        return array[(int)key] != 0 && array[(int)key] != 1;
    }
    public static bool KeyboardKeyDown()
    {
        GetKeyState();
        byte[] array = new byte[256];
        GetKeyboardState(array);
        return array.Any(x => x != 0 && x != 1);
    }
}
