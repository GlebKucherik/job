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
    
    enum RowState
    {
        Existed,
        New,
        Modifiend,
        ModifiendNew,
        Deleted
    }

    public partial class DepartamentForm : Form
    {
        DataBase dataBase = new DataBase();
        private int selectedRow;
        public DepartamentForm()
        {
            InitializeComponent();
        }
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("Departament_ID", "Departament_ID");
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("IsNew", String.Empty);

        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), RowState.ModifiendNew);
        }
        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $" select * from Deportament";

            SqlCommand command = new SqlCommand(queryString, DataBase.GetConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())

            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DepartamentForm_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);

        }
    }
}
