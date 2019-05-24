using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using T_Easy.ViewModels;

namespace T_Easy.Views
{
    /// <summary>
    /// Logique d'interaction pour DestinationView.xaml
    /// </summary>
    public partial class DestinationView : UserControl
    {
        DestinationViewModel _viewModel = new DestinationViewModel();
        private bool DateFrom = false;
        private bool DateTo = false;
        private bool CheckAddress = false;
        
        public DestinationView()
        {
            InitializeComponent();
            base.DataContext = _viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.CheckPlace(DestinationTextBox.Text))
            {
                CheckAddress = true;
                Console.WriteLine("DateTo " + DateTo + " DateFrom " + DateFrom);
                if (DateTo && DateFrom)
                {
                    Console.WriteLine("ENABLEEEE");
                    AddButton.IsEnabled = true;
                }
            }
            else
            {
                CheckAddress = false;
            }
        }

        private void DestinationTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DestinationTextBox.Text.Length > 0)
            {
                CheckAddressButton.IsEnabled = true;
            }
            else
            {
                CheckAddressButton.IsEnabled = false;
            }
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("CHANNNGENNEEN");
            DateFrom = true;
            if (DateTo && CheckAddress)
                AddButton.IsEnabled = true;

        }

        private void DatePicker_SelectedDateChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("AAAAAAAAAAAA");
            DateTo = true;
            if (DateFrom && CheckAddress)
                AddButton.IsEnabled = true;
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddDestination();
            DestinationDialog.IsOpen = false;
        }
    }
}
