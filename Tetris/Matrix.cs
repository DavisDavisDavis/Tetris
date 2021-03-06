

namespace Tetris 
{
    internal class Matrix
    {
     
        private static int downCount { get; set; }
        private static bool fullRow { get; set; }

        public static int[,] RotateLeft(int[,] block)
        {
            var size = block.GetLength(0);
            var copy = new int[size, size];

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    copy[size - j - 1, i] = block[i, j];
                }
            }

            return copy;
        }

        public static bool IsRowClear(int[,] grid, int r)
        {
            for (int c = 0; c < grid.GetLength(0) - 1; c++)
            {
                if (grid[c, r] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static int ClearRow(int[,] grid, int r)
        {
            for (int c = 0; c < grid.GetLength(0) - 5; c++)
            {
                grid[c, r] = 0;
            }
            downCount++;
            return downCount;
        }

        public static void MoveRow(int[,] grid, int r)
        {
            

            for (int c = 0; c < grid.GetLength(0); c++)
            {
                grid[c, r + downCount] = grid[c, r];
                grid[c, r] = 0;
            }
            
        }

        public static void ClearBoard(int[,] grid)
        {
            downCount = 0;
            for (int r = grid.GetLength(1) - 1; r >= 0; r--)
            {
                if (IsRowClear(grid, r))
                {
                    ClearRow(grid, r);
                    downCount++;
                }
                else if (downCount > 0)
                {
                    MoveRow(grid, r);
                }
            }
        }

        public static bool Collision(int[,] grid, int[,] blockGrid)
        {
            for (int r = 0; r <= grid.GetLength(1) - 1; r++)
            {
                for (int c = 0; c <= grid.GetLength(0) - 1; c++)
                {

                    if (blockGrid[c, r] == 1 && grid[c, r] == 1)
                    {
                        return true;

                    }
                }
            }

            return false;
        }
    }
}
