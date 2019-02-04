using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace EmployeeModule
{
    public class EmployeeModule : IModule
    {

        private IContainerExtension _container;
        private IRegionManager _regionManager;

        public EmployeeModule(IContainerExtension container, IRegionManager regionManager)
        {

            _container = container;
            _regionManager = regionManager;

        }


        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<EmployeeListView>("EmployeeList");
        }
    }
}
