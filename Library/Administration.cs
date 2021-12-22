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
    public partial class Administration : Form
    {
        public Administration()
        {
            InitializeComponent();
            LoadData();
            LoadActivityRead();
            LoadDebt();
            LoadLocation();
            dATE_RETURN_BOOKDataGridView.DataError += new DataGridViewDataErrorEventHandler(dATE_RETURN_BOOKDataGridView_DataError);
            fORMS_READERDataGridView.DataError += new DataGridViewDataErrorEventHandler(fORMS_READERDataGridView_DataError);
            bLOCKSDataGridView.DataError += new DataGridViewDataErrorEventHandler(bLOCKSDataGridView_DataError);
        }

        private void dATE_RETURN_BOOKDataGridView_DataError (object sender, DataGridViewDataErrorEventArgs e)
        {
            if(e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("У этого читателя уже есть эта книга!");
            }
           else
            {
                MessageBox.Show("Проверьте введенные значения!");
                e.ThrowException = false;
            }
         
       
        }

        private void fORMS_READERDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            MessageBox.Show("Проверьте введенные значения!");
            e.ThrowException = false;

        }

        private void bLOCKSDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Этот читатель уже находится в черном списке!");
            }
            else
            {

                MessageBox.Show("Проверьте введенные значения!");
                e.ThrowException = false;
            }
        }
        

        private void LoadData()
        {
            string connectionString = @"Data Source = ADMIN\MSSQ; Initial Catalog = Library; Integrated Security = True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string query = "SELECT * FROM EXTEND";

            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[5]);
                for (int i = 0; i < 5; i++)
                {
                    data[data.Count - 1][i] = reader[i].ToString();
                }

            }

            reader.Close();
            connection.Close();
            foreach (string[] s in data)
            {
                dataGridViewExtend.Rows.Add(s);
            }

 
        }

        private void LoadActivityRead()
        {
            string connectionActivityString = @"Data Source = ADMIN\MSSQ; Initial Catalog = Library; Integrated Security = True";
            SqlConnection connectionActivity = new SqlConnection(connectionActivityString);

            connectionActivity.Open();

            string queryActivity = "SELECT * FROM Activity_Reader";

            SqlCommand cmdActivity = new SqlCommand(queryActivity, connectionActivity);

            SqlDataReader readerActivity = cmdActivity.ExecuteReader();

            List<string[]> dataActivity = new List<string[]>();

            while (readerActivity.Read())
            {
                dataActivity.Add(new string[6]);


                for (int i = 0; i < 6; i++)
                {
                    dataActivity[dataActivity.Count - 1][i] = readerActivity[i].ToString();
                }

            }
            readerActivity.Close();
            connectionActivity.Close();

            foreach (string[] str in dataActivity)
            {
                dataGridActivity.Rows.Add(str);
            }
        }

        private void LoadDebt()
        {
            string connectionDebtString = @"Data Source = ADMIN\MSSQ; Initial Catalog = Library; Integrated Security = True";
            SqlConnection connectionDebt = new SqlConnection(connectionDebtString);

            connectionDebt.Open();

            string queryDebt= "SELECT * FROM Debt";

            SqlCommand cmdDebt = new SqlCommand(queryDebt, connectionDebt);

            SqlDataReader readerDebt = cmdDebt.ExecuteReader();

            List<string[]> dataDebt = new List<string[]>();

            while (readerDebt.Read())
            {
                dataDebt.Add(new string[7]);


                for (int i = 0; i < 7; i++)
                {
                    dataDebt[dataDebt.Count - 1][i] = readerDebt[i].ToString();
                }

            }
            readerDebt.Close();
            connectionDebt.Close();

            foreach (string[] str in dataDebt)
            {
                dataGridDebt.Rows.Add(str);
            }
        }

        private void LoadLocation()
        {
            string connectionLockString = @"Data Source = ADMIN\MSSQ; Initial Catalog = Library; Integrated Security = True";
            SqlConnection connectionLock = new SqlConnection(connectionLockString);

            connectionLock.Open();

            string queryLock = "SELECT * FROM [dbo].[TABLE_BOOK_LOCATION] ()";

            SqlCommand cmdLock = new SqlCommand(queryLock, connectionLock);

            SqlDataReader readerLock = cmdLock.ExecuteReader();

            List<string[]> dataLock = new List<string[]>();

            while (readerLock.Read())
            {
                dataLock.Add(new string[6]);


                for (int i = 0; i < 6; i++)
                {
                    dataLock[dataLock.Count - 1][i] = readerLock[i].ToString();
                }

            }
            readerLock.Close();
            connectionLock.Close();

            foreach (string[] str in dataLock)
            {
                dataBookILocation.Rows.Add(str);
            }
        }


        private void agree_Click(object sender, EventArgs e)
        {
            int err = 0;
            string connectionAgree = @"Data Source = ADMIN\MSSQ; Initial Catalog = Library; Integrated Security = True";
            SqlConnection connection2 = new SqlConnection(connectionAgree);
            connection2.Open();

            int ident = Convert.ToInt32(dataGridViewExtend[1, dataGridViewExtend.CurrentRow.Index].Value);
            int book = Convert.ToInt32(dataGridViewExtend[0, dataGridViewExtend.CurrentRow.Index].Value);

            string queryAgree = String.Format("SELECT * FROM Debt WHERE ID = {0}", ident);
            string queryUpdate = String.Format("UPDATE DATE_RETURN_BOOK SET Date_start = Date_start + 21 WHERE Id_reader = {0} AND Id_BOOK = {1}", ident, book);
            string queryDelete = String.Format("DELETE FROM EXTEND WHERE Id_reader = {0}", ident);

            SqlCommand cmd2 = new SqlCommand(queryAgree, connection2);

            SqlDataReader reader2 = cmd2.ExecuteReader();

            if (reader2.HasRows)
            {
                MessageBox.Show("У читателя ИМЕЮТСЯ задолженности. Отклоните запрос на продление!");
                err = 1;
            }
            else
            {
                err = 0;
            }

            reader2.Close();

            if(err == 0)
            {
                SqlCommand cmdUpdate = new SqlCommand(queryUpdate, connection2);
                SqlCommand cmdDelete = new SqlCommand(queryDelete, connection2);
                cmdUpdate.Prepare();
                cmdUpdate.ExecuteNonQuery();

                cmdDelete.Prepare();
                cmdDelete.ExecuteNonQuery();
                int a;
                a = dataGridViewExtend.CurrentRow.Index;
                dataGridViewExtend.Rows.Remove(dataGridViewExtend.Rows[a]);
               
            }

            connection2.Close();
        }
                
    private void disagree_Click(object sender, EventArgs e)
        {
            int ident = Convert.ToInt32(dataGridViewExtend[1, dataGridViewExtend.CurrentRow.Index].Value);
            string connectionDisagree = @"Data Source = ADMIN\MSSQ; Initial Catalog = Library; Integrated Security = True";
            SqlConnection connectionDel = new SqlConnection(connectionDisagree);
            string queryDelete = String.Format("DELETE FROM EXTEND WHERE Id_reader = {0}", ident);
            connectionDel.Open();
            SqlCommand cmdDeleteDisagree = new SqlCommand(queryDelete, connectionDel);
            cmdDeleteDisagree.Prepare();
            cmdDeleteDisagree.ExecuteNonQuery();
            int a;
            a = dataGridViewExtend.CurrentRow.Index;
            dataGridViewExtend.Rows.Remove(dataGridViewExtend.Rows[a]);
            connectionDel.Close();
        }

        private void fORMS_READERBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.fORMS_READERBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.libraryDataSet);

        }


        private void fORMS_READERBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.fORMS_READERBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.libraryDataSet);

        }

        private void dATE_RETURN_BOOKBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dATE_RETURN_BOOKBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.libraryDataSet);

        }

        private void bLOCKSBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bLOCKSBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.libraryDataSet);

        }

        private void Administration_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryDataSet.COUNT_TITLE". При необходимости она может быть перемещена или удалена.
            this.cOUNT_TITLETableAdapter.Fill(this.libraryDataSet.COUNT_TITLE);

            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryDataSet1.DATE_RETURN_BOOK". При необходимости она может быть перемещена или удалена.
            this.dATE_RETURN_BOOKTableAdapter.Fill(this.libraryDataSet1.DATE_RETURN_BOOK);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryDataSet1.DATE_RETURN_BOOK". При необходимости она может быть перемещена или удалена.
            this.dATE_RETURN_BOOKTableAdapter.Fill(this.libraryDataSet1.DATE_RETURN_BOOK);

            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryDataSet.BLOCKS". При необходимости она может быть перемещена или удалена.
            this.bLOCKSTableAdapter.Fill(this.libraryDataSet.BLOCKS);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryDataSet.BOOK". При необходимости она может быть перемещена или удалена.
            this.bOOKTableAdapter.Fill(this.libraryDataSet.BOOK);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryDataSet.DATE_RETURN_BOOK". При необходимости она может быть перемещена или удалена.
            this.dATE_RETURN_BOOKTableAdapter.Fill(this.libraryDataSet.DATE_RETURN_BOOK);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryDataSet.FORMS_READER". При необходимости она может быть перемещена или удалена.
            this.fORMS_READERTableAdapter.Fill(this.libraryDataSet.FORMS_READER);

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.DataGridViewColumn Col = null;
            switch (listBox1.SelectedIndex)
            {
                case 0: Col = dataGridViewTextBoxColumn1; break;
                case 1: Col = dataGridViewTextBoxColumn2; break;
                case 2: Col = dataGridViewTextBoxColumn3; break;
                case 3: Col = dataGridViewTextBoxColumn4; break;
                case 4: Col = dataGridViewTextBoxColumn5; break;
                case 5: Col = dataGridViewTextBoxColumn6; break;

            }

            if (radioButton1.Checked)
            {
                fORMS_READERDataGridView.Sort(Col, System.ComponentModel.ListSortDirection.Ascending);
            }
            else
            {
                fORMS_READERDataGridView.Sort(Col, System.ComponentModel.ListSortDirection.Descending);
            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < fORMS_READERDataGridView.ColumnCount - 1; i++)
            {
                for (int j = 0; j < fORMS_READERDataGridView.RowCount - 1; j++)
                {
                    fORMS_READERDataGridView.Rows[j].Cells[i].Style.BackColor = Color.White;
                    fORMS_READERDataGridView.Rows[j].Cells[i].Style.ForeColor = Color.Black;
                }
            }
            for (int i = 0; i < fORMS_READERDataGridView.ColumnCount - 1; i++)
            {
                for (int j = 0; j < fORMS_READERDataGridView.RowCount - 1; j++)
                {
                    var value = fORMS_READERDataGridView.Rows[j].Cells[i].Value;
                    if (value != null)
                    {
                        String baseStr = value.ToString();
                        if (baseStr.IndexOf(textBox2.Text) > -1)
                        {
                            fORMS_READERDataGridView.Rows[j].Cells[i].Style.BackColor = Color.Yellow;
                            fORMS_READERDataGridView.Rows[j].Cells[i].Style.ForeColor = Color.Black;
                        }
                    }
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            fORMS_READERBindingSource.Filter = "";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            fORMS_READERBindingSource.Filter = "Id_reader='" + comboBox1.Text + "'";
        }

        private void answerButton_Click(object sender, EventArgs e)
        {
            string titleFindBook = textBox5.Text.ToString();

            if(titleFindBook == "")
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

                reader.Close();
               
            }
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

        private void button18_Click(object sender, EventArgs e)
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
                }

            }
            readerBook.Close();

            connectionNewFind.Close();


            foreach (string[] strrr in dataBook)
            {
                bookAuthordataGridView.Rows.Add(strrr);
            }
    

            foreach (DataGridViewRow row in bookAuthordataGridView.Rows)
            {

                row.DefaultCellStyle.BackColor = Color.Teal;


            }
        }

        private void button17_Click(object sender, EventArgs e)
        {


            string titleBook = textBox7.Text;
            string connectionStringNew = @"Data Source = ADMIN\MSSQ; Initial Catalog = Library; Integrated Security = True";
            SqlConnection connectionNew = new SqlConnection(connectionStringNew);
            connectionNew.Open();
      
            string findPlace = String.Format("EXEC[LOCATION_OF_BOOK] '{0}' ", titleBook);


            SqlCommand cmdfindPlace = new SqlCommand(findPlace, connectionNew);

            SqlDataReader readerPlace = cmdfindPlace.ExecuteReader();
            String h, s, pol;

            while (readerPlace.Read())
            {

                h = readerPlace[0].ToString();
                s = readerPlace[1].ToString();
                pol = readerPlace[2].ToString();
                hall.Text = h;
                polkaLabel.Text = pol;
                stendLabel.Text = s;
            }

            if (!readerPlace.HasRows)
            {
                MessageBox.Show("Такой книги нет в библиотеке!");
            }

            readerPlace.Close();
            connectionNew.Close();


        }

        private void button12_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DataGridViewColumn Col = null;
            switch (listBox3.SelectedIndex)
            {
                case 0: Col = dataGridViewTextBoxColumn11; break;
                case 1: Col = dataGridViewTextBoxColumn12; break;
                case 2: Col = dataGridViewTextBoxColumn13; break;
                case 3: Col = dataGridViewTextBoxColumn14; break;
                case 4: Col = dataGridViewTextBoxColumn15; break;
                case 5: Col = dataGridViewTextBoxColumn16; break;
                case 6: Col = dataGridViewTextBoxColumn17; break;
                case 7: Col = dataGridViewTextBoxColumn18; break;
                case 8: Col = dataGridViewTextBoxColumn19; break;
                case 9: Col = dataGridViewTextBoxColumn20; break;

            }

            if (radioButton6.Checked)
            {
                bOOKDataGridView.Sort(Col, System.ComponentModel.ListSortDirection.Ascending);
            }
            else
            {
                bOOKDataGridView.Sort(Col, System.ComponentModel.ListSortDirection.Descending);
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
                button12.Enabled = true;
 
        }

        private void button9_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bOOKDataGridView.ColumnCount - 1; i++)
            {
                for (int j = 0; j < bOOKDataGridView.RowCount - 1; j++)
                {
                    bOOKDataGridView.Rows[j].Cells[i].Style.BackColor = Color.White;
                    bOOKDataGridView.Rows[j].Cells[i].Style.ForeColor = Color.Black;
                }
            }
            for (int i = 0; i < bOOKDataGridView.ColumnCount - 1; i++)
            {
                for (int j = 0; j < bOOKDataGridView.RowCount - 1; j++)
                {
                    var value = bOOKDataGridView.Rows[j].Cells[i].Value;
                    if (value != null)
                    {
                        String baseStr = value.ToString();
                        if (baseStr.IndexOf(textBox3.Text) > -1)
                        {
                            bOOKDataGridView.Rows[j].Cells[i].Style.BackColor = Color.Yellow;
                            bOOKDataGridView.Rows[j].Cells[i].Style.ForeColor = Color.Black;
                        }
                    }
                }
            }
        }


        private void button11_Click(object sender, EventArgs e) //фильтровать
        {
            bOOKBindingSource.Filter = "Author_Surname='" + comboBox3.Text + "'";
        }

        private void button10_Click(object sender, EventArgs e) //показать
        {
            bOOKBindingSource.Filter = "";
        }



        private void button16_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DataGridViewColumn Col = null;
            switch (listBox4.SelectedIndex)
            {
                case 0: Col = dataGridViewTextBoxColumn21; break;
                case 1: Col = dataGridViewTextBoxColumn22; break;
                case 2: Col = dataGridViewTextBoxColumn24; break;

            }

            if (radioButton8.Checked)
            {
                bLOCKSDataGridView.Sort(Col, System.ComponentModel.ListSortDirection.Ascending);
            }
            else
            {
                bLOCKSDataGridView.Sort(Col, System.ComponentModel.ListSortDirection.Descending);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            bLOCKSBindingSource.Filter = "Id_reader='" + comboBox4.Text + "'";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            bLOCKSBindingSource.Filter = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bLOCKSDataGridView.ColumnCount - 1; i++)
            {
                for (int j = 0; j < bLOCKSDataGridView.RowCount - 1; j++)
                {
                    bLOCKSDataGridView.Rows[j].Cells[i].Style.BackColor = Color.White;
                    bLOCKSDataGridView.Rows[j].Cells[i].Style.ForeColor = Color.Black;
                }
            }
            for (int i = 0; i < bLOCKSDataGridView.ColumnCount - 1; i++)
            {
                for (int j = 0; j < bLOCKSDataGridView.RowCount - 1; j++)
                {
                    var value = bLOCKSDataGridView.Rows[j].Cells[i].Value;
                    if (value != null)
                    {
                        String baseStr = value.ToString();
                        if (baseStr.IndexOf(textBox4.Text) > -1)
                        {
                            bLOCKSDataGridView.Rows[j].Cells[i].Style.BackColor = Color.Yellow;
                            bLOCKSDataGridView.Rows[j].Cells[i].Style.ForeColor = Color.Black;
                        }
                    }
                }
            }
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            button16.Enabled = true;
        }

        private void fORMS_READERBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.fORMS_READERBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.libraryDataSet);
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bOOKBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.libraryDataSet);
        }

        private void dATE_RETURN_BOOKBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.dATE_RETURN_BOOKBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.libraryDataSet);
        }

        private void bLOCKSBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.bLOCKSBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.libraryDataSet);
        }

       

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dATE_RETURN_BOOKBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.libraryDataSet);
        }

        private void toolStripButton27_Click(object sender, EventArgs e)
        {
  /*          string connectionString = @"Data Source = ADMIN\MSSQ; Initial Catalog = Library; Integrated Security = True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            int count;
            int book = Convert.ToInt32(dATE_RETURN_BOOKDataGridView[0, dATE_RETURN_BOOKDataGridView.CurrentRow.Index].Value);
            
            string query = String.Format("SELECT COUNT_OF_BOOK FROM BOOK WHERE ID_BOOK = {0} ", book);

            SqlCommand cmd = new SqlCommand(query, connection);


            count = (int)cmd.ExecuteScalar();
            if (count == 0) MessageBox.Show("Книг нет в наличии! Невозможно выдать ее на руки!");
            else
            {*/
                this.Validate();
                this.dATE_RETURN_BOOKBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.libraryDataSet);
               
           // }
        

        }

        private void toolStripButton14_Click_1(object sender, EventArgs e)
        {
            
            this.Validate();
            this.bLOCKSBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.libraryDataSet);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            ReporActivity formReport = new ReporActivity();
            formReport.Show();
        }


        private void button8_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.DataGridViewColumn Col = null;
            switch (listBox2.SelectedIndex)
            {
                case 0: Col = dataGridViewTextBoxColumn7; break;
                case 1: Col = dataGridViewTextBoxColumn8; break;
                case 2: Col = dataGridViewTextBoxColumn9; break;
                case 3: Col = dataGridViewTextBoxColumn10; break;

            }

            if (radioButton4.Checked)
            {
                dATE_RETURN_BOOKDataGridView.Sort(Col, System.ComponentModel.ListSortDirection.Ascending);
            }
            else
            {
                dATE_RETURN_BOOKDataGridView.Sort(Col, System.ComponentModel.ListSortDirection.Descending);
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            dATE_RETURN_BOOKBindingSource.Filter = "Id_reader='" + comboBox2.Text + "'";
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            dATE_RETURN_BOOKBindingSource.Filter = "";
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < dATE_RETURN_BOOKDataGridView.ColumnCount - 1; i++)
            {
                for (int j = 0; j < dATE_RETURN_BOOKDataGridView.RowCount - 1; j++)
                {
                    dATE_RETURN_BOOKDataGridView.Rows[j].Cells[i].Style.BackColor = Color.White;
                    dATE_RETURN_BOOKDataGridView.Rows[j].Cells[i].Style.ForeColor = Color.Black;
                }
            }
            for (int i = 0; i < dATE_RETURN_BOOKDataGridView.ColumnCount - 1; i++)
            {
                for (int j = 0; j < dATE_RETURN_BOOKDataGridView.RowCount - 1; j++)
                {
                    var value = dATE_RETURN_BOOKDataGridView.Rows[j].Cells[i].Value;
                    if (value != null)
                    {
                        String baseStr = value.ToString();
                        if (baseStr.IndexOf(textBox1.Text) > -1)
                        {
                            dATE_RETURN_BOOKDataGridView.Rows[j].Cells[i].Style.BackColor = Color.Yellow;
                            dATE_RETURN_BOOKDataGridView.Rows[j].Cells[i].Style.ForeColor = Color.Black;
                        }
                    }
                }
            }
        }

        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            button8.Enabled = true;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            UpdateLocation upd = new UpdateLocation();
            upd.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Report_Debt formReportDebt = new Report_Debt();
            formReportDebt.Show();
        }
    }
}
