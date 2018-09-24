using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Persistance.Repositories
{
    public class UserRepositorio : RepositorioBase<User>,IUserRepositorio
    {
        private readonly RepublicManagerContext _republicManagerContext;
        public UserRepositorio(RepublicManagerContext republicManagerContext) : base(republicManagerContext)
        {
            _republicManagerContext = republicManagerContext;
        }

        public User GetById(string userId)
        {
            return _republicManagerContext.Users.FirstOrDefault( x => x.UserId == userId);
        }
    }
}
