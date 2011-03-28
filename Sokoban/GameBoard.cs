using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Sokoban
{
   /**
    * Reads in the file representing the board and handles movement logic.
    * 
    * @author Lewis Williams
    * @version 2011.2.17
    */
    public class GameBoard
    {
        // Instance variables
        private char[,] theBoard;
        private char[,] originalCloneBoard;
        private int playerRow;
        private int playerColumn;
        private int boardRows;
        private int boardColumns;
        private String boardSource = "board.txt";

        public GameBoard()
        {
            SetBoardDimensions("../../Images/" + boardSource);
            theBoard = new char[boardRows, boardColumns];
            originalCloneBoard = new char[boardRows, boardColumns];
            PopulateBoard("../../Images/" + boardSource);
        }

        public char getCharacter(int row, int col)
        {
            return theBoard[row, col];
        }

        /*
         * The move method moves the player (and boulders if necessary) 
         * by the amounts specified in the parameters
         * 
         * @param rowShiftByOne
         * 			the amount to change the row index to move one square
         * @param rowShiftByTwo
         * 			the amount to change the row index to move two squares
         * @param columnShiftByOne
         * 			the amount to change the column index to move one square
         * @param columnShiftByTwo
         * 			the amount to change the column index to move two squares
         */
        private void Move(int rowShiftByOne, int rowShiftByTwo, int columnShiftByOne, int columnShiftByTwo)
        {
            String nextTwoTiles = "";
            //Checks to make sure the the row or column the player is attempting to enter 
            //is not the first or last (the entire board must be surrounded by walls)
            if (playerColumn + columnShiftByTwo == -1 || playerRow + rowShiftByTwo == -1 || playerColumn + columnShiftByTwo == boardColumns || playerRow + rowShiftByTwo == boardRows)
            {
                nextTwoTiles = "bb";
            }
            else
            {
                nextTwoTiles = nextTwoTiles + Convert.ToString(theBoard[playerRow + rowShiftByOne, playerColumn + columnShiftByOne]) + Convert.ToString(theBoard[playerRow + rowShiftByTwo, playerColumn + columnShiftByTwo]);
            }
            if (theBoard[playerRow + rowShiftByOne, playerColumn + columnShiftByOne] != '#' && !nextTwoTiles.Equals("bb") && !nextTwoTiles.Equals("b#"))
            {
                if (Convert.ToChar(nextTwoTiles.Substring(0, 1)) == ' ' || Convert.ToChar(nextTwoTiles.Substring(0, 1)) == 'g')
                {
                    theBoard[playerRow, playerColumn] = originalCloneBoard[playerRow, playerColumn];
                    playerColumn = playerColumn + columnShiftByOne;
                    playerRow = playerRow + rowShiftByOne;
                    theBoard[playerRow, playerColumn] = 'p';
                }
                else if (Convert.ToChar(nextTwoTiles.Substring(0, 1)) == 'b')
                {
                    theBoard[playerRow, playerColumn] = originalCloneBoard[playerRow, playerColumn];
                    theBoard[playerRow + rowShiftByTwo, playerColumn + columnShiftByTwo] = 'b';
                    playerColumn = playerColumn + columnShiftByOne;
                    playerRow = playerRow + rowShiftByOne;
                    theBoard[playerRow, playerColumn] = 'p';
                }
            }
        }

        public void MoveLeft()
        {
            Move(0, 0, -1, -2);
        }

        public void MoveRight()
        {
            Move(0, 0, 1, 2);
        }

        public void MoveUp()
        {
            Move(-1, -2, 0, 0);
        }

        public void MoveDown()
        {
            Move(1, 2, 0, 0);
        }

        public int getBoardRows() { return boardRows; }
        public int getBoardColumns() { return boardColumns; }

        /**
         * Reads in the board file and maps it to theBoard and the originalCloneBoard
         * @param filename
         * 			The name of the file being read in.
         */
        private void PopulateBoard(String fileName)
        {
            string line;

            if (File.Exists(fileName))
            {
                StreamReader file = null;
                try
                {
                    int row = -1;

                    file = new StreamReader(fileName);
                    //Populates theBoard by reading in and parsing the lines of the file.
                    while ((line = file.ReadLine()) != null)
                    {
                        row++;
                        //Loops through the line
                        for (int column = 0; column < 20; column++)
                        {
                            theBoard[row, column] = Convert.ToChar(line.Substring(column, 1));
                            //Sets the playerRow and playerColumn when 'p' is found
                            if (Convert.ToChar(line.Substring(column, 1)) == 'p')
                            {
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
                //Handles if the board file cannot be found.
                finally
                {
                    if (file != null)
                        file.Close();
                }
            }
        }

        private void SetBoardDimensions(String fileName)
        {
            if (File.Exists(fileName))
            {
                StreamReader file = null;
                try
                {
                    String line;
                    int rowCount = 0;
                    int columnCount = 0;
                    file = new StreamReader(fileName);
                    while ((line = file.ReadLine()) != null)
                    {
                        rowCount++;
                        if (line.Length > columnCount)
                        {
                            columnCount = line.Length;
                        }
                    }
                    boardRows = rowCount;
                    boardColumns = columnCount;
                }
                //Handles if the board file cannot be found.
                finally
                {
                    if (file != null)
                        file.Close();
                }
            }
        }







    }
}
