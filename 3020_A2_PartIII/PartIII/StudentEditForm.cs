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
* COMP 3020 Assignment 2, Part III
* Joshua Chan 7722727
* Josh Lemer 7634755
* 
* Supplementary form to Form1. Used to create and edit Students.
* It's function varies depending on how it is instantiated.
* 
* If creating a student, the constructor with a Form1 parameter should be called. 
* That pointer to Form1 is used to call addItem, which is used to add a new Student.
* As well the ListViewItem student should never be initialized.
* 
* If editing a student, the constructor with the ListViewItem should be called.
* This points to an item in the calling Form1 that's going to be edited.
* Changes are saved when the "Accept" button is pressed.
*/
namespace PartIII {
    public partial class StudentEditForm : Form {

        private ListViewItem student;
        private Form1 parent;
        private Control[] controls;
        private String[] controlNames;

        public StudentEditForm() {
            InitializeComponent();
            controls = new Control[7];
                controls[0] = textbox_firstName;
                controls[1] = textbox_lastName;
                controls[2] = textbox_age;
                controls[3] = combobox_gender;
                controls[5] = textbox_phone;
                controls[4] = combobox_year;
                controls[6] = textbox_address;
            controlNames = new String[7];
                controlNames[0] = "First name";
                controlNames[1] = "Last name";
                controlNames[2] = "Age";
                controlNames[3] = "Gender";
                controlNames[5] = "Phone";
                controlNames[4] = "Year";
                controlNames[6] = "Address";
        }

        /*
         *  Constructor called on when creating a new Student
         */
        public StudentEditForm(Form1 parent): this() {
            this.parent = parent;
        }

        /*
         *  Constructor called on when editing an existing Student
         */
        public StudentEditForm(Form1 parent, ListViewItem item) : this(parent) {
            student = item;
            populateFields();
        }

        /*
         *  If editing a Student, fill the fields in with that Student's information.
         */
        private void populateFields() {
            if (student != null) {
                for (int a = 0; a < controls.Length; a++) {
                    controls[a].Text = student.SubItems[a].Text.ToString();
                }
            }
        }

        /*
         *  When user submits data to add to the table, the fields must be valid.
         *  Presently there are no constraints other than no field can be empty.
         *  
         *  If there are any issues, we add that information to a string errorMessage
         *  before displaying it to the user.
         */
        private bool validateFields() {
            bool output = true;
            String errorOutput = "Errors with Student Information!\nPlease fill these fields before continuing.\n\n";
            //Iterate through the controls to see if any fail the conditions.
            for (int a = 0; a < controls.Length; a++) {
                if (String.IsNullOrWhiteSpace(controls[a].Text)) {
                    output = false;
                    //Add information about error to errorOutput
                    errorOutput += controlNames[a]+" is empty.\n";
                }
            }
            if (!output) {
                MessageBox.Show(errorOutput);
            }
            return output;
        }
        

        /*
         *  Validate the fields then if they're validated successfully, we
         *  use the fields to create a new list item to send back to Form1.
         *  Depending on whether the variable ListViewItem student was
         *  instantiated, we'll either call addItem or completeEdit.
         *  StudentEditForm closes afterwards.
         *  
         *  If invalid, error communication will be handled in the
         *  validateFields method.
         */
        private void button_accept_Click(object sender, EventArgs e) {
            if (validateFields()) {
                if (student != null && parent!=null) {
                    ListViewItem item = new ListViewItem(textbox_firstName.Text);
                    for (int a = 1; a < controls.Length; a++) {
                        item.SubItems.Add(controls[a].Text);
                    }
                    parent.completeEdit(item);
                } else if(parent!=null){
                    ListViewItem item = new ListViewItem(textbox_firstName.Text);
                    for (int a = 1; a < controls.Length; a++) {
                        item.SubItems.Add(controls[a].Text);
                    }
                    parent.addItem(item);
                }
                this.Close();
            }
        }

        /*
         *  Simply close the window.
         */
        private void button_cancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        /*
         *  KeyPress events for the age textbox need to be handled specially because
         *  this box should only allow numbers and control keys (to allow backspace).
         *  As well only up to 2 digits (Apologies to students older than 100).
         *  
         *  For any key press that isn't either a number or control key, we set the
         *  event's handled property to true so that the character isn't entered.
         */ 
        private void textbox_age_KeyPress(Object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }
    }
}
