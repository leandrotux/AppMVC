using AppMvcBasica.Models;
using Dev.Business.Models.Validations;
using Dev.Business.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Dev.Business.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        public async Task Add(Fornecedor fornecedor)
        {

            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)
                && !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco)) return;

            return;
        }

        public async Task Update(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;
        }

        public async Task UpdateAddress(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
