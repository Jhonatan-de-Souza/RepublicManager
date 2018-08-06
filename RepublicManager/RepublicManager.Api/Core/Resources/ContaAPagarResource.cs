using System;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Resources
{
    public class ContaAPagarResource : Base
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public int TipoContaId { get; set; }
        public virtual TipoContaResource TipoConta { get; set; }
        public int ContaId { get; set; }
        
    }



    public static class ContaAPagarMapper
    {
        public static ContaAPagarResource ModelToResource(ContaAPagar contaAPagar)
        {
            var contaAPagarResource = new ContaAPagarResource()
            {
                Valor = contaAPagar.Valor,
                TipoContaId = contaAPagar.TipoContaId,
                TipoConta =  TipoContaMapper.ModelToResource(contaAPagar.TipoConta),
                ContaId = contaAPagar.ContaId,
                
                Id = contaAPagar.Id,
                IsAtivo = contaAPagar.IsAtivo,
                CriadoPor = contaAPagar.CriadoPor,
                DataRegistro = contaAPagar.DataRegistro
            };
            return contaAPagarResource;
        }
        public static ContaAPagar ResourceToModel(ContaAPagarResource contaAPagarResource, ContaAPagar contaAPagar)
        {

            contaAPagar.Valor = contaAPagarResource.Valor;
            contaAPagar.TipoContaId = contaAPagarResource.TipoContaId;
            contaAPagar.ContaId = contaAPagarResource.ContaId;

            contaAPagar.Id = contaAPagarResource.Id;
            contaAPagar.IsAtivo = contaAPagarResource.IsAtivo;
            contaAPagar.CriadoPor = contaAPagarResource.CriadoPor;
            contaAPagar.DataRegistro = contaAPagarResource.DataRegistro;

            return contaAPagar;
        }
    }
}
