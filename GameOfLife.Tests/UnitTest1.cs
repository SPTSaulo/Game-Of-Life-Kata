using System;
using FluentAssertions;
using GameOfLife;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        
        [Test]
        public void Generate_monodimensional_board_with_one_live_cell()
        {
            int[,] board = new int [,] {{1}};

            int[,] generatedBoard = Game.GenerateNextGenerationBoard(board);

            int[,] expectedBoard = new int[,] {{0}};
            generatedBoard.Should().BeEquivalentTo(expectedBoard);
        }

        
        [Test]
        public void Generate_monodimensional_board_with_one_die_cell_and_one_live_cell()
        {
            int[,] board = new int[,] {{0, 1}};

            int[,] generatedBoard = Game.GenerateNextGenerationBoard(board);

            int[,] expectedBoard = new int[,] {{0, 0}};
            generatedBoard.Should().BeEquivalentTo(expectedBoard);
        }
        
        [Test]
        public void Generate_monodimensional_board_with_three_live_cell()
        {
            int [,] board = new int[,] {{1, 1, 1}};

            int[,] generatedBoard = Game.GenerateNextGenerationBoard(board);

            int[,] expectedBoard = new int[,] {{0, 1, 0}};
            generatedBoard.Should().BeEquivalentTo(expectedBoard);
        }
        
        [Test]
        public void Generate_monodimensional_board_with_one_live_cell_between_two_die_cell()
        {
            int [,] board = new int[,] {{0, 1, 0}};

            int[,] generatedBoard = Game.GenerateNextGenerationBoard(board);

            int[,] expectedBoard = new int[,] {{0, 0, 0}};
            generatedBoard.Should().BeEquivalentTo(expectedBoard);
        }
        
        [Test]
        public void Generate_bidimensional_board_with_one_life_cell_and_one_die_cell()
        {
            int[,] board = new int[,] {{1,1}, {0,1}};

            int[,] generatedBoard = Game.GenerateNextGenerationBoard(board);

            int [,] expectedBoard = new int[,] {{1,1},{1,1}};
            generatedBoard.Should().BeEquivalentTo(expectedBoard);
        }


    }
}