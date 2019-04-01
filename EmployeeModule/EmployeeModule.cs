using EmployeeModuleNamespace.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace EmployeeModuleNamespace
{
    public class EmployeeModule : IModule
    {

        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoginView>("LoginView");
        }
    }
}
