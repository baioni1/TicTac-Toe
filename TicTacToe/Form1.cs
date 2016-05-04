using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int player = 2;//even=X turn 0dd=O turn
        public int turns = 0;//counting turns
        public int p1 = 0;
        public int p2 = 0;
        public int gameDraw = 0;

        private void ButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "")
            {
                if (player % 2 == 0)
                {
                    button.Text = "X";
                    player++;
                    turns++;
                }
                else
                {
                    button.Text = "O";
                    player++;
                    turns++;
                }
                if (CheckDraw() == true)
                {
                    MessageBox.Show("Tie Game");
                    gameDraw++;
                    NewGame();
                }
                if (CheckWinner() == true)
                {
                    if (button.Text == "X")
                    {
                        MessageBox.Show("X's win!");
                        p1++;
                        NewGame();
                    }
                    else
                    {
                        MessageBox.Show("O's win!");
                        p2++;
                        NewGame();
                    }
                }
            }
        }


        bool CheckWinner()
        {//horizontal check
            if ((A00.Text == A01.Text) && (A01.Text == A02.Text) && A00.Text != "")
            {
                return true;
            }
            else if ((A10.Text == A11.Text) && (A11.Text == A12.Text) && A10.Text != "")
            {
                return true;
            }
            else if ((A20.Text == A21.Text) && (A21.Text == A22.Text) && A20.Text != "")
            {
                return true;
            }

            //vertical check
            if ((A00.Text == A10.Text) && (A10.Text == A20.Text) && A00.Text != "")
            {
                return true;
            }
            else if ((A01.Text == A11.Text) && (A11.Text == A21.Text) && A01.Text != "")
            {
                return true;
            }
            else if ((A02.Text == A12.Text) && (A12.Text == A22.Text) && A02.Text != "")
            {
                return true;
            }

            //diagonal check
            if ((A00.Text == A11.Text) && (A11.Text == A22.Text) && A00.Text != "")
            {
                return true;
            }
            else if ((A02.Text == A11.Text) && (A11.Text == A20.Text) && A02.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XWin.Text = "X:" + p1;
            OWin.Text = "O:" + p2;
            Draws.Text = "Draws:" + gameDraw;
        }
        void NewGame()
        {
            player = 2;
            turns = 0;
            A00.Text = A01.Text = A02.Text = A10.Text = A11.Text = A12.Text = A20.Text = A21.Text = A22.Text = "";
            XWin.Text = "X:" + p1;
            OWin.Text = "O:" + p2;
            Draws.Text = "Draws:" + gameDraw;

        }

        private void NGButton_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        bool CheckDraw()
        {
            if ((turns == 9) &&CheckWinner()== false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            p1 = p2 = gameDraw = 0;
            NewGame();
        }
    }
}
