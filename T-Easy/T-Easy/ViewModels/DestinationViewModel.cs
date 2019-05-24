﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        #endregion

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

        public void AddDestination()
        {
            DestinationHelper.Instance.AddDestination();
            Destinations = DestinationHelper.Instance.Destinations;
            OnPropertyChanged("Destinations");
        }
        #endregion
    }
}