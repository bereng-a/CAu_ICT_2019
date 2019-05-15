using System.ComponentModel;
using System.Linq;
using T_Easy.Models;
using T_Easy.Utils;

namespace T_Easy.ViewModels
{
    public class TravelViewModel : ObservableObject
    {
        #region Construction
        public TravelViewModel()
        {
            _travel = new Travel { Name = null, SharingCode = null };
        }
        #endregion

        #region Members
        Travel _travel;
        #endregion

        #region Properties
        public Travel Travel
        {
            get
            {
                return _travel;
            }
            set
            {
                _travel = value;
            }
        }

        public string SharingCode
        {
            get
            {
                Models.DataContext context = new Models.DataContext();
                var user = context.User.First();
                return user.FamilyName;
            }
            set
            {
                _travel.SharingCode = value;
            }
        }

        public string Name
        {
            get
            {
                return _travel.Name;
            }
            set
            {
                _travel.Name = value;
            }
        }
        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
