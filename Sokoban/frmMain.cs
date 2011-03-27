using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sokoban
{
    public partial class frmMain : Form
    {
        // Instance variables
        private Controller gameController;
        private GameBoard board;
        private int cellHeight = 20, cellWidth = 20;

        // Create an instance variable for the player and the ball
        private Image player = Image.FromFile("../../Images/character.gif");
        //private Image player = Image.FromFile("../../Images/pacman.gif");
        private Image ball = Image.FromFile("../../Images/ball.gif");

        // Default constructor
        public frmMain()
        {
            InitializeComponent();
        }

        /* Constructor used to accept the GameBoard object
         * Sets up the Form, stores the GameBoard object,
         *  and creates a Controller object
         */

        public frmMain(GameBoard board)
        {
            InitializeComponent();
            this.board = board;
            gameController = new Controller(board, this);
        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics g = this.CreateGraphics();
            
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Just to show you how to fill a rectangle in C#
            //  - you'll want to remove this line of code! (and the comments)
            //g.FillRectangle(new SolidBrush(Color.Black), 100, 125, cellWidth, cellHeight);
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

           // Get the entire board and paint it
            for (int rows = 0; rows < board.getBoardRows(); rows++)
            {
                for (int columns = 0; columns < board.getBoardColumns(); columns++)
                {
                    char current = board.getCharacter(rows, columns);
                    if (current == 'p')
                    {
                        Point p = new Point(cellWidth * columns, cellHeight * rows);
                        g.DrawImage(player, p);
                    }
                    else if (current == '#')
                    {
                        g.FillRectangle(new SolidBrush(Color.Blue), cellWidth * columns, cellHeight * rows, cellWidth, cellHeight);    
                    }
                    else if (current == 'g')
                    {
                        g.FillRectangle(new SolidBrush(Color.Gold), cellWidth * columns, cellHeight * rows, cellWidth, cellHeight); 
                    }
                    else if (current == 'b')
                    {
                        Point p = new Point(cellWidth * columns, cellHeight * rows);
                        g.DrawImage(ball, p);
                    }
                    else if (current == ' ')
                    {
                        g.FillRectangle(new SolidBrush(Color.Green), cellWidth * columns, cellHeight * rows, cellWidth, cellHeight);    
                    }
                }
            }
        }


        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                gameController.moveLeft();
            }
            else if (e.KeyCode == Keys.Right)
            {
                gameController.moveRight();
            }
            else if (e.KeyCode == Keys.Up)
            {
                gameController.moveUp();
            }
            else if (e.KeyCode == Keys.Down)
            {
                gameController.moveDown();
            }
        }
    }
}
