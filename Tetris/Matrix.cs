

namespace Tetris 
{
    internal class Matrix
    {
     
        private static int downCount { get; set; }
        private static bool fullRow { get; set; }

        public static bool IsRowClear(int[,] grid, int r)
        {
            for (int c = 0; c < grid.GetLength(0); c++)
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
            for (int c = 0; c < grid.GetLength(0); c++)
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
    }
}
