//
// This is the game event logic that you can customize and cannibalize
// as needed. You should try to write your game in a modular way, avoid
// making one huge Game class.
//

class Game
{
    ScheduleTimer? _timer;

    public bool Paused { get; private set; }
    public bool GameOver { get; private set; }

    public int x = 3;
    public int y = 0;
    public int gridWidth = 5;
    public int gridHeight = 16;
    public int[,] grid = new int[5, 16];

    public void Start()
    {
        Console.WriteLine("Start");
        ScheduleNextTick();
    }

    public void Pause()
    {
        Console.WriteLine("Pause");
        Paused = true;
        _timer!.Pause();
    }

    public void Resume()
    {
        Console.WriteLine("Resume");
        Paused = false;
        _timer!.Resume();
    }

    public void Stop()
    {
        Console.WriteLine("Stop");
        GameOver = true;
    }

    public void Input(ConsoleKey key)
    {
        if (ConsoleKey.LeftArrow == key && x > 0 )
        {
            x--;
        }
        if (ConsoleKey.RightArrow == key && x < gridWidth - 1)
        {
            x++;
        }
    }

    void Tick()
    {
        var block = new byte[,]
        {
            { 0, 0, 0 },
            { 1, 1, 1 },
            { 0, 1, 0 },
        };


        Console.Clear();
        Console.WriteLine($"X: {x} Y: {y}");
        for (int r = 0; r < grid.GetLength(1); r++)
        {
            var fullRow = 0;
            for (int c = 0; c < grid.GetLength(0); c++)
            {
                if (c == x && r == y)
                {
                    for (var i = 0; i < 2; i++)
                    {
                        for (var j = 0; j < 2; j++)
                        {
                            Console.Write(block[i, j]);
                        }

                        Console.WriteLine();
                    }
                    continue;
                }
                if (grid[c, r] == 1)
                {
                    Console.Write("X");
                    fullRow++;
                    if (fullRow >= 5)
                    {

                        for (int i = 0; i < 5; i++)
                        {
                            grid[i, r] = 0;
                        }
                    }
                    continue;
                }
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        y++;
        if (y > 14 || grid[x , y + 1] == 1)
        {
            grid[x, y] = 1;
            y = 0;
        }

        ScheduleNextTick();
    }

    void ScheduleNextTick()
    {
        // the game will automatically update itself every half a second, adjust as needed
        _timer = new ScheduleTimer(200, Tick);
    }
}