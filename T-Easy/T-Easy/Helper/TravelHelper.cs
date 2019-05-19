using System;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using T_Easy.Models;

namespace T_Easy.Helper
{
    /// <summary>
    /// Class managing the current travel
    /// </summary>
    public sealed class TravelHelper
    {
        #region Members
        private static readonly TravelHelper _instance = new TravelHelper();
        private Travel _travel; 
        #endregion

        #region Construction
        static TravelHelper()
        {
        }

        private TravelHelper()
        {
        }
        #endregion

        #region Properties
        public static TravelHelper Instance
        {
            get
            {
                return _instance;
            }
        }

        public Travel Travel
        {
            get
            {
                return _travel;
            }
        }
        #endregion

        #region Methods
        public bool JoinTravel(string sharingCode)
        {
            Models.DataContext context = new Models.DataContext();
            try
            {
                var travel = context.Travel.Single(t => t.SharingCode == sharingCode);
                _travel = travel;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void CreateTravel(string name)
        {
            var createdAt = DateTime.Now;
            var sharingCode = GetHashString(createdAt.ToString());
            Models.DataContext context = new Models.DataContext();

            _travel = context.Travel.Add(new Travel { SharingCode = sharingCode, CreatedAt = createdAt, Name = name }).Entity;
            context.SaveChanges();
        }

        private static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        private static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
        #endregion
    }
}
