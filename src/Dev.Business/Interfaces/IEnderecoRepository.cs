﻿using AppMvcBasica.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> GetEnderecoPorFornecedor(Guid fornecedorId);
    }
}
