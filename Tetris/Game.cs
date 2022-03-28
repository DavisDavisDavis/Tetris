//
// This is the game event logic that you can customize and cannibalize
// as needed. You should try to write your game in a modular way, avoid
// making one huge Game class.
//
using Tetris;

class Game
{
    ScheduleTimer? _timer;
    

    public bool Paused { get; private set; }
    public bool GameOver { get; private set; }

    public bool Windows { get;  set; }
    public string icon { get;  set; }
    public string emptySpace { get; set; }

    public int x = 0;
    public int y = 0;  
    public int[,] grid = new int[10, 10];


    public void Start()
    {
        Console.WriteLine("Start");
        Windows = true;

        if (Windows)
        {
            icon = "X";
            emptySpace = " ";

        }
        else
        {
            icon = "🐱";
            emptySpace = "🌀";
        }
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
        if (ConsoleKey.RightArrow == key && x < grid.GetLength(0) - 1)
        {
            x++;
        }
    }

    void Tick()
    {
        var block = new int[,]
        {
            { 1, 0, 0 },
            { 0, 1, 0 },
            { 0, 0, 1 },
        };

        var blockX = 0;
        var blockY = 0;

        int[,] blockGrid = new int[10, 10];

        Console.Clear();
        Console.WriteLine($"X: {x} Y: {y}");

        for (int r = 0; r < grid.GetLength(0); r++)
        {
            for (int c = 0; c < grid.GetLength(1); c++)
            {

                if (c == x && r == y + blockY || blockX > 0)
                {
                    blockGrid[c, r] = block[blockY, blockX];
                    var what_is_this_value = block[blockX, blockY];
                    var what_is_that_value = blockGrid[c, r];
                    blockX++;
                    if (blockX >= block.GetLength(0))
                    {
                        blockX = 0;
                        blockY++;
                    }
                }
            }
            if (blockY >= block.GetLength(1))
            {
                blockY = 0;
            }
        }

        for (int r = 0; r <= grid.GetLength(1) - 1; r++)
        {
            for (int c = 0; c <= grid.GetLength(0) - 1; c++)
            {
                if (blockGrid[c, r] == 1)
                {
                    //Console.Write("X");
                    Console.Write(icon);
                    continue;
                }

        
                Matrix.ClearBoard(grid);

                if (grid[c, r] == 1)
                {
                    Console.Write(icon);
                    //Console.Write("X");
                    continue;
                } 
                Console.Write(emptySpace);
                //Console.Write(" ");
            }
            Console.WriteLine();
        }

        y++;
        if (y >= grid.GetLength(1) - 3 || grid[x , y + 1] == 1)
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