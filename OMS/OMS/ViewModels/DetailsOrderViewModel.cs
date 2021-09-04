using OMS.Interface;
using OMS.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.ViewModels
{
    public class DetailsOrderViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager _regionManager;
        private IRegionNavigationJournal _journal;
        private ILogger _logger;
        private OrderModel _selectedOrder;

        public OrderModel SelectedOrder
        {
            get { return _selectedOrder; }
            set { SetProperty(ref _selectedOrder, value); }
        }

        public DelegateCommand GoBackHomeViewCommand { get; private set; }

        public DetailsOrderViewModel(IRegionManager regionManager, ILogger logger)
        {
            _regionManager = regionManager;
            _logger = logger;
            GoBackHomeViewCommand = new DelegateCommand(GoBackHomeView);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _journal = navigationContext.NavigationService.Journal;

            try
            {
                var order = navigationContext.Parameters["SelectedOrder"] as OrderModel;

                if (order != null)
                {
                    SelectedOrder = order;
                }
            }
            catch (Exception e)
            {
                string fName = "DetailsOrderViewModel -> OnNavigatedTo";
                string msg = e.Message;
                _logger.LogErr(fName, msg);
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        private void GoBackHomeView()
        {
            _journal.GoBack();
        }
    }
}
