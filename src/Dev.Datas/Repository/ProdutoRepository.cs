using AppMvcBasica.Models;
using Dev.Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Datas.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public async Task<Produto> GetProdutoFornecedor(Guid id)
        {
            return await db.Produtos.AsNoTracking()
                .Include(f => f.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> GetProdutosFornecedores()
        {
            return await db.Produtos.AsNoTracking()
               .Include(f => f.Fornecedor)
               .OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> GetProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Search(p => p.FornecedorId == fornecedorId);
        }
    }
}
