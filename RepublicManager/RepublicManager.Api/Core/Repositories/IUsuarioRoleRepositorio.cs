using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Repositories
{
    public interface IUsuarioRoleRepositorio : IRepositorioBase<UsuarioRole>
    {
        Task<IEnumerable<UsuarioRole>> GetUsuarioWithRoles();
        List<UsuarioRole> GetUsuarioWithRolesById(int usuarioId);
    }
}
