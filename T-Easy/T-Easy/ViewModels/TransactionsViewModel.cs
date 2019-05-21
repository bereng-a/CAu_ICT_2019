using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using T_Easy.Helper;
using T_Easy.Models;
using T_Easy.Utils;

namespace T_Easy.ViewModels
{
    class TransactionsViewModel : ObservableObject, IPageViewModel, INotifyPropertyChanged
    {
        #region Construction
        public TransactionsViewModel()
        {
            Transactions = getData();
        }
        #endregion

        #region Properties
        public string Icon { get; set; } = "BankTransfer";
        public string Visible { get; } = "Visible ";

        public ObservableCollection<Transaction> Transactions { get; set; }
        public string eventName { get; set; }


        #endregion

        #region Methods
        private ObservableCollection<Transaction> getData()
        {
            Models.DataContext context = new Models.DataContext();
            var transactions = context.Transaction.Where(x => x.User.TravelId == TravelHelper.Instance.Travel.Id).ToList();
            return new ObservableCollection<Transaction>(transactions);
        }

        public void createTransaction()
        {
            //Models.DataContext context = new Models.DataContext();
            //context.Transaction.Add(new Transaction { UserId =  });
            //context.SaveChanges();
        }

        
        #endregion
    }
}
