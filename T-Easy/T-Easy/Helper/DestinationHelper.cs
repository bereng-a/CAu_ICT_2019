using Google.Maps;
using Google.Maps.Geocoding;
using Google.Maps.StaticMaps;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using T_Easy.Models;

namespace T_Easy.Helper
{
    public class DestinationHelper
    {
        #region Members
        private static readonly DestinationHelper _instance = new DestinationHelper();
        private ObservableCollection<Destination> _destinations;
        private const string API_KEY = "AIzaSyActMHNUddNilt6hRqmgiG3AJLBxEuFTCM";
        #endregion

        #region Construction
        static DestinationHelper()
        {
        }

        private DestinationHelper
()
        {
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

        public void AddDestination()
        {

        }
    }
}
