using AppMvcBasica.Models;
using Dev.Business.Interfaces;
using Dev.Business.Models.Validations;
using Dev.Business.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dev.Business.Services
{
    public class FornecedorService : BaseService, IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository,
                                 IEnderecoRepository enderecoRepository)
        {
            _fornecedorRepository = fornecedorRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task Add(Fornecedor fornecedor)
        {

            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)
                && !ExecutarValidacao(new EnderecoValidation(), fornecedor.Endereco)) return;

            if(_fornecedorRepository.Search(f => f.Documento == fornecedor.Documento).Result.Any())
            {
                Notificar("Já existe um fornecedor com esse documento informado.");
                return;
            }

            await _fornecedorRepository.Add(fornecedor);
        }

        public async Task Update(Fornecedor fornecedor)
        {
            if (!ExecutarValidacao(new FornecedorValidation(), fornecedor)) return;

            if (_fornecedorRepository.Search(f => f.Documento == fornecedor.Documento && f.Id != fornecedor.Id).Result.Any())
            {
                Notificar("Já existe um fornecedor com esse documento informado.");
                return;
            }

            await _fornecedorRepository.Update(fornecedor);

        }

        public async Task UpdateAddress(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

            await _enderecoRepository.Update(endereco);
        }

        public async Task Remove(Guid id)
        {
            if (_fornecedorRepository.GetFornecedorProdutoEndereco(id).Result.Produtos.Any())
            {
                Notificar("O fornecedor possui produtos cadastrados!");
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
