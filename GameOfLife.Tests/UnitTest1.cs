using System;
using FluentAssertions;
using GameOfLife;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void Generate_board_with_one_die_cell()
        {
            char[] board = new char [] {'-'};

            char[] generateBoard = Game.EvaluateBoard(board);

            char[] expectedBoard = new char[] {'-'};
            generateBoard.Should().BeEquivalentTo(expectedBoard);
        }

        [Test]
        public void Generate_board_with_one_die_cell_and_one_live_cell()
        {
            char[] board = new char[] {'-','*'};

            char[] generateBoard = Game.EvaluateBoard(board);

            char[] expectedBoard = new char[] {'*','*'};
            generateBoard.Should().BeEquivalentTo(expectedBoard);
        }
    }
}