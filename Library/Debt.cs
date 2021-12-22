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

namespace Library
{
    public partial class Debt : Form
    {
        int identif;
        public Debt(int id)
        {
            InitializeComponent();
            identif = id;
            LoadData();
        }

        private void LoadData()
        {
            string connectionString = @"Data Source = ADMIN\MSSQ; Initial Catalog = Library; Integrated Security = True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM [dbo].[Function_of_SUMM_OF_DEBT_ONE_BOOK_TABLE] ("+identif+ ")";
            string querySum = "SELECT dbo.[Function_of_SUMM_OF_DEBT]  (" + identif + ")";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlCommand cmdSum = new SqlCommand(querySum, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            List<string[]> data = new List<string[]>();

            noDebt.Visible = false;
            haveDebt.Visible = true;
            summ.Visible = true;
            sumOutput.Visible = true;
            rub.Visible = true;
            dataGridView1.Visible = true;


            while (reader.Read())
            {
                data.Add(new string[4]);
                for (int i = 0; i < 4; i++)
                {
                    data[data.Count - 1][i] = reader[i].ToString();
                }

            }


            reader.Close();
            if (cmd.ExecuteScalar() == null)
            {
                noDebt.Visible = true;
                haveDebt.Visible = false;
                summ.Visible = false;
                sumOutput.Visible = false;
                rub.Visible = false;
                dataGridView1.Visible = false;
            }

            reader.Close();
            string sum;
            sum = cmdSum.ExecuteScalar().ToString();
            sumOutput.Text = sum;

            connection.Close();


            foreach (string[] s in data)
            {
                dataGridView1.Rows.Add(s);
            }
        }

            private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
