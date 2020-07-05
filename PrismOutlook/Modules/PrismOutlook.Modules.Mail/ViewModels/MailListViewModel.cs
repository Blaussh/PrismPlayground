using Prism.Regions;
using PrismOutlook.Buisness;
using PrismOutlook.Core;
using PrismOutlook.Services.Interfaces;
using System.Collections.ObjectModel;
using static PrismOutlook.Modules.Mail.ViewModels.MailGroupViewModel;

namespace PrismOutlook.Modules.Mail.ViewModels
{
    public class MailListViewModel : ViewModelBase
    {
        private string _title = "default";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private ObservableCollection<MailMessage> _messages;
        private readonly IMailService _mailService;

        public ObservableCollection<MailMessage> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }

        private MailMessage _selectedMessage;
        public MailMessage SelectedMessage
        {
            get { return _selectedMessage; }
            set { SetProperty(ref _selectedMessage, value); }
        }

        public MailListViewModel(IMailService mailService)
        {
            _mailService = mailService;
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            var folder = navigationContext.Parameters.GetValue<string>(FolderParameters.FolderKey);
            switch (folder)
            {
                case FolderParameters.Inbox:
                    {
                        Messages = new ObservableCollection<MailMessage>(_mailService.GetInboxItems());
                        break;
                    }
                case FolderParameters.Sent:
                    {
                        Messages = new ObservableCollection<MailMessage>(_mailService.GetSentItems());
                        break;
                    }
                case FolderParameters.Deleted:
                    {
                        Messages = new ObservableCollection<MailMessage>(_mailService.GetDeletedItems());
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
