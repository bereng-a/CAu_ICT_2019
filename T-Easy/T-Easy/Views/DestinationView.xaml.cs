using MaterialDesignThemes.Wpf;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        private int CurrentDestination;
        
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
                if (DateTo && DateFrom)
                {
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
            DateFrom = true;
            _viewModel.UpdateFromDate(NewFrom.Text);
            if (DateTo && CheckAddress)
                AddButton.IsEnabled = true;
        }

        private void DatePicker_SelectedDateChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DateTo = true;
            _viewModel.UpdateToDate(NewTo.Text);
            if (DateFrom && CheckAddress)
                AddButton.IsEnabled = true;
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddDestination();
            DestinationDialog.IsOpen = false;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Cancel_Event_Click(object sender, RoutedEventArgs e)
        {
            NewEventCost.Text = "";
            NewEventDate.Text = "";
            NewEventTime.Text = "";
            NewEventTypes.Text = "";
            NewEventName.Text = "";
            NewEventDescription.Text = "";
        }

        private void Add_Event_In_Destination_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            CurrentDestination = (int)button.Tag;
            Console.WriteLine("Destination id : " + CurrentDestination);
        }

        private void Add_Event_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddEvent(CurrentDestination);
            EventDialog.IsOpen = false;
        }

        private void NewEventDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.UpdateEventDate(NewEventDate.Text);
        }

        private void NewEventTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            _viewModel.UpdateEventTime(NewEventTime.Text);
        }
    }
}
