using Google.Maps;
using Google.Maps.Geocoding;
using Google.Maps.StaticMaps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media.Imaging;
using T_Easy.Models;

namespace T_Easy.Helper
{
    public class DestinationHelper
    {
        #region Members
        private static readonly DestinationHelper _instance = new DestinationHelper();
        private ObservableCollection<Destination> _destinations;
        private ObservableCollection<EventType> _eventTypes;
        private const string API_KEY = "AIzaSyActMHNUddNilt6hRqmgiG3AJLBxEuFTCM";
        #endregion

        #region Construction
        static DestinationHelper()
        {

        }

        private DestinationHelper()
        {
            Models.DataContext context = new Models.DataContext();
            var destinations = context.Destination.Where(x => x.TravelId == TravelHelper.Instance.Travel.Id).Include(x => x.Event).ToList();
            _destinations = new ObservableCollection<Destination>(destinations);
            var eventTypes = context.EventType.ToList();
            _eventTypes = new ObservableCollection<EventType>(eventTypes);
        }
        #endregion

        #region Properties
        public static DestinationHelper Instance
        {
            get
            {
                return _instance;
            }
        }

        public ObservableCollection<Destination> Destinations
        {
            get
            {
                return _destinations;
            }
        }

        public ObservableCollection<EventType> EventTypes
        {
            get
            {
                return _eventTypes;
            }
        }
        #endregion

        public bool CheckAddress(ref string address)
        {
            GoogleSigned.AssignAllServices(new GoogleSigned(API_KEY));

            var request = new GeocodingRequest();
            request.Address = address;
            var response = new GeocodingService().GetResponse(request);

            if (response.Status == ServiceResponseStatus.Ok && response.Results.Count() > 0)
            {
                var result = response.Results.First();
                address = result.FormattedAddress;
                Console.WriteLine(result.FormattedAddress);
                return true;
            }
            else
            {
                return false;
            }
        }

        public BitmapImage GenerateMap(string address)
        {
            GoogleSigned.AssignAllServices(new GoogleSigned(API_KEY));
            var map = new StaticMapRequest();
            map.Center = new Location(address);
            map.Size = new System.Drawing.Size(400, 400);
            map.Zoom = 14;

            StaticMapService staticMapService = new StaticMapService();
            BitmapImage img = new BitmapImage();
            img.StreamSource = staticMapService.GetStream(map);
            return img;
        }

        public void AddDestination(Destination destination)
        {
            destination.TravelId = TravelHelper.Instance.Travel.Id;
            Models.DataContext context = new Models.DataContext();
            var newDestination = context.Destination.Add(destination);
            context.SaveChanges();
            _destinations.Add(newDestination.Entity);
        }

        public void DeleteDestination(int id)
        {
            Models.DataContext context = new Models.DataContext();
            Destination tmp = new Destination { Id = id };
            context.Destination.Remove(tmp);
            context.SaveChanges();
            _destinations.Remove(_destinations.Where(d => d.Id == id).Single());
        }

        public void AddEvent(Event newEvent, EventType type)
        {
            Models.DataContext context = new Models.DataContext();
            var eventInDb = context.Event.Add(newEvent);
            context.SaveChanges();
            newEvent.Id = eventInDb.Entity.Id;
            newEvent.Type = type;
            _destinations.Where(d => d.Id == newEvent.DestinationId).First().Event.Add(newEvent);
        }

        public void DeleteEvent(int idEvent)
        {
            Models.DataContext context = new Models.DataContext();
            Event tmp = new Event { Id = idEvent };
            context.Event.Remove(tmp);
            context.SaveChanges();

            Event currentEvent = null;
            foreach (var destination in _destinations)
            {
                foreach (var evt in destination.Event)
                {
                    if (evt.Id == idEvent)
                    {
                        currentEvent = evt;
                        break;
                    }
                }
            }
            if (currentEvent != null) {
                _destinations.Where(d => d.Id == currentEvent.DestinationId).First().Event.Remove(currentEvent);
            }
        }
    }
}
