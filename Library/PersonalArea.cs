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
    public partial class PersonalArea : Form
    {
        string titleBook;
        int identif;
        public PersonalArea(int id)
        {
            InitializeComponent();
            identif = id;
            LoadData();
            LoadCombo();
        }

        private void LoadCombo()
        {
            string connectionString = @"Data Source = ADMIN\MSSQ; Initial Catalog = Library; Integrated Security = True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string combo = String.Format("SELECT TITLE FROM TABLE_DATE_RETURN_BOOK() A, BOOK B WHERE ID_READER = {0} AND A.ID_BOOK = B.ID_BOOK ", identif);
            SqlCommand cmd = new SqlCommand(combo, connection);
            List<string[]> dataCombo = new List<string[]>();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {dataCombo.Add(new string[1]);
                for (int i = 0; i < 1; i++)
                {comboBox1.Items.Add(reader[i].ToString()); } }
            connection.Close();
            reader.Close();
        }

        private void LoadData()
        {
            string connectionString = @"Data Source = ADMIN\MSSQ; Initial Catalog = Library; Integrated Security = True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string surnameUser =  String.Format("SELECT Surname FROM FORMS_READER WHERE ID_READER = {0} ", identif);
            string nameUser = String.Format("SELECT NAME FROM FORMS_READER WHERE ID_READER = {0} ", identif);
            string patronymicUser = String.Format("SELECT PATRONYMIC FROM FORMS_READER WHERE ID_READER = {0} ", identif);
            string query = "SELECT TITLE,Author_Surname, Author_Name, Author_Patronymic, Year, Count_of_book, Genre, Original_language FROM BOOK";
            string queryBookInStock = "SELECT * FROM [dbo].[TABLE_BOOK_IN_STOCK] ()";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlCommand cmdSurname = new SqlCommand(surnameUser, connection);
            SqlCommand cmdName = new SqlCommand(nameUser, connection);
            SqlCommand cmdPatronymic = new SqlCommand(patronymicUser, connection);
            SqlCommand cmdBookInStock = new SqlCommand(queryBookInStock, connection);

            SqlDataReader reader = cmd.ExecuteReader();
            String su, n, p;

            List<string[]> data = new List<string[]> ();
            List<string[]> dataBookInStock = new List<string[]>();

            while (reader.Read()){
                data.Add(new string[8]);
                for(int i = 0; i < 8; i++)
                {
                    data[data.Count - 1][i] = reader[i].ToString(); } }
            reader.Close();
      
            su = cmdSurname.ExecuteScalar().ToString();
            n = cmdName.ExecuteScalar().ToString();
            p = cmdPatronymic.ExecuteScalar().ToString();

            label4.Text = su;
            label5.Text = n;
            label6.Text = p;
            reader.Close();

            SqlDataReader readerBookInStock = cmdBookInStock.ExecuteReader();

            while (readerBookInStock.Read())
            {
                dataBookInStock.Add(new string[6]);
                for (int i = 0; i < 6; i++)
                {
                    dataBookInStock[dataBookInStock.Count - 1][i] = readerBookInStock[i].ToString();
                }  }
            readerBookInStock.Close();
            connection.Close();
            
            foreach (string[] s in data)
            {
                dataGridView1.Rows.Add(s);       
            }

            foreach (string[] stroka in dataBookInStock)
            {
                dataBookInStockgrid.Rows.Add(stroka);
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var a = row.Cells[5].Value.ToString();
                if (a != null)
                {
                    if (a == "0")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.PaleGreen;
                    }} } }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BookOfUser f = new BookOfUser(identif);
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Debt f2 = new Debt(identif);
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            titleBook = titleTextBox.Text;
            string connectionStringNew = @"Data Source = ADMIN\MSSQ; Initial Catalog = Library; Integrated Security = True";
            SqlConnection connectionNew = new SqlConnection(connectionStringNew);
            connectionNew.Open();
            string findPlace = String.Format("EXEC[LOCATION_OF_BOOK] '{0}' ", titleBook);


            SqlCommand cmdfindPlace = new SqlCommand(findPlace, connectionNew);

            SqlDataReader readerPlace = cmdfindPlace.ExecuteReader();
            String h,s,pol;

            while (readerPlace.Read())
            {

                h = readerPlace[0].ToString();
                s = readerPlace[1].ToString();
                pol = readerPlace[2].ToString();
                hall.Text = h;
                polkaLabel.Text = pol;
                stendLabel.Text = s;
            }
            readerPlace.Close();
           connectionNew.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bookAuthordataGridView.Rows.Clear();
            bookAuthordataGridView.Refresh();

            string surnTB = surnameAuthorTextBox.Text;
            string nameTB = nameAuthorTextBox.Text;
            List<string[]> dataBook = new List<string[]>();

            string connectionStringNewFind = @"Data Source = ADMIN\MSSQ; Initial Catalog = Library; Integrated Security = True";
            SqlConnection connectionNewFind = new SqlConnection(connectionStringNewFind);
            connectionNewFind.Open();
            string findBook = String.Format("EXEC [BOOK_OF_AUTHOR] '{0}', '{1}' ", surnTB, nameTB);
            
            SqlCommand cmdfindBook = new SqlCommand(findBook, connectionNewFind);
            SqlDataReader readerBook = cmdfindBook.ExecuteReader();

            while (readerBook.Read())
            {
                dataBook.Add(new string[5]);
                for (int i = 0; i < 5; i++)
                {
                    dataBook[dataBook.Count - 1][i] = readerBook[i].ToString();
                } }
            readerBook.Close();

            connectionNewFind.Close();

            foreach (string[] strrr in dataBook)
            {
                bookAuthordataGridView.Rows.Add(strrr);
            }

            foreach (DataGridViewRow row in bookAuthordataGridView.Rows)
            { row.DefaultCellStyle.BackColor = Color.Teal;} }

        private void button6_Click(object sender, EventArgs e)
        {
            string titleofBook =comboBox1.SelectedItem.ToString();
      
            string connectionStringNewExtend = @"Data Source = ADMIN\MSSQ; Initial Catalog = Library; Integrated Security = True";
            SqlConnection connectionNewExtend = new SqlConnection(connectionStringNewExtend);
            connectionNewExtend.Open();
            string ExtendBook = String.Format("INSERT INTO EXTEND  SELECT  A.Id_book, A.Id_reader, A.Date_start, A.Date_end, A.Count_extend_book FROM DATE_RETURN_BOOK A, BOOK B WHERE A.ID_BOOK = B.ID_BOOK AND  B.Title = '{0}' and A.ID_READER = {1}", titleofBook, identif);
            
            SqlCommand cmdfExtendBook = new SqlCommand(ExtendBook, connectionNewExtend);

            cmdfExtendBook.Prepare();
            cmdfExtendBook.ExecuteNonQuery();

            MessageBox.Show("Ваш запрос успешно принят! Проверяйте дату сдачи данной книги. Если она не обновилась в течении двух рабочих дней, значит библиотекарь отклонил ваш запрос. В таком случае свяжитесь с библиотекой по телефону");
        
            connectionNewExtend.Close();
        }

        private void PersonalArea_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryDataSet.TABLE_DATE_RETURN_BOOK". При необходимости она может быть перемещена или удалена.
            this.tABLE_DATE_RETURN_BOOKTableAdapter.Fill(this.libraryDataSet.TABLE_DATE_RETURN_BOOK);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryDataSet.BOOK". При необходимости она может быть перемещена или удалена.
            this.bOOKTableAdapter.Fill(this.libraryDataSet.BOOK);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryDataSet.TABLE_DATE_RETURN_BOOK". При необходимости она может быть перемещена или удалена.
            this.tABLE_DATE_RETURN_BOOKTableAdapter.Fill(this.libraryDataSet.TABLE_DATE_RETURN_BOOK);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryDataSet.DATE_RETURN_BOOK". При необходимости она может быть перемещена или удалена.
            this.dATE_RETURN_BOOKTableAdapter.Fill(this.libraryDataSet.DATE_RETURN_BOOK);

        }

        private void answerButton_Click(object sender, EventArgs e)
        {
            string titleFindBook = textBox5.Text.ToString();

            if (titleFindBook == "")
            {
                int idBook = Convert.ToInt32(textBox6.Text);
                string connectionString = @"Data Source = ADMIN\MSSQ; Initial Catalog = Library; Integrated Security = True";
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                string query = String.Format("SELECT * FROM BOOK WHERE COUNT_OF_BOOK = 0 AND id_book = {0}", idBook);

                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    answer.Text = "Книги нет в наличии в библиотеке!";
                }
                else
                {
                    answer.Text = "Книга есть в наличии в библиотеке!";
                }

                reader.Close();}
            else
            {
                string connectionTitleString = @"Data Source = ADMIN\MSSQ; Initial Catalog = Library; Integrated Security = True";
                SqlConnection connectionTitle = new SqlConnection(connectionTitleString);

                connectionTitle.Open();

                string queryTitle = String.Format("SELECT * FROM BOOK WHERE COUNT_OF_BOOK = 0 AND Title = '{0}'", titleFindBook);

                SqlCommand cmdTitle = new SqlCommand(queryTitle, connectionTitle);

                SqlDataReader readerTitle = cmdTitle.ExecuteReader();

                if (readerTitle.HasRows)
                {
                    answer.Text = "Книги нет в наличии в библиотеке!";
                }
                else
                {
                    answer.Text = "Книга есть в наличии в библиотеке!";
                }

                readerTitle.Close();
            }
        }
    }
}
