using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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
            originalCloneBoard = new char[boardRows, boardColumns];
            //playerRow = 10;
            //playerColumn = 10;
            //theBoard[playerRow, playerColumn] = 'p';

            //theBoard[0, 0] = 'b';

            populateBoard("../../Images/board.txt");
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
                nextTwoTiles = nextTwoTiles + Convert.ToString(theBoard[playerRow + rowShiftByOne , playerColumn + columnShiftByOne]) + Convert.ToString(theBoard[playerRow + rowShiftByTwo , playerColumn + columnShiftByTwo]);
            }
            if (theBoard[playerRow + rowShiftByOne , playerColumn + columnShiftByOne] != '#' && !nextTwoTiles.Equals("bb") && !nextTwoTiles.Equals("b#"))
            {
                if (Convert.ToChar(nextTwoTiles.Substring(0, 1)) == ' ' || Convert.ToChar(nextTwoTiles.Substring(0, 1)) == 'g')
                {
                    theBoard[playerRow , playerColumn] = originalCloneBoard[playerRow , playerColumn];
                    playerColumn = playerColumn + columnShiftByOne;
                    playerRow = playerRow + rowShiftByOne;
                    theBoard[playerRow , playerColumn] = 'p';
                }
                else if (Convert.ToChar(nextTwoTiles.Substring(0, 1)) == 'b')
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
            move(0, 0, -1, -2);
        }

        public void moveRight()
        {
            move(0, 0, 1, 2);
        }

        public void moveUp()
        {
            move(-1, -2, 0, 0);
        }

        public void moveDown()
        {
            move(1, 2, 0, 0);
        }

        public int getBoardRows() { return boardRows; }
        public int getBoardColumns() { return boardColumns; }

        private void populateBoard(String fileName)
        {
            string line;

            if (File.Exists(fileName))
            {
                StreamReader file = null;
                int row = -1;
                try
                {
                    file = new StreamReader(fileName);
                    while ((line = file.ReadLine()) != null)
                    {
                        row++;
                        for (int column = 0; column < 20; column++)
                        {
                            //System.Windows.Forms.MessageBox.Show(line.Substring(column, 1));
                            theBoard[row, column] = Convert.ToChar(line.Substring(column, 1));
                            if(Convert.ToChar(line.Substring(column, 1)) == 'p'){
                                playerRow = row;
                                playerColumn = column;
                            }
                            //Populates a clone of the board replacing boulders with blank spaces to help in movement redrawing
                            originalCloneBoard[row, column] = Convert.ToChar(line.Substring(column, 1));
                            if (Convert.ToChar(line.Substring(column, 1)) == 'b')
                            {
                                originalCloneBoard[row, column] = ' ';
                            }
                        }
                    }
                    //Replaces where the player is found with a blank space in the clone board to help in movement redrawing.
                    originalCloneBoard[playerRow, playerColumn] = ' ';
                }
                finally
                {
                    if (file != null)
                        file.Close();
                }
            }
        }
    }
}
