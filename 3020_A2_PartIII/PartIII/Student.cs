using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        
        public override String ToString() {
            return firstname + lastname + age.ToString() + gender + year + phone + address;
        }

    }

}
