using System;
using System.Collections.Generic;
using System.Linq;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Resources
{
    public class RepublicaResource : Base
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Vagas { get; set; }
        public virtual IEnumerable<RegraResource> Regras { get; set; }
        public virtual IEnumerable<AvisoResource> Avisos { get; set; }
        public virtual IEnumerable<UsuarioResource> Usuarios { get; set; }
        public virtual IEnumerable<CarrinhoDeCompraResource> CarrinhosDeCompra { get; set; }
    }

    public static class RepublicaMapper
    {
        public static RepublicaResource ModelToResource(Republica republica)
        {
            var republicaResource = new RepublicaResource()
            {
                Nome = republica.Nome,
                Vagas = republica.Vagas,
                Regras = republica.Regras == null ? null : republica.Regras.Select(RegraMapper.ModelToResource),
                Avisos = republica.Avisos == null ? null : republica.Avisos.Select(AvisoMapper.ModelToResource),

                Usuarios = republica.Usuarios == null ? null : republica.Usuarios.Select(UsuarioMapper.ModelToResource),
                CarrinhosDeCompra = republica.CarrinhosDeCompra == null ? null : republica.CarrinhosDeCompra.Select(CarrinhoDeCompraMapper.ModelToResource),

                Id = republica.Id,
                IsAtivo = republica.IsAtivo,
                CriadoPor = republica.CriadoPor,
                DataRegistro = republica.DataRegistro
            };
            return republicaResource;
        }
        public static Republica ResourceToModel(RepublicaResource republicaResource, Republica republica)
        {

            republica.Nome = republicaResource.Nome ?? republica.Nome;
            republica.Vagas = republicaResource.Vagas == 0 ? republica.Vagas : republicaResource.Vagas;
            republica.Id = (republica.Id > 0) ? republica.Id : republicaResource.Id;
            republica.IsAtivo = republicaResource.IsAtivo;
            republica.CriadoPor = republicaResource.CriadoPor > 0 ? republicaResource.CriadoPor : republica.CriadoPor;
            republica.DataRegistro = (republicaResource.Id > 0) ? republica.DataRegistro : DateTime.Now;

            return republica;
        }
    }

}


