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
* COMP 3020 Assignment 2, Part II.C
* Joshua Chan 7722727
* Josh Lemer 7634755
*/

namespace Scrollbar {
    public partial class Form2 : Form {
        public Form2() {
            InitializeComponent();
        }

        /*
         *  Makes the resizing occur.
         *  
         * Textbox properties have been changed necessarily (in Form2.Designer.cs
         * since the edits were done in the visual editor)
         * 
         */
        private void textBox1_TextChanged(object sender, EventArgs e) {
            //Returns the dimensions of the textbox given its current contents and font
            Size size = TextRenderer.MeasureText(textBox1.Text,textBox1.Font);
            //Only resize if the width of the textbox is less than the form. 
            //This way the scrollbar takes over when the box size exceeds the form.
            if (size.Width <= this.Width ) {
                textBox1.Width = size.Width;
            }
        }
    }
}
