using System;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Resources
{
    public class ContaAPagarResource
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioResource Usuario { get; set; }
        public int TipoContaId { get; set; }
        public TipoContaResource TipoConta { get; set; }
        public int ContaId { get; set; }
        public virtual ContaResource Conta { get; set; }
        public ContaAPagarResource()
        {
            isAtivo = true;
        }
        public DateTime DataRegistro { get; set; }
        public bool isAtivo { get; set; }
        public int CriadoPor { get; set; }
    }



    public static class ContaAPagarMapper
    {
        public static ContaAPagarResource ModelToResource(ContaAPagar contaAPagar)
        {
            var contaAPagarResource = new ContaAPagarResource()
            {
                Valor = contaAPagar.Valor,
                UsuarioId = contaAPagar.UsuarioId,
                TipoContaId = contaAPagar.TipoContaId,
                ContaId = contaAPagar.ContaId,

                Id = contaAPagar.Id,
                isAtivo = contaAPagar.IsAtivo,
                CriadoPor = contaAPagar.CriadoPor,
                DataRegistro = contaAPagar.DataRegistro
            };
            return contaAPagarResource;
        }
        public static ContaAPagar ResourceToModel(ContaAPagarResource contaAPagarResource, ContaAPagar contaAPagar)
        {

            contaAPagar.Valor = contaAPagarResource.Valor;
            contaAPagar.UsuarioId = contaAPagarResource.UsuarioId;
            contaAPagar.TipoContaId = contaAPagarResource.TipoContaId;
            contaAPagar.ContaId = contaAPagarResource.ContaId;

            contaAPagar.Id = contaAPagarResource.Id;
            contaAPagar.IsAtivo = contaAPagarResource.isAtivo;
            contaAPagar.CriadoPor = contaAPagarResource.CriadoPor;
            contaAPagar.DataRegistro = contaAPagarResource.DataRegistro;

            return contaAPagar;
        }
    }
}
