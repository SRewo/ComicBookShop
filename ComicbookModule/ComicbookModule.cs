using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComicbookModule.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace ComicbookModule
{
    public class ComicbookModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

            containerRegistry.RegisterForNavigation<PublishersListView>("PublisherList");

        }
    }
}
