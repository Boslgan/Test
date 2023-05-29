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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();

            // задаем контекст данных для окна
            this.DataContext = new SettingsViewModel();
        }
    }

    public class SettingsViewModel : INotifyPropertyChanged
    {
        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                NotifyPropertyChanged("Имя пользователя");
            }
        }

        private bool isGeneralEnabled;
        public bool IsGeneralEnabled
        {
            get { return isGeneralEnabled; }
            set
            {
                isGeneralEnabled = value;
                NotifyPropertyChanged("IsGeneralEnabled");
            }
        }

        private bool isPersonalEnabled;
        public bool IsPersonalEnabled
        {
            get { return isPersonalEnabled; }
            set
            {
                isPersonalEnabled = value;
                NotifyPropertyChanged("IsPersonalEnabled");
            }
        }

        private object currentViewModel;
        public object CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                NotifyPropertyChanged("CurrentViewModel");
            }
        }

        public ICommand GeneralSettingsCommand { get; private set; }
        public ICommand PersonalSettingsCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public SettingsViewModel()
        {
            userName = "Захар";
            IsGeneralEnabled = true;
            IsPersonalEnabled = false;

            GeneralSettingsCommand = new RelayCommand(ShowGeneralSettings);
            PersonalSettingsCommand = new RelayCommand(ShowPersonalSettings);
            SaveCommand = new RelayCommand(SaveSettings);
        }

        private void ShowGeneralSettings()
        {
            IsGeneralEnabled = true;
            IsPersonalEnabled = false;

            CurrentViewModel = new GeneralSettingsViewModel();
        }

        private void ShowPersonalSettings()
        {
            IsGeneralEnabled = false;
            IsPersonalEnabled = true;

            CurrentViewModel = new PersonalSettingsViewModel();
        }

        private void SaveSettings()
        {
            // Save settings here
            MessageBox.Show("настройки сохранены.");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class GeneralSettingsViewModel
    {
        // Здесь содержатся общие настройки приложения
    }

    public class PersonalSettingsViewModel
    {
        // Здесь содержатся персональные настройки пользователя
    }

    public class RelayCommand : ICommand
    {
        private Action _action;

        public RelayCommand(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public event EventHandler CanExecuteChanged;
    }
}
