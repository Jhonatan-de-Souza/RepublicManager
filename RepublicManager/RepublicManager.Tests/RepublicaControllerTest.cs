using RepublicManager.Api.Controllers;
using RepublicManager.Api.Core;
using RepublicManager.Api.Persistance;
using System;
using System.Linq;
using Xunit;

namespace RepublicManager.Tests
{
    public class RepublicaControllerTest
    {
        private readonly IUnitOfWork unitOfWork;
        [Fact(DisplayName = "Deve retornar uma Republica")]
        public void Deve_retornar_uma_republica()
        {
            bool existe;

            using (var contexto = Carregar.DadosMemoria())
            using (var republica = new RepublicaController(unitOfWork))
            {
                var pessoaPTBR = republica.Get(1);

                if (pessoaPTBR != null)
                {
                    existe = true;
                }
                else
                {
                    existe = false;
                }
            }
            Assert.True(existe);

        }

        /*
        [Theory(DisplayName = "Deve retornar  a pessoa pelo nome")]
        [InlineData("Junior")]
        public void deve_retornar_a_pessoa_pelo_nome(string nome)
        {


            using (var contexto = Carregar.DadosMemoria())
            using (var pessoa = new PessoaController(contexto))
            {
                var pessoaporNome = pessoa.porNome(nome);

                Assert.NotNull(pessoaporNome);
                Assert.NotEmpty(pessoaporNome.Nome);
            }
        }*/

    }
}