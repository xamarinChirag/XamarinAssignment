using Akavache;
using Cirrious.CrossCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinAssignment.Model;
using XamarinAssignment.ServiceClient;
using System.Reactive.Linq;
namespace XamarinAssignment.Infrastructure.CrossCuttings
{
    public static class SQLLightCachingHelper
    {


        public async static Task<List<Property>> GetProperties()
        {
            var cache = BlobCache.LocalMachine;
            var cachedProperties = cache.GetAndFetchLatest("properties", () => Mvx.GetSingleton<IPropertyMangager>().GetItemsAsync(),
                offset =>
                {
                    TimeSpan elapsed = DateTimeOffset.Now - offset;
                    return elapsed > new TimeSpan(hours: 0, minutes: 30, seconds: 0);
                });

            var properties = await cachedProperties.FirstOrDefaultAsync();
            return properties;
        }
    }
}
