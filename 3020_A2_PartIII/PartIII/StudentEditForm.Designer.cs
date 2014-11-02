namespace PartIII {
    partial class StudentEditForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.textbox_firstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textbox_lastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textbox_age = new System.Windows.Forms.TextBox();
            this.combobox_gender = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textbox_phone = new System.Windows.Forms.TextBox();
            this.combobox_year = new System.Windows.Forms.ComboBox();
            this.textbox_address = new System.Windows.Forms.TextBox();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_accept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student Info";
            // 
            // textbox_firstName
            // 
            this.textbox_firstName.Location = new System.Drawing.Point(94, 36);
            this.textbox_firstName.Name = "textbox_firstName";
            this.textbox_firstName.Size = new System.Drawing.Size(100, 22);
            this.textbox_firstName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "First Name";
            // 
            // textbox_lastName
            // 
            this.textbox_lastName.Location = new System.Drawing.Point(319, 34);
            this.textbox_lastName.Name = "textbox_lastName";
            this.textbox_lastName.Size = new System.Drawing.Size(100, 22);
            this.textbox_lastName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Last Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Age";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(237, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Gender";
            // 
            // textbox_age
            // 
            this.textbox_age.Location = new System.Drawing.Point(94, 75);
            this.textbox_age.MaxLength = 2;
            this.textbox_age.Name = "textbox_age";
            this.textbox_age.Size = new System.Drawing.Size(100, 22);
            this.textbox_age.TabIndex = 9;
            this.textbox_age.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_age_KeyPress);
            // 
            // combobox_gender
            // 
            this.combobox_gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_gender.FormattingEnabled = true;
            this.combobox_gender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.combobox_gender.Location = new System.Drawing.Point(319, 71);
            this.combobox_gender.Name = "combobox_gender";
            this.combobox_gender.Size = new System.Drawing.Size(100, 24);
            this.combobox_gender.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(237, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Year";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Phone";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Address";
            // 
            // textbox_phone
            // 
            this.textbox_phone.Location = new System.Drawing.Point(94, 113);
            this.textbox_phone.Name = "textbox_phone";
            this.textbox_phone.Size = new System.Drawing.Size(100, 22);
            this.textbox_phone.TabIndex = 14;
            // 
            // combobox_year
            // 
            this.combobox_year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_year.FormattingEnabled = true;
            this.combobox_year.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "Master\'s",
            "Ph.D"});
            this.combobox_year.Location = new System.Drawing.Point(319, 109);
            this.combobox_year.Name = "combobox_year";
            this.combobox_year.Size = new System.Drawing.Size(100, 24);
            this.combobox_year.TabIndex = 15;
            // 
            // textbox_address
            // 
            this.textbox_address.Location = new System.Drawing.Point(94, 155);
            this.textbox_address.Name = "textbox_address";
            this.textbox_address.Size = new System.Drawing.Size(100, 22);
            this.textbox_address.TabIndex = 16;
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(344, 199);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 17;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_accept
            // 
            this.button_accept.Location = new System.Drawing.Point(252, 199);
            this.button_accept.Name = "button_accept";
            this.button_accept.Size = new System.Drawing.Size(75, 23);
            this.button_accept.TabIndex = 18;
            this.button_accept.Text = "Accept";
            this.button_accept.UseVisualStyleBackColor = true;
            this.button_accept.Click += new System.EventHandler(this.button_accept_Click);
            // 
            // StudentEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 234);
            this.Controls.Add(this.button_accept);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.textbox_address);
            this.Controls.Add(this.combobox_year);
            this.Controls.Add(this.textbox_phone);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.combobox_gender);
            this.Controls.Add(this.textbox_age);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textbox_lastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textbox_firstName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StudentEditForm";
            this.Text = "Student Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textbox_firstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textbox_lastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textbox_age;
        private System.Windows.Forms.ComboBox combobox_gender;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textbox_phone;
        private System.Windows.Forms.ComboBox combobox_year;
        private System.Windows.Forms.TextBox textbox_address;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_accept;
    }
}