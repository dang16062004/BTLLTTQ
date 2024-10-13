﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ_VIP
{
    public partial class ThemDiop : Form
    {
        private string connectionString = "Data Source=LAPTOP-7NSHMMSK;Initial Catalog=quanlybankinh;Integrated Security=True";
        public ThemDiop()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Diop (MaDiop, TenDiop) " +
                                   "VALUES (@MaDiop, @TenDiop)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số cho câu truy vấn
                        command.Parameters.AddWithValue("@MaDiop", Ma.Text);
                        command.Parameters.AddWithValue("@TenDiop", Ten.Text);
                        // Thực thi câu lệnh
                        command.ExecuteNonQuery();
                        MessageBox.Show("Thêm công dụng thành công!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm công dụng: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemHangHoa thh = new ThemHangHoa();
            thh.Show();
            this.Close();
        }
    }
}