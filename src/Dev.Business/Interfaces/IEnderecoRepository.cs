using AppMvcBasica.Models;
using System;
using System.Threading.Tasks;

namespace Dev.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> GetEnderecoPorFornecedor(Guid fornecedorId);
    }
}
