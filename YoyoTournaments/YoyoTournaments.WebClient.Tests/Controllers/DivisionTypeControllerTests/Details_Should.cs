using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YoyoTournaments.Services.Contracts;
using Moq;
using YoyoTournaments.WebClient.Controllers;
using YoyoTournaments.Models;
using TestStack.FluentMVCTesting;
using YoyoTournaments.WebClient.Models;

namespace YoyoTournaments.WebClient.Tests.Controllers.DivisionTypeControllerTests
{
    /// <summary>
    /// Summary description for Details_Should
    /// </summary>
    [TestClass]
    public class Details_Should
    {
        public Details_Should()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CallGetDivisionTypeByIdOnce()
        {
            // Arrange
            var expectedDivisionType = new DivisionType
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Description = "Test description"
            };

            var divisionTypeServiceMock = new Mock<IDivisionTypeService>();
            divisionTypeServiceMock
                .Setup(x => x.GetDivisionTypeById(expectedDivisionType.Id))
                .Returns(expectedDivisionType);

            var controller = new DivisionTypeController(divisionTypeServiceMock.Object);

            // Act
            controller.Details(expectedDivisionType.Id);

            // Assert
            divisionTypeServiceMock.Verify(x => x.GetDivisionTypeById(expectedDivisionType.Id), Times.Once);
        }

        [TestMethod]
        public void ReturnDetailsWithDivisionTypeDetailsViewModel()
        {
            // Arrange
            var expectedDivisionType = new DivisionType
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Description = "Test description"
            };

            var divisionTypeServiceMock = new Mock<IDivisionTypeService>();
            divisionTypeServiceMock
                .Setup(x => x.GetDivisionTypeById(expectedDivisionType.Id))
                .Returns(expectedDivisionType);

            var controller = new DivisionTypeController(divisionTypeServiceMock.Object);

            // Act & Assert
            controller
                .WithCallTo(x => x.Details(expectedDivisionType.Id))
                .ShouldRenderDefaultView()
                .WithModel<DivisionTypeDetailsViewModel>();
        }
    }
}
