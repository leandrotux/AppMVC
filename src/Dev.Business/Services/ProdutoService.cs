using AppMvcBasica.Models;
using Dev.Business.Models.Validations;
using Dev.Business.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Dev.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        public async Task Add(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;
        }

        public async Task Update(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;
        }

        public Task Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
