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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string User = Login.Text;
            string Password = this.Password.Text;

            Surname.Text = Surname.Text.Trim();
            Name.Text = Name.Text.Trim();
            Patronymic.Text = Patronymic.Text.Trim();
            if (Login.Text == "" || this.Password.Text == "" || Surname.Text == "" || Name.Text == "" || Patronymic.Text == "" || maskedTextBox2.Text == "" || maskedTextBox1.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля для регистрации!");
            }
            else
            {
                if (System.Text.RegularExpressions.Regex.Match(Surname.Text,"^[А-ИК-ЩЭ-Я][а-яА-Я]*$").Success ==false)
                {
                    MessageBox.Show("Пожалуйста, введите корректные данные в поле Фамилия! Фамилия начинается с заглавной буквы и записывается на русском языке", "Ошибка в поле Фамилия");
                }
                else
                {
                    if (System.Text.RegularExpressions.Regex.Match(Name.Text, "^[А-ИК-ЩЭ-Я][а-яА-Я]*$").Success == false)
                    {
                        MessageBox.Show("Пожалуйста, введите корректные данные в поле Имя! Имя начинается с заглавной буквы и записывается на русском языке", "Ошибка в поле Имя");
                    }
                    else
                    {
                        if (System.Text.RegularExpressions.Regex.Match(Patronymic.Text, "^[А-ИК-ЩЭ-Я][а-яА-Я]*$").Success == false)
                        {
                            MessageBox.Show("Пожалуйста, введите корректные данные в поле Отчество! Отчество начинается с заглавной буквы и записывается на русском языке", "Ошибка в поле Отчество");
                        }
                        else
                        {
                            string birthday = (Convert.ToDateTime(maskedTextBox1.Text)).ToString("yyyy-MM-dd");
                            string connectionString = @"Data Source = ADMIN\MSSQ; Initial Catalog = Library; Integrated Security = True";
                            SqlConnection connection = new SqlConnection(connectionString);
                            string errorUser = String.Format("SELECT * FROM USERS WHERE ID = '{0}' ", Login.Text);
                            connection.Open();



                            SqlCommand error = new SqlCommand(errorUser, connection);
                            SqlDataReader reader = error.ExecuteReader();

                            if (reader.HasRows)
                            {
                                MessageBox.Show("Такой логин уже существует! Попробуйте еще раз");
                            }
                            else
                            {
                                reader.Close();
                                string chechcmd = String.Format("INSERT INTO Users (RIGHTS,ID, PASSWORD) VALUES (" + 0 + ",'" + User + "','" + Password + "')");
                                string noInsert = String.Format("SELECT * FROM FORMS_READER WHERE Surname = '{0}' and name = '{1}' and patronymic = '{2}' and Phone = '{3}'", Surname.Text, Name.Text, Patronymic.Text, maskedTextBox2.Text);
                                string cmd = String.Format("INSERT INTO FORMS_READER(SURNAME, NAME, PATRONYMIC, BIRTHDAY, PHONE) VALUES('" + Surname.Text + "', '" + Name.Text + "', '" + Patronymic.Text + "', '" + birthday + "', '" + maskedTextBox2.Text + "')");
                                string id = String.Format("SELECT ID_READER FROM FORMS_READER WHERE Surname = '{0}' and name = '{1}' and patronymic = '{2}' and Phone = '{3}'", Surname.Text, Name.Text, Patronymic.Text, maskedTextBox2.Text);

                                SqlCommand check = new SqlCommand(chechcmd, connection);
                                SqlCommand check2 = new SqlCommand(cmd, connection);
                                SqlCommand noIns = new SqlCommand(noInsert, connection);
                                SqlCommand idCmd = new SqlCommand(id, connection);
                                
                                SqlDataReader readerIns = noIns.ExecuteReader();

                                if (readerIns.HasRows)
                                {
                                    MessageBox.Show("У вас уже есть формуляр. Вы уверены что не зарегистрированы в системе? Если уверены, нажмите появившуюся кнопку, иначе зайдите в систему со своим логином и паролем");
                                    button4.Visible = false;
                                    button2.Visible = true;

                                }
                                else
                                {
                                    readerIns.Close();
                                   
                                    check2.Prepare();
                                    check2.ExecuteNonQuery();
                                    int idUs;
                                    idUs = (int)idCmd.ExecuteScalar();
                                    string Insert = String.Format("INSERT INTO Users (RIGHTS,ID, PASSWORD,ID_READER_USER) VALUES (" + 0 + ",'" + User + "','" + Password + "','" + idUs + "')");
                                    SqlCommand ins = new SqlCommand(Insert, connection);
                                    ins.Prepare();
                                    ins.ExecuteNonQuery();
                                    //  check.Prepare();
                                    //   check.ExecuteNonQuery();

                                    MessageBox.Show("Вы успешно зарегистрированы!");
                                }

                            }
                        }
                        
                    }
                    
                }
              
              

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string User = Login.Text;
            string Password = this.Password.Text;
            int idUs;
          
            string connectionString = @"Data Source = ADMIN\MSSQ; Initial Catalog = Library; Integrated Security = True";
           
            SqlConnection connection = new SqlConnection(connectionString);
          
            string id = String.Format("SELECT ID_READER FROM FORMS_READER WHERE Surname = '{0}' and name = '{1}' and patronymic = '{2}' and Phone = '{3}'", Surname.Text, Name.Text, Patronymic.Text, maskedTextBox2.Text);
            string errorUser = String.Format("SELECT * FROM USERS WHERE ID = '{0}' ", Login.Text);
        
            connection.Open();

            SqlCommand error = new SqlCommand(errorUser, connection);
            SqlDataReader reader = error.ExecuteReader();

            if (reader.HasRows)
            {
                MessageBox.Show("Такой логин уже сущестует! Попробуйте еще раз");
            }
            else
            {
                reader.Close();

                SqlCommand idCmd = new SqlCommand(id, connection);

                idUs = (int)idCmd.ExecuteScalar();
                string errorInsert = String.Format("SELECT * FROM USERS WHERE ID_READER_USER = {0}",idUs);
                SqlCommand errorIns = new SqlCommand(errorInsert, connection);
                SqlDataReader readerError = errorIns.ExecuteReader();
                if (readerError.HasRows)
                {
                    MessageBox.Show("Вы уже зарегистрированы в системе! Зайдите под своим логином и паролем");
                }
                else
                {
                    readerError.Close();
                    string Insert = String.Format("INSERT INTO Users (RIGHTS,ID, PASSWORD,ID_READER_USER) VALUES (" + 0 + ",'" + User + "','" + Password + "','" + idUs + "')");
                    SqlCommand ins = new SqlCommand(Insert, connection);
                    ins.Prepare();
                    ins.ExecuteNonQuery();
                    MessageBox.Show("Вы успешно зарегистрированы!");
                }
             
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            textBox1.Visible = true;
            button3.Visible = true;

            button1.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string User = Login.Text;
            string Password = this.Password.Text;

            string connectionString = @"Data Source = ADMIN\MSSQ; Initial Catalog = Library; Integrated Security = True";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string errorUser = String.Format("SELECT * FROM USERS WHERE ID = '{0}' ", Login.Text);

            SqlCommand error = new SqlCommand(errorUser, connection);
            SqlDataReader reader = error.ExecuteReader();

            string kod = textBox1.Text;

            if (reader.HasRows)
            {
                MessageBox.Show("Такой логин уже сущестует! Попробуйте еще раз");
            }
            else
            {
                reader.Close();
                if (kod == "12k178pBD")
                {
                    string Insert = String.Format("INSERT INTO Users (RIGHTS,ID, PASSWORD) VALUES (" + 1 + ",'" + User + "','" + Password + "')");
                    SqlCommand ins = new SqlCommand(Insert, connection);
                    ins.Prepare();
                    ins.ExecuteNonQuery();
                    MessageBox.Show("Вы успешно зарегистрированы!");
                }
                else
                {
                    MessageBox.Show("Неверный код!");
                }
                
            }
            connection.Close();
        }
     
    }
}
