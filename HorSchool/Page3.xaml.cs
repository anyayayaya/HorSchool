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
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        DataBase dataBase = new DataBase();

        public Page3()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var name = fio_in.Text;
                var login = Convert.ToInt32(password_in.Text);

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataTable table = new DataTable();

                    string querystring = $"SELECT * FROM us WHERE fio = '{name}' AND pass = '{login}'";
                    SqlCommand comman = new SqlCommand(querystring, dataBase.getConnection());

                    adapter.SelectCommand = comman;
                    adapter.Fill(table);


                    if (table.Rows.Count == 1)
                    {
                        MessageBox.Show("Авторизация прошла успешно!");
                        NavigationService.Navigate(new Page4());
                    }
                    else
                    {
                        MessageBox.Show("Что-то пошло не так");
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                var name = fio_reg.Text;
                var login = Convert.ToInt32(password_reg.Text);

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataTable table = new DataTable();

                    string queryCheck = $"SELECT * FROM us WHERE fio = '{name}' AND pass = '{login}'";
                    SqlCommand commanCheck = new SqlCommand(queryCheck, dataBase.getConnection());
                    adapter.SelectCommand = commanCheck;
                    adapter.Fill(table);

                    string querystring = $"insert into us(fio, pass) values('{name}', '{login}')";
                    SqlCommand comman = new SqlCommand(querystring, dataBase.getConnection());

                    dataBase.openConnection();

                    if (table.Rows.Count > 0)
                    {
                        MessageBox.Show("Пользователь уже существует");
                    }
                    else
                    {
                        if (comman.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Регистрация прошла успешно!");
                        NavigationService.Navigate(new Page4());
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
    }
}
