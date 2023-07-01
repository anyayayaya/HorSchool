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
    /// Логика взаимодействия для Page6.xaml
    /// </summary>
    public partial class Page6 : Page
    {
        DataBase dataBase = new DataBase();

        public Page6()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var dateEdit = name.Text;
            var conceptEdit = director.Text;
            var timeEdit = open.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryUpdate = $"UPDATE concert SET название = '{dateEdit}', дата = '{conceptEdit}', место = '{timeEdit}'";
            SqlCommand comman = new SqlCommand(queryUpdate, dataBase.getConnection());

            dataBase.openConnection();

            if (comman.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Редактирование успешно!");
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page12());
        }
    }
}
