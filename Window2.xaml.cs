using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            // задаем контекст данных для окна
            this.DataContext = new ReportsViewModel();
        }
    }

    public class ReportsViewModel : INotifyPropertyChanged
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

        private ObservableCollection<Report> reports;
        public ObservableCollection<Report> Reports
        {
            get { return reports; }
            set
            {
                reports = value;
                NotifyPropertyChanged("Reports");
            }
        }

        private Report selectedReport;
        public Report SelectedReport
        {
            get { return selectedReport; }
            set
            {
                selectedReport = value;
                NotifyPropertyChanged("SelectedReport");
            }
        }

        public ReportsViewModel()
        {
            userName = "John Smith";
            reports = new ObservableCollection<Report>()
        {
            new Report() { Name = "Project 1", Entries = new ObservableCollection<Entry>()
                {
                    new Entry() { Date = DateTime.Today, TimeSpent = TimeSpan.FromHours(5), Notes = "Working on feature X"},
                    new Entry() { Date = DateTime.Today.AddDays(-1), TimeSpent = TimeSpan.FromHours(3), Notes = "Testing and bug fixing"}
                }},
            new Report() { Name = "Project 2", Entries = new ObservableCollection<Entry>()
                {
                    new Entry() { Date = DateTime.Today.AddDays(-1), TimeSpent = TimeSpan.FromHours(7), Notes = "Helping team with issue Y"},
                    new Entry() { Date = DateTime.Today.AddDays(-2), TimeSpent = TimeSpan.FromHours(4), Notes = "Preparation for presentation"}
                }}
        };

            selectedReport = reports.FirstOrDefault();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Report
    {
        public string Name { get; set; }
        public ObservableCollection<Entry> Entries { get; set; }
    }

    public class Entry
    {
        public DateTime Date { get; set; }
        public TimeSpan TimeSpent { get; set; }
        public string Notes { get; set; }
    }
}
