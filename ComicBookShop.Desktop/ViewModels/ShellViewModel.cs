using EmployeeModuleNamespace.Views;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicBookShop.Desktop.Views;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using System.Windows.Input;
using ComicBookShop.Data;

namespace ComicBookShop.Desktop.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        private IContainerExtension _container;
        private readonly IRegionManager _regionManager;

        public DelegateCommand<string> NavigationCommand { get; private set; }
        public DelegateCommand DbCheckCommand { get; private set; }


        public ShellViewModel(IContainerExtension container, IRegionManager manager)
        {

            _container = container;
            _regionManager = manager;

            _regionManager.RegisterViewWithRegion("content", typeof(LoginView));
            container.RegisterForNavigation<MenuView>("MenuView");
            NavigationCommand = new DelegateCommand<string>(Navigate);
            ApplicationCommands.NavigateCommand.RegisterCommand(NavigationCommand);

        }

        private void Navigate(string control)
        {
            if (control != null)
            {
                _regionManager.RequestNavigate("content", control);
            }
        }

    }
}
