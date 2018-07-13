using System;
using System.Collections.Generic;
using System.Linq;
using RepublicManager.Api.Core.Domain;

namespace RepublicManager.Api.Core.Resources
{
    public class ContaResource
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioResource Usuario { get; set; }
        public IEnumerable<ContaAPagarResource> ContasAPagar { get; set; }
        public IEnumerable<ContaAReceberResource> ContasAReceber { get; set; }

        public ContaResource()
        {
            isAtivo = true;
        }
        public DateTime DataRegistro { get; set; }
        public bool isAtivo { get; set; }
        public int CriadoPor { get; set; }
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

                Id = conta.Id,
                isAtivo = conta.IsAtivo,
                CriadoPor = conta.CriadoPor,
                DataRegistro = conta.DataRegistro
            };
            return contaResource;
        }
        public static Conta ResourceToModel(ContaResource contaResource, Conta conta)
        {

            conta.UsuarioId = contaResource.UsuarioId;
            //conta.ContasAPagar = contaResource.ContasAPagar.Select(c => c.ContaAPagarResourceToContaAPagar());
            //conta.ContasAReceber = contaResource.ContasAReceber.Select(c => c.ContaAReceberResourceToContaAReceber());

            conta.Id = contaResource.Id;
            conta.IsAtivo = contaResource.isAtivo;
            conta.CriadoPor = contaResource.CriadoPor;
            conta.DataRegistro = contaResource.DataRegistro;

            return conta;
        }

    }


    public static class ContaAPagarExtensions
    {
        public static ContaAPagar ContaAPagarResourceToContaAPagar(this ContaAPagarResource contaAPagarResoure)
        {
            return new ContaAPagar();
        }
    }

    public static class ContaAReceberExtensions
    {
        public static ContaAReceber ContaAReceberResourceToContaAReceber(this ContaAReceberResource contaAReceberResoure)
        {
            return new ContaAReceber();
        }
    }
}
