using GameEngine;
using static GameEngine.WindowUtility;
using static GameEngine.GameState;

if (!OperatingSystem.IsWindows())
    return;
Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
MoveWindowTopLeftCorner();
ScreenBuffer.Initialize();
Console.CursorVisible = false;

int enemyCount = 0;

Task runGame = new(RunGame);
Task userInput = new(UserInput);

runGame.Start();
userInput.Start();

Task[] tasks = new [] { runGame, userInput };
Task.WaitAll(tasks);


void UserInput()
{
    while (true)
    {

    }
}

void RunGame()
{
    int count = 0;
    while (true)
    {
        count++;
        if (count == 10)
        {
            enemyCount++;
            AddEnemyObject(enemyCount);
            count = 0;

        }
        Thread.Sleep(20);
        GameTick();
        ScreenBuffer.DrawText(enemyCount.ToString(), 0, 0);
        ScreenBuffer.DrawScreen();
    }
}


