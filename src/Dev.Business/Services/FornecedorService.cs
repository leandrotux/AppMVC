using AppMvcBasica.Models;
using Dev.Business.Interfaces;
using Dev.Business.Models.Validations;
using Dev.Business.Notifications.Interfaces;
using Dev.Business.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dev.Business.Services
{
    public class FornecedorService : IBaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository,
                                 IEnderecoRepository enderecoRepository,
                                 INotificator notificator) : base(notificator)
        {
            _fornecedorRepository = fornecedorRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task Add(Fornecedor fornecedor)
        {

            if (!ExecuteValidation(new FornecedorValidation(), fornecedor)
                && !ExecuteValidation(new EnderecoValidation(), fornecedor.Endereco)) return;

            if(_fornecedorRepository.Search(f => f.Documento == fornecedor.Documento).Result.Any())
            {
                Notify("Já existe um fornecedor com esse documento informado.");
                return;
            }

            await _fornecedorRepository.Add(fornecedor);
        }

        public async Task Update(Fornecedor fornecedor)
        {
            if (!ExecuteValidation(new FornecedorValidation(), fornecedor)) return;

            if (_fornecedorRepository.Search(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id).Result.Any())
            {
                Notify("Já existe um fornecedor com esse documento informado.");
                return;
            }

            await _fornecedorRepository.Update(fornecedor);

        }

        public async Task UpdateAddress(Endereco endereco)
        {
            if (!ExecuteValidation(new EnderecoValidation(), endereco)) return;

            await _enderecoRepository.Update(endereco);
        }

        public async Task Remove(Guid id)
        {
            if (_fornecedorRepository.GetFornecedorProdutoEndereco(id).Result.Produtos.Any())
            {
                Notify("O fornecedor possui produtos cadastrados!");
                return;
            }
            await _fornecedorRepository.Delete(id);
        }

        public void Dispose()
        {
            _fornecedorRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }
    }
}
