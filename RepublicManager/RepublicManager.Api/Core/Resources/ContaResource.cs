using System;
using System.Collections.Generic;
using System.Linq;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Resources
{
    public class ContaResource : Base
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioResource Usuario { get; set; }
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
                ContasAPagar = conta.ContasAPagar.Select(ContaAPagarMapper.ModelToResource),
                ContasAReceber = conta.ContasAReceber.Select(ContaAReceberMapper.ModelToResource),
                Usuario = UsuarioMapper.ModelToResource(conta.Usuario),

                Id = conta.Id,
                IsAtivo = conta.IsAtivo,
                CriadoPor = conta.CriadoPor,
                DataRegistro = conta.DataRegistro
            };
            return contaResource;
        }

        public static Conta ResourceToModel(ContaResource contaResource, Conta conta)
        {

            conta.UsuarioId = contaResource.UsuarioId;

            conta.Id = contaResource.Id;
            conta.IsAtivo = contaResource.IsAtivo;
            conta.CriadoPor = contaResource.CriadoPor;
            conta.DataRegistro = contaResource.DataRegistro;

            return conta;
        }

    }

}
