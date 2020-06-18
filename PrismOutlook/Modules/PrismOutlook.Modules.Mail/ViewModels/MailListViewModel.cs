using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismOutlook.Modules.Mail.ViewModels
{
    public class MailListViewModel : BindableBase, INavigationAware
    {
        private string _title = "default";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MailListViewModel()
        {

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Title = navigationContext.Parameters.GetValue<string>("id");
        }
    }
}
