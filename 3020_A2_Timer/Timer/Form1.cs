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
* COMP 3020 Assignment 2, Question II.B
* Joshua Chan 7722727
* Josh Lemer 7634755
*/
namespace Timer {
    public partial class Form1 : Form {

        private int imageIndex = 0;
        private int imageIndexCap;

        public Form1() {
            InitializeComponent();
            imageIndexCap = imageList1.Images.Count;
            timer1.Interval = 10000;
            timer1.Start();
        }

        /*
         *  Every 10 seconds increment an integer.
         *  Use that integer as an index for the ImageList.
         *  The list's size is stored in the integer imageIndexCap.
         *  Reset the count when the index exceed or reach the cap.
         */
        private void timer1_Elapsed(Object sender, EventArgs e) {
            pictureBox1.Image = imageList1.Images[imageIndex];
            imageIndex++;
            if (imageIndex >= imageIndexCap) {
                imageIndex = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e) {

        }
    }
}
