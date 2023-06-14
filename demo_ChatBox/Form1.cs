using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo_ChatBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private const string connectionString = @"Data Source=DESKTOP-IHLHQSB\SQLEXPRESS;Initial Catalog=QL_GD;Integrated Security=True";

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPassword.Text;

            if (AuthenticateUser(username, password))
            {
                Form2 form2 = new Form2(GetLoggedInUserId());
                form2.Show();
                this.Hide();
            }
            else
            {
                // Hiển thị thông báo đăng nhập không thành công
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.");
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            /*bool isAuthenticated = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        isAuthenticated = true;
                    }
                }
            }

            return isAuthenticated;*/

        }
        private int GetLoggedInUserId()
        {
            int userId = -1;

            string username = txtUser.Text;
            string password = txtPassword.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT UserId FROM Users WHERE Username = @Username AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    object result = command.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int id))
                    {
                        userId = id;
                    }
                }
            }

            return userId;
        }


    }
}
