using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using DigitalSignature.DataEntities;

namespace DigitalSignature
{
    /// <summary>
    /// Interaction logic for UCFileList.xaml
    /// </summary>
    public partial class UCFileList : UserControl
    {
        public UCFileListModel CurrentContext = new UCFileListModel();

        public UCFileList()
        {
            InitializeComponent();
            this.DataContext = CurrentContext;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentContext.Files = new ObservableCollection<DigitalFile>(
                new List<DigitalFile>
                {
                    new DigitalFile { FileName = "Document1.docx", FileSize = 25000, LastModified = DateTime.Now },
                    new DigitalFile { FileName = "Document2.docx", FileSize = 25000, LastModified = DateTime.Now },
                    new DigitalFile { FileName = "Document3.docx", FileSize = 25000, LastModified = DateTime.Now }
                }
            );
        }

        private void FileListView_MouseDoubleClicked(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender is System.Windows.Controls.ListView listView && listView.SelectedItem is DigitalFile selectedFile)
            {
                Globals.MainWindow!.CurrentContext.MainContentControl = new UCFile(selectedFile);
            }
        }
    }

    public class UCFileListModel : ModelBase
    {
        private ObservableCollection<DigitalFile>? _files;
        public ObservableCollection<DigitalFile>? Files
        {
            get { return _files; }
            set
            {
                if (_files != value)
                {
                    _files = value;
                    OnPropertyChanged(nameof(Files));
                }
            }
        }
    }
}
