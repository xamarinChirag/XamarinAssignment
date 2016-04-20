using Cirrious.CrossCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XamarinAssignment.Infrastructure.CrossCuttings;
using XamarinAssignment.Model;

namespace XamarinAssignment.ServiceClient
{
    /// <summary>
    /// Offline property Manager for handling the offiline mode
    /// </summary>
    public class OfflinePropertyMangager : IPropertyMangager
    {
        #region Methods

        /// <summary>
        /// Get the items from teh sqllite db
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="forceRefresh"></param>
        /// <returns></returns>
        public async Task<List<Property>> GetItemsAsync(int skip = 0, int take = 100, bool forceRefresh = false)
        {
            List<Property> listings = new List<Property>();

            try
            {
                var propertyRepository = Mvx.GetSingleton<PropertyRepository>();
                listings = await propertyRepository.RetrieveAllProperties();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listings;
        }

        /// <summary>
        /// Get property detail by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PropertyDetail> GetItemAsync(string id)
        {
            PropertyDetail propertyDetail = new PropertyDetail();
            try
            {
                var propertyRepository = Mvx.GetSingleton<PropertyRepository>();
                propertyDetail = await propertyRepository.GetPropertyDetailById(Convert.ToInt32(id));
            }
            catch (Exception ex)
            {
                throw;
            }
            return propertyDetail;
        }

        /// <summary>
        /// Images are taken form the local storage so returning the null byte array.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<byte[]> GetImageAsync(string name)
        {
            byte[] imageBytes = null;
            return imageBytes;
        }

        #endregion

    }
}
