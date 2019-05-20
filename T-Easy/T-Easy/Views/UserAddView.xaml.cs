using System.Windows.Controls;
using T_Easy.ViewModels;

namespace T_Easy.Views
{
    public partial class UserAddView : UserControl
    {
        UserViewModel _viewModel = new UserViewModel();
        public UserAddView()
        {
            InitializeComponent();
            base.DataContext = _viewModel;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _viewModel.CreateUser();
        }
    }
}
