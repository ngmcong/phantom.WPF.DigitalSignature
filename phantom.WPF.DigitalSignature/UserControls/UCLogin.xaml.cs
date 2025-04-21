using System.Windows.Controls;
using DigitalSignature;

namespace phantom.WPF.DigitalSignature
{
    /// <summary>
    /// Interaction logic for UCLogin.xaml
    /// </summary>
    public partial class UCLogin : UserControl
    {
        public UCLogin()
        {
            InitializeComponent();
        }

        private void LoginButton_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {
            Globals.MainWindow!.CurrentContext.MainContentControl = new UCFileList();
        }
    }
}
