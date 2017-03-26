using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using YoyoTournaments.Services.Contracts;
using YoyoTournaments.WebClient.Controllers;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace YoyoTournaments.WebClient.Tests.Controllers.TournamentControllerTests
{
    /// <summary>
    /// Summary description for SignIn
    /// </summary>
    [TestClass]
    public class SignIn_Should
    {
        public SignIn_Should()
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
        public void ReturnErrorView_WhenTheDivisionIdIsNull()
        {
            // Arrange
            var expectedId = Guid.Empty.ToString();
            var tournamentServiceMock = new Mock<ITournamentService>();
            var divisionServiceMock = new Mock<IDivisionService>();

            var controller = new TournamentController(tournamentServiceMock.Object, divisionServiceMock.Object);

            // Act & Assert
            controller
                .WithCallTo(x => x.SignIn(expectedId))
                .ShouldRenderView("Error");
        }

        //[TestMethod]
        //public void CallAddUserToDivisionOnce()
        //{
        //    // Arrange
        //    var userId = Guid.NewGuid().ToString();
        //    var divisionId = Guid.NewGuid();

        //    var userControllerMock = new Mock<ControllerContext>();
        //    userControllerMock.Setup(x => x.HttpContext.User.Identity.Name).Returns("testUser");

        //    var tournamentServiceMock = new Mock<ITournamentService>();

        //    var divisionServiceMock = new Mock<IDivisionService>();
        //    divisionServiceMock.Setup(x => x.AddUserToDivision(userId, divisionId)).Verifiable();

        //    var controller = new TournamentController(tournamentServiceMock.Object, divisionServiceMock.Object);
        //    controller.ControllerContext = userControllerMock.Object;

        //    // Act
        //    controller.SignIn(divisionId.ToString());

        //    // Assert
        //    divisionServiceMock.Verify(x => x.AddUserToDivision(userId, divisionId), Times.Once);
        //}
    }
}
