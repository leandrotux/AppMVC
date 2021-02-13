using AppMvcBasica.Models;
using Dev.Business.Interfaces;
using Dev.Datas.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev.Datas.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DevDbContext context): base(context)
        {

        }

        public async Task<Produto> GetProdutoFornecedor(Guid id)
        {
            return await _Db.Produtos.AsNoTracking()
                .Include(f => f.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> GetProdutosFornecedores()
        {
            return await _Db.Produtos.AsNoTracking()
               .Include(f => f.Fornecedor)
               .OrderBy(p => p.Nome)
               .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> GetProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Search(p => p.FornecedorId == fornecedorId);
        }
    }
}
