using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Page13.xaml
    /// </summary>
    public partial class Page13 : Page
    {
        DataBase dataBase = new DataBase();
        private List<DatabaseItem> prodList = new List<DatabaseItem>();

        private List<DatabaseItem1> prodList1 = new List<DatabaseItem1>();

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

        public void filllabel1()
        {
            string connectionString = @" Data Source = DESKTOP-01EBAMC\SQLEXPRESS;Initial Catalog = HorSchool;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM daydd";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    com.Items.Clear();

                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0)) // Проверяем, что значение не является NULL
                        {
                            object value = reader.GetValue(1);
                            com.Items.Add(value.ToString());
                        }
                    }
                }
            }
        }

        public Page13()
        {
            InitializeComponent();
            filllabel();
            filllabel1();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
                        Label nam = new Label();
                        Label cl = new Label();

                        nam.Content = reader.GetValue(0);
                        cl.Content = reader.GetValue(1);

                        MessageBox.Show("Преподаватель: "+nam.Content+" преподает "+ cl.Content);
                    }
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        public class DatabaseItem
        {
            public string Fio { get; set; }
            public string Class { get; set; }
        }

        public class DatabaseItem1
        {
            public string Fio { get; set; }
            public string Class { get; set; }
            public int Kub { get; set; }
            public string Date {get; set;}
            public int Count { get; set; }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page4());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {

                string connectionString = @" Data Source = DESKTOP-01EBAMC\SQLEXPRESS;Initial Catalog = HorSchool;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();

                    string query = $"select fio, class dayd, kub, countt, (select namee from daydd where namee = '{com.SelectedItem}' AND daydd.namee = sched.dayd) from sched where fio = '{combo.SelectedItem}'";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                        Label fio = new Label();
                        Label cl = new Label();
                        Label date = new Label();
                        Label kub = new Label();
                        Label count = new Label();

                        fio.Content = reader.GetValue(0);
                                date.Content = reader.GetValue(1);
                                cl.Content = reader.GetValue(2);
                                kub.Content = reader.GetValue(3);
                                count.Content = reader.GetValue(4);

                                MessageBox.Show("Преподаватель: " + fio.Content + " пары по " + date.Content +" в кабинете "+ cl.Content+" кол-во занятий"+ kub.Content );
                            } 
                        
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
