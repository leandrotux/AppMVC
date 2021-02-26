using System;
using System.Collections.Generic;
using System.Text;

namespace Dev.Business.Notifications
{
    public class Notification
    {
        public Notification(string mensage)
        {
            Mensage = mensage;
        }

        public string Mensage { get; }

    }
}
