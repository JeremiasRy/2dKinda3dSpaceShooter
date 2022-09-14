using GameEngine;
using static GameEngine.WindowUtility;
using static GameEngine.GameState;

if (!OperatingSystem.IsWindows())
    return;
Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
MoveWindowTopLeftCorner();
ScreenBuffer.Initialize();
Console.CursorVisible = false;
AddFlyingObject();

int count = 0;

while (true)
{
    if (count == 10)
    {
        AddFlyingObject();
        count = 0;
    }
    Thread.Sleep(20);
    GameTick();
    ScreenBuffer.DrawScreen();
    count++;
}

