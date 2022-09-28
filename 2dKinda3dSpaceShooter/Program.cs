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

int enemyIds = 5;
int tick = 0;
int consecutiveKeyPresses = 0;
Task runGame = new(RunGame);

runGame.Start();
runGame.Wait();



void UserInput() // negative integer is left or up, 0 means no movement on that plane and positive integer is right or down
{
    if (KeyboardKeyDown())
    {
        consecutiveKeyPresses++;
        int speed = consecutiveKeyPresses < 10 ? 2 : consecutiveKeyPresses / 10 > 3 ? 3 : consecutiveKeyPresses / 10;
        if (OnTarget)
            speed = 1;

        if (CheckKeyPress(ConsoleKey.UpArrow))
            MoveCursor(-1, 0, speed);
        if (CheckKeyPress(ConsoleKey.LeftArrow))
            MoveCursor(0, -1, speed + 1);
        if (CheckKeyPress(ConsoleKey.RightArrow))
            MoveCursor(0, 1, speed + 1);
        if (CheckKeyPress(ConsoleKey.DownArrow))
            MoveCursor(1, 0, speed);
        if (CheckKeyPress(ConsoleKey.Spacebar))
            if (consecutiveKeyPresses % 5 == 0 || consecutiveKeyPresses == 1)
                PlayerShoot(tick);
        return;
    }
    consecutiveKeyPresses = 0;
}


void RunGame()
{
    AddHumanPlayer();
    while (true)
    {
        tick++;
        Tick = tick;
        if (tick % 40 == 0)
        {
            enemyIds++;
            AddEnemyObject(enemyIds);
        } else if (tick % 2 == 0)
        {
            AddIllusionParticle(tick + 5);
        }
        Thread.Sleep(20);
        GameTick();
        UserInput();
        ScreenBuffer.DrawText($"Tick {tick}, EnemyCount: {enemyIds - 4}, consecutiveKeyPresses: {consecutiveKeyPresses}, Enemies destroyed: {EnemiesDestroyed}, Enemies escaped: {EnemiesEscaped}", Console.WindowHeight - 1, Console.WindowWidth / 4);
        ScreenBuffer.DrawScreen();
    }
}


