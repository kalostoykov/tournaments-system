using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YoyoTournaments.Models;
using YoyoTournaments.WebClient.Tests.Helpers;
using Moq;
using YoyoTournaments.Services;
using YoyoTournaments.Data.Contracts;

namespace YoyoTournaments.WebClient.Tests.Services.DivisionServiceTests
{
    /// <summary>
    /// Summary description for GetDivisionById_Should
    /// </summary>
    [TestClass]
    public class GetDivisionById_Should
    {
        public GetDivisionById_Should()
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
        public void ReturnDivisionTypeWithProvidedId()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            Guid divisionTypeId = Guid.NewGuid();
            Guid tournamentId = Guid.NewGuid();

            Division expectedDivision = new Division
            {
                Id = id,
                DivisionTypeId = divisionTypeId,
                TournamentId = tournamentId
            };

            var divisionDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(new List<Division>() { expectedDivision });
            divisionDbSetMock.Setup(x => x.Find(expectedDivision.Id)).Returns(expectedDivision);

            var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();
            yoyoTournamentsDbContextMock.Setup(x => x.Divisions).Returns(divisionDbSetMock.Object);

            var divisionService = new DivisionService(yoyoTournamentsDbContextMock.Object);

            //Act
            var actualDivision = divisionService.GetDivisionById(id);

            //Assert
            Assert.AreSame(expectedDivision, actualDivision);
        }

        [TestMethod]
        public void ReturnNullWhenDivisionTypeWithIdIsNotFound()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            Guid divisionTypeId = Guid.NewGuid();
            Guid tournamentId = Guid.NewGuid();

            Division expectedDivision = new Division
            {
                Id = id,
                DivisionTypeId = divisionTypeId,
                TournamentId = tournamentId
            };

            var divisionDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(new List<Division>() { expectedDivision });
            divisionDbSetMock.Setup(x => x.Find(Guid.NewGuid())).Returns((Division)null);

            var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();
            yoyoTournamentsDbContextMock.Setup(x => x.Divisions).Returns(divisionDbSetMock.Object);

            var divisionService = new DivisionService(yoyoTournamentsDbContextMock.Object);

            //Act
            var actualDivision = divisionService.GetDivisionById(id);

            //Assert
            Assert.IsNull(actualDivision);
        }
    }
}
