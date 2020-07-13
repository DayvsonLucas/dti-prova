using System.Collections.Generic;

namespace DTI.Domain.Core.Notifications
{
    public interface INotificationHandler
    {
        void Handle(DomainNotification notification);
        List<DomainNotification> GetNotifications();
        bool HaveNotification();
    }
}
