using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestExtensions;
using YoyoTournaments.Data.Contracts;
using YoyoTournaments.Services;
using Moq;
using YoyoTournaments.Services.Contracts;

namespace YoyoTournaments.WebClient.Tests.Services.TournamentServiceTests
{
    /// <summary>
    /// Summary description for Constructor_Should
    /// </summary>
    [TestClass]
    public class Constructor_Should
    {
        public Constructor_Should()
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
        public void ThrowException_WhenDivisionTypeServiceIsNull()
        {
            // Arrange
            var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();

            // Assert
            ThrowsAssert.Throws<ArgumentNullException>(() => new TournamentService(yoyoTournamentsDbContextMock.Object, null));
        }

        [TestMethod]
        public void ThrowException_WhenDbContextIsNull()
        {
            // Arrange
            var divisionTypeServiceMock = new Mock<IDivisionTypeService>();

            // Assert
            ThrowsAssert.Throws<ArgumentNullException>(() => new TournamentService(null, divisionTypeServiceMock.Object));
        }

        [TestMethod]
        public void ReturnAnInstance_WhenDbContextIsPassed()
        {
            //Arrange
            var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();
            var divisionTypeServiceMock = new Mock<IDivisionTypeService>();

            //Act
            var divisionTypeService = new TournamentService(yoyoTournamentsDbContextMock.Object, divisionTypeServiceMock.Object);

            //Assert
            Assert.IsNotNull(divisionTypeService);
        }
    }
}
