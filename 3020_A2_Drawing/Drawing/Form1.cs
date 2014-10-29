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
* COMP 3020 Assignment 2, Question II.C
* Joshua Chan 7722727
* Josh Lemer 7634755
*/
namespace Drawing {
    public partial class Form1 : Form {

        private bool drawing;
        private SolidBrush brush;

        public Form1() {
            InitializeComponent();
            drawing = false;
            brush = new SolidBrush(Color.Black);
            label1.Text = "Drawing: False";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(form1_mousePress);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(form1_mouseRelease);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(form1_mouseMove);
        }

        /*
         *  Mouse handler for when the mouse is pressed down on the form.
         *  
         * Pressing down sets the boolean "drawing" variable to true.
         * This enables drawing in the form1_mouseMove method.
         */
        private void form1_mousePress(Object sender, EventArgs e) {
            drawing = true;
            label1.Text = "Drawing: True";
        }

        /*
         *  Mouse handler for when the mouse is released on the form.
         *  
         *  Releasing the mouse key sets the boolean "drawing" variable
         *  to false. This disables drawing in the form1_mouseMove method.
         */
        private void form1_mouseRelease(Object sender, EventArgs e) {
            drawing = false;
            label1.Text = "Drawing: False";
        }

        /*
         *  This performs the actual drawing on the form.
         *  
         *  If drawing is set to true, then the mouse coordinates are used
         *  to paint a pixel on the form.
         */
        private void form1_mouseMove(Object sender, MouseEventArgs e) {
            label2.Text = "X: "+e.X.ToString() + "\nY: " + e.Y.ToString();
            if (drawing) {
                Graphics formGraphics = this.CreateGraphics();
                formGraphics.FillRectangle(brush, e.X, e.Y, 1, 1);
            }
        }

    }//classForm1


}
