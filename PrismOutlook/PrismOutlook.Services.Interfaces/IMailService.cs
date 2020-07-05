using PrismOutlook.Buisness;
using System.Collections.Generic;

namespace PrismOutlook.Services.Interfaces
{
    public interface IMailService
    {
        IList<MailMessage> GetInboxItems();
        IList<MailMessage> GetSentItems();
        IList<MailMessage> GetDeletedItems();
    }
}
