using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
            getData();
        }

        private async void getData()
        {
            Models.DataContext context = new Models.DataContext();
            var user = await context.User.Where(x => x.TravelId == TravelHelper.Instance.Travel.Id).ToListAsync();
            Users = new ObservableCollection<User>(user);
        }

        public async void CreateUser()
        {
            Models.DataContext context = new Models.DataContext();
            await context.User.AddAsync(new User { FamilyName = FamilyName, Name = Name, TravelId = TravelHelper.Instance.Travel.Id });
            await context.SaveChangesAsync();
        }

    }
}
