using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class GameBoard
    {
        // Instance variables
        private char[,] theBoard;
        private int playerRow;
        private int playerColumn;
        private int boardRows = 30;
        private int boardColumns = 30;

        public GameBoard()
        {
            theBoard = new char[boardRows, boardColumns];
            playerRow = 10;
            playerColumn = 10;
            theBoard[playerRow, playerColumn] = 'p';
        }

        public char getCharacter(int row, int col)
        {
            return theBoard[row, col];
        }

        public void moveLeft()
        {
            theBoard[playerRow, playerColumn] = ' ';
            playerColumn--;
            theBoard[playerRow, playerColumn] = 'p';
        }

        public void moveRight()
        {
            theBoard[playerRow, playerColumn] = ' ';
            playerColumn--;
            theBoard[playerRow, playerColumn] = 'p';
        }

        public void moveUp()
        {
            theBoard[playerRow, playerColumn] = ' ';
            playerColumn--;
            theBoard[playerRow, playerColumn] = 'p';
        }

        public void moveDown()
        {
            theBoard[playerRow, playerColumn] = ' ';
            playerColumn--;
            theBoard[playerRow, playerColumn] = 'p';
        }

        public int getBoardRows() { return boardRows; }
        public int getBoardColumns() { return boardColumns; }
    }
}
