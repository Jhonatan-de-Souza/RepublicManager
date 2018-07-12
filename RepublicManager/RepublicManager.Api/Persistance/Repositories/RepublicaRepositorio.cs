using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Persistance.Repositories
{
    public class RepublicaRepositorio : RepositorioBase<Republica>, IRepublicaRepositorio
    {
        private readonly RepublicManagerContext _republicManagerContext;

        public RepublicaRepositorio(RepublicManagerContext republicManagerContext) : base(republicManagerContext)
        {
            _republicManagerContext = republicManagerContext;
        }


        public async Task<IEnumerable<Republica>> GetRepublicaWithRegras()
        {
            var test =  await _republicManagerContext.Republica.Include(x => x.Regras).ToListAsync();
            return test;
        }
    }
}