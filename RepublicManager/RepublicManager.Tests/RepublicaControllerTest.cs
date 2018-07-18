
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RepublicManager.Api.Controllers;
using RepublicManager.Api.Core;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;
using RepublicManager.Api.Core.Resources;
using Xunit;

namespace RepublicManager.Tests
{
    public class RepublicaControllerTest
    {
        private readonly RepublicaController _republicaController;

        public RepublicaControllerTest()
        {
            //In order to use a mock implementation of a Unit Of work you must 
            // first create a mock representation of it and pass it Object instance to where it needs to be used
            var mockRepository = new Mock<IRepublicaRepositorio>();
            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(a => a.Republicas).Returns(mockRepository.Object);
            _republicaController = new RepublicaController(mockUoW.Object);


            List<Republica> republicas = new List<Republica>();
            republicas.Add(new  Republica()
            {
                Nome = "Nome Teste",
                Vagas = 3
            });

            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(republicas);            

        }

        [Fact]
        public async Task Values_GetAll_OkResult()
        {

            // Act
            var result = await _republicaController.GetAll();
            result.Should().BeOfType<OkObjectResult>();

           /* var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var republicas = okResult.Value.Should().BeAssignableTo<List<RepublicaResource>>().Subject;


            republicas.Count().Should().Be(0);*/

        }


        [Fact]
        public async Task Values_GetAll_N_Results()
        {

            // Act
            var result = await _republicaController.GetAll();
           

            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var republicas = okResult.Value.Should().BeAssignableTo<List<RepublicaResource>>().Subject;


            republicas.Count().Should().Be(0);

        }


        /*[Fact]
  public async Task Persons_Add()
  {
    // Arrange
    var controller = new PersonsController(new PersonService());
    var newPerson = new Person
    {
      FirstName = "John",
      LastName = "Doe",
      Age = 50,
      Title = "FooBar",
      Email = "john.doe@foo.bar"
    };

    // Act
    var result = await controller.Post(newPerson);

    // Assert
    var okResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;
    var person = okResult.Value.Should().BeAssignableTo<Person>().Subject;
    person.Id.Should().Be(51);
  }

  [Fact]
  public async Task Persons_Change()
  {
    // Arrange
    var service = new PersonService();
    var controller = new PersonsController(service);
    var newPerson = new Person
    {
      FirstName = "John",
      LastName = "Doe",
      Age = 50,
      Title = "FooBar",
      Email = "john.doe@foo.bar"
    };

    // Act
    var result = await controller.Put(20, newPerson);

    // Assert
    var okResult = result.Should().BeOfType<NoContentResult>().Subject;

    var person = service.Get(20);
    person.Id.Should().Be(20);
    person.FirstName.Should().Be("John");
    person.LastName.Should().Be("Doe");
    person.Age.Should().Be(50);
    person.Title.Should().Be("FooBar");
    person.Email.Should().Be("john.doe@foo.bar");
  }

  [Fact]
  public async Task Persons_Delete()
  {
    // Arrange
    var service = new PersonService();
    var controller = new PersonsController(service);

    // Act
    var result = await controller.Delete(20);

    // Assert
    var okResult = result.Should().BeOfType<NoContentResult>().Subject;

    // should throw an eception, 
    // because the person with id==20 doesn't exist enymore
    AssertionExtensions.ShouldThrow<InvalidOperationException>(
      () => service.Get(20));
  }
}*/
    }
}
