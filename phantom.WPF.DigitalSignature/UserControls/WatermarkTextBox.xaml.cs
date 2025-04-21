using System.ComponentModel;
using System.Windows.Controls;

namespace phantom.WPF.DigitalSignature
{
    /// <summary>
    /// Interaction logic for WatermarkTextBox.xaml
    /// </summary>
    public partial class WatermarkTextBox : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        internal void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string watermarkText = "Place Holder Text";
        public string PlaceHolderText
        {
            get => watermarkText;
            set
            {
                watermarkText = value;
                OnPropertyChanged(nameof(PlaceHolderText));
            }
        }

        public WatermarkTextBox()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
