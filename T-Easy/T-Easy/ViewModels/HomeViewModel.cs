﻿using T_Easy.Utils;

namespace T_Easy.ViewModels
{
    public class HomeViewModel : ObservableObject, IPageViewModel
    {
        public string Icon { get; } = "HomeAccount";
    }
}
