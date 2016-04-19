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
    public class OfflinePropertyMangager : IPropertyMangager
    {

        public async Task<List<Property>> GetItemsAsync(int skip = 0, int take = 100, bool forceRefresh = false)
        {
            List<Property> listings = new List<Property>();

            try
            {
                var repository = Mvx.GetSingleton<PropertyRepository>();
                listings = await repository.RetrieveAllProperties();
            }
            catch (Exception ex)
            {
                throw;
            }
            return listings;
        }

        public async Task<PropertyDetail> GetItemAsync(string id)
        {
            PropertyDetail listingDetail = new PropertyDetail();
            try
            {
                var repository = Mvx.GetSingleton<PropertyRepository>();
                listingDetail = await repository.GetPropertyDetailById(Convert.ToInt32(id));
            }
            catch (Exception ex)
            {
                throw;
            }
            return listingDetail;
        }

        
        public async Task<byte[]> GetImageAsync(string name)
        {
            byte[] imageBytes = null;
            //var uri = new Uri(Constants.strRestUrl + name);
            //using (var client = new HttpClient(new NativeMessageHandler()))
            //{
            //    //client.BaseAddress = new Uri(Constants.strRestUrl);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    //var task = Task.Run(async () => { imageBytes = await client.GetByteArrayAsync(uri); });
            //    //task.Wait();
            //    imageBytes = await client.GetByteArrayAsync(uri).ConfigureAwait(false);
            //}
            return imageBytes;
        }


    }
}
