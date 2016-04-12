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
    public class ListingMangager : IListingMangager
    {
        public async Task<List<Listing>> GetItemsAsync(int skip = 0, int take = 100, bool forceRefresh = false)
        {
            List<Listing> listings = new List<Listing>();

            try
            {
                var uri = new Uri(Constants.strRestUrl + Constants.strListing);
                using (var client = new HttpClient())
                {
                    ConfigureHttpClient(client);
                    var response = await client.GetAsync(uri).ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                        listings = JsonConvert.DeserializeObject<List<Listing>>(content);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return listings;
        }

        public async Task<ListingDetail> GetItemAsync(string id)
        {
            ListingDetail listingDetail = new ListingDetail();
            try
            {


                var uri = new Uri(Constants.strRestUrl + string.Format(Constants.strListingById, id));
                using (var client = new HttpClient())
                {
                    ConfigureHttpClient(client);
                    var response = await client.GetAsync(uri).ConfigureAwait(false); ;
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false); 

                        listingDetail = JsonConvert.DeserializeObject<ListingDetail>(content);
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
            using (var client = new HttpClient())
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
        private static void ConfigureHttpClient(HttpClient client)
        {
            client.BaseAddress = new Uri(Constants.strRestUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
