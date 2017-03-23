using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YoyoTournaments.Models;
using YoyoTournaments.WebClient.Tests.Helpers;
using Moq;
using YoyoTournaments.Data.Contracts;
using YoyoTournaments.Services;
using YoyoTournaments.Services.Contracts;

namespace YoyoTournaments.WebClient.Tests.Services.TournamentServiceTests
{
    /// <summary>
    /// Summary description for GetTournamentById_Should
    /// </summary>
    [TestClass]
    public class GetTournamentById_Should
    {
        public GetTournamentById_Should()
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
        public void ReturnTournamentWithProvidedId()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid countryId = Guid.NewGuid();

            Tournament expectedTournament = new Tournament
            {
                Id = id,
                Name = "Test tournament",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Place = "Test place",
                CountryId = countryId
            };

            var tournamentDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(new List<Tournament>() { expectedTournament });
            tournamentDbSetMock.Setup(x => x.Find(expectedTournament.Id)).Returns(expectedTournament);

            var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();
            yoyoTournamentsDbContextMock.Setup(x => x.Tournaments).Returns(tournamentDbSetMock.Object);

            var divisionTypeServiceMock = new Mock<IDivisionTypeService>();

            var tournamentService = new TournamentService(yoyoTournamentsDbContextMock.Object, divisionTypeServiceMock.Object);

            // Act
            var actualTournament = tournamentService.GetTournamentById(id);

            // Assert
            Assert.AreSame(expectedTournament, actualTournament);
        }

        [TestMethod]
        public void ReturnNullWhenWithTournamentIdIsNotFound()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid countryId = Guid.NewGuid();

            Tournament expectedTournament = new Tournament
            {
                Id = id,
                Name = "Test tournament",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Place = "Test place",
                CountryId = countryId
            };

            var tournamentDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(new List<Tournament>() { expectedTournament });
            tournamentDbSetMock.Setup(x => x.Find(Guid.NewGuid())).Returns((Tournament)null);

            var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();
            yoyoTournamentsDbContextMock.Setup(x => x.Tournaments).Returns(tournamentDbSetMock.Object);

            var divisionTypeServiceMock = new Mock<IDivisionTypeService>();

            var tournamentService = new TournamentService(yoyoTournamentsDbContextMock.Object, divisionTypeServiceMock.Object);

            // Act
            var actualTournament = tournamentService.GetTournamentById(id);

            // Assert
            Assert.IsNull(actualTournament);
        }
    }
}
