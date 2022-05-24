using API.Controllers;
using Application.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace DailyCasesReportTest
{
    public class DailyCasesReportControllerTest
    {
        [Fact]
        public void Get_Returns_StringMessage()
        {
            //Arrange
            var mediatorMock = new Mock<IMediator>();
            var controller = new DailyCasesReportController(mediatorMock.Object);

            //Act
            var actionResult = controller.Get();

            //Assert
            var result = actionResult as OkObjectResult;
            Assert.Equal("Fullstack Challenge 2021 🏅 - Covid Daily Cases", result.Value);
        }
    }
}
