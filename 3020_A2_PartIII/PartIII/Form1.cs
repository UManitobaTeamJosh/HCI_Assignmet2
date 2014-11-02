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
*/

namespace PartIII {
    public partial class Form1 : Form {

        private static readonly String FILE_NAME = "xmlSource.xml";
        private XDocument xmlSource;
        private XElement editItem;

        public Form1() {
            InitializeComponent();
            loadXML();
        }
        
        /*
         *  Fills the table with Students from xmlSource whose age is less than that
         *  selected by trackBar1. Students are added in the order they are found in
         *  the XDocument.
         */
        private void populateTable() {
            if (xmlSource != null) {
                listView1.Items.Clear();
                var data = from item in xmlSource.Descendants("person") 
                    where Convert.ToInt32(item.Element("age").Value) <= trackBar1.Value
                    select new{
                        firstname = item.Element("firstname").Value,
                        lastname = item.Element("lastname").Value,
                        age = item.Element("age").Value,
                        gender = item.Element("gender").Value,
                        year = item.Element("year").Value,
                        phone = item.Element("phone").Value,
                        address = item.Element("address").Value
                };//query
                foreach (var p in data) {
                    ListViewItem item = new ListViewItem(p.firstname);
                    item.SubItems.Add(p.lastname);
                    item.SubItems.Add(p.age);
                    item.SubItems.Add(p.gender);
                    item.SubItems.Add(p.year);
                    item.SubItems.Add(p.phone);
                    item.SubItems.Add(p.address);
                    listView1.Items.Add(item);
                }
            }//if
        }

        /*
         *  Attempt to load an XML file into xmlSource
         */
        private void loadXML() {
            if (System.IO.File.Exists(FILE_NAME)){
                xmlSource = XDocument.Load(FILE_NAME);
            } else {
                //File not found. Instantiate xmlSource ourselves
                xmlSource = new XDocument(new XElement("people"));
            }
            
        }

        /*
         *  Redraws the contents of the ListView depending on the age selected.
         *  Also updates the label showing the user exactly what age is selected.
         */
        private void trackBar1_Scroll(object sender, EventArgs e) {
            populateTable();
            label1.Text = ("Showing students with age less than : "+trackBar1.Value);
        }

        /*
         *  Accepts a ListViewItem. Any items passed into this method should be formmatted
         *  as correct students.
         *  
         * This will add the new student to the XDocument and then refresh the ListView.
         */
        public void addItem(ListViewItem item) {
            XElement root = new XElement("person");
            root.Add(new XElement("firstname",item.SubItems[0].Text));
            root.Add(new XElement("lastname", item.SubItems[1].Text));
            root.Add(new XElement("age", item.SubItems[2].Text));
            root.Add(new XElement("gender", item.SubItems[3].Text));
            root.Add(new XElement("year", item.SubItems[4].Text));
            root.Add(new XElement("phone", item.SubItems[5].Text));
            root.Add(new XElement("address", item.SubItems[6].Text));
            xmlSource.Element("people").Add(root);
            populateTable();
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
            /* Using a foreach because it's safer(?) than accessing SelectedItems from a fixed
             * index, since it's length cannot be determined.
             */
            foreach (ListViewItem item in listView1.SelectedItems) {
                //Produce a string representing the entirety of the selected student
                String value = "";
                ListViewItem.ListViewSubItemCollection subitems = item.SubItems;
                foreach (ListViewItem.ListViewSubItem currSubItem in subitems) {
                    value += currSubItem.Text.ToString();
                }

                //Look through the XDocument for a student with exactly the same elements
                //Remove them if found.
                var data = xmlSource.Descendants("person").ToList();
                foreach (XElement el in data) {
                    if (el.Value.CompareTo(value) == 0) {
                        el.Remove();
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
                StudentEditForm editForm = new StudentEditForm(this,item);
                editForm.Show();
            }
            foreach (ListViewItem item in listView1.SelectedItems) {
                //Produce a string representing the entirety of the selected student
                String value = "";
                ListViewItem.ListViewSubItemCollection subitems = item.SubItems;
                foreach (ListViewItem.ListViewSubItem currSubItem in subitems) {
                    value += currSubItem.Text.ToString();
                }

                //Look through the XDocument for a student with exactly the same elements
                var data = xmlSource.Descendants("person").ToList();
                foreach (XElement el in data) {
                    if (el.Value.CompareTo(value) == 0) {
                        editItem = el;
                    }
                }
            }//foreach
        }

        /*
         *  Called by StudentEditForm to complete an edit.
         *  
         *  EditItem should have been set by button_edit_Click. We finish the edit action here
         *  by deleting the old student and adding its replacement.
         */
        public void completeEdit(ListViewItem item) {
            if (editItem != null) {
                editItem.Remove();
                addItem(item);
                editItem = null;
            }
        }

        

        /*
         *  Simply saves the current XDocument to the XML file name specified by the FILE_NAME
         *  constant.
         */
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            if (System.IO.File.Exists(FILE_NAME)) {
                xmlSource.Save(FILE_NAME);
                MessageBox.Show("File saved");
            } else {
                xmlSource.Save(FILE_NAME);
                MessageBox.Show("Could not find xmlSource.xml\nxmlSource.xml created.");
            }
        }
    }//class Form1
}
