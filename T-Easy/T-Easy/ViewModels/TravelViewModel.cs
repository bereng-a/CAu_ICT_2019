using T_Easy.Helper;
using T_Easy.Utils;

namespace T_Easy.ViewModels
{
    public class TravelViewModel : ObservableObject
    {
        #region Construction
        public TravelViewModel()
        {
          
        }
        #endregion


        #region Properties
        public string SharingCode { get; set; }

        public string Name { get; set; }
        #endregion


        #region Methods
        public bool Create()
        {
            TravelHelper.Instance.CreateTravel(Name);
            return true;
        }

        public bool Join()
        {
            if (TravelHelper.Instance.JoinTravel(SharingCode))
                return true;
            else
                return false;
        }
        #endregion
    }
}
