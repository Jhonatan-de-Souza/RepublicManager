﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Persistance.Repositories
{
    public class ContaRepositorio : RepositorioBase<Conta>, IContaRepositorio
    {
        private readonly RepublicManagerContext _republicManagerContext;

        public ContaRepositorio(RepublicManagerContext republicManagerContext) : base(republicManagerContext)
        {
            _republicManagerContext = republicManagerContext;
        }

        public async Task<IEnumerable<Conta>> GetAllContaWithPagarEReceberEUsuario()
        {
            return await _republicManagerContext.Contas
                .Include(x => x.ContasAPagar)                
                        .ThenInclude(x => x.TipoConta)
                .Include(x => x.ContasAReceber)
                    .ThenInclude(x => x.TipoConta)
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<Conta> GetByIdContaWithPagarEReceber(int id)
        {
            return await _republicManagerContext.Contas
                .Where(x => x.Id == id)
                 .Include(x => x.ContasAPagar)
                        .ThenInclude(x => x.TipoConta)
                .Include(x => x.ContasAReceber)
                    .ThenInclude(x => x.TipoConta)
                .FirstOrDefaultAsync();
        }
    }
}