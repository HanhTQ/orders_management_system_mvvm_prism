using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Models
{
    public enum State
    {
        New,
        Pending,
        Completed,
        Rejected
    }

    public class OrderModel : INotifyPropertyChanged
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

        private int _orderID;
        public int OrderID
        {
            get
            {
                return _orderID;
            }
            set
            {
                _orderID = value;
                OnPropertyChanged();
            }
        }

        private int _itemsTotal;
        public int ItemsTotal
        {
            get
            {
                return _itemsTotal;
            }
            set
            {
                _itemsTotal = value;
                OnPropertyChanged();
            }
        }

        private double _priceTotal;
        public double PriceTotal
        {
            get
            {
                return _priceTotal;
            }
            set
            {
                _priceTotal = value;
                OnPropertyChanged();
            }
        }

        private DateTime _orderDate;
        public DateTime OrderDate
        {
            get
            {
                return _orderDate;
            }
            set
            {
                _orderDate = value;
                OnPropertyChanged();
            }
        }

        private State _state;
        public State State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
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
