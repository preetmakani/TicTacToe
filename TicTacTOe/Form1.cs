using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TicTacTOe
{
    public partial class Form1 : Form
    {
        bool turn = true; // when true == x turn; false == y turn
        int turnCount = 1;
        int scoreX = 0;
        int scoreO = 0;
        int draw = 0;

        public Form1()
        {
            InitializeComponent();
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Preet Makani", "Tic Tac Toe Program");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            //MessageBox.Show("Works");
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "x";
            }
            else
            {
                b.Text = "O";
            }
            turn = !turn;
            b.Enabled = false;
            checkForWinner();
            turnCount++;
            
        }

        private void checkForWinner()//Logaritm for determining if a player has won
        {
            bool winner = false;
            //Horizontal checks
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                winner = true;

            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                winner = true;

            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                winner = true;

            //Vertical checks
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!C1.Enabled))
                winner = true;

            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!C2.Enabled))
                winner = true;

            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!C3.Enabled))
                winner = true;

            //Diagonal checks
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!C3.Enabled))
                winner = true;

            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                winner = true;


            if (winner)
            {
                disableButtons();
                String player = "";
                if (turn)
                {
                    player = "O";
                    scoreX++;
                    winnerO.Text = ((scoreX)).ToString();
                }
                else
                {
                    player = "X";
                    scoreO++;
                    winnerX.Text = ((scoreO)).ToString();
                }//decides who the winner was
                MessageBox.Show("The Winner is: " + player);

                resetGame();
            }

            else
            {
                if (turnCount == 9) {

                       draw++;
                       draws.Text = ((draw)).ToString();
                       MessageBox.Show("There is a draw");
                       resetGame();
                }
     
            }

          
        }//Checking for a winner

        private void resetGame() 
        {
            turn = true;
            turnCount = 0;

            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }//checking to see if there is any expections 
            }
         
        
        }

        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }//checking to see if there is any expections 
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetGame();

        }

        private void buttonEnter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {

                if (turn == true)
                {
                    b.Text = "X";
                }
                else
                {
                    b.Text = "O";
                }
            }
        }
        
        //change to inheritance 
        private void buttonLeave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }
           
        }

        private void gameResult()
        {
           

            //using (StreamWriter next = new StreamWriter("gameResult.txt", true))//opens file to write.
            //{

            //    next.WriteLine("Player One - X = " + scoreX);//writes line.
            //    next.WriteLine("Player Two - O = " + scoreO);//writes line.
            //    next.WriteLine("Draws = " + draw);//writes line.
            //}
        }

        private void endGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Check the text file to see the final score");
            gameResult();
            Application.Exit();
        }
            
    }
}
