using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestExtensions;
using YoyoTournaments.Data.Contracts;
using Moq;
using YoyoTournaments.Services;
using YoyoTournaments.Models;
using YoyoTournaments.WebClient.Tests.Helpers;
using System.Linq;

namespace YoyoTournaments.WebClient.Tests.Services.DivisionServiceTests
{
    /// <summary>
    /// Summary description for AddUserToDivision_Should
    /// </summary>
    [TestClass]
    public class AddUserToDivision_Should
    {
        public AddUserToDivision_Should()
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
        public void ThrowArgumentException_WhenTheUserIdIsNullOrEmpty()
        {
            // Arrange
            Guid divisionId = Guid.NewGuid();
            var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();

            var divisionService = new DivisionService(yoyoTournamentsDbContextMock.Object);
            // Act & Assert
            ThrowsAssert.Throws<ArgumentException>(() => divisionService.AddUserToDivision(String.Empty, divisionId));
        }

        [TestMethod]
        public void ReturnZero_WhenTheDivisionIsNotFound()
        {
            // Arrange
            var division = new Division
            {
                Id = Guid.NewGuid(),
                DivisionTypeId = Guid.NewGuid(),
                TournamentId = Guid.NewGuid()
            };

            var user = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Pesho",
                LastName = "Peshev",
                CountryId = Guid.NewGuid()
            };

            var divisionDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(new List<Division>() { division });
            divisionDbSetMock.Setup(x => x.Find(Guid.NewGuid())).Returns((Division)null);

            var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();
            yoyoTournamentsDbContextMock.Setup(x => x.Divisions).Returns(divisionDbSetMock.Object);

            var divisionService = new DivisionService(yoyoTournamentsDbContextMock.Object);

            // Act
            int actualResult = divisionService.AddUserToDivision(user.Id, division.Id);

            // Assert
            Assert.AreEqual(0, actualResult);
        }

        [TestMethod]
        public void ReturnZero_WhenTheUserIsNotFound()
        {
            // Arrange
            var division = new Division
            {
                Id = Guid.NewGuid(),
                DivisionTypeId = Guid.NewGuid(),
                TournamentId = Guid.NewGuid()
            };

            var user = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Pesho",
                LastName = "Peshev",
                CountryId = Guid.NewGuid(),
            };

            var divisionDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(new List<Division>() { division });
            divisionDbSetMock.Setup(x => x.Find(division.Id)).Returns(division);

            var usersDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(new List<ApplicationUser>() { user });
            usersDbSetMock.Setup(x => x.Find(Guid.NewGuid())).Returns((ApplicationUser)null);

            var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();
            yoyoTournamentsDbContextMock.Setup(x => x.Divisions).Returns(divisionDbSetMock.Object);
            yoyoTournamentsDbContextMock.Setup(x => x.Users).Returns(usersDbSetMock.Object);

            var divisionService = new DivisionService(yoyoTournamentsDbContextMock.Object);

            // Act
            int actualResult = divisionService.AddUserToDivision(user.Id, division.Id);

            // Assert
            Assert.AreEqual(0, actualResult);
        }

        [TestMethod]
        public void AddTheUserToTheDevision()
        {
            // Arrange
            var division = new Division
            {
                Id = Guid.NewGuid(),
                DivisionTypeId = Guid.NewGuid(),
                TournamentId = Guid.NewGuid()
            };

            var expectedUser = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Pesho",
                LastName = "Peshev",
                CountryId = Guid.NewGuid()
            };

            var divisionDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(new List<Division>() { division });
            divisionDbSetMock.Setup(x => x.Find(division.Id)).Returns(division);

            var usersDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(new List<ApplicationUser>() { expectedUser });
            usersDbSetMock.Setup(x => x.Find(expectedUser.Id)).Returns(expectedUser);

            var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();
            yoyoTournamentsDbContextMock.Setup(x => x.Divisions).Returns(divisionDbSetMock.Object);
            yoyoTournamentsDbContextMock.Setup(x => x.Users).Returns(usersDbSetMock.Object);

            var divisionService = new DivisionService(yoyoTournamentsDbContextMock.Object);

            // Act
            divisionService.AddUserToDivision(expectedUser.Id, division.Id);

            // Assert
            Assert.AreSame(expectedUser, division.Users.First());
        }
    }
}
