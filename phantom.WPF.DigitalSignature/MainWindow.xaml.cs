using System.Windows;
using System.Windows.Controls;
using DigitalSignature.DataEntities;
using phantom.WPF.DigitalSignature;

namespace DigitalSignature
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel CurrentContext = new MainWindowViewModel();

        public MainWindow()
        {
            InitializeComponent();
            Globals.MainWindow = this;
            this.DataContext = CurrentContext;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentContext.MainContentControl = new UCLogin();
        }
    }

    public class MainWindowViewModel : ModelBase
    {
        private UserControl? _mainContentControl;
        public UserControl? MainContentControl
        {
            get { return _mainContentControl; }
            set
            {
                if (_mainContentControl != value)
                {
                    _mainContentControl = value;
                    OnPropertyChanged(nameof(MainContentControl));
                }
            }
        }
    }
}