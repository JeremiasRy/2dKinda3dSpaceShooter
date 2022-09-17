using GameEngine;
using static GameEngine.WindowUtility;
using static GameEngine.GameState;
using static GameEngine.KeyboardControls;

if (!OperatingSystem.IsWindows())
    return;
Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
MoveWindowTopLeftCorner();
ScreenBuffer.Initialize();
Console.CursorVisible = false;

int enemyCount = 0;
int tick = 0;
Task runGame = new(RunGame);
Task userInput = new(UserInput);

runGame.Start();
userInput.Start();

Task[] tasks = new [] { runGame, userInput, };
Task.WaitAll(tasks);



void UserInput()
{
    while (true)
    {
        if (CheckKeyPress(ConsoleKey.UpArrow))
            MovePlayer(-2, 0);
        if (CheckKeyPress(ConsoleKey.LeftArrow))
            MovePlayer(0, -2);
    }
}


void RunGame()
{
    AddHumanPlayer();
    while (true)
    {
        tick++;
        if (tick % 20 == 0)
        {
            enemyCount++;
            AddEnemyObject(enemyCount);
        }
        Thread.Sleep(1000 / 60);
        GameTick();
        ScreenBuffer.DrawText($"Tick {tick}, EnemyCount: {enemyCount}", 0, 0);
        ScreenBuffer.DrawScreen();
    }
}


