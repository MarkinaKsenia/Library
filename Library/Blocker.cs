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
    public partial class Blocker : Form
    {
        int identif;
        public Blocker( int id )
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
            string reason, date_start, days;
            string reasonString = String.Format("SELECT REASON  FROM BLOCKS WHERE ID_READER = {0}", identif);
            string date_startString = String.Format("SELECT DATE_START   FROM BLOCKS WHERE ID_READER = {0}", identif);
            string scalarFuncString = String.Format(" SELECT dbo.[Function_of_DAYS_AFTER_BLOCK] ({0})", identif);
           

            SqlCommand cmdReason = new SqlCommand(reasonString, connection);
            SqlCommand cmdDateStart = new SqlCommand(date_startString, connection);
            SqlCommand cmdDay = new SqlCommand(scalarFuncString, connection);

            reason = cmdReason.ExecuteScalar().ToString();
            date_start = cmdDateStart.ExecuteScalar().ToString();
            days = cmdDay.ExecuteScalar().ToString();

            label1.Text = date_start;
            textBox1.Text = reason;
            label4.Text = days;


            connection.Close();



        }



        private void Blocker_Load(object sender, EventArgs e)
        {
    

        }
    }
}
