using System;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Resources
{
    public class ContaAReceberResource :Base
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public int TipoContaId { get; set; }
        public virtual TipoContaResource TipoConta { get; set; }
        public int ContaId { get; set; }
        }



    public static class ContaAReceberMapper
    {
        public static ContaAReceberResource ModelToResource(ContaAReceber contaAReceber)
        {
            var contaAReceberResource = new ContaAReceberResource()
            {
                Valor = contaAReceber.Valor,
                TipoContaId = contaAReceber.TipoContaId,
                TipoConta = TipoContaMapper.ModelToResource(contaAReceber.TipoConta),
                ContaId = contaAReceber.ContaId,

                Id = contaAReceber.Id,
                IsAtivo = contaAReceber.IsAtivo,
                CriadoPor = contaAReceber.CriadoPor,
                DataRegistro = contaAReceber.DataRegistro
            };
            return contaAReceberResource;
        }
        public static ContaAReceber ResourceToModel(ContaAReceberResource contaAReceberResource, ContaAReceber contaAReceber)
        {

            contaAReceber.Valor = contaAReceberResource.Valor;
            contaAReceber.TipoContaId = contaAReceberResource.TipoContaId;
            contaAReceber.ContaId = contaAReceberResource.ContaId;

            contaAReceber.Id = contaAReceberResource.Id;
            contaAReceber.IsAtivo = contaAReceberResource.IsAtivo;
            contaAReceber.CriadoPor = contaAReceberResource.CriadoPor;
            contaAReceber.DataRegistro = contaAReceberResource.DataRegistro;

            return contaAReceber;
        }
    }
}
