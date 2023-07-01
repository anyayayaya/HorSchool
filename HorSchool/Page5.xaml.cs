using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HorSchool
{
    /// <summary>
    /// Логика взаимодействия для Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {
        DataBase dataBase = new DataBase(); 

        public void filllabel()
        {
            string connectionString = @" Data Source = DESKTOP-01EBAMC\SQLEXPRESS;Initial Catalog = HorSchool;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM prepod";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    combo.Items.Clear();

                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0)) // Проверяем, что значение не является NULL
                        {
                            object value = reader.GetValue(0);
                            combo.Items.Add(value.ToString());
                        }
                    }
                }
            }
        }

        public Page5()
        {
            InitializeComponent();
            filllabel();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var nameAdd = num.Text;
            var clAdd = cl.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryUpdate = $"UPDATE prepod SET фио = '{nameAdd}', дисциплина = '{clAdd}' where Название = '{combo.SelectedItem}'";
            SqlCommand comman = new SqlCommand(queryUpdate, dataBase.getConnection());

            dataBase.openConnection();

            if (comman.ExecuteNonQuery() == 1)
            {
                filllabel();
                MessageBox.Show("Редактирование успешно!");
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");

            }
        }

            private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
            string connectionString = @" Data Source = DESKTOP-01EBAMC\SQLEXPRESS;Initial Catalog = HorSchool;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                string query = $"SELECT * FROM prepod where фио = '{combo.SelectedItem}'";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            object value1 = reader.GetValue(0);
                            num.Text = value1.ToString();

                            object value2 = reader.GetValue(1);
                            cl.Text = value2.ToString();

                        }
                    }
                }
            }
        }

        private void Button_Click_30(object sender, RoutedEventArgs e)
        {
            try
            {
                var nameAdd = num.Text;
                var clAdd = cl.Text;


                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();


                string queryCheck = $"SELECT * FROM prepod WHERE фио = '{nameAdd}'";
                SqlCommand commanCheck = new SqlCommand(queryCheck, dataBase.getConnection());
                adapter.SelectCommand = commanCheck;
                adapter.Fill(table);

                string querystring = $"insert into prepod(фио, дисциплина) values('{nameAdd}', '{clAdd}')";
                SqlCommand comman = new SqlCommand(querystring, dataBase.getConnection());

                dataBase.openConnection();


                if (table.Rows.Count > 0)
                {
                    MessageBox.Show("Событие уже существует");
                }
                else
                {
                    if (comman.ExecuteNonQuery() == 1)
                    {
                        filllabel();
                        MessageBox.Show("Добавление прошло успешно!");
                    }
                    else
                    {
                        MessageBox.Show("Что-то пошло не так");
                    }
                }

                dataBase.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var combo2 = combo.SelectedItem;

            try
            {

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();

                string querystring = $"delete from prepod where фио='{combo2}'";
                SqlCommand comman = new SqlCommand(querystring, dataBase.getConnection());

                dataBase.openConnection();

                if (comman.ExecuteNonQuery() == 1)
                {
                    filllabel();
                    MessageBox.Show("Удаление прошло успешно!");
                }
                else
                {
                    MessageBox.Show("Что-то пошло не так");
                }


                dataBase.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page9());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                var nameAdd = num.Text;
                var clAdd = cl.Text;

                var kubadd = Convert.ToInt32(kub.Text);
                var dayAdd = day.Text;
                var countadd = Convert.ToInt32(count.Text);

                SqlDataAdapter adapter1 = new SqlDataAdapter();
                DataTable table1 = new DataTable();

                string querystring1 = $"insert into sched(fio, dayd, class, kub, countt) values('{nameAdd}', '{dayAdd}', '{clAdd}', {kubadd}, {countadd})";
                SqlCommand comman1 = new SqlCommand(querystring1, dataBase.getConnection());

                dataBase.openConnection();

                    if (comman1.ExecuteNonQuery() == 1)
                    {
                        filllabel();
                        MessageBox.Show("Добавление прошло успешно!");
                    }
                    else
                    {
                        MessageBox.Show("Что-то пошло не так");
                    }
                

                dataBase.closeConnection();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
