using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderModule.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace OrderModule
{
    public class OrderModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<AddOrderView>("AddOrder");
        }
    }
}
