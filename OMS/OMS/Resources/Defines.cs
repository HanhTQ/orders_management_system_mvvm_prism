using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Resources
{
    public enum MsgType
    {
        Warning,
        Error,
        Information
    }

    public class Defines
    {
        public const string FILENAME_LOGS = "logs.txt";

        public const string HOME = "Home";
        public const string ITEMS = "Items";
        public const string VIEW_HOME = "HomeView";
        public const string VIEW_ITEMS = "ItemsView";
        public const string VIEW_ADD_ORDER = "AddOrderView";
        public const string VIEW_DETAILS_ORDER = "DetailsOrderView";

        public const string MSGTYPE_WARNING = "WARNING";
        public const string MSGTYPE_ERROR = "ERROR";
        public const string MSGTYPE_INFOR = "INFOR";

        public const string MSG_CHECKFROMDATE = "FROM DATE is invalid!";
        public const string MSG_CHECKTODATE = "TO DATE is invalid!";

        public const int CONST_NUMBER_OF_ORDERS_IN_A_PAGE = 20;
        public const int CONST_NUMBER_OF_DAYS_COLLECT_ORDERS= 10;

        public const string STATE_ORDER_NEW = "New";
        public const string STATE_ORDER_PENDING = "Pending";
        public const string STATE_ORDER_COMPLETED = "Completed";
        public const string STATE_ORDER_REJECTED = "Rejected";
    }
}
