using Dev.Business.Notifications;
using Dev.Business.Notifications.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dev.App.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotificator _notificator;
        public BaseController(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected bool ValidOperation()
        {
            return !_notificator.HasNotification();
        }
    }
}
