using T_Easy.Utils;

namespace T_Easy.ViewModels
{
    class UserAddViewModel : ObservableObject, IPageViewModel
    {
        public string Icon { get; set; } = "AccountMultiplePlus";
        public string Visible { get; } = "Collapsed";
    }
}
