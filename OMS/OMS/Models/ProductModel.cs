using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Models
{
    public class ProductModel : INotifyPropertyChanged
    {
        #region Properties
        private int _index;
        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
                OnPropertyChanged();
            }
        }

        private int _productID;
        public int ProductID
        {
            get
            {
                return _productID;
            }
            set
            {
                _productID = value;
                OnPropertyChanged();
            }
        }

        private string _productName;
        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
                OnPropertyChanged();
            }
        }

        private string _category;
        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                OnPropertyChanged();
            }
        }

        private int _unitPrice;
        public int UnitPrice
        {
            get
            {
                return _unitPrice;
            }
            set
            {
                _unitPrice = value;
                OnPropertyChanged();
            }
        }

        private int _unitsInStock;
        public int UnitsInStock
        {
            get
            {
                return _unitsInStock;
            }
            set
            {
                _unitsInStock = value;
                OnPropertyChanged();
            }
        }

        private int _unitsOnOrder;
        public int UnitsOnOrder
        {
            get
            {
                return _unitsOnOrder;
            }
            set
            {
                _unitsOnOrder = value;
                OnPropertyChanged();
            }
        }

        private bool _discontinued;
        public bool Discontinued
        {
            get
            {
                return _discontinued;
            }
            set
            {
                _discontinued = value;
                OnPropertyChanged();
            }
        }

        #endregion //Properties

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        #endregion //INotifyPropertyChanged


    }
}
