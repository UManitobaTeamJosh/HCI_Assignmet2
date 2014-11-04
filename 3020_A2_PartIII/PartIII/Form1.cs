using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

/*
* COMP 3020 Assignment 2, Part III
* Joshua Chan 7722727
* Josh Lemer 7634755
* 
* Assumes a file with a name corresponding to the variable FILE_NAME exists. If not, if the user
* ever uses the "Save" button, such a file will be created and used for data storage.
* 
* The program can be run with or without an xmlSource.xml file. Any and all saving however
* will be done to that file, or will create that file if it does not exist.
*/

namespace PartIII {
    public partial class Form1 : Form {

        private static readonly String FILE_NAME = "xmlSource.xml";
        private List<Student> studentList;

        public Form1() {
            InitializeComponent();
            studentList = new List<Student>();
            loadXML();
        }

        /*
         *  Adds a new Student to the table.
         */
        public void addStudent(Student newStudent) {
            if (newStudent != null && newStudent.isValid()) {
                populateTable();
                studentList.Add(newStudent);
            }
        }
        
        /*
         *  Fills the table with Students from studentList whose age is less than that
         *  selected by trackBar1. Students are added in the order they are found in
         *  the studentList.
         */
        public void populateTable() {
            if (studentList != null) {
                listView1.Items.Clear();
                foreach (Student student in studentList) {
                    if (student.age <= trackBar1.Value) {
                        ListViewItem item = new ListViewItem(student.firstname);
                        item.SubItems.Add(student.lastname);
                        item.SubItems.Add(student.age.ToString());
                        item.SubItems.Add(student.gender);
                        item.SubItems.Add(student.year);
                        item.SubItems.Add(student.phone);
                        item.SubItems.Add(student.address);
                        listView1.Items.Add(item);
                    }
                }
            }
        }//populateTable

        /*
         *  Attempt to load an XML file and put that data into studentList.
         */
        private void loadXML() {
            if (System.IO.File.Exists(FILE_NAME)){
                XDocument xmlSource = XDocument.Load(FILE_NAME);
                var data = from item in xmlSource.Descendants("person")
                           where true
                           select new {
                               firstname = item.Element("firstname").Value,
                               lastname = item.Element("lastname").Value,
                               age = item.Element("age").Value,
                               gender = item.Element("gender").Value,
                               year = item.Element("year").Value,
                               phone = item.Element("phone").Value,
                               address = item.Element("address").Value
                           };//query
                foreach (var p in data) {
                    Student newStudent = new Student(p.firstname, p.lastname, p.age,
                                                        p.gender, p.year, p.phone, p.address);
                    studentList.Add(newStudent);
                }
            } else {
                MessageBox.Show("xmlSource.xml not found. No data loaded.");
            }
        }//loadXML

        /*
         *  Redraws the contents of the ListView depending on the age selected.
         *  Also updates the label showing the user exactly what age is selected.
         */
        private void trackBar1_Scroll(object sender, EventArgs e) {
            populateTable();
            label1.Text = ("Showing students with age less than : "+trackBar1.Value);
        }

        /*
         *  Opens a new StudentEditForm, passing this Form1 instance.
         *  It will call back to this instance through the addItem method.
         *  This will add a new student to the XDocument.
         */
        private void button_new_Click(object sender, EventArgs e) {
            StudentEditForm editForm = new StudentEditForm(this);
            editForm.Show();
        }

        /*
         *  Deletes the currently selected Student then repopulates the table after
         *  changes are made.
         */
        private void button_delete_Click(object sender, EventArgs e) {
            foreach (ListViewItem item in listView1.SelectedItems) {
                //Produce a string representing the entirety of the selected student
                String value = "";
                ListViewItem.ListViewSubItemCollection subitems = item.SubItems;
                foreach (ListViewItem.ListViewSubItem currSubItem in subitems) {
                    value += currSubItem.Text.ToString();
                }
                foreach (Student student in studentList) {
                    if (student.ToString().CompareTo(value) == 0) {
                        studentList.Remove(student);
                        break;
                    }
                }
            }//foreach
            populateTable();
        }

        /*
         *  Opens a new StudentEditForm, passing it the selected ListViewItem and itself.
         *  The StudentEditForm will use that pointer to save the info changes.
         *  The pointer to Form1 will be used to call completeEdit.
         *  
         *  When editing a Student, we're really locating, deleting, and making a new student.
         *  In this method, the student is located and stored in the editItem varaible.
         *  If the edit action is completed by the StudentEditForm if it calls completeEdit, then 
         *  we'll be able to use that variable to remove the old student.
         */
        private void button_edit_Click(object sender, EventArgs e){
            foreach (ListViewItem item in listView1.SelectedItems) {
                //Produce a string representing the entirety of the selected student
                String value = "";
                ListViewItem.ListViewSubItemCollection subitems = item.SubItems;
                foreach (ListViewItem.ListViewSubItem currSubItem in subitems) {
                    value += currSubItem.Text.ToString();
                }
                foreach (Student student in studentList) {
                    if (student.ToString().CompareTo(value) == 0) {
                        StudentEditForm editForm = new StudentEditForm(this, student);
                        editForm.Show();
                        break;
                    }
                }
            }//foreach
        }

        /*
         *  Simply saves the current XDocument to the XML file name specified by the FILE_NAME
         *  constant.
         */
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            XDocument xdoc = new XDocument(new XElement("people"));
            foreach(Student student in studentList){
                XElement root = new XElement("person");
                root.Add(new XElement("firstname",student.firstname));
                root.Add(new XElement("lastname", student.lastname));
                root.Add(new XElement("age", student.age.ToString()));
                root.Add(new XElement("gender", student.gender));
                root.Add(new XElement("year", student.year));
                root.Add(new XElement("phone", student.phone));
                root.Add(new XElement("address", student.address));
                xdoc.Element("people").Add(root);
            }
            xdoc.Save(FILE_NAME);
            MessageBox.Show("File saved");
        }
    }//class Form1
}
