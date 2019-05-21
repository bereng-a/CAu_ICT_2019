using System.Windows.Controls;
using T_Easy.ViewModels;

namespace T_Easy.Views
{
    public partial class TransactionAddView : UserControl
    {
        TransactionsViewModel _viewModel = new TransactionsViewModel();
        public TransactionAddView()
        {
            InitializeComponent();
            base.DataContext = _viewModel;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _viewModel.createTransaction();
        }
    }
}
