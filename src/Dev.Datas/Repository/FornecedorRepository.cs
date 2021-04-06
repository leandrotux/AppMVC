using Dev.Business.Models;
using Dev.Business.Interfaces;
using Dev.Datas.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Dev.Datas.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(DevDbContext context) : base(context)
        {

        }

        public async Task<Fornecedor> GetFornecedorEndereco(Guid id)
        {
            return await _Db.Fornecedores.AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Fornecedor> GetFornecedorProdutoEndereco(Guid id)
        {
            return await _Db.Fornecedores.AsNoTracking()
                .Include(p => p.Produtos)
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
