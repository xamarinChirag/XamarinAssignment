using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XamarinAssignment.ServiceClient;
using System.Threading.Tasks;

namespace XamarinAssignment.UntiTest
{
    [TestClass]
    public class ListMangaerUnitTest
    {
        [TestMethod]
        public void TestGetItemsAsync()
        {
            Task.Run(async () =>
            {
                IPropertyMangager mgr = new PropertyMangager();
                var list = await mgr.GetItemsAsync();
                Assert.IsNotNull(list);
            }
           ).GetAwaiter().GetResult();
            
        }
        [TestMethod]
        public void TestGetItemAsync()
        {
            Task.Run(async () =>
            {
                IPropertyMangager mgr = new PropertyMangager();
                var listDetail = await mgr.GetItemAsync("1");
                Assert.IsNotNull(listDetail);
            }
           ).GetAwaiter().GetResult();

        }
        [TestMethod]
        public void TestGetImageAsync()
        {
            Task.Run(async () =>
            {
                IPropertyMangager mgr = new PropertyMangager();
                var list = await mgr.GetImageAsync("/images/1.jpg");
                Assert.IsNotNull(list);
            }
           ).GetAwaiter().GetResult();

        }
    }
}
