using Prism.Commands;
using Prism.Mvvm;
using PrismOutlook.Buisness;
using PrismOutlook.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismOutlook.Modules.Mail.ViewModels
{
    public class MailGroupViewModel : BindableBase
    {
        private ObservableCollection<NavigationItem> _items;
        public ObservableCollection<NavigationItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        private DelegateCommand<NavigationItem> _selectedCommand;
        private readonly IApplicationCommands _applicationCommands;

        public DelegateCommand<NavigationItem> SelectedCommand =>
            _selectedCommand ?? (_selectedCommand = new DelegateCommand<NavigationItem>(ExecuteCommandName));

        public MailGroupViewModel(IApplicationCommands applicationCommands)
        {
            GenerateMenu();
            _applicationCommands = applicationCommands;
        }

        void ExecuteCommandName(NavigationItem navigationItem)
        {
            if (navigationItem != null)
            {
                _applicationCommands.NavigateCommand.Execute(navigationItem.NavigationPath);
            }
        }

        void GenerateMenu()
        {
            Items = new ObservableCollection<NavigationItem>();

            var root = new NavigationItem() { Caption = "Personal Folder", NavigationPath = "MailList?id=Default" };
            root.Items.Add(new NavigationItem() { Caption = "Inbox", NavigationPath = "MailList?id=Inbox" });
            root.Items.Add(new NavigationItem() { Caption = "Deleted", NavigationPath = "MailList?id=Delete" });
            root.Items.Add(new NavigationItem() { Caption = "Sent", NavigationPath = "MailList?id=Sent" });

            Items.Add(root);
        }
    }
}
