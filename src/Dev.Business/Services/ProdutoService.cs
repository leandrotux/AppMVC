using AppMvcBasica.Models;
using Dev.Business.Interfaces;
using Dev.Business.Models.Validations;
using Dev.Business.Notifications.Interfaces;
using Dev.Business.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Dev.Business.Services
{
    public class ProdutoService : IBaseService, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository,
                              INotificator notificator) : base(notificator)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Add(Produto produto)
        {
            if (!ExecuteValidation(new ProdutoValidation(), produto)) return;

            await _produtoRepository.Add(produto);
        }

        public async Task Update(Produto produto)
        {
            if (!ExecuteValidation(new ProdutoValidation(), produto)) return;

            await _produtoRepository.Update(produto);

        }

        public async Task Remove(Guid id)
        {
            await _produtoRepository.Delete(id);

        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }
    }
}
