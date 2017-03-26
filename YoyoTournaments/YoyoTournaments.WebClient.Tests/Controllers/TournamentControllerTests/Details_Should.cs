using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using YoyoTournaments.Services.Contracts;
using YoyoTournaments.Models;
using YoyoTournaments.WebClient.Controllers;
using TestStack.FluentMVCTesting;
using YoyoTournaments.WebClient.Models;

namespace YoyoTournaments.WebClient.Tests.Controllers.TournamentControllerTests
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
        public void CallGetTournamentByIdOnce()
        {
            // Arrange
            var expectedTournament = new Tournament
            {
                Id = Guid.NewGuid(),
                Name = "Test name",
                Place = "Test place",
                StartDate = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0, 0)),
                EndDate = DateTime.Now.Add(new TimeSpan(2, 0, 0, 0, 0)),
                CountryId = Guid.NewGuid()
            };

            var tournamentServiceMock = new Mock<ITournamentService>();
            tournamentServiceMock.Setup(x => x.GetTournamentById(expectedTournament.Id)).Returns(expectedTournament);

            var divisionServiceMock = new Mock<IDivisionService>();

            var controller = new TournamentController(tournamentServiceMock.Object, divisionServiceMock.Object);

            // Act
            controller.Details(expectedTournament.Id);

            // Assert
            tournamentServiceMock.Verify(x => x.GetTournamentById(expectedTournament.Id), Times.Once);

        }

        [TestMethod]
        public void ReturnDetailsWithTournamentDetailsViewModel()
        {
            // Arrange
            var expectedTournament = new Tournament
            {
                Id = Guid.NewGuid(),
                Name = "Test name",
                Place = "Test place",
                StartDate = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0, 0)),
                EndDate = DateTime.Now.Add(new TimeSpan(2, 0, 0, 0, 0)),
                CountryId = Guid.NewGuid()
            };

            var tournamentServiceMock = new Mock<ITournamentService>();
            tournamentServiceMock.Setup(x => x.GetTournamentById(expectedTournament.Id)).Returns(expectedTournament);

            var divisionServiceMock = new Mock<IDivisionService>();

            var controller = new TournamentController(tournamentServiceMock.Object, divisionServiceMock.Object);

            // Act & Assert
            controller
                .WithCallTo(x => x.Details(expectedTournament.Id))
                .ShouldRenderDefaultView()
                .WithModel<TournamentDetailsViewModel>();
        }

        [TestMethod]
        public void ReturnErrorView_WhenTheIdIsNull()
        {
            // Arrange
            var expectedId = Guid.Empty;
            var tournamentServiceMock = new Mock<ITournamentService>();

            var divisionServiceMock = new Mock<IDivisionService>();

            var controller = new TournamentController(tournamentServiceMock.Object, divisionServiceMock.Object);

            // Act & Assert
            controller
                .WithCallTo(x => x.Details(expectedId))
                .ShouldRenderView("Error");
        }
    }
}
