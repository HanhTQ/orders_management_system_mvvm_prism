using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using OMS.Entities;
using OMS.Interface;
using OMS.Models;
using OMS.Resources;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace OMS.ViewModels
{
    public class HomeViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private ILogger _logger;
        private DateTime _fromDate;
        private DateTime _toDate;
        private DateTime _prevFromDate;
        private DateTime _prevToDate;
        private int _prevIndexPage;
        private int _indexPage;
        private int _numberPages;
        private int _ordersTotal;
        private string _searchText;

        private ObservableCollection<OrderModel> _ordersListInAPage;
        private List<List<Orders_View>> _ordersInPagesList;
        private List<Orders_View> _allOrdersViewList;

        public ObservableCollection<OrderModel> OrdersListInAPage
        {
            get
            {
                return _ordersListInAPage;
            }
            set
            {
                SetProperty(ref _ordersListInAPage, value);
            }
        }

        public DateTime FromDate
        {
            get
            {
                return _fromDate;
            }
            set
            {
                SetProperty(ref _fromDate, value);
            }
        }

        public DateTime ToDate
        {
            get
            {
                return _toDate;
            }
            set
            {
                SetProperty(ref _toDate, value);
            }
        }

        public int IndexPage
        {
            get
            {
                return _indexPage;
            }
            set
            {
                SetProperty(ref _indexPage, value);
            }
        }

        public int NumberPages
        {
            get
            {
                return _numberPages;
            }
            set
            {
                SetProperty(ref _numberPages, value);
            }
        }

        public int OrdersTotal
        {
            get
            {
                return _ordersTotal;
            }
            set
            {
                SetProperty(ref _ordersTotal, value);
            }
        }

        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                SetProperty(ref _searchText, value);
            }
        }

        public DelegateCommand AddOrderCommand { get; private set; }

        public DelegateCommand SelectedDateCommand { get; private set; }

        public DelegateCommand CollectOrdersInEnterPageCommand { get; private set; }

        public DelegateCommand ShowFirstPageCommand { get; private set; }

        public DelegateCommand ShowLastPageCommand { get; private set; }

        public DelegateCommand ShowPreviousPageCommand { get; private set; }

        public DelegateCommand ShowNextPageCommand { get; private set; }

        public DelegateCommand<object> ShowDetailsOrderViewCommand { get; private set; }

        public DelegateCommand SearchOrderCommand { get; private set; }

        public HomeViewModel(IRegionManager regionManager, ILogger logger)
        {
            _regionManager = regionManager;
            _logger = logger;
            OrdersListInAPage = new ObservableCollection<OrderModel>();
            _allOrdersViewList = new List<Orders_View>();

            AddOrderCommand = new DelegateCommand(AddOrder);
            SelectedDateCommand = new DelegateCommand(CollectOrdersFromDateToDate);
            CollectOrdersInEnterPageCommand = new DelegateCommand(CollectOrdersInEnterPage);
            ShowFirstPageCommand = new DelegateCommand(ShowFirstPage);
            ShowLastPageCommand = new DelegateCommand(ShowLastPage);
            ShowPreviousPageCommand = new DelegateCommand(ShowPreviousPage);
            ShowNextPageCommand = new DelegateCommand(ShowNextPage);
            ShowDetailsOrderViewCommand = new DelegateCommand<object>(ShowDetailsOrderView);
            SearchOrderCommand = new DelegateCommand(SearchOrder);


            InitDateCollectOrders();
            CollectOrders(_fromDate, _toDate);
        }

        private void InitDateCollectOrders()
        {
            DateTime nowDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            FromDate = nowDate.AddDays(-1 * Defines.CONST_NUMBER_OF_DAYS_COLLECT_ORDERS);
            ToDate = nowDate;
            _prevFromDate = FromDate;
            _prevToDate = ToDate;
        }

        private void AddOrder()
        {
            _regionManager.RequestNavigate("ContentRegion", Defines.VIEW_ADD_ORDER, NavigationCompleted);
        }

        private void SearchOrder()
        {
            try
            {
                if ((SearchText != null) && (!SearchText.Equals("")))
                {
                    string text = SearchText;
                    var isNumeric = int.TryParse(text, out int num);

                    List<Orders_View> ordersList = new List<Orders_View>();

                    if (isNumeric)
                    {
                        ordersList = _allOrdersViewList.Where(x => x.OrderID.Equals(num)).ToList();
                    }
                    else
                    {
                        string uWord = text.ToUpper();
                        switch (uWord)
                        {
                            case "N":
                                ordersList = _allOrdersViewList.Where(x => x.State.Equals(Defines.STATE_ORDER_NEW)).ToList();
                                break;
                            case "P":
                                ordersList = _allOrdersViewList.Where(x => x.State.Equals(Defines.STATE_ORDER_PENDING)).ToList();
                                break;
                            case "C":
                                ordersList = _allOrdersViewList.Where(x => x.State.Equals(Defines.STATE_ORDER_COMPLETED)).ToList();
                                break;
                            case "R":
                                ordersList = _allOrdersViewList.Where(x => x.State.Equals(Defines.STATE_ORDER_REJECTED)).ToList();
                                break;
                            default:
                                break;
                        }
                    }

                    CollectOrdersInLists(ordersList);
                }
                else
                {
                    CollectOrdersInLists(_allOrdersViewList);
                }
            }
            catch (Exception e)
            {
                string fName = "HomeViewModel -> SearchOrder";
                string msg = e.Message;
                _logger.LogErr(fName, msg);
            }
        }

        private void CollectOrdersFromDateToDate()
        {
            if (!_prevFromDate.Equals(FromDate) || !_prevToDate.Equals(ToDate))
            {
                bool isDateValid = DateValidationError(FromDate, ToDate);

                if (isDateValid)
                {
                    CollectOrders(FromDate, ToDate);

                    _prevFromDate = FromDate;
                    _prevToDate = ToDate;
                }
                else
                {
                    FromDate = _prevFromDate;
                    ToDate = _prevToDate;
                }
            }
            else
            {
                //Do nothing
            }
        }

        private void NavigationCompleted(NavigationResult result)
        {
            if ((bool)result.Result)
            {
                //Do nothing
            }
            else
            {
                //Do nothing
            }
        }
        
        /// <summary>
        /// Collect orders from DB
        /// </summary>
        /// <returns>List of orders</returns>
        private void CollectOrders(DateTime fromDate, DateTime toDate)
        {
            try
            {
                DateTime fromDateTemp = fromDate;
                DateTime toDateTemp = toDate.AddDays(1);

                using (OMSEntities db = new OMSEntities())
                {
                    _allOrdersViewList = db.Orders_Views.Where(o => (o.OrderDate >= fromDateTemp) && (o.OrderDate <= toDateTemp))
                                        .OrderByDescending(x => x.OrderID).ToList();

                    CollectOrdersInLists(_allOrdersViewList);
                }
            }
            catch(Exception e)
            {
                string fName = "HomeViewModel -> CollectOrders";
                string msg = e.Message;
                _logger.LogErr(fName, msg);
            }
        }

        private void CollectOrdersInLists(List<Orders_View> allOrdersList)
        {
            try
            {
                OrdersTotal = allOrdersList.Count();

                if (OrdersTotal <= Defines.CONST_NUMBER_OF_ORDERS_IN_A_PAGE)
                {
                    IndexPage = 1;
                    NumberPages = 1;

                    _ordersInPagesList = new List<List<Orders_View>>();
                    _ordersInPagesList.Add(allOrdersList);
                }
                else
                {
                    _ordersInPagesList = allOrdersList.Select((x, i) => new { Index = i, Value = x })
                                .GroupBy(x => x.Index / Defines.CONST_NUMBER_OF_ORDERS_IN_A_PAGE)
                                .Select(x => x.Select(v => v.Value).ToList())
                                .ToList();

                    IndexPage = 1;
                    NumberPages = _ordersInPagesList.Count;
                }

                CollectOrdersInPage();
            }
            catch (Exception e)
            {
                string fName = "HomeViewModel -> CollectOrdersInLists";
                string msg = e.Message;
                _logger.LogErr(fName, msg);
            }
        }

        private void CollectOrdersInEnterPage()
        {
            try
            {
                if ((IndexPage < 1) || (IndexPage > NumberPages))
                {
                    IndexPage = _prevIndexPage;
                }
                else
                {
                    CollectOrdersInPage();
                }
            }
            catch (Exception e)
            {
                string fName = "HomeViewModel -> CollectOrdersInEnterPage";
                string msg = e.Message;
                _logger.LogErr(fName, msg);
            }
        }

        private void CollectOrdersInPage()
        {
            try
            {
                OrdersListInAPage.Clear();

                int index = IndexPage - 1;
                int indexOrder = index * Defines.CONST_NUMBER_OF_ORDERS_IN_A_PAGE + 1;
                foreach (var order in _ordersInPagesList[index])
                {
                    OrderModel orderModel = new OrderModel();
                    orderModel.Index = indexOrder;
                    orderModel.OrderID = order.OrderID;
                    orderModel.OrderDate = (DateTime)order.OrderDate;
                    orderModel.ItemsTotal = (int)order.ItemsTotal;
                    orderModel.PriceTotal = (double)order.PriceTotal;
                    orderModel.State = (State)Enum.Parse(typeof(State), order.State);

                    OrdersListInAPage.Add(orderModel);
                    indexOrder++;
                }

                _prevIndexPage = IndexPage;
            }
            catch (Exception e)
            {
                string fName = "HomeViewModel -> CollectOrdersInPage";
                string msg = e.Message;
                _logger.LogErr(fName, msg);
            }
        }

        private void ShowFirstPage()
        {
            try
            {
                IndexPage = 1;
                CollectOrdersInPage();
            }
            catch (Exception e)
            {
                string fName = "HomeViewModel -> ShowFirstPage";
                string msg = e.Message;
                _logger.LogErr(fName, msg);
            }
        }

        private void ShowLastPage()
        {
            try
            {
                IndexPage = NumberPages;
                CollectOrdersInPage();
            }
            catch (Exception e)
            {
                string fName = "HomeViewModel -> ShowLastPage";
                string msg = e.Message;
                _logger.LogErr(fName, msg);
            }
        }

        private void ShowPreviousPage()
        {
            try
            {
                if (IndexPage > 1)
                {
                    IndexPage--;
                    CollectOrdersInPage();
                }
                else
                {
                    //Do nothing
                }
            }
            catch (Exception e)
            {
                string fName = "HomeViewModel -> ShowPreviousPage";
                string msg = e.Message;
                _logger.LogErr(fName, msg);
            }
        }

        private void ShowNextPage()
        {
            try
            {
                if (IndexPage < NumberPages)
                {
                    IndexPage++;
                    CollectOrdersInPage();
                }
                else
                {
                    //Do nothing
                }
            }
            catch (Exception e)
            {
                string fName = "HomeViewModel -> ShowNextPage";
                string msg = e.Message;
                _logger.LogErr(fName, msg);
            }
        }

        private void ShowDetailsOrderView(object parameter)
        {
            try
            {
                if (parameter != null)
                {
                    var order = (OrderModel)parameter;
                    var parameters = new NavigationParameters();
                    parameters.Add("SelectedOrder", order);
                    _regionManager.RequestNavigate("ContentRegion", Defines.VIEW_DETAILS_ORDER, NavigationCompleted, parameters);
                }
                else
                {
                    //Do nothing
                }
            }
            catch (Exception e)
            {
                string fName = "HomeViewModel -> ShowDetailsOrderView";
                string msg = e.Message;
                _logger.LogErr(fName, msg);
            }
        }

        private bool DateValidationError(DateTime fromDate, DateTime toDate)
        {
            bool isCheck = false;

            try
            {
                if (fromDate > toDate)
                {
                    isCheck = false;

                    if (!_prevFromDate.Equals(fromDate))
                    {
                        ShowMessageBox(MsgType.Warning, Defines.MSG_CHECKFROMDATE);
                    }
                    else if (!_prevToDate.Equals(toDate))
                    {
                        ShowMessageBox(MsgType.Warning, Defines.MSG_CHECKTODATE);
                    }
                }
                else
                {
                    isCheck = true;
                }
            }
            catch (Exception exc)
            {
                isCheck = false;
                string fName = "HomeViewModel -> DateValidationError";
                string msg = exc.Message;
                _logger.LogErr(fName, msg);
            }

            return isCheck;
        }

        private void ShowMessageBox(MsgType msgType, string msg)
        {
            switch (msgType)
            {
                case MsgType.Warning:
                    MessageBox.Show(msg, Defines.MSGTYPE_WARNING, MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                case MsgType.Error:
                    MessageBox.Show(msg, Defines.MSGTYPE_ERROR, MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case MsgType.Information:
                    MessageBox.Show(msg, Defines.MSGTYPE_INFOR, MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                default:
                    break;
            }
        }
    }
}
