using System;
using FluentAssertions;
using GameOfLife;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        
        [Test]
        public void Generate_monodimensional_board_where_one_live_cell_die()
        {
            int[,] board = new int [,] {{1}};

            int[,] generatedBoard = Game.GenerateNextGenerationBoard(board);

            int[,] expectedBoard = new int[,] {{0}};
            generatedBoard.Should().BeEquivalentTo(expectedBoard);
        }

        
        [Test]
        public void Generate_monodimensional_board_where_live_cell_die_by_underpopulation()
        {
            int[,] board = new int[,] {{0, 1}};

            int[,] generatedBoard = Game.GenerateNextGenerationBoard(board);

            int[,] expectedBoard = new int[,] {{0, 0}};
            generatedBoard.Should().BeEquivalentTo(expectedBoard);
        }
        
        [Test]
        public void Generate_monodimensional_board_with_three_live_cell_where_1_cell_survive()
        {
            int [,] board = new int[,] {{1, 1, 1}};

            int[,] generatedBoard = Game.GenerateNextGenerationBoard(board);

            int[,] expectedBoard = new int[,] {{0, 1, 0}};
            generatedBoard.Should().BeEquivalentTo(expectedBoard);
        }
        
        [Test]
        public void Generate_monodimensional_board_with_one_live_cell_between_two_die_cell_where_live_cell_die_by_underpopulation()
        {
            int [,] board = new int[,] {{0, 1, 0}};

            int[,] generatedBoard = Game.GenerateNextGenerationBoard(board);

            int[,] expectedBoard = new int[,] {{0, 0, 0}};
            generatedBoard.Should().BeEquivalentTo(expectedBoard);
        }
        
        [Test]
        public void Generate_bidimensional_board_where_die_cell_revive()
        {
            int[,] board = new int[,] {{1,1}, {0,1}};

            int[,] generatedBoard = Game.GenerateNextGenerationBoard(board);

            int [,] expectedBoard = new int[,] {{1,1},{1,1}};
            generatedBoard.Should().BeEquivalentTo(expectedBoard);
        }
        
        [Test]
        public void Generate_bidimensional_board_with_four_live_cell_where_all_live()
        {
            int[,] board = new int[,] {{1, 1}, {1, 1}};

            int[,] generateBoard = Game.GenerateNextGenerationBoard(board);

            int[,] expectedBoard = new int[,] {{1, 1}, {1, 1}};
            generateBoard.Should().BeEquivalentTo(expectedBoard);
        }

        [Test]
        public void Generate_bidimensional_board_where_live_cell_die_by_overcrowding()
        {
            int [,] board = new int[,] {{0,1,0}, {1,1,1}, {0,1,0}};

            int[,] generateBoard = Game.GenerateNextGenerationBoard(board);

            int [,] expectedBoard = new int[,] {{1,1,1},{1,0,1},{1,1,1}};
            generateBoard.Should().BeEquivalentTo(expectedBoard);
        }
    }
}