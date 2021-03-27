using System.Windows;
using AnimalPark.ViewModel;

namespace AnimalPark
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ((MainViewModel) (this.DataContext)).ErrorMessageDelegate += s => MessageBox.Show(s);
        }
    }
}
