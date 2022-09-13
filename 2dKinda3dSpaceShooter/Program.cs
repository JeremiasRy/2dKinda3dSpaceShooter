using GameEngine;
using static GameEngine.WindowUtility;

if (!OperatingSystem.IsWindows())
    return;
Console.SetWindowSize(Console.LargestWindowWidth - 5, Console.LargestWindowHeight);
MoveWindowTopLeftCorner();
ScreenBuffer.Initialize();

Console.CursorVisible = false;

FlyingObject flyingObject = new();
flyingObject.Draw();

while (true)
{
    Console.ReadKey();
    flyingObject.Move();
    flyingObject.Draw();
    ScreenBuffer.DrawScreen();

}

