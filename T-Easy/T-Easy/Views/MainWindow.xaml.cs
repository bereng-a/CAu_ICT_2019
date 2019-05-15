using System.Windows;
using T_Easy.ViewModels;

namespace T_Easy
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel _viewModel = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            base.DataContext = _viewModel;
        }
    }
}
