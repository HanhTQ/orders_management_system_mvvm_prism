using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Interface
{
    public interface ILogger
    {
        void LogIn4(string fName, string msg);

        void LogErr(string fName, string msg);
    }
}
