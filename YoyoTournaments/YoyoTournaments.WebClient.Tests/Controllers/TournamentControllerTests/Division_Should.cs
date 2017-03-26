using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YoyoTournaments.Services.Contracts;
using Moq;
using YoyoTournaments.WebClient.Controllers;
using TestStack.FluentMVCTesting;
using YoyoTournaments.Models;
using YoyoTournaments.WebClient.Models;

namespace YoyoTournaments.WebClient.Tests.Controllers.TournamentControllerTests
{
    /// <summary>
    /// Summary description for Division_Should
    /// </summary>
    [TestClass]
    public class Division_Should
    {
        public Division_Should()
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
        public void ReturnErrorView_WhenTheIdIsNull()
        {
            // Arrange
            var expectedId = Guid.Empty;
            var page = 1;
            var pageSize = 1;
            var tournamentServiceMock = new Mock<ITournamentService>();

            var divisionServiceMock = new Mock<IDivisionService>();

            var controller = new TournamentController(tournamentServiceMock.Object, divisionServiceMock.Object);

            // Act & Assert
            controller
                .WithCallTo(x => x.Division(expectedId, page, pageSize))
                .ShouldRenderView("Error");
        }

        [TestMethod]
        public void CallGetDivisionByIdOnce()
        {
            var expectedDivision = new Division
            {
                Id = Guid.NewGuid(),
                DivisionTypeId = Guid.NewGuid(),
                TournamentId = Guid.NewGuid()
            };
            var page = 1;
            var pageSize = 1;

            var tournamentServiceMock = new Mock<ITournamentService>();

            var divisionServiceMock = new Mock<IDivisionService>();
            divisionServiceMock.Setup(x => x.GetDivisionById(expectedDivision.Id)).Returns(expectedDivision);

            var controller = new TournamentController(tournamentServiceMock.Object, divisionServiceMock.Object);

            // Act
            controller.Division(expectedDivision.Id, page, pageSize);

            // Assert
            divisionServiceMock.Verify(x => x.GetDivisionById(expectedDivision.Id), Times.Once);
        }

        [TestMethod]
        public void ReturnDivisionWithDivisionDetailsViewModel()
        {
            var expectedDivision = new Division
            {
                Id = Guid.NewGuid(),
                DivisionTypeId = Guid.NewGuid(),
                TournamentId = Guid.NewGuid()
            };
            var page = 1;
            var pageSize = 1;

            var tournamentServiceMock = new Mock<ITournamentService>();

            var divisionServiceMock = new Mock<IDivisionService>();
            divisionServiceMock.Setup(x => x.GetDivisionById(expectedDivision.Id)).Returns(expectedDivision);

            var controller = new TournamentController(tournamentServiceMock.Object, divisionServiceMock.Object);

            // Act & Assert
            controller
                .WithCallTo(x => x.Division(expectedDivision.Id, page, pageSize))
                .ShouldRenderDefaultView()
                .WithModel<DivisionDetailsViewModel>();
        }
    }
}
