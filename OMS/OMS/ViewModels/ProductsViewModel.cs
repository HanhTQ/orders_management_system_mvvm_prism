using OMS.Entities;
using OMS.Interface;
using OMS.Models;
using OMS.Resources;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.ViewModels
{

    public class ProductsViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private ILogger _logger;
        private int _prevIndexPage;
        private int _indexPage;
        private int _numberPages;
        private int _productsTotal;
        private string _searchText;

        private ObservableCollection<ProductModel> _productsListInAPage;
        private List<List<Products_View>> _productsInPagesList;
        private List<Products_View> _allProductsViewList;

        public ObservableCollection<ProductModel> ProductsListInAPage
        {
            get
            {
                return _productsListInAPage;
            }
            set
            {
                SetProperty(ref _productsListInAPage, value);
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

        public int ProductsTotal
        {
            get
            {
                return _productsTotal;
            }
            set
            {
                SetProperty(ref _productsTotal, value);
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

        public DelegateCommand AddProductCommand { get; private set; }

        public DelegateCommand CollectProductsInEnterPageCommand { get; private set; }

        public DelegateCommand ShowFirstPageCommand { get; private set; }

        public DelegateCommand ShowLastPageCommand { get; private set; }

        public DelegateCommand ShowPreviousPageCommand { get; private set; }

        public DelegateCommand ShowNextPageCommand { get; private set; }

        public DelegateCommand SearchProductCommand { get; private set; }

        public ProductsViewModel(IRegionManager regionManager, ILogger logger)
        {
            _regionManager = regionManager;
            _logger = logger;

            ProductsListInAPage = new ObservableCollection<ProductModel>();
            _allProductsViewList = new List<Products_View>();

            AddProductCommand = new DelegateCommand(AddProduct);
            CollectProductsInEnterPageCommand = new DelegateCommand(CollectProductsInEnterPage);
            ShowFirstPageCommand = new DelegateCommand(ShowFirstPage);
            ShowLastPageCommand = new DelegateCommand(ShowLastPage);
            ShowPreviousPageCommand = new DelegateCommand(ShowPreviousPage);
            ShowNextPageCommand = new DelegateCommand(ShowNextPage);
            SearchProductCommand = new DelegateCommand(SearchProduct);

            CollectProducts();
        }

        private void AddProduct()
        {
            _regionManager.RequestNavigate("ContentRegion", Defines.VIEW_ADD_PRODUCT, NavigationCompleted);
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

        private void CollectProducts()
        {
            try
            {
                using (OMSEntities db = new OMSEntities())
                {
                    _allProductsViewList = db.Products_Views.OrderBy(x => x.ProductID).ToList();

                    CollectProductsInLists(_allProductsViewList);
                }
            }
            catch (Exception e)
            {
                string fName = "ProductsViewModel -> CollectProducts";
                string msg = e.Message;
                _logger.LogErr(fName, msg);
            }
        }

        private void CollectProductsInLists(List<Products_View> allProductsViewList)
        {
            try
            {
                ProductsTotal = allProductsViewList.Count();

                if (ProductsTotal <= Defines.CONST_NUMBER_OF_PRODUCTS_IN_A_PAGE)
                {
                    IndexPage = 1;
                    NumberPages = 1;

                    _productsInPagesList = new List<List<Products_View>>();
                    _productsInPagesList.Add(allProductsViewList);
                }
                else
                {
                    _productsInPagesList = allProductsViewList.Select((x, i) => new { Index = i, Value = x })
                                .GroupBy(x => x.Index / Defines.CONST_NUMBER_OF_PRODUCTS_IN_A_PAGE)
                                .Select(x => x.Select(v => v.Value).ToList())
                                .ToList();

                    IndexPage = 1;
                    NumberPages = _productsInPagesList.Count;
                }

                CollectProductsInPage();
            }
            catch (Exception e)
            {
                string fName = "ProductsViewModel -> CollectProductsInLists";
                string msg = e.Message;
                _logger.LogErr(fName, msg);
            }
        }

        private void CollectProductsInPage()
        {
            try
            {
                ProductsListInAPage.Clear();

                int index = IndexPage - 1;
                int indexProduct = index * Defines.CONST_NUMBER_OF_PRODUCTS_IN_A_PAGE + 1;
                foreach (var item in _productsInPagesList[index])
                {
                    ProductModel productModel = new ProductModel();
                    productModel.Index = indexProduct;
                    productModel.ProductID = item.ProductID;
                    productModel.ProductName = item.ProductName;
                    productModel.Category = item.CategoryName;
                    productModel.UnitPrice = (int)item.UnitPrice;
                    productModel.UnitsInStock = (int)item.UnitsInStock;
                    productModel.UnitsOnOrder = (int)item.UnitsOnOrder;
                    productModel.Discontinued = item.Discontinued;

                    ProductsListInAPage.Add(productModel);
                    indexProduct++;
                }

                _prevIndexPage = IndexPage;
            }
            catch (Exception e)
            {
                string fName = "ProductsViewModel -> CollectProductsInPage";
                string msg = e.Message;
                _logger.LogErr(fName, msg);
            }
        }

        private void CollectProductsInEnterPage()
        {
            try
            {
                if ((IndexPage < 1) || (IndexPage > NumberPages))
                {
                    IndexPage = _prevIndexPage;
                }
                else
                {
                    CollectProductsInPage();
                }
            }
            catch (Exception e)
            {
                string fName = "ProductsViewModel -> CollectProductsInEnterPage";
                string msg = e.Message;
                _logger.LogErr(fName, msg);
            }
        }

        private void ShowFirstPage()
        {
            try
            {
                IndexPage = 1;
                CollectProductsInPage();
            }
            catch (Exception e)
            {
                string fName = "ProductsViewModel -> ShowFirstPage";
                string msg = e.Message;
                _logger.LogErr(fName, msg);
            }
        }

        private void ShowLastPage()
        {
            try
            {
                IndexPage = NumberPages;
                CollectProductsInPage();
            }
            catch (Exception e)
            {
                string fName = "ProductsViewModel -> ShowLastPage";
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
                    CollectProductsInPage();
                }
                else
                {
                    //Do nothing
                }
            }
            catch (Exception e)
            {
                string fName = "ProductsViewModel -> ShowPreviousPage";
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
                    CollectProductsInPage();
                }
                else
                {
                    //Do nothing
                }
            }
            catch (Exception e)
            {
                string fName = "ProductsViewModel -> ShowNextPage";
                string msg = e.Message;
                _logger.LogErr(fName, msg);
            }
        }

        private void SearchProduct()
        {
            try
            {
                if ((SearchText != null) && (!SearchText.Equals("")))
                {
                    string text = SearchText;
                    var isNumeric = int.TryParse(text, out int num);

                    List<Products_View> productsList = new List<Products_View>();

                    if (isNumeric)
                    {
                        productsList = _allProductsViewList.Where(x => x.ProductID.Equals(num)).ToList();
                    }
                    else
                    {
                        string uWord = text.ToUpper();

                        productsList = _allProductsViewList.Where(x => x.ProductName.ToUpper().Contains(uWord)).ToList();
                    }

                    CollectProductsInLists(productsList);
                }
                else
                {
                    CollectProductsInLists(_allProductsViewList);
                }
            }
            catch (Exception e)
            {
                string fName = "ProductsViewModel -> SearchProduct";
                string msg = e.Message;
                _logger.LogErr(fName, msg);
            }
        }
    }
}
