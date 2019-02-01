    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
    using ComicBookShop.Desktop.Views;
    using Prism.Ioc;
    using Prism.Regions;

namespace ComicBookShop.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy Shell.xaml
    /// </summary>
    public partial class Shell : Window
    {
        private IContainerExtension _container;
        private IRegionManager _regionManager;


        public Shell(IContainerExtension container, IRegionManager manager)
        {

            InitializeComponent();

            _container = container;
            _regionManager = manager;

            _regionManager.RegisterViewWithRegion("menu", typeof(MenuView));
        }


        
    }
}
