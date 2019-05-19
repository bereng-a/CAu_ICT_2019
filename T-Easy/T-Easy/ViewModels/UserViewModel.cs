using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using T_Easy.Helper;
using T_Easy.Models;
using T_Easy.Utils;

namespace T_Easy.ViewModels
{
    public class UserViewModel : ObservableObject, IPageViewModel, INotifyPropertyChanged
    {
        public string Icon { get; set; } = "Users";
        private readonly ObservableCollection<User> _users;
        public ObservableCollection<User> Users => _users;

        public UserViewModel()
        {
                _users = CreateData();
        }

        private ObservableCollection<User> CreateData()
        {
            Models.DataContext context = new Models.DataContext();
            var user = context.User.Where(x => x.TravelId == TravelHelper.Instance.Travel.Id).ToList();
            return new ObservableCollection<User>(user);
        }

    }
}
