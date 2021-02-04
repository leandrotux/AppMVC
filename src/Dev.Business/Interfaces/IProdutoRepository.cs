﻿using AppMvcBasica.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Business.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> GetProdutosPorFornecedor(Guid fornecedorId);

        Task<IEnumerable<Produto>> GetProdutosFornecedores();

        Task<Produto> GetProdutoFornecedor(Guid id);
    }
}
