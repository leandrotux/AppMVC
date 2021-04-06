using Dev.Business.Notifications.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dev.App.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly INotificator _notificator;

        public SummaryViewComponent(INotificator notificator)
        {
            _notificator = notificator;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notifications = await Task.FromResult(_notificator.GetNotifications());

            notifications.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Mensage));

            return View();
        }
    }
}
