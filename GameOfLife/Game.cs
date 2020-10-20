using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Game
    {
        public static int[] GenerateNextGenerationBoard(int[] board)
        {
            int [] neighborsAlivePerCell = new int[board.GetLength(0)];
            updateNeighborsAlivePerCell(neighborsAlivePerCell, board);
            updateBoard(neighborsAlivePerCell, board);
            return board;
        }

        private static void updateBoard(int[] neighborsAlivePerCell, int[] board)
        {
            for (int i = 0; i < neighborsAlivePerCell.Length; i++)
            {
                board[i] = neighborsAlivePerCell[i] == 2 && board[i] == 1 ? 1 : 0;
            }
        }

        private static void updateNeighborsAlivePerCell(int[] neighborsAlivePerCell, int[] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                neighborsAlivePerCell[i] = CountLivingNeigbors(i, board);
            }
        }

        private static int CountLivingNeigbors(int i, int[] board)
        {
            int count = 0;
            count += CountMiddleLivingNeigbors(i, board);
            count += CountStartLivingNeighbors(i, board);
            count += CountEndLivingNeighbors(i, board);
            return count;
        }

        private static int CountEndLivingNeighbors(int i, int[] board)
        {
            int count = 0;
            if (i == board.GetLength(0) - 1 && board.GetLength(0) > 1)
            {
                if (board[i - 1] == 1) count++;
            }
            return count;
        }

        private static int CountStartLivingNeighbors(int i, int[] board)
        {
            int count = 0;
            if (i == 0 && board.GetLength(0) > 1)
            {
                if (board[i + 1] == 1) count++;
            }

            return count;
        }

        private static int CountMiddleLivingNeigbors(int i, int[] board)
        {
            int count = 0;
            if (i < board.GetLength(0) - 1 && i > 0)
            {
                if (board[i - 1] == 1) count++;
                if (board[i + 1] == 1) count++;
            }
            return count;
        }
    }
}

