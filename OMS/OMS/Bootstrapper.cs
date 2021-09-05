using OMS.Interface;
using OMS.Resources;
using OMS.Views;
using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OMS
{
    class Bootstrapper : PrismBootstrapper
    {
        private Logger _logger;

        /// <summary>
        /// Initializes shell
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell(DependencyObject shell)
        {
            base.InitializeShell(shell);

            var regionManager = Container.Resolve<IRegionManager>();

            if (regionManager != null)
            {
                regionManager.RequestNavigate("ContentRegion", Defines.VIEW_HOME);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<HomeView>();
            containerRegistry.RegisterForNavigation<ProductsView>();
            containerRegistry.RegisterForNavigation<AddOrderView>();
            containerRegistry.RegisterForNavigation<AddProductView>();
            containerRegistry.RegisterForNavigation<DetailsOrderView>();
            _logger = new Logger();
            containerRegistry.RegisterInstance<ILogger>(_logger);
        }
    }
}
