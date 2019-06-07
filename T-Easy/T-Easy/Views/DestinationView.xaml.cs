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
        
        // Variables to check if all fields for add a destination are filled
        private bool DateFrom = false;
        private bool DateTo = false;
        private bool CheckAddress = false;

        // Variables to check if all fields for add an event are filled
        private bool EventDate = false;
        private bool EventTime = false;
        private bool EventName = false;
        private bool EventType = false;
        private bool EventDescription = false;

        private int CurrentDestination; // To associate a new event with the correspondant destination
        
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
            NewEventCost.Text = "0";
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
        }

        private void Add_Event_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddEvent(CurrentDestination);
            EventDialog.IsOpen = false;
            NewEventCost.Text = "0";
            NewEventDate.Text = "";
            NewEventTime.Text = "";
            NewEventTypes.Text = "";
            NewEventName.Text = "";
            NewEventDescription.Text = "";
        }

        private void UpdateAddEventButton()
        {
            if (EventDate && EventDescription && EventType && EventName && EventTime)
            {
                AddEventButton.IsEnabled = true;
            }
            else
            {
                AddEventButton.IsEnabled = false;
            }
        }

        private void NewEventDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NewEventDate.Text != null && NewEventDate.Text.Length > 0)
            {
                EventDate = true;
                _viewModel.UpdateEventDate(NewEventDate.Text);
            }
            else
            {
                EventDate = false;
            }
            UpdateAddEventButton();
        }

        private void NewEventTime_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            if (NewEventTime.Text != null && NewEventTime.Text.Length > 0)
            {
                EventTime = true;
                _viewModel.UpdateEventTime(NewEventTime.Text);
            }
            else
            {
                EventTime = false;
            }
            UpdateAddEventButton();
        }

        private void NewEventName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NewEventName.Text.Length > 0)
                EventName = true;
            else
                EventName = false;
            UpdateAddEventButton();
        }

        private void NewEventTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EventType = true;
            UpdateAddEventButton();
        }

        private void NewEventDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NewEventDescription.Text.Length > 0)
                EventDescription = true;
            else
                EventDescription = false;
            UpdateAddEventButton();
        }

        private void DeleteDestinationButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            _viewModel.DeleteDestination((int)button.Tag);
        }

        private void DeleteEventButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            _viewModel.DeleteEvent((int)button.Tag);
        }
    }
}
