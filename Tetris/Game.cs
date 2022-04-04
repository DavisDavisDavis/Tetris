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
    public int random = 0;  
    public int[,] grid = new int[10, 18];
    public int[,] blockGrid = new int[10, 18];
    public int[,] block = new int[3, 3];
    public int[,] copy = new int[3, 3];
    public List<Block> _blocks = new List<Block>()
         {
            new Block("T-block", "🐶", new int[,]
            {
                { 0, 0, 0 },
                { 1, 1, 1 },
                { 0, 1, 0 },
            }),
            new Block("I-block", "🐸", new int[,]
            {
                { 0, 2, 0 },
                { 0, 2, 0 },
                { 0, 2, 0 },
            }),
            new Block("L-block", "🐱", new int[,]
            {
                { 3, 0, 0 },
                { 3, 0, 0 },
                { 3, 3, 0 },
            }),
            new Block("Square-block", "🐷", new int[,]
            {
                { 0, 0, 0 },
                { 4, 4, 0 },
                { 4, 4, 0 },
            })
        };

    

    public void Start()
    {
        

        Console.WriteLine("Start");
        Windows = false;
        //For some reason emojis dont work on the windows console
        if (Windows)
        {
            icon = "X";
            emptySpace = " ";

        }
        else
        {
            icon = "💖";
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

    void Tick()
    {
        var blockX = 0;
        var blockY = 0;

        var rnd = new Random();
        if (y == 0)
        {
            random = rnd.Next(0, _blocks.Count);
        }
        int[,] block = _blocks[random].Map;
        icon = _blocks[random].Icon;

        int[,] blockGrid = new int[grid.GetLength(0), grid.GetLength(1)];

        Console.Clear();
        Console.WriteLine($"X: {x} Y: {y}");

        for (int r = 0; r < grid.GetLength(0); r++)
        {
            for (int c = 0; c < grid.GetLength(1); c++)
            {

                if (c == x && r == y + blockY || blockX > 0)
                {
                    blockGrid[c, r] = block[blockY, blockX];
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
                if (grid[c, r] != 0)
                {
                    if (blockGrid[c, r] != 0)
                    {
                        for (int a = 0; a <= grid.GetLength(1) - 1; a++)
                        {
                            for (int b = 0; b <= grid.GetLength(0) - 1; b++)
                            {

                                if (blockGrid[b, a] != 0)
                                {
                                    grid[b, a - 1] = blockGrid[b, a];

                                }
                            }
                        }
                        y = 0;
                        continue;


                    }
                    var uwu = grid[c, r] - 1;
                    Console.Write(_blocks[(grid[c, r] - 1)].Icon);
                    continue;
                }

                Matrix.ClearBoard(grid);

                if (blockGrid[c, r] != 0)
                {
                    Console.Write(_blocks[(blockGrid[c, r] - 1)].Icon);
                    continue;
                }

                Console.Write(emptySpace);
            }
            Console.WriteLine();
        }

        y++;
        if (y >= grid.GetLength(1) - 7 - block.GetLength(1))
        {
            //Copy the block grid onto grid
            for (int r = 0; r <= grid.GetLength(1) - 1; r++)
            {
                for (int c = 0; c <= grid.GetLength(0) - 1; c++)
                {

                    if (blockGrid[c, r] != 0)
                    {
                        grid[c, r] = blockGrid[c, r];

                    }
                }
            }
            y = 0;
        }

        ScheduleNextTick();
    }

    public void Input(ConsoleKey key)
    {
        if (ConsoleKey.LeftArrow == key && x > 0)
        {
            x--;
        }
        if (ConsoleKey.RightArrow == key && x < grid.GetLength(0) - 3)
        {
            if (Matrix.Collision(grid, blockGrid))
            {
                Console.WriteLine(grid);
                Console.WriteLine();
            }
            x++;
        }
        if (ConsoleKey.Spacebar == key)
        {
            block = Matrix.RotateLeft(block);
        }
    }

    void ScheduleNextTick()
    {
        // the game will automatically update itself every half a second, adjust as needed
        _timer = new ScheduleTimer(500, Tick);
    }
}