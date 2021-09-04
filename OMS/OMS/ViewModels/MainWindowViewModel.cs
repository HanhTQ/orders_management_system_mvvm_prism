using OMS.Resources;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OMS.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        private string _title = "OMS";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand<string> NavigateCommand { get; private set; }

        public DelegateCommand<object[]> SelectedCommand { get; private set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            NavigateCommand = new DelegateCommand<string>(Navigate);

            // This command will be executed when the selection of the ListBox in the view changes.
            SelectedCommand = new DelegateCommand<object[]>(OnItemSelected);
        }

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("ContentRegion", navigatePath, NavigationCompleted);
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

        private void OnItemSelected(object[] selectedItems)
        {
            if (selectedItems != null && selectedItems.Count() > 0)
            {
                string view = selectedItems.FirstOrDefault().ToString();
                switch (view)
                {
                    case Defines.HOME:
                        NavigateCommand.Execute(Defines.VIEW_HOME);
                        break;
                    case Defines.ITEMS:
                        NavigateCommand.Execute(Defines.VIEW_ITEMS);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
