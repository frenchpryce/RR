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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void user_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void signup_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void login_Click(object sender, EventArgs e)
        {
            String username, password;

            username = user.Text;
            password = pass.Text;

            DataAccess db = new DataAccess();

            db.LoginUser(username, password);
        }
    }
}
