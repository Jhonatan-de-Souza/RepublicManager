using System;
using System.Collections.Generic;
using System.Linq;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Persistance.Repositories;

namespace RepublicManager.Api.Core.Resources
{
    public class ContaResource : Base
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
       
        public IEnumerable<ContaAPagarResource> ContasAPagar { get; set; }
        public IEnumerable<ContaAReceberResource> ContasAReceber { get; set; }

    }

    public static class ContaMapper
    {
        public static ContaResource ModelToResource(Conta conta)
        {
            var contaResource = new ContaResource()
            {
                UsuarioId = conta.UsuarioId,
                ContasAPagar = conta.ContasAPagar == null ? null : conta.ContasAPagar.Select(ContaAPagarMapper.ModelToResource) ,
                ContasAReceber = conta.ContasAReceber == null ? null : conta.ContasAReceber.Select(ContaAReceberMapper.ModelToResource),

                Id = conta.Id,
                IsAtivo = conta.IsAtivo,
                CriadoPor = conta.CriadoPor,
                DataRegistro = conta.DataRegistro
            };
            return contaResource;
        }

        public static Conta ResourceToModel(ContaResource contaResource, Conta conta)
        {

            conta.UsuarioId = contaResource.UsuarioId > 0 ? contaResource.UsuarioId : conta.UsuarioId;
            conta.Id = contaResource.Id > 0 ? contaResource.Id : conta.Id;
            conta.IsAtivo = contaResource.IsAtivo;
            conta.CriadoPor = contaResource.CriadoPor;
            conta.DataRegistro = contaResource.DataRegistro;

            return conta;
        }

    }

}
