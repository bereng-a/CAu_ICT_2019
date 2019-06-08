using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using T_Easy.Helper;
using T_Easy.Models;
using T_Easy.Utils;

namespace T_Easy.ViewModels
{
    class TransactionViewModel : ObservableObject, IPageViewModel, INotifyPropertyChanged
    {
        #region Construction
        public TransactionViewModel()
        {
            Transactions = getTransaction();
            Users = getUsers();
            Events = getEvents();
        }
        #endregion

        #region Properties

        public string Icon { get; set; } = "BankTransfer";
        public string Visible { get; } = "Visible ";

        public ObservableCollection<Transaction> Transactions { get; set; }
        public User TransactionUser { get; set; }
        public Event TransactionEvent { get; set; }
        public int TransactionCost { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Event> Events { get; set; }

        #endregion

        #region Methods
        /// <summary>
        /// Get all the transactions
        /// </summary>
        /// <returns>
        /// Return the transactions in ObservableCollection
        /// </returns>
        private ObservableCollection<Transaction> getTransaction()
        {
            Models.DataContext context = new Models.DataContext();
            var transactions = context.Transaction.Where(x => x.User.TravelId == TravelHelper.Instance.Travel.Id).Include(x => x.User).Include(x => x.Event).ToList();
            return new ObservableCollection<Transaction>(transactions);
        }

        /// <summary>
        /// Get alll Users
        /// </summary>
        /// <returns>
        /// Return the users in ObservableCollection
        /// </returns>
        private ObservableCollection<User> getUsers()
        {
            Models.DataContext context = new Models.DataContext();
            var user = context.User.Where(x => x.TravelId == TravelHelper.Instance.Travel.Id).ToList();
            return new ObservableCollection<User>(user);
        }


        private ObservableCollection<Event> getEvents()
        {
            Models.DataContext context = new Models.DataContext();
            var events = context.Event.Where(x => x.Destination.TravelId == TravelHelper.Instance.Travel.Id).ToList();
            return new ObservableCollection<Event>(events);
        }


        /// <summary>
        /// Create a transaction
        /// </summary>
        public void createTransaction()
        {
            Models.DataContext context = new Models.DataContext();
            context.Transaction.Add(new Transaction { EventId = TransactionEvent.Id, UserId = TransactionUser.Id, Cost = TransactionCost, CreatedAt = System.DateTime.Now});
            context.SaveChanges();
        }

        public async void DeleteTransaction(int id)
        {
            Models.DataContext context = new Models.DataContext();
            Transaction tmp = new Transaction { Id = id };
            context.Transaction.Remove(tmp);
            await context.SaveChangesAsync();
            getTransaction();
            OnPropertyChanged("Transactions");
        }

        #endregion
    }
}
