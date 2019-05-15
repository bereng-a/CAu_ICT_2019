using System.ComponentModel;
using T_Easy.Models;

namespace T_Easy.ViewModels
{
    public class TravelViewModel : INotifyPropertyChanged
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
                return _travel.SharingCode;
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
