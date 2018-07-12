using RepublicManager.Api.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicManager.Api.Core.Resources
{
    public class UsuarioResource : Base
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime DataFinalContrato { get; set; }

    }
    public static class UsuarioMapper
    {
        public static UsuarioResource ModelToResource(Usuario usuario)
        {
            var usuarioResource = new UsuarioResource()
            {
                Login = usuario.Login,
                Senha = usuario.Senha,
                DataFinalContrato = usuario.DataFinalContrato,

                Id = usuario.Id,
                IsAtivo = usuario.IsAtivo,
                CriadoPor = usuario.CriadoPor,
                DataRegistro = usuario.DataRegistro
            };
            return usuarioResource;
        }
        public static Usuario ResourceToModel(UsuarioResource usuarioResource, Usuario usuario)
        {

            usuario.Login = usuarioResource.Login;
            usuario.Senha = usuarioResource.Senha;
            usuario.DataFinalContrato = usuarioResource.DataFinalContrato;

            usuario.Id = usuarioResource.Id;
            usuario.IsAtivo = usuarioResource.IsAtivo;
            usuario.CriadoPor = usuarioResource.CriadoPor;
            usuario.DataRegistro = (usuarioResource.Id > 0) ? usuario.DataRegistro : DateTime.Now;

            return usuario;
        }
    }
}
