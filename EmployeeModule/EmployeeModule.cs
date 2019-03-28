using EmployeeModuleNamespace.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace EmployeeModuleNamespace
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
            containerRegistry.RegisterForNavigation<LoginView>("LoginView");
        }
    }
}
