using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestExtensions;
using YoyoTournaments.Services;
using Moq;
using YoyoTournaments.Services.Contracts;
using YoyoTournaments.Data.Contracts;
using YoyoTournaments.WebClient.Controllers;

namespace YoyoTournaments.WebClient.Tests.Controllers.TournamentControllerTests
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
        public void ThrowArgumentNullException_WhenDbContextIsNull()
        {
            // Arrange
            var divisionServiceMock = new Mock<IDivisionService>();

            // Act & Assert
            ThrowsAssert.Throws<ArgumentNullException>(
                () => new TournamentController(null, divisionServiceMock.Object)
            );
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenDivisionTypeService()
        {
            // Arrange
            var tournamentServiceMock = new Mock<ITournamentService>();

            // Act & Assert
            ThrowsAssert.Throws<ArgumentNullException>(
                () => new TournamentController(tournamentServiceMock.Object, null)
            );
        }

        [TestMethod]
        public void ReturnAnInstanceOfTournamentService_WhenDbContextAndDivisionTypeServiceArePassed()
        {
            //Arrange
            var tournamentServiceMock = new Mock<ITournamentService>();
            var divisionServiceMock = new Mock<IDivisionService>();

            //Act
            var controller = new TournamentController(tournamentServiceMock.Object, divisionServiceMock.Object);

            //Assert
            Assert.IsInstanceOfType(controller, typeof(TournamentController));
        }
    }
}
