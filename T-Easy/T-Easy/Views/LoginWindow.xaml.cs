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
            if (_travelViewModel.Create())
            {
                SwitchToMain();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("An error occured, please try again later.",
                                          "Error",
                                          MessageBoxButton.OK);
            }
        }

        private void Join_Button_Click(object sender, RoutedEventArgs e)
        {
            if (_travelViewModel.Join())
            {
                SwitchToMain();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("An error occured, please try again later.",
                                          "Error",
                                          MessageBoxButton.OK);
            }
        }

        private void SwitchToMain()
        {
            MainWindow main = new MainWindow();
            App.Current.MainWindow = main;
            this.Close();
            main.Show();
        }

        private void SharingCodeTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (SharingCodeTextBox.Text.Length > 0)
            {
                Join_Button.IsEnabled = true;
            }
            else
            {
                Join_Button.IsEnabled = false;
            }
        }

        private void CreateTravelTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (CreateTravelTextBox.Text.Length > 0)
            {
                Create_Button.IsEnabled = true;
            }
            else
            {
                Create_Button.IsEnabled = false;
            }
        }
    }
}
