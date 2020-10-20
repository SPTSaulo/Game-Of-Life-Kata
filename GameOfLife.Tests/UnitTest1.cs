using System;
using FluentAssertions;
using GameOfLife;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Generate_board_with_one_live_cell()
        {
            int[] board = new int [] {1};

            int[] generateBoard = Game.GenerateNextGenerationBoard(board);

            int[] expectedBoard = new int[] {0};
            generateBoard.Should().BeEquivalentTo(expectedBoard);
        }

        [Test]
        public void Generate_board_with_one_die_cell_and_one_live_cell()
        {
            int[] board = new int[] {0, 1};

            int[] generateBoard = Game.GenerateNextGenerationBoard(board);

            int[] expectedBoard = new int[] {0, 0};
            generateBoard.Should().BeEquivalentTo(expectedBoard);
        }

        [Test]
        public void Generate_board_with_three_live_cell()
        {
            int [] board = new int[] {1, 1, 1};

            int[] generateBoard = Game.GenerateNextGenerationBoard(board);

            int[] expectedBoard = new int[] {0, 1, 0};
            generateBoard.Should().BeEquivalentTo(expectedBoard);
        }

        [Test]
        public void Generate_board_with_one_live_cell_between_two_die_cell()
        {
            int [] board = new int[] {0, 1, 0};

            int[] generateBoard = Game.GenerateNextGenerationBoard(board);

            int[] expectedBoard = new int[] {0, 0, 0};
            generateBoard.Should().BeEquivalentTo(expectedBoard);
        }
    }
}