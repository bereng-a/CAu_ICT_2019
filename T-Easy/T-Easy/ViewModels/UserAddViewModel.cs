using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T_Easy.Utils;

namespace T_Easy.ViewModels
{
    class UserAddViewModel : ObservableObject, IPageViewModel, INotifyPropertyChanged
    {
        public string Icon { get; set; } = "AccountMultiplePlus";
        public string Visible { get; } = "Collapsed";
    }
}
