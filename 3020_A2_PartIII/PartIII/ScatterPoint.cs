using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * COMP 3020 Assignment 2, Part III Bonus
 * Joshua Chan 7722727
 * Josh Lemer 7634755
 * 
 * Represents a data point on the scatter chart.
 * Keeps track of male and female counts individually to determine the
 * dominant gender for the point.
*/
namespace PartIII {
    public class ScatterPoint {

        private int age;
        private int year;
        private int femaleCount;
        private int maleCount;

        public ScatterPoint(int age, int year) {
            this.age = age;
            this.year = year;
            maleCount = 0;
            femaleCount = 0;
        }

        public int getAge() {
            return age;
        }

        public int getYear() {
            return year;
        }

        public int getPopulation() {
            return maleCount + femaleCount;
        }

        /*
         *  Returns an integer representing the dominant gender.
         *  0 Implies equality
         *  1 Implies female dominance
         *  2 Implies male dominance
         */
        public int getDominance() {
            int result = 0;
            if (femaleCount > maleCount) {
                result = 1;
            } else if (femaleCount < maleCount) {
                result = 2;
            }
            return result;
        }

        public void addMale() {
            maleCount++;
        }

        public void addFemale() {
            femaleCount++;
        }

        public bool matches(int age, int year) {
            return (this.age == age && this.year == year);
        }



    }
}
