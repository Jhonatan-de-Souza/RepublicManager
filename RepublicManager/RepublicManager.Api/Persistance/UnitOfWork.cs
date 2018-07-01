using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepublicManager.Api.Core;
using RepublicManager.Api.Core.Repositories;
using RepublicManager.Api.Persistance.Repositories;

namespace RepublicManager.Api.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepublicManagerContext _context;

        //here the unit of work will instaniate the repositories and use it across all of the application
        public UnitOfWork(RepublicManagerContext context)
        {
            _context = context;
            //Example Below
            Republicas = new RepublicaRepositorio(_context);
            

        }
        //The repositories used in the application must be set here , Example Below
        public IRepublicaRepositorio Republicas { get; set; }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {

            _context.Dispose();
        }
    }
}
