using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
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
            Mvx.RegisterSingleton<IPropertyMangager>(new PropertyMangager());
        }
    }
   
    
}
