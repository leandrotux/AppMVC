using AppMvcBasica.Models;
using System;
using System.Threading.Tasks;

namespace Dev.Business.Services.Interfaces
{
    public interface IFornecedorService
    {
        Task Add(Fornecedor fornecedor);

        Task Update(Fornecedor fornecedor);

        Task Remove(Guid id);

        Task UpdateAddress(Endereco endereco);
    }
}
