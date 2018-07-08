using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RepublicManager.Api.Controllers;
using RepublicManager.Api.Core;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Tests
{
    [TestClass]
    public class AvisoControllerTest
    {
        private AvisoController _avisoController;

        public AvisoControllerTest()
        {
            //In order to use a mock implementation of a Unit Of work you must 
            // first create a mock representation of it and pass it Object instance to where it needs to be used
            var mockRepository = new Mock<IAvisoRepositorio>();
            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(a => a.Avisos).Returns(mockRepository.Object);
            _avisoController = new AvisoController(mockUoW.Object);
        }
        [TestMethod]
        public async Task Get_NoAvisoWithGiveIdExists_returnsNotFound()
        {
            var result = await _avisoController.Get(1);
            result.Should().BeOfType<NotFoundResult>();
        }

        [TestMethod]
        public async Task MethodName_Condition_ExpectedResult()
        {

        }

    }
}
