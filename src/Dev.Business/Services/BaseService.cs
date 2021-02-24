using AppMvcBasica.Models;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

using System.Text;

namespace Dev.Business.Services
{
    public abstract class BaseService
    {
        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                Notificar(erro.ErrorMessage);
            } 
        }
        protected void Notificar(string mensagem)
        {

        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }

    }
}
