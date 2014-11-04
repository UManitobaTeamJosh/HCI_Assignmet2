using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * COMP 3020 Assignment 2, Part III
 * Joshua Chan 7722727
 * Josh Lemer 7634755
 * 
 *  Student represents a student. It functions mostly as a data container.
*/
namespace PartIII {

    public class Student {

        public String firstname;
        public String lastname;
        public int age;
        public String gender;
        public String year;
        public String phone;
        public String address;

        public Student(String firstname, String lastname, int age,
                       String gender, String year, String phone, String address) {
            this.firstname = firstname;
            this.lastname = lastname;
            this.age = age;
            this.gender = gender;
            this.year = year;
            this.phone = phone;
            this.address = address;
        }

        //Allow instantiation using a String for age instead of an integer.
        public Student(String firstname, String lastname, String age,
                       String gender, String year, String phone, String address)
            : this(firstname, lastname, Convert.ToInt32(age), gender, year,phone, address) {
        }

        /*
         *  Can be called on to make sure that this Student is a valid Student with
         *  data in all fields.
         */
        public bool isValid() {
            bool result = false;
            if(
                !String.IsNullOrWhiteSpace(firstname) &&
                !String.IsNullOrWhiteSpace(lastname) &&
                !String.IsNullOrWhiteSpace(gender) &&
                !String.IsNullOrWhiteSpace(year) &&
                !String.IsNullOrWhiteSpace(phone) &&
                !String.IsNullOrWhiteSpace(address)
               ) {
                   result = true;
            }
            return result;
        }

        /*
         *  Returns an integer representation of the Student's year.
         */
        public int yearValue() {
            int result = 0;
            if (year.Equals("1") || year.Equals("2") || year.Equals("3")) {
                result = Convert.ToInt32(year);
            }else if (year.Equals("Master's")) {
                result = 4;
            }else if (year.Equals("Ph.D")) {
                result = 5;
            }
            return result;
        }
        
        public override String ToString() {
            return firstname + lastname + age.ToString() + gender + year + phone + address;
        }

    }

}
