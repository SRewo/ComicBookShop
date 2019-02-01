﻿using System.Windows;
using CommonServiceLocator;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;

namespace ComicBookShop.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override Window CreateShell()
        {
            return ServiceLocator.Current.GetInstance<Shell>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {

            moduleCatalog.AddModule<ComicbookModule.ComicbookModule>();
            moduleCatalog.AddModule<EmployeeModule.EmployeeModule>();
            moduleCatalog.AddModule<OrderModule.OrderModule>();

        }

    }
}
