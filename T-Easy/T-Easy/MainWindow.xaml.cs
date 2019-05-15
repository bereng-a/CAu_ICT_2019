using System.Windows;
using T_Easy.ViewModels;

namespace T_Easy
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TravelViewModel _travelViewModel = new TravelViewModel();

        public MainWindow()
        {
            InitializeComponent();
            base.DataContext = _travelViewModel;
        }
    }
}
