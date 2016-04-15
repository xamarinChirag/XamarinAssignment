using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XamarinAssignment.Model;

namespace XamarinAssignment.ServiceClient
{
    public class PropertyMangager : IPropertyMangager
    {
        public async Task<List<Property>> GetItemsAsync(int skip = 0, int take = 100, bool forceRefresh = false)
        {
            List<Property> listings = new List<Property>();

            try
            {
                var uri = new Uri(Constants.strRestUrl + Constants.strListing);
                using (var client = CreateClient())
                {
                    
                    var response = await client.GetAsync(uri).ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                        listings = JsonConvert.DeserializeObject<List<Property>>(content);
                    }
                }
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


                var uri = new Uri(Constants.strRestUrl + string.Format(Constants.strListingById, id));
                using (var client = CreateClient())
                {
                    var response = await client.GetAsync(uri).ConfigureAwait(false); ;
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false); 

                        listingDetail = JsonConvert.DeserializeObject<PropertyDetail>(content);
                    }
                }
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
            var uri = new Uri(Constants.strRestUrl + name);
            using (var client = new HttpClient(new NativeMessageHandler()))
            {
                //client.BaseAddress = new Uri(Constants.strRestUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                //var task = Task.Run(async () => { imageBytes = await client.GetByteArrayAsync(uri); });
                //task.Wait();
                imageBytes = await client.GetByteArrayAsync(uri).ConfigureAwait(false);
            }
            return imageBytes;
        }


        /// <summary>
        /// Configure the Http client
        /// </summary>
        /// <param name="client"></param>
        /// 
        private HttpClient CreateClient()
        {
            var httpClient = new HttpClient(new NativeMessageHandler())
            {
                BaseAddress = new Uri(Constants.strRestUrl)
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }
       
    }
}
