using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DataBase
{
    public partial class sign_up : Form
    {
     

        public sign_up()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox_login.Text = "";
            textBox_password.Text = "";
        }

        private void sign_up_Load(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = '#';
            textBox_login.MaxLength = 50;
            textBox_password.MaxLength = 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();

            var login = textBox_login.Text;
            var password = textBox_password.Text;

            string querystring = $"insert into register(login_user, password_user) values('{login}','{password}')";

            SqlCommand command = new SqlCommand(querystring, dataBase.GetSqlConnection());

            dataBase.openConnection();

            if (command.ExecuteNonQuery() == 1)

            {
                MessageBox.Show("Аккаунт успешно создан!", "Успех!");
                log_in frm_login = new log_in();
                this.Hide();
                frm_login.ShowDialog();

            }

            else 
            {
                MessageBox.Show("Акааунт не создан!");
            }
            dataBase.CloseConnection();
        }
        private Boolean checkuser()
        {
            var loginUser = textBox_login.Text;
            var passUser = textBox_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring);

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже существует!");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            log_in log = new log_in();
            log.ShowDialog();
        }
    }
}
