using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThuVien;

namespace Buoi3
{
    public partial class Form1 : Form
    {
        SQL tv = new SQL("Data Source=A109PC32;Initial Catalog=B3;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            testConnect();
            string Name = textBox1.Text;
            string Pass = textBox2.Text;

            string sql = "select * from Account where Name = '" + Name + "' and Pass = '" + Pass + "'";

            DataTable dtTbl = tv.ExcuteQuery(sql);
            if (dtTbl.Rows.Count > 0)
            {
                MessageBox.Show("Đăng Nhập Thành Công!!");
            }
        }

        private void testConnect()
        {
            if (tv.TestConnect())
            {
                MessageBox.Show("Kết nối thành công");
            }
            else
            {
                MessageBox.Show("Kết nối thất bại");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Name = textBox1.Text;
            string Pass = textBox2.Text;
            string query = "insert into Account values ('"+Name+"', '"+Pass+"')";
            if (tv.Insert(query))
            {
                MessageBox.Show("Thêm Thành Công");
            }
            else
            {
                MessageBox.Show("Thêm Thất Bại");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
