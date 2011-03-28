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

        private Image wall = Image.FromFile("../../Images/wall.gif");
        private Image goal = Image.FromFile("../../Images/goal.gif");

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
            //SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //SetStyle(ControlStyles.DoubleBuffer, true);
            this.ClientSize = new System.Drawing.Size(board.getBoardColumns() * 20, board.getBoardRows() * 20);
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
                        Point p = new Point(cellWidth * columns, cellHeight * rows);
                        g.DrawImage(wall, p);    
                    }
                    else if (current == 'g')
                    {
                        Point p = new Point(cellWidth * columns, cellHeight * rows);
                        g.DrawImage(goal, p);  
                    }
                    else if (current == 'b')
                    {
                        Point p = new Point(cellWidth * columns, cellHeight * rows);
                        g.DrawImage(ball, p);
                    }
                    else if (current == ' ')
                    {
                        g.FillRectangle(new SolidBrush(Color.Black), cellWidth * columns, cellHeight * rows, cellWidth, cellHeight);    
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
