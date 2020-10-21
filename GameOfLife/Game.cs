using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GameOfLife
{
    public class Game
    {
        public static int[,] GenerateNextGenerationBoard(int[,] board)
        {
            int [,] neighboursAlivePerCell = new int[board.GetLength(0), board.GetLength(1)];
            UpdateNeighboursAlivePerCell(neighboursAlivePerCell, board);
            UpdateBoard(neighboursAlivePerCell, board);
            return board;
        }

        private static int [,] UpdateNeighboursAlivePerCell(int[,] neighboursAlivePerCell, int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    neighboursAlivePerCell[i,j] = CountLivingNeigbours(i, j, board);
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
                    board[i, j] = neighboursAlivePerCell[i, j] == 2 && board[i, j] == 1 ? 1 : 0;
                }
            }
        }

        private static int CountLivingNeigbours(int i, int j, int[,] board)
        {
            int count = 0;
            count += CountStartLivingNeighbours(i, j, board);
            count += CountMiddleLivingNeigbours(i, j, board);
            count += CountEndLivingNeighbours(i, j, board);
            return count;
        }

        private static int CountStartLivingNeighbours(int i, int j, int[,] board)
        {
            int count = 0;
            if (j == 0 && board.GetLength(1) > 1)
            {
                if (board[i, j + 1] == 1) count++;
            }

            return count;
        }

        private static int CountMiddleLivingNeigbours(int i, int j, int[,] board)
        {
            int count = 0;
            if (j < board.GetLength(1) - 1 && j > 0)
            {
                if (board[i, j - 1] == 1) count++;
                if (board[i, j + 1] == 1) count++;
            }
            return count;
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

