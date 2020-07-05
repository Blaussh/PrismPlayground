using PrismOutlook.Buisness;
using PrismOutlook.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PrismOutlook.Services
{
    public class EmailService : IMailService
    {
        static List<MailMessage> InboxItems = new List<MailMessage>()
        {
            new MailMessage()
            {
                Id = 1,
                From = "blaussh",
                To = new ObservableCollection<string>() { "gogo@dodo.com", "moo@lala.com"},
                Subject = "This is a test email",
                Body = "This is the body on an email",
                DateSent = DateTime.Now
            },
            new MailMessage()
            {
                Id = 2,
                From = "blaussh",
                To = new ObservableCollection<string>() { "gogo@dodo.com", "moo@lala.com"},
                Subject = "This is a test email 2",
                Body = "This is the body on an email 2",
                DateSent = DateTime.Now.AddDays(-1)
            },
            new MailMessage()
            {
                Id = 3,
                From = "blaussh",
                To = new ObservableCollection<string>() { "gogo@dodo.com", "moo@lala.com"},
                Subject = "This is a test email 3",
                Body = "This is the body on an email 3",
                DateSent = DateTime.Now.AddDays(-2)
            },
            new MailMessage()
            {
                Id = 4,
                From = "blaussh",
                To = new ObservableCollection<string>() { "gogo@dodo.com", "moo@lala.com"},
                Subject = "This is a test email 4",
                Body = "This is the body on an email 4",
                DateSent = DateTime.Now.AddDays(-5)
            }
        };

        static List<MailMessage> SentItems = new List<MailMessage>();

        static List<MailMessage> DeletedItems = new List<MailMessage>();

        public IList<MailMessage> GetInboxItems()
        {
            return InboxItems;
        }

        public IList<MailMessage> GetDeletedItems()
        {
            return DeletedItems;
        }

        public IList<MailMessage> GetSentItems()
        {
            return SentItems;
        }
    }
}
