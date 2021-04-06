using Dev.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Business.Services.Interfaces
{
    public interface IProdutoService : IDisposable
    {
        Task Add(Produto produto);

        Task Update(Produto produto);

        Task Remove(Guid id);
    }
}
