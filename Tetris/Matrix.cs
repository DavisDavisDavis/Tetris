

namespace Tetris 
{
    internal class Matrix
    {
        public static void ClearRow(int fullRow, int[,] grid, int r)
        {
            if (fullRow >= grid.GetLength(0))
            {
                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    grid[i, r] = 0;
                }
            }
        }

        public static void MoveRow(int fullRow, int[,] grid, int r, int downCount)
        {
            for (int c = 0; c < grid.GetLength(1); c++)
            {
                grid[r + downCount, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

    }
}
