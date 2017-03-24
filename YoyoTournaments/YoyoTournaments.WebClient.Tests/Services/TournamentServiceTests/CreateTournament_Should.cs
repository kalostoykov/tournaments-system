using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YoyoTournaments.Services;
using Moq;
using YoyoTournaments.Data.Contracts;
using YoyoTournaments.Services.Contracts;
using MSTestExtensions;
using YoyoTournaments.Models;
using YoyoTournaments.WebClient.Tests.Helpers;

namespace YoyoTournaments.WebClient.Tests.Services.TournamentServiceTests
{
    /// <summary>
    /// Summary description for CreateTournament_Should
    /// </summary>
    [TestClass]
    public class CreateTournament_Should
    {
        public CreateTournament_Should()
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
        public void ThrowArgumentException_WhenTheTournamentNameIsNullOrEmpty()
        {
            // Arrange
            var expectedTournament = new Tournament
            {
                Name = String.Empty,
                Place = "TestPlace",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                CountryId = Guid.NewGuid()
            };

            var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();
            var divisionTypeService = new Mock<IDivisionTypeService>();

            var tournamentService = new TournamentService(yoyoTournamentsDbContextMock.Object, divisionTypeService.Object);

            // Act & Assert
            ThrowsAssert.Throws<ArgumentException>(
                () => tournamentService.CreateTournament(expectedTournament.Name,
                    expectedTournament.Place,
                    expectedTournament.StartDate,
                    expectedTournament.EndDate,
                    expectedTournament.CountryId)
            );
        }

        [TestMethod]
        public void ThrowArgumentException_WhenTheTournamentPlaceIsNullOrEmpty()
        {
            // Arrange
            var expectedTournament = new Tournament
            {
                Name = "Test name",
                Place = String.Empty,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                CountryId = Guid.NewGuid()
            };

            var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();
            var divisionTypeService = new Mock<IDivisionTypeService>();

            var tournamentService = new TournamentService(yoyoTournamentsDbContextMock.Object, divisionTypeService.Object);

            // Act & Assert
            ThrowsAssert.Throws<ArgumentException>(
                () => tournamentService.CreateTournament(expectedTournament.Name,
                    expectedTournament.Place,
                    expectedTournament.StartDate,
                    expectedTournament.EndDate,
                    expectedTournament.CountryId)
            );
        }

        [TestMethod]
        public void ThrowArgumentOutOfRangeException_WhenTheTournamentStartDateIsLessThenDateTimeNow()
        {
            // Arrange
            var expectedTournament = new Tournament
            {
                Name = "Test name",
                Place = "Test place",
                StartDate = new DateTime(2017, 3, 3),
                EndDate = DateTime.Now,
                CountryId = Guid.NewGuid()
            };

            var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();
            var divisionTypeService = new Mock<IDivisionTypeService>();

            var tournamentService = new TournamentService(yoyoTournamentsDbContextMock.Object, divisionTypeService.Object);

            // Act & Assert
            ThrowsAssert.Throws<ArgumentOutOfRangeException>(
                () => tournamentService.CreateTournament(expectedTournament.Name,
                    expectedTournament.Place,
                    expectedTournament.StartDate,
                    expectedTournament.EndDate,
                    expectedTournament.CountryId)
            );
        }

        [TestMethod]
        public void ThrowArgumentOutOfRangeException_WhenTheTournamentEndDateIsLessThenStartDate()
        {
            // Arrange
            var expectedTournament = new Tournament
            {
                Name = "Test name",
                Place = "Test place",
                StartDate = new DateTime(2017, 4, 3),
                EndDate = new DateTime(2017, 3, 3),
                CountryId = Guid.NewGuid()
            };

            var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();
            var divisionTypeService = new Mock<IDivisionTypeService>();

            var tournamentService = new TournamentService(yoyoTournamentsDbContextMock.Object, divisionTypeService.Object);

            // Act & Assert
            ThrowsAssert.Throws<ArgumentOutOfRangeException>(
                () => tournamentService.CreateTournament(expectedTournament.Name,
                    expectedTournament.Place,
                    expectedTournament.StartDate,
                    expectedTournament.EndDate,
                    expectedTournament.CountryId)
            );
        }

        //[TestMethod]
        //public void ThrowArgumentException_WhenTheListWIthDivisionTypesIsNullOrEmpty()
        //{
        //    // Arrange
        //    var expectedTournament = new Tournament
        //    {
        //        Name = "Test name",
        //        Place = "Test place",
        //        StartDate = DateTime.Now,
        //        EndDate = DateTime.Now.Add(new TimeSpan(1, 0, 0, 0, 0)),
        //        CountryId = Guid.NewGuid()
        //    };

        //    var divisionTypes = new List<DivisionType>()
        //    {
        //        new DivisionType()
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "TestName",
        //            Description = "TestName"
        //        }
        //    };


        //    var divisionTypeDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(divisionTypes);

        //    var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();
        //    yoyoTournamentsDbContextMock.Setup(x => x.DivisionTypes).Returns(divisionTypeDbSetMock.Object);

        //    var divisionTypeServiceMock = new Mock<IDivisionTypeService>();
        //    divisionTypeServiceMock.SetupAllProperties();
        //    divisionTypeServiceMock.Setup(x => x.GetAllDivisionTypes()).Returns(divisionTypeDbSetMock.Object);


        //    var tournamentService = new TournamentService(yoyoTournamentsDbContextMock.Object, divisionTypeServiceMock.Object);

        //    // Act & Assert
        //    ThrowsAssert.Throws<NullReferenceException>(
        //        () => tournamentService.CreateTournament(expectedTournament.Name,
        //            expectedTournament.Place,
        //            expectedTournament.StartDate,
        //            expectedTournament.EndDate,
        //            expectedTournament.CountryId)
        //    );
        //}
    }
}
