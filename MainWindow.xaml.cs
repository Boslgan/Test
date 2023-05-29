using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Лабиринт_времени
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = tbUsername.Text;
            string password = pbPassword.Password;

            if (AuthenticateUser(username, password))
            {
                Window1 Win1 = new Window1();
                Win1.Show();
                this.Close();
            }
            else
                MessageBox.Show("Incorrect username or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private bool AuthenticateUser(string username, string password)
        {
            // здесь можно реализовать запрос к базе данных, чтобы проверить,
            // правильно ли введены логин и пароль
            return username == "admin" && password == "admin";
            

        }
    
    }
}
