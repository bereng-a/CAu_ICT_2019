using System;
using System.Diagnostics;
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

        public TransactionsView()
        {
            InitializeComponent();
            base.DataContext = _viewModel;
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.createTransaction();
            DestinationDialog.IsOpen = false;
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            int id = Int32.Parse(((Button)sender).Tag.ToString());
            _viewModel.DeleteTransaction(id);
        }
    }
}
