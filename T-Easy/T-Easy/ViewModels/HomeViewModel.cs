using T_Easy.Helper;
using T_Easy.Utils;

namespace T_Easy.ViewModels
{
    public class HomeViewModel : ObservableObject, IPageViewModel
    {
        public string Icon { get; } = "HomeAccount";
        public string Visible { get; } = "Visible ";

        public string Name
        {
            get
            {
                return TravelHelper.Instance.Travel.Name; 
            }
        }

        public string SharingCode
        {
            get
            {
                return TravelHelper.Instance.Travel.SharingCode;
            }
        }
    }
}
