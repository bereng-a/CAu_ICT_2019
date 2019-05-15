using System.Windows;
using T_Easy.ViewModels;

namespace T_Easy
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        TravelViewModel _travelViewModel = new TravelViewModel();

        public LoginWindow()
        {
            InitializeComponent();
            base.DataContext = _travelViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            App.Current.MainWindow = main;
            this.Close();
            main.Show();
        }

        private void Join_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            App.Current.MainWindow = main;
            this.Close();
            main.Show();
        }
    }
}
