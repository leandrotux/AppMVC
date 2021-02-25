using System;
using System.Collections.Generic;
using System.Text;

namespace Dev.Business.Notifications.Interfaces
{
    public interface INotificator
    {
        bool HasNotification();

        List<Notification> GetNotifications();

        void Handle(Notification notification);
    }
}
