
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
    public partial class Form2 : Form
    {
        private const string connectionString = @"Data Source=DESKTOP-IHLHQSB\SQLEXPRESS;Initial Catalog=QL_GD;Integrated Security=True"; // Thay thế YOUR_CONNECTION_STRING bằng chuỗi kết nối SQL của bạn
        private int loggedInUserId;

        public Form2(int loggedInUserId)
        {
            InitializeComponent();
            this.loggedInUserId = loggedInUserId;

            LoadTeachers();
            listMessage.Items.Clear(); // Xóa sạch các item trong listBoxChat trước khi load lại cuộc trò chuyện
            LoadChatMessages(); // Load lại cuộc trò chuyện từ cơ sở dữ liệu
        }
        public int UserId { get; set; }

        private void LoadTeachers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT TeacherId, FullName FROM Teachers";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int teacherId = Convert.ToInt32(reader["TeacherId"]);
                            string fullName = Convert.ToString(reader["FullName"]);
                            comboBox2.Items.Add(new Teacher(teacherId, fullName));
                        }
                    }
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Teacher receiver = comboBox2.SelectedItem as Teacher;
            if (receiver != null)
            {
                string messageContent = txtBoxChat.Text;
                DateTime dateTime = DateTime.Now;

                SaveMessage(loggedInUserId, receiver.TeacherId, messageContent, dateTime);

                string message = $"[{dateTime}] You: {messageContent}";
                listMessage.Items.Add(message);

                txtBoxChat.Clear();
            }
        }

        private void SaveMessage(int senderId, int receiverId, string content, DateTime dateTime)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Messages (SenderId, ReceiverId, Content, DateTime) VALUES (@SenderId, @ReceiverId, @Content, @DateTime)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SenderId", senderId);
                    command.Parameters.AddWithValue("@ReceiverId", receiverId);
                    command.Parameters.AddWithValue("@Content", content);
                    command.Parameters.AddWithValue("@DateTime", dateTime);

                    command.ExecuteNonQuery();
                }
            }
        }

        public class Teacher
        {
            public int TeacherId { get; set; }
            public string FullName { get; set; }

            public Teacher(int teacherId, string fullName)
            {
                TeacherId = teacherId;
                FullName = fullName;
            }

            public override string ToString()
            {
                return FullName;
            }
        }

        private void LoadChatMessages()
        {
            if (comboBox2.SelectedItem != null)
            {
                Teacher selectedTeacher = comboBox2.SelectedItem as Teacher;
                int receiverId = selectedTeacher.TeacherId;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Content, DateTime FROM Messages WHERE (SenderId = @SenderId AND ReceiverId = @ReceiverId) OR (SenderId = @ReceiverId AND ReceiverId = @SenderId) ORDER BY DateTime";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SenderId", loggedInUserId);
                        command.Parameters.AddWithValue("@ReceiverId", receiverId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string content = Convert.ToString(reader["Content"]);
                                DateTime dateTime = Convert.ToDateTime(reader["DateTime"]);
                                string message = $"[{dateTime}] You: {content}";
                                listMessage.Items.Add(message);
                            }
                        }
                    }
                }
            }
        }

       
    }
}