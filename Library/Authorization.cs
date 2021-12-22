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
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string User = textBox1.Text;
            string Password = textBox2.Text;
            int identity = 0;
            string connectionString = @"Data Source = ADMIN\MSSQ; Initial Catalog = Library; Integrated Security = True";
            string chechcmd = String.Format("SELECT * from Users where ID = '{0}' and PASSWORD ='{1}'", User, Password);
            string id = String.Format("SELECT ID_READER_USER FROM USERS WHERE ID = '{0}' ", User);

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand check = new SqlCommand(chechcmd, connection);
            SqlCommand cmd = new SqlCommand(id, connection);

            connection.Open();

            check.Prepare();
            check.ExecuteNonQuery();


            if (check.ExecuteScalar() == null)
           {
               MessageBox.Show("Учетная запись не найдена! Проверьте правильность введенных данных.");
          }
           else
            {
                 if (1 == (int)check.ExecuteScalar())
                {
                    MessageBox.Show("Вы вошли под учетной записью библиотекаря");
                    Administration adminForm = new Administration();
                    adminForm.Show();
                }
                else
                {
                    identity = (int)cmd.ExecuteScalar();
                    string block = String.Format("SELECT * FROM BLOCKS WHERE Id_reader = {0} ", identity);
                    SqlCommand cmdblock = new SqlCommand(block, connection);
                    cmdblock.Prepare();

                    if (cmdblock.ExecuteScalar() ==null)
                    {
                        MessageBox.Show("Вы вошли под учетной записью читателя.");
                        this.Close();
                        PersonalArea form = new PersonalArea(identity);
                        form.Show();
                    }
                    else
                    {
                        this.Close();
                        Blocker formBlock = new Blocker(identity);
                        formBlock.Show();
                    }
                    
                   // Hide();
                }
            }
    
        }
    }
}
