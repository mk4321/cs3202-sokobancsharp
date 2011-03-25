using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Controller
    {
        // Instance variables
        private GameBoard board;
        private frmMain form;

        /* Constructor
         * Accepts the GameBoard object and the Form object
         */
        public Controller(GameBoard board, frmMain form)
        {
            this.board = board;
            this.form = form;
        }

        public void moveLeft()
        {
            board.moveLeft();
            form.Refresh();
        }

        public void moveRight()
        {
            board.moveRight();
            form.Refresh();
        }

        public void moveUp()
        {
            board.moveUp();
            form.Refresh();
        }

        public void moveDown()
        {
            board.moveDown();
            form.Refresh();
        }
    }
}
