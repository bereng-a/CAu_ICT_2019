using System.Windows.Controls;
using T_Easy.ViewModels;

namespace T_Easy.Views
{
    /// <summary>
    /// Logique d'interaction pour UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        UserViewModel _viewModel = new UserViewModel();

        public UserView()
        {
            InitializeComponent();
            base.DataContext = _viewModel;
        }

    }
}
