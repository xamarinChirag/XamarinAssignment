using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XamarinAssignment.ServiceClient;
using System.Threading.Tasks;

namespace XamarinAssignment.UntiTest
{
    [TestClass]
    public class ListMangaerUnitTest
    {
        IPropertyMangager mgr = null;

        [TestInitialize]
        public void Setup()
        {
            mgr = new PropertyMangager();
        }

        [TestMethod]
        public void TestGetItemsAsync()
        {
            Task.Run(async () =>
            {
                var list = await mgr.GetItemsAsync();
                Assert.IsTrue(list != null && list.Count > 0);
            }
           ).GetAwaiter().GetResult();
            
        }
        [TestMethod]
        public void TestGetItemAsync()
        {
            Task.Run(async () =>
            {
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
                var image = await mgr.GetImageAsync("/images/1.jpg");
                Assert.IsTrue(image != null && image.Length > 0);
            }
           ).GetAwaiter().GetResult();

        }
    }
}
