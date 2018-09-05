using RepublicManager.Api.Core.Domain;
using System;

namespace RepublicManager.Api.Core.Resources
{
    public class UsuarioResource : Base
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataFinalContrato { get; set; }
        public int? ContaId { get; set; }
        public virtual ContaResource Conta { get; set; }
        public int? RepublicaId { get; set; }

    }
    public static class UsuarioMapper
    {
        public static UsuarioResource ModelToResource(Usuario usuario)
        {
            var usuarioResource = new UsuarioResource()
            {
                Login = usuario.Login,
                Senha = usuario.Senha,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataFinalContrato = usuario.DataFinalContrato,
                ContaId = usuario.ContaId,
                Conta = usuario.Conta == null ? null : ContaMapper.ModelToResource(usuario.Conta) ,
                RepublicaId = usuario.RepublicaId,

                Id = usuario.Id,
                IsAtivo = usuario.IsAtivo,
                CriadoPor = usuario.CriadoPor,
                DataRegistro = usuario.DataRegistro
            };
            return usuarioResource;
        }
        public static Usuario ResourceToModel(UsuarioResource usuarioResource, Usuario usuario)
        {

            usuario.Login = usuarioResource.Login ?? usuario.Login;
            usuario.Senha = usuarioResource.Senha ?? usuario.Senha;
            usuario.Nome = usuarioResource.Nome ?? usuario.Nome;
            usuario.DataFinalContrato = usuarioResource.DataFinalContrato;
            usuario.ContaId = usuarioResource.ContaId ?? usuario.ContaId;
            usuario.RepublicaId = usuarioResource.RepublicaId ?? usuario.RepublicaId;
            usuario.Email = usuarioResource.Email ?? usuario.Email;
            //this logig is wrong
            usuario.Id = (usuario.Id > 0) ? usuario.Id : usuarioResource.Id;
            usuario.IsAtivo = usuarioResource.IsAtivo;
            usuario.CriadoPor = usuarioResource.CriadoPor > 0 ? usuarioResource.CriadoPor : usuario.CriadoPor;
            usuario.DataRegistro = (usuarioResource.Id > 0) ? usuario.DataRegistro : DateTime.Now;

            return usuario;
        }
    }
}
