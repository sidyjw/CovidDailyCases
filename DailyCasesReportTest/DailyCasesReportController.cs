using API.Controllers;
using Microsoft.AspNetCore.Mvc;
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
            var controller = new DailyCasesReportController();

            //Act
            var actionResult = controller.Get();

            //Assert
            var result = actionResult as OkObjectResult;
            Assert.Equal("Fullstack Challenge 2021 🏅 - Covid Daily Cases", result.Value);
        }
    }
}
