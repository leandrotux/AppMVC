using AppMvcBasica.Models;
using Dev.Business.Interfaces;
using Dev.Datas.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Dev.Datas.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(DevDbContext context) : base(context)
        {

        }

        public async Task<Endereco> GetEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await _Db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
        }
    }
}
