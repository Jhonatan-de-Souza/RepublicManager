
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
        }

        [Fact]
        public async Task Values_Get_All()
        {

            // Act
            var result = await _republicaController.GetAll();
            result.Should().BeOfType<OkObjectResult>();

        }
    }
}
