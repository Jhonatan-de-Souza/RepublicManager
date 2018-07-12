using System;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Resources
{
    public class ContaAReceberResource
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioResource Usuario { get; set; }
        public int TipoContaId { get; set; }
        public TipoContaResource TipoConta { get; set; }
        public ContaAReceberResource()
        {
            isAtivo = true;
        }
        public DateTime DataRegistro { get; set; }
        public bool isAtivo { get; set; }
        public int CriadoPor { get; set; }
    }



    public static class ContaAReceberMapper
    {
        public static ContaAReceberResource ModelToResource(ContaAReceber contaAReceber)
        {
            var contaAReceberResource = new ContaAReceberResource()
            {
                Valor = contaAReceber.Valor,
                UsuarioId = contaAReceber.UsuarioId,
                TipoContaId = contaAReceber.TipoContaId,

                Id = contaAReceber.Id,
                isAtivo = contaAReceber.IsAtivo,
                CriadoPor = contaAReceber.CriadoPor,
                DataRegistro = contaAReceber.DataRegistro
            };
            return contaAReceberResource;
        }
        public static ContaAReceber ResourceToModel(ContaAReceberResource contaAReceberResource, ContaAReceber contaAReceber)
        {

            contaAReceber.Valor = contaAReceberResource.Valor;
            contaAReceber.UsuarioId = contaAReceberResource.UsuarioId;
            contaAReceber.TipoContaId = contaAReceberResource.TipoContaId;

            contaAReceber.Id = contaAReceberResource.Id;
            contaAReceber.IsAtivo = contaAReceberResource.isAtivo;
            contaAReceber.CriadoPor = contaAReceberResource.CriadoPor;
            contaAReceber.DataRegistro = contaAReceberResource.DataRegistro;

            return contaAReceber;
        }
    }
}
