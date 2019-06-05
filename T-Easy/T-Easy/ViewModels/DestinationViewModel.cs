using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using T_Easy.Helper;
using T_Easy.Models;
using T_Easy.Utils;

namespace T_Easy.ViewModels
{
    public class DestinationViewModel : ObservableObject, IPageViewModel
    {
        #region Properties
        public string Icon { get; } = "AeroplaneTakeoff";
        public DateTime NewDestinationFrom { get; set; } = DateTime.Now;
        public DateTime NewDestinationTo { get; set; } = DateTime.Now;
        public string Address { get; set; } = "";
        public BitmapImage Map { get; set; }
        public string Visible { get; } = "Visible ";
        public ObservableCollection<Destination> Destinations { get; set; }
        public ObservableCollection<EventType> EventTypes { get; }
        public EventType NewEventType { get; set; }
        public int NewEventCost { get; set; }
        public DateTime NewEventDate { get; set; }
        public DateTime NewEventTime { get; set; }
        public string NewEventName { get; set; }
        public string NewEventDescription { get; set; }
        #endregion

        public DestinationViewModel()
        {
            Destinations = DestinationHelper.Instance.Destinations;
            EventTypes = DestinationHelper.Instance.EventTypes;
        }

        #region Methods
        public bool CheckPlace(string address)
        {
            if (DestinationHelper.Instance.CheckAddress(ref address))
            {
                Console.WriteLine(address);
                Address = address;
                OnPropertyChanged("Address");

                //Map = _destinationHelper.GenerateMap(address);
                //OnPropertyChanged("Map");
                return true;
            }
            Address = "";
            OnPropertyChanged("Address");
            return false;
        }

        public void UpdateFromDate(string date)
        {
            if (date.Length > 0)
                NewDestinationFrom = Convert.ToDateTime(date);
        }

        public void UpdateToDate(string date)
        {
            if (date.Length > 0)
                NewDestinationTo = Convert.ToDateTime(date);
        }

        public void UpdateEventDate(string date)
        {
            if (date.Length > 0)
                NewEventDate = Convert.ToDateTime(date);
        }

        public void UpdateEventTime(string date)
        {
            if (date.Length > 0)
                NewEventTime = Convert.ToDateTime(date);
        }

        public void AddDestination()
        {
            DestinationHelper.Instance.AddDestination(new Destination { FromDate = NewDestinationFrom, ToDate = NewDestinationTo, Address = Address});
            Destinations = DestinationHelper.Instance.Destinations;
            OnPropertyChanged("Destinations");
        }

        public void AddEvent(int destinationId)
        {
            Console.WriteLine("Type " + NewEventType.Name);
            var date = new DateTime(NewEventDate.Year, NewEventDate.Month, NewEventDate.Day, NewEventTime.Hour, NewEventTime.Minute, 0);
            DestinationHelper.Instance.AddEvent(new Event { Cost = NewEventCost, DestinationId = destinationId, Name = NewEventName, FromDate = date, ToDate = date, TypeId = NewEventType.Id, Description = NewEventDescription });
            Destinations = DestinationHelper.Instance.Destinations;
            OnPropertyChanged("Destinations");
        }
        #endregion
    }
}
