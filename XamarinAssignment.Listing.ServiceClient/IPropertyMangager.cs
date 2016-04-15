using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinAssignment.Model;
namespace XamarinAssignment.ServiceClient
{
    public interface IPropertyMangager
    {
        Task<List<Property>> GetItemsAsync(int skip = 0, int take = 100, bool forceRefresh = false);
        Task<PropertyDetail> GetItemAsync(string id);
        Task<byte[]> GetImageAsync(string name);
    }
}
