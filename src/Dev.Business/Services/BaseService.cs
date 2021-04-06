using Dev.Business.Models;
using Dev.Business.Notifications;
using Dev.Business.Notifications.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

using System.Text;

namespace Dev.Business.Services
{
    public abstract class IBaseService
    {
        private readonly INotificator _notificator;

        public IBaseService(INotificator notificator)
        {
            _notificator = notificator;
        }
        protected void Notify(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                Notify(erro.ErrorMessage);
            } 
        }
        protected void Notify(string mensage)
        {
            _notificator.Handle(new Notification(mensage));
        }

        protected bool ExecuteValidation<TV, TE>(TV validate, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validate.Validate(entity);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }

    }
}
