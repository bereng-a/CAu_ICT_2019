using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T_Easy.Utils;
namespace T_Easy.ViewModels
{
	public class TransactionAddViewModel : ObservableObject, IPageViewModel, INotifyPropertyChanged
    {
        public string Icon { get; set; } = "TrolleyPlus";
        public string Visible { get; } = "Collapsed";
    }
}