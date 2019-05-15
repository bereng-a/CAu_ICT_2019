using System.Windows.Controls;
using T_Easy.ViewModels;

namespace T_Easy.Views
{
    /// <summary>
    /// Logique d'interaction pour HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        HomeViewModel _viewModel = new HomeViewModel();

        public HomeView()
        {
            InitializeComponent();
            base.DataContext = _viewModel;
        }
    }
}
