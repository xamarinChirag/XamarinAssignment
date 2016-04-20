using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinAssignment.ServiceClient;

namespace XamarinAssignment.Infrastructure.CrossCuttings
{
    /// <summary>
    /// Setting up the IOC Service locator
    /// </summary>
    public static class SetUpIOC
    {
        #region Methods
        /// <summary>
        /// SetupContainer
        /// </summary>
        public static void SetupContainer()
        {
            MvxSimpleIoCContainer.Initialize();
            try
            {
                // Android-specific code
                if (CrossConnectivity.Current.IsConnected)
                {
                    Mvx.RegisterSingleton<IPropertyMangager>(new PropertyMangager());
                }
                else
                {
                    Mvx.RegisterSingleton<IPropertyMangager>(new OfflinePropertyMangager());
                }
            }
            catch
            {
                //TODO: need to handle the exception
            }
        }
        #endregion
    }
}
