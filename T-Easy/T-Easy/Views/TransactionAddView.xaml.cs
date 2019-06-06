using System.Windows;
using System.Windows.Controls;
using T_Easy.ViewModels;

namespace T_Easy.Views
{
    public partial class TransactionAddView : UserControl
    {
        TransactionViewModel _viewModel = new TransactionViewModel();
        MainWindow _mainWindow;

        public TransactionAddView()
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
            _viewModel.createTransaction();
            MainViewModel tmp = (MainViewModel)_mainWindow.DataContext;
            tmp.ChangeViewModel(tmp.PageViewModels[4]);
        }
    }
}
