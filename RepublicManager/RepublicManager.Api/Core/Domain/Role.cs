using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicManager.Api.Core.Domain
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public List<UsuarioRole> Usuarios { get; set; }
    }
}
