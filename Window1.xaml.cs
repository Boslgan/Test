using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Лабиринт_времени
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent(); // задаем контекст данных для окна
            this.DataContext = new MainViewModel();
        }

        private void UchTimeBtn_Click(object sender, RoutedEventArgs e)
        {

            Window3 Win3 = new Window3();
            Win3.Show();
            this.Close();
        }

        private void reportbtn_Click(object sender, RoutedEventArgs e)
        {
            Window2 Win2 = new Window2();
            Win2.Show();
            this.Close();
        }
    }

    public class MainViewModel : INotifyPropertyChanged
    {
        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                NotifyPropertyChanged("UserName");
            }
        }

        private DateTime startTime;
        public DateTime StartTime
        {
            get { return startTime; }
            set
            {
                startTime = value;
                NotifyPropertyChanged("StartTime");
                NotifyPropertyChanged("WorkTime");
            }
        }

        public string WorkTime
        {
            get { return (DateTime.Now - startTime).ToString(@"hh\:mm\:ss"); }
        }

        public MainViewModel()
        {
            userName = "John Smith";
            startTime = DateTime.Now;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
