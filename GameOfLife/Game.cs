using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;

namespace GameOfLife
{
    public class Game
    {
        public static int[,] GenerateNextGenerationBoard(int[,] board)
        {
            int[,] neighboursAlivePerCell = new int[board.GetLength(0), board.GetLength(1)];
            UpdateNeighboursAlivePerCell(neighboursAlivePerCell, board);
            UpdateBoard(neighboursAlivePerCell, board);
            return board;
        }

        private static int[,] UpdateNeighboursAlivePerCell(int[,] neighboursAlivePerCell, int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    neighboursAlivePerCell[i, j] = CountLivingNeigbours(i, j, board);
                }
            }
            return neighboursAlivePerCell;
        }

        private static void UpdateBoard(int[,] neighboursAlivePerCell, int[,] board)
        {
            for (int i = 0; i < neighboursAlivePerCell.GetLength(0); i++)
            {
                for (int j = 0; j < neighboursAlivePerCell.GetLength(1); j++)
                {
                    board[i,j] = (neighboursAlivePerCell[i, j] == 2 || neighboursAlivePerCell[i,j] == 3) && board[i, j] == 1 ? 1 : 0;
                    board[i, j] = (neighboursAlivePerCell[i, j] == 3 && board[i, j] == 0) ? 1 : board[i,j];
                }
            }
        }

        private static int CountLivingNeigbours(int i, int j, int[,] board)
        {
            int count = 0;
            count += CountLeftLivingNeighbours(i, j, board);
            count += CountRightLivingNeigbours(i, j, board);
            //count += CountEndLivingNeighbours(i, j, board);
            count += CountTopLeftLivingNeighbours(i, j, board);
            count += CountTopRightLivingNeighbours(i, j, board);
            count += CountUnderLivingNeighbours(i, j, board);
            count += CountUpLivingNeighbours(i, j, board);
            count += CountLowerRightNeighBours(i, j, board);
            return count;
        }

        private static int CountLowerRightNeighBours(int i, int j, int[,] board)
        {
            try
            {
                if (board[i + 1, j + 1] == 1) return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
            return 0;
        }

        private static int CountUpLivingNeighbours(int i, int j, int[,] board)
        {
            try
            {
                if (board[i - 1, j] == 1) return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
            return 0;
        }

        private static int CountUnderLivingNeighbours(int i, int j, int[,] board)
        {
            try
            {
                if (board[i + 1, j] == 1) return 1;
            }
            catch (Exception e)
            {
                return 0;
            }

            return 0;
        }

        private static int CountTopRightLivingNeighbours(int i, int j, int[,] board)
        {
            try
            {
                if (board[i - 1, j + 1] == 1) return 1;
            }
            catch (Exception e)
            {
                return 0;
            }

            return 0;
        }

        private static int CountTopLeftLivingNeighbours(int i, int j, int[,] board)
        {
            try
            {
                if (board[i - 1, j - 1] == 1) return 1;
            }
            catch (Exception e)
            {
                return 0;
            }

            return 0;
        }

        private static int CountLeftLivingNeighbours(int i, int j, int[,] board)
        {
            try
            {
                if (board[i, j - 1] == 1) return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
            return 0;
        }

        private static int CountRightLivingNeigbours(int i, int j, int[,] board)
        {
            try
            {
                if (board[i, j + 1] == 1) return 1;
            }
            catch (Exception e)
            {
                return 0;
            }

            return 0;
        }

        private static int CountEndLivingNeighbours(int i, int j, int[,] board)
        {
            int count = 0;
            if (j == board.GetLength(1) - 1 && board.GetLength(1) > 1)
            {
                if (board[i, j - 1] == 1) count++;
            }
            return count;
        }
    }
}

