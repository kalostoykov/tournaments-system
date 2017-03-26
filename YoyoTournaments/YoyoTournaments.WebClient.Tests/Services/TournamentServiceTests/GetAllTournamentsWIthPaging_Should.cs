using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YoyoTournaments.WebClient.Tests.Helpers;
using YoyoTournaments.Models;
using YoyoTournaments.Data.Contracts;
using Moq;
using YoyoTournaments.Services.Contracts;
using YoyoTournaments.Services;
using System.Linq;

namespace YoyoTournaments.WebClient.Tests.Services.TournamentServiceTests
{
    /// <summary>
    /// Summary description for GetAllTournamentsWIthPaging_Should
    /// </summary>
    [TestClass]
    public class GetAllTournamentsWIthPaging_Should
    {
        public GetAllTournamentsWIthPaging_Should()
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

        //[TestMethod]
        //public void ReturnCountEqualsToOne_WhenTournamentsCountainsOneTournament()
        //{
        //    // Arrange
        //    int expectedCount = 1;
        //    int page = 1;
        //    int pageSize = 1;

        //    Guid id = Guid.NewGuid();
        //    Guid countryId = Guid.NewGuid();

        //    Tournament expectedTournament = new Tournament
        //    {
        //        Id = id,
        //        Name = "Test tournament",
        //        StartDate = DateTime.Now,
        //        EndDate = DateTime.Now,
        //        Place = "Test place",
        //        CountryId = countryId
        //    };

        //    var expectedTournaments = new List<Tournament>()
        //    {
        //        expectedTournament
        //    };

        //    var tournamentDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(expectedTournaments);
        //    tournamentDbSetMock.Setup(x => x.ToList()).Returns(expectedTournaments);

        //    var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();
        //    yoyoTournamentsDbContextMock.Setup(x => x.Tournaments.ToList()).Returns(tournamentDbSetMock.Object.ToList());

        //    var divisionTypeServiceMock = new Mock<IDivisionTypeService>();

        //    var tournamentService = new TournamentService(yoyoTournamentsDbContextMock.Object, divisionTypeServiceMock.Object);

        //    // Act
        //    var actualCount = 0;
        //    var actualTournaments = tournamentService.GetAllTournamentsWIthPaging(out actualCount, page, pageSize);

        //    // Assert
        //    Assert.AreEqual(expectedCount, actualCount);
        //}
    }
}
