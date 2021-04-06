using Dev.Business.Models;
using System;
using System.Threading.Tasks;

namespace Dev.Business.Interfaces
{
    public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task<Fornecedor> GetFornecedorEndereco(Guid id);

        Task<Fornecedor> GetFornecedorProdutoEndereco(Guid id);
    }
}
