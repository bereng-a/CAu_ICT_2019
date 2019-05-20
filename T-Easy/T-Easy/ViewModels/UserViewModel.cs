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
        public string Visible { get; } = "Visible ";

        public ObservableCollection<User> Users { get; set; }
        public string FamilyName { get; set; }
        public string Name { get; set; }

        public UserViewModel()
        {
                Users = getData();
        }

        private ObservableCollection<User> getData()
        {
            Models.DataContext context = new Models.DataContext();
            var user = context.User.Where(x => x.TravelId == TravelHelper.Instance.Travel.Id).ToList();
            return new ObservableCollection<User>(user);
        }

        public void CreateUser()
        {
            Models.DataContext context = new Models.DataContext();
            context.User.Add(new User { FamilyName = FamilyName, Name = Name, TravelId = TravelHelper.Instance.Travel.Id });
            context.SaveChanges();
        }

    }
}
