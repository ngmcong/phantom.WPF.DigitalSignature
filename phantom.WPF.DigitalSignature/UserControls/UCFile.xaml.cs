using System.Diagnostics;
using System.Windows.Controls;
using DigitalSignature.DataEntities;

namespace DigitalSignature
{
    /// <summary>
    /// Interaction logic for UCFile.xaml
    /// </summary>
    public partial class UCFile : UserControl
    {
        public UCFileModel CurrentContext = new UCFileModel();
        public UCFile(DigitalFile digitalFile)
        {
            InitializeComponent();
            this.DataContext = CurrentContext;
            CurrentContext.DigitalFile = digitalFile;
        }

        private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await WebBrowser.EnsureCoreWebView2Async();
            WebBrowser.Source = new System.Uri(@"E:\Downloads\Permanently Keep Current OS Version using Group Policy - Copy.pdf");
        }

        private void OpenFile_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo("E:\\Downloads\\Permanently Keep Current OS Version using Group Policy.docx")
            {
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void SignFile_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }

    public class UCFileModel : ModelBase
    {
        private DigitalFile? _digitalFile;
        public DigitalFile? DigitalFile
        {
            get { return _digitalFile; }
            set
            {
                if (_digitalFile != value)
                {
                    _digitalFile = value;
                    OnPropertyChanged(nameof(DigitalFile));
                }
            }
        }
    }
}
