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
    public partial class BookOfUser : Form
    {
        int identif;
        public BookOfUser(int id)
        {
            identif = id;
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            string connectionString = @"Data Source = ADMIN\MSSQ; Initial Catalog = Library; Integrated Security = True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM [dbo].[TABLE_DAYS_BOOK_TURN_IN] ("+identif+ ")";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[3]);
                for (int i = 0; i < 3; i++)
                {
                    data[data.Count - 1][i] = reader[i].ToString();
                }

            }

            reader.Close();
           string a;

            if (cmd.ExecuteNonQuery() == -1)
            {
                string queryDebt = "SELECT * FROM [dbo].[TABLE_DEBT_BOOK_OF_USER] (" + identif + ")";

                SqlCommand cmdDebt = new SqlCommand(queryDebt, connection);
                SqlDataReader readerDebt = cmdDebt.ExecuteReader();

                List<string[]> dataDebt = new List<string[]>();

                while (readerDebt.Read())
                {
                    dataDebt.Add(new string[3]);
                    for (int i = 0; i < 3; i++)
                    {
                        dataDebt[dataDebt.Count - 1][i] = readerDebt[i].ToString();
                    }

                }
                readerDebt.Close();

                foreach (string[] str in dataDebt)
                {
                    bookdataGrid.Rows.Add(str);
                }
            }

            connection.Close();


            foreach (string[] s in data)
            {
               bookdataGrid.Rows.Add(s);
            }
        }

        }
}
