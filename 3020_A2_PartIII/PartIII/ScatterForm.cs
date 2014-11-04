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
 * COMP 3020 Assignment 2, Part III Bonus
 * Joshua Chan 7722727
 * Josh Lemer 7634755
 * 
 * Form shows a scatter plot representation of the students as dots whose
 * size and colour represent the students in each category.
 * Dots scale with the number of students represented, up to a maximum of 50.
 * This was not a technical decision, but a soft one. We feel that dots larger
 * than that would obscure too much of the screen.
 * 
 * The colour of the dots represent the dominant gender by number.
*/
namespace PartIII {
    public partial class ScatterForm : Form {

        private List<Student> studentList;
        private List<Student> graphMembers;
        private Form1 parent;

        public ScatterForm(Form1 parent, List<Student> studentList) {
            InitializeComponent();
            this.parent = parent;
            this.studentList = studentList;
            graphMembers = new List<Student>();
            populateChart();
        }

        /*
         *  Draws the chart given the contents of studentList.
         *  
         *  First iterates through all students, pulling their age and year.
         *  It then checks if a point exists that corresponds to that age and year.
         *  If not, then one is created and that student added as the appropriate gender.
         *  If so, then we add a count of the appropriate gender to that point.
         *  
         * When that's done, we iterate through all the points and draw each
         * one on the chart. Age is used for the x value, year for the y value, and
         * the total population for the 2nd y value.
         * 
         * Points on the chart will grow as the population they represent grows,up to
         * a maximum of 50 students. This was made as a soft decision, as any higher
         * would cover up too much of the rest of the chart.
         */
        public void populateChart() {
            if (studentList != null) {
                foreach (var series in chart1.Series) {
                    series.Points.Clear();
                }
                List<ScatterPoint> pointList = new List<ScatterPoint>();
                pointList.Clear();
                //Process students into points
                foreach (Student student in studentList) {
                    int year = student.yearValue();
                    int age = student.age;
                    //See if we already have a point
                    bool pointExists = false;
                    foreach (ScatterPoint point in pointList) {
                        if (point.matches(age, year)) {
                            pointExists = true;
                            if (student.gender.Equals("Male")) {
                                point.addMale();
                            } else {
                                point.addFemale();
                            }
                        }
                    }//foreach ScatterPoint
                    if (!pointExists) {
                        ScatterPoint newPoint = new ScatterPoint(age,year);
                        if (student.gender.Equals("Male")) {
                            newPoint.addMale();
                        } else {
                            newPoint.addFemale();
                        }
                        pointList.Add(newPoint);
                    }
                }//end of process student into points
                //Add each point to the chart
                foreach (ScatterPoint point in pointList) {
                    if(point.getYear() <= trackBar1.Value){
                    switch (point.getDominance()) {
                        case 0:
                            chart1.Series["Even Genders"].Points.AddXY(point.getAge(),point.getYear(),point.getPopulation());
                            break;
                        case 1:
                            chart1.Series["Female Dominant"].Points.AddXY(point.getAge(), point.getYear(), point.getPopulation());
                            break;
                        case 2:
                            chart1.Series["Male Dominant"].Points.AddXY(point.getAge(), point.getYear(), point.getPopulation());
                            break;
                    }
                }
                    
                }//each Point
            }
        }

        /*
         *  Redraw the chart when the user scrolls the track bar
         */
        private void trackBar1_Scroll(object sender, EventArgs e) {
            populateChart();
        }//populateChart

        /*
         *  We keep the scatter form as an instance variable in Form1 so the user cannot
         *  open multiple charts. We communicate that the chart has closed and
         *  that another must be instantiated by having the this call
         *  scatterFormClose on it's parent Form1.
         */
        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            parent.scatterFormClose();
        }

    }
}
