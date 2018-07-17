using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RepublicManager.Api.Controllers;
using RepublicManager.Api.Core;
using RepublicManager.Api.Core.Domain;
using RepublicManager.Api.Core.Repositories;

namespace RepublicManager.Tests
{
    [TestClass]
    public class RepublicaControllerTest
    {
        private readonly RepublicaController _republicaController;
        public RepublicaControllerTest()
        {
            var mockRepository = new Mock<IRepublicaRepositorio>();
            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(a => a.Republicas).Returns(mockRepository.Object);
            _republicaController = new RepublicaController(mockUoW.Object);
        }

        [TestMethod]
        public async Task GetAll_returnsSuccess()
        {
            var result = await _republicaController.GetAll();
            //result.Should().
        }
    }
}
