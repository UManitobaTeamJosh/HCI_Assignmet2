using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
* COMP 3020 Assignment 2, Question II.A
* Joshua Chan 7722727
* Josh Lemer 7634755
*/
namespace _3020_A2_keyboard
{
    public partial class Form1 : Form
    {
        enum Mode {Select, MoveRight, MoveLeft};

        private int mode = (int)Mode.Select;
        private static readonly char RightKey = 'r';
        private static readonly char LeftKey = 'l';


        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(Form1_KeyPressed);
        }

        /*
         *  Allows user to move the screen by typing either 'r' or 'l'
         *  then typing a number. The state of the program is
         *  stored in the integer "mode". An enum has been created to make these
         *  modes more understandable. The program begins in mode "Select".
         *  
         * When in "Select" the program first awaits for a 'l' or 'r' selection.
         * This will change the mode in a way that corresponds to the user input.
         * 
         * When in either "Move----" mode, the number the user types will determine
         * how far the form moves either left or right.
         */
        private void Form1_KeyPressed(Object sender, KeyPressEventArgs e){
            //Are we selecting left or right? If so, check for the appropriate key
            if (mode == (int)Mode.Select){
                if (e.KeyChar == RightKey) {
                    mode = (int)Mode.MoveRight;
                    e.Handled = true;
                } else if (e.KeyChar == LeftKey) {
                    mode = (int)Mode.MoveLeft;
                    e.Handled = true;
                }
            }else{
                //We're not selecting left or right, so we're inputting a number.
                if (Char.IsDigit(e.KeyChar)){
                    int value = (int)Char.GetNumericValue(e.KeyChar);
                    if (mode == (int)Mode.MoveLeft){
                        panel1.Left -= value;
                    } else if(mode == (int)Mode.MoveRight){
                        panel1.Left += value;
                    }
                    mode = (int)Mode.Select;
                    e.Handled = true;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }
    }
}
