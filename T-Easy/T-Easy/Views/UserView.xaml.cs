using System;
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

        public UserView()
        {
            InitializeComponent();
            base.DataContext = _viewModel;
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CreateUser();
            ClearFields();
            DestinationDialog.IsOpen = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           _viewModel.DeleteUser(Int32.Parse(((Button)sender).Tag.ToString()));
        }

        private void NameField_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAddButton();
        }

        private void FamilyNameField_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAddButton();
        }

        private void UpdateAddButton()
        {
            if (NameField.Text.Length > 0 && FamilyNameField.Text.Length > 0)
            {
                AddButton.IsEnabled = true;
            }
        }

        private void ClearFields()
        {
            NameField.Text = "";
            FamilyNameField.Text = "";
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }
    }
}
