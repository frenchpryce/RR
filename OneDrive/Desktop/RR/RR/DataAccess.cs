using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace RR
{
    public class DataAccess
    {
        public void InsertUser(string firstName, string lastName, string emailAddress, string password)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AppDB")))
            {
                List<Users> users = new List<Users>();

                users.Add(new Users {FirstName = firstName, LastName = lastName, Email = emailAddress, Pass = password});

                connection.Execute("dbo.Insert_Users @FirstName, @LastName, @Email, @Pass", users);
            }
        }

        public void LoginUser(string email, string password)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("AppDB")))
            {
                //string query = "SELECT * FROM dbo.UsersDB WHERE Email = '" + email + "' AND Pass = '" + password + "'";
                connection.Open();

                using (IDbCommand comm = connection.CreateCommand())
                {
                    comm.CommandText = "SELECT * FROM dbo.UsersDB WHERE Email = '" + email + "' AND Pass = '" + password + "'";

                    IDbDataParameter userEmail = comm.CreateParameter();
                    userEmail.ParameterName = "@Email";
                    userEmail.Value = email;
                    comm.Parameters.Add(userEmail);

                    IDbDataParameter userPass = comm.CreateParameter();
                    userPass.ParameterName = "@Password";
                    userPass.Value = password;
                    comm.Parameters.Add(userPass);

                    object result = comm.ExecuteScalar();

                    if (result != null)
                    {
                        MessageBox.Show("Login Successful");
                    }
                    else
                    {
                        MessageBox.Show("Login Denied");
                    }
                }
            }
        }
    }
}
