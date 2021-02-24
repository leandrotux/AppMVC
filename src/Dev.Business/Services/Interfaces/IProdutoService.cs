using AppMvcBasica.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Business.Services.Interfaces
{
    public interface IProdutoService
    {
        Task Add(Fornecedor fornecedor);

        Task Update(Fornecedor fornecedor);

        Task Remove(Guid id);
    }
}
