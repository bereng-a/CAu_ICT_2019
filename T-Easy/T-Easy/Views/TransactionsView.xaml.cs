using System.Linq;
using System.Windows;
using System.Windows.Controls;
using T_Easy.ViewModels;

namespace T_Easy.Views
{
    /// <summary>
    /// Interaction logic for Transactions1.xaml
    /// </summary>
    public partial class TransactionsView : UserControl
    {
        TransactionViewModel _viewModel = new TransactionViewModel();
        MainWindow _mainWindow;

        public TransactionsView()
        {
            InitializeComponent();
            base.DataContext = _viewModel;
            this.Loaded += (s, e) =>
            {
                _mainWindow = Window.GetWindow(this) as MainWindow;
            };
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainViewModel tmp = (MainViewModel)_mainWindow.DataContext;
            tmp.ChangeViewModel(tmp.PageViewModels[5]);
        }
    }
}
