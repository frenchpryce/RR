using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RR
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();

            db.InsertUser(firstNameTextBox.Text, lastNameTextBox.Text, emailTextBox.Text, passBox.Text);

            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            emailTextBox.Text = "";
            passBox.Text = "";

            MessageBox.Show("Added Succesfully");
        }
    }
}
