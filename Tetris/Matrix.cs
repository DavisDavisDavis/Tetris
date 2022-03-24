

namespace Tetris 
{
    internal class Matrix
    {
     

        public static int ClearRow(int fullRow, int[,] grid, int r, int downCount)
        {
            if (fullRow >= grid.GetLength(0))
            {
                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    grid[i, r] = 0;
                }
                return downCount++;
            }
            return 0;
        }

        public static void MoveRow(int fullRow, int[,] grid, int r, int downCount)
        {
            

            for (int c = 0; c < grid.GetLength(0); c++)
            {
                grid[c, r + downCount] = grid[c, r];
                grid[c, r] = 0;
            }
            
        }

    }
}
