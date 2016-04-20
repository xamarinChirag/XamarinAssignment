using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinAssignment.Model;
namespace XamarinAssignment.ServiceClient
{
    /// <summary>
    /// Property manager contract
    /// </summary>
    public interface IPropertyMangager
    {
        #region Methods
       
        /// <summary>
        /// GetItems for property
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="forceRefresh"></param>
        /// <returns></returns>
        Task<List<Property>> GetItemsAsync(int skip = 0, int take = 100, bool forceRefresh = false);

        /// <summary>
        /// GetItem property detail item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PropertyDetail> GetItemAsync(string id);

        /// <summary>
        /// Get the image byte array from the url
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<byte[]> GetImageAsync(string name);

        #endregion
    }
}
