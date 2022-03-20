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

    public int x = 5;
    public int y = 0;
    public int gridWidth = 10;
    public int gridHeight = 16;
    public int[,] grid = new int[10, 16];

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
        Console.Clear();
        Console.WriteLine($"X: {x} Y: {y}");
       
        //int[,] gridFilled = new int[gridWidth, gridHeight];
        //yeah something like this! We can make this work!!! uwuwuwuuw
        //var gridFilledX = new List<int>();
        for (int r = 0; r < grid.GetLength(1); r++)
        {
            for (int c = 0; c < grid.GetLength(0); c++)
            {
                if (c == x && r == y)
                {
                    Console.Write("X");
                    continue;
                }
                if (grid[c, r] == 1)
                {
                    Console.Write("X");
                    continue;
                }
                Console.Write("  ");
            }
            Console.WriteLine();
        }
        y++;
        if (y > 14 || grid[x, y] == 1)
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