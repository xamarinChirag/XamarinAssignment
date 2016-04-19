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
    public static class SetUpIOC
    {

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

            }
        }
    }
}
