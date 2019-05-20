using System.Linq;
using System.Windows;
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
        MainWindow _mainWindow;

        public UserView()
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
            tmp.ChangeViewModel(tmp.PageViewModels[2]);
        }
    }
}
