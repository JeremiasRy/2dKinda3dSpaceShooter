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

int enemyIds = 2;
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
        int speed = consecutiveKeyPresses < 10 ? 1 : consecutiveKeyPresses / 10 > 2 ? 2 : consecutiveKeyPresses / 10;
        if (CheckKeyPress(ConsoleKey.UpArrow))
            MovePlayer(-1, 0, 1);
        if (CheckKeyPress(ConsoleKey.LeftArrow))
            MovePlayer(0, -1, 2);
        if (CheckKeyPress(ConsoleKey.RightArrow))
            MovePlayer(0, 1, 2);
        if (CheckKeyPress(ConsoleKey.DownArrow))
            MovePlayer(1, 0, 1);
        if (CheckKeyPress(ConsoleKey.Spacebar))
            PlayerShoot(tick);
        return;
    }
    AimCursorControlToComputer();
    consecutiveKeyPresses = 0;
}


void RunGame()
{
    AddHumanPlayer();
    while (true)
    {
        tick++;
        Tick = tick;
        if (tick % 20 == 0)
        {
            enemyIds++;
            AddEnemyObject(enemyIds);
        } else if (tick % 2 == 0)
        {
            AddIllusionParticle(tick);
        }
        Thread.Sleep(5);
        GameTick();
        UserInput();
        ScreenBuffer.DrawText($"Tick {tick}, EnemyCount: {enemyIds}, consecutiveKeyPresses: {consecutiveKeyPresses}", 0, 0);
        ScreenBuffer.DrawScreen();
    }
}


