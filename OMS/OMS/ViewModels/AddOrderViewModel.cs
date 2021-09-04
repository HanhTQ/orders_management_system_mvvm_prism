using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.ViewModels
{
    public class AddOrderViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public AddOrderViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
    }
}
