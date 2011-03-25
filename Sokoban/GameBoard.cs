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
        private char[,] originalCloneBoard;
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

        private void move(int rowShiftByOne, int rowShiftByTwo, int columnShiftByOne, int columnShiftByTwo)
        {
            String nextTwoTiles = "";
            if (playerColumn + columnShiftByTwo == -1)
            {
                nextTwoTiles = "bb";
            }
            else
            {
                nextTwoTiles = nextTwoTiles + String.valueOf(theBoard[playerRow + rowShiftByOne , playerColumn + columnShiftByOne]) + String.valueOf(theBoard[playerRow + rowShiftByTwo , playerColumn + columnShiftByTwo]);
            }
            if (theBoard[playerRow + rowShiftByOne , playerColumn + columnShiftByOne] != '#' && !nextTwoTiles.Equals("bb") && !nextTwoTiles.Equals("b#"))
            {
                if (nextTwoTiles.charAt(0) == ' ' || nextTwoTiles.charAt(0) == 'g')
                {
                    theBoard[playerRow , playerColumn] = originalCloneBoard[playerRow , playerColumn];
                    playerColumn = playerColumn + columnShiftByOne;
                    playerRow = playerRow + rowShiftByOne;
                    theBoard[playerRow , playerColumn] = 'p';
                }
                else if (nextTwoTiles.charAt(0) == 'b')
                {
                    theBoard[playerRow , playerColumn] = originalCloneBoard[playerRow , playerColumn];
                    theBoard[playerRow + rowShiftByTwo , playerColumn + columnShiftByTwo] = 'b';
                    playerColumn = playerColumn + columnShiftByOne;
                    playerRow = playerRow + rowShiftByOne;
                    theBoard[playerRow , playerColumn] = 'p';
                }
            }
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
