using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Api.Persistance.Repositories
{
    public class UsuarioRoleRepositorio : RepositorioBase<UsuarioRole>, IUsuarioRoleRepositorio
    {
        private readonly RepublicManagerContext _republicManagerContext;

        public UsuarioRoleRepositorio(RepublicManagerContext republicManagerContext) 
            : base(republicManagerContext)
        {
            _republicManagerContext = republicManagerContext;
        }

        public async Task<IEnumerable<UsuarioRole>> GetUsuarioWithRoles()
        {
            return await _republicManagerContext.UsuarioRoles
                .Include(x => x.Role)
                .Include(x => x.Usuario).ToListAsync();
        }

        public  List<UsuarioRole> GetUsuarioWithRolesById(int usuarioId)
        {
            var results = _republicManagerContext.UsuarioRoles
                .Include(usuarioRole => usuarioRole.Role)
                .Include(usuarioRole => usuarioRole.Usuario)
                .GroupBy(usuarioRole => new
                {
                    usuarioRole.UsuarioId,
                    usuarioRole.RoleId
                })
                .Select(usuarioRole => new UsuarioRole
                {
                    UsuarioId = usuarioRole.Key.UsuarioId,
                    RoleId = usuarioRole.Key.RoleId,
                })
                .Where(usuario => usuario.UsuarioId == usuarioId);
            return results.ToList();
        }
    }
}

