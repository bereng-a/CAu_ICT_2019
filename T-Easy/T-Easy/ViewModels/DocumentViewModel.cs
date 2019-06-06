using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using T_Easy.Helper;
using T_Easy.Models;
using T_Easy.Utils;

namespace T_Easy.ViewModels
{
    class DocumentViewModel : ObservableObject, IPageViewModel
    {
        public string Icon { get; } = "HomeAccount";

        public string Name { get; } = "Document Manager";

        public User User { get; set; }
        public DocumentType Type { get; set; }
        public string Path { get; set; }
        public int? EventId { get; set; }

        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Document> Documents { get; set; }
        public ObservableCollection<DocumentType> Types { get; set; }

        public DocumentViewModel()
        {
            GetData();
            GetUsers();
            GetTypes();
        }

        private async void GetData()
        {
            Models.DataContext context = new Models.DataContext();
            var docs = await context.Document.Where(x => x.TravelId == TravelHelper.Instance.Travel.Id)
                                             .Include(x => x.User)
                                             .Include(x => x.Type)
                                             .ToListAsync();
            Documents = new ObservableCollection<Document>(docs);
        }

        private async void GetUsers()
        {
            Models.DataContext context = new Models.DataContext();
            var tmp = await context.User.Where(x => x.TravelId == TravelHelper.Instance.Travel.Id).ToListAsync();
            Users = new ObservableCollection<User>(tmp);
        }

        private async void GetTypes()
        {
            Models.DataContext context = new Models.DataContext();
            var tmp = await context.DocumentType.ToListAsync();
            Types = new ObservableCollection<DocumentType>(tmp);
        }

        public async void CreateDocument()
        {
            Models.DataContext context = new Models.DataContext();
            await context.Document.AddAsync(new Document { UserId = User.Id, TypeId = Type.Id, TravelId = TravelHelper.Instance.Travel.Id, Path = Path, EventId = EventId });
            await context.SaveChangesAsync();
            GetData();
            OnPropertyChanged("Documents");
        }

        public async void DeleteDocument(int id)
        {
            Models.DataContext context = new Models.DataContext();
            Document tmp = new Document { Id = id };
            context.Document.Remove(tmp);
            await context.SaveChangesAsync();
            GetData();
            OnPropertyChanged("Documents");
        }
    }
}
