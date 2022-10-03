using System.ComponentModel;
using System.Windows;
using LoginCTEDS.Database;

namespace LoginCTEDS
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private DatabaseService databaseService = new DatabaseService();

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private Visibility _isRectangleVisible = Visibility.Collapsed;
        public Visibility IsRectangleVisible
        {
            get
            {
                return _isRectangleVisible;
            }
            set
            {
                _isRectangleVisible = value;
                OnPropertyChanged(nameof(IsRectangleVisible));
            }
        }
        private Visibility _isSuccessTextVisible = Visibility.Collapsed;
        public Visibility IsSuccessTextVisible
        {
            get
            {
                return _isSuccessTextVisible;
            }
            set
            {
                _isSuccessTextVisible = value;
                OnPropertyChanged(nameof(IsSuccessTextVisible));
            }
        }
        private Visibility _isFailTextVisible = Visibility.Collapsed;
        public Visibility IsFailTextVisible
        {
            get
            {
                return _isFailTextVisible;
            }
            set
            {
                _isFailTextVisible = value;
                OnPropertyChanged(nameof(IsFailTextVisible));
            }
        }
        public string InputUsername { set; get; } = string.Empty;
        public string InputPassword { set; get; } = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            IsRectangleVisible = Visibility.Visible;
            bool isValid = databaseService.AreCrendentialsValid(InputUsername, InputPassword);
            IsSuccessTextVisible = isValid ? Visibility.Visible : Visibility.Collapsed;
            IsFailTextVisible = isValid ? Visibility.Collapsed : Visibility.Visible;
        }

        private void ClosePopup(object sender, RoutedEventArgs e)
        {
            IsRectangleVisible = Visibility.Collapsed;
            IsSuccessTextVisible = Visibility.Collapsed;
            IsFailTextVisible = Visibility.Collapsed;
        }
    }
}
