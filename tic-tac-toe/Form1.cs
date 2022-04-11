using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {

        public int[] listOfX = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public int[] listOfO = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public char turn = 'X';

        public Form1()
        {
            InitializeComponent();

            this.turnLable.Text = "X";
        }

        void reset()
        {
            void resetByGivenArray(int[] givenArray)
            {
                for(int i=0;i< givenArray.Length; i++)
                {
                    givenArray[i] = 0;
                }
            }

            resetByGivenArray(listOfX);
            resetByGivenArray(listOfO);

            this.button1.Text = "";
            this.button2.Text = "";
            this.button3.Text = "";
            this.button4.Text = "";
            this.button5.Text = "";
            this.button6.Text = "";
            this.button7.Text = "";
            this.button8.Text = "";
            this.button9.Text = "";

            this.turnLable.Text = "X";
        }

        void changeTurn()
        {
            if (turn == 'X')
            {
                turn = 'O';
                this.turnLable.Text = "O";
            }
            else 
            {
                turn = 'X';
                this.turnLable.Text = "X";
            }
        }

        Boolean checkForWinForGivenList(int[] givenList)
        {
            Boolean conditions1 = givenList[0] == 1 && givenList[1] == 1 && givenList[2] == 1;
            Boolean conditions2 = givenList[3] == 1 && givenList[4] == 1 && givenList[5] == 1;
            Boolean conditions3 = givenList[6] == 1 && givenList[7] == 1 && givenList[8] == 1;

            Boolean conditions4 = givenList[0] == 1 && givenList[3] == 1 && givenList[6] == 1;
            Boolean conditions5 = givenList[1] == 1 && givenList[4] == 1 && givenList[7] == 1;
            Boolean conditions6 = givenList[2] == 1 && givenList[5] == 1 && givenList[8] == 1;

            Boolean conditions7 = givenList[0] == 1 && givenList[4] == 1 && givenList[8] == 1;
            Boolean conditions8 = givenList[6] == 1 && givenList[4] == 1 && givenList[2] == 1;

            return (conditions1 || conditions2 || conditions3 || conditions4 || conditions5 || conditions6 || conditions7 || conditions8);
        }


        Boolean checkForWin()
        {
            if (checkForWinForGivenList(listOfX))
            {
                MessageBox.Show("X wins");
                reset();
                return true;
            }

            if (checkForWinForGivenList(listOfO))
            {
                MessageBox.Show("O wins");
                reset();
                return true;
            }
            return false;
        }


        Boolean checkForDraw()
        {
            
            int loopIntoGivenArray(int[] givenArray)
            {
                int countOfFilled = 0;
                foreach(int val in givenArray)
                {
                    if (val == 1)
                        countOfFilled += 1;
                }
                return countOfFilled;
            }

            if(loopIntoGivenArray(listOfX) + loopIntoGivenArray(listOfO) >= 9)
            {
                MessageBox.Show("Draw");
                reset();
                return true;
            }
            return false;
                
        }

        void doClick(int index, Button button)
        {
            if (listOfX[index] == 0 && listOfO[index] == 0)
            {
                if (turn == 'X')
                {
                    button.Text = "X";
                    listOfX[index] = 1;
                }

                else
                {
                    button.Text = "O";
                    listOfO[index] = 1;
                }
                if (checkForWin())
                    return;
                if (checkForDraw())
                    return;
                changeTurn();
            }
            else
            {
                MessageBox.Show("This box is already taken");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doClick(0, this.button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            doClick(1, this.button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            doClick(2, this.button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            doClick(3, this.button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            doClick(4, this.button5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            doClick(5, this.button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            doClick(6, this.button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            doClick(7, this.button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            doClick(8, this.button9);
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
}
