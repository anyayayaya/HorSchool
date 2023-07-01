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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public DataBase dataBase = new DataBase();

        public Page2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var name = FIO.Text;
                var login = Convert.ToInt32(password.Text);

                if (login == 2113)
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataTable table = new DataTable();

                    string querystring = $"SELECT * FROM admin WHERE fio = '{name}' AND pass = '{login}'";
                    SqlCommand comman = new SqlCommand(querystring, dataBase.getConnection());

                    adapter.SelectCommand = comman;
                    adapter.Fill(table);


                    if (table.Rows.Count == 1)
                    {
                        MessageBox.Show("Авторизация прошла успешно!");
                        NavigationService.Navigate(new Page9());
                    }
                    else
                    {
                        MessageBox.Show("Что-то пошло не так" );
                    }
                }

                else
                {
                    MessageBox.Show("неверный пароль");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
