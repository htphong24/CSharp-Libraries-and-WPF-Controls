using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace WizardProgressBarDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();

            Steps = new ObservableCollection<string>
            {
                "WELCOME",
                "PROFILE",
                "CREDENTIALS",
                "GROUPS",
                "FINISHED"
            };

            DataContext = this;
        }

        private int m_progress;

        public int Progress
        {
            get => m_progress;
            set
            {
                m_progress = value;
                OnPropertyChanged("Progress");
            }
        }

        public ObservableCollection<string> Steps
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (Progress == Steps.Count)
                return;

            Progress++;
        }

        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (Progress == 0)
                return;

            Progress--;
        }
    }
}
