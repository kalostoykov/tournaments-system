using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YoyoTournaments.Services.Contracts;
using Moq;
using YoyoTournaments.Models;
using YoyoTournaments.WebClient.Controllers;
using TestStack.FluentMVCTesting;
using YoyoTournaments.WebClient.Models;
using PagedList;

namespace YoyoTournaments.WebClient.Tests.Controllers.TournamentControllerTests
{
    /// <summary>
    /// Summary description for Index_Should
    /// </summary>
    [TestClass]
    public class Index_Should
    {
        public Index_Should()
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
        public void CallGetAllTournamentsWIthPagingOnce()
        {
            // Arrange
            int count = 0;
            int page = 1;
            int pageSize = 1;

            var tournamentServiceMock = new Mock<ITournamentService>();
            tournamentServiceMock
                .Setup(x => x.GetAllTournamentsWIthPaging(out count, page, pageSize)).Returns(new List<Tournament>());

            var divisionServiceMock = new Mock<IDivisionService>();

            var controller = new TournamentController(tournamentServiceMock.Object, divisionServiceMock.Object);

            // Act
            controller.Index(page, pageSize);

            // Assert
            tournamentServiceMock.Verify(x => x.GetAllTournamentsWIthPaging(out count, page, pageSize), Times.Once);
        }

        [TestMethod]
        public void ReturnIndexWithStaticPagedListOfTournamentGriViewModel()
        {
            // Arrange
            int count = 0;
            int page = 1;
            int pageSize = 1;

            var tournamentServiceMock = new Mock<ITournamentService>();
            tournamentServiceMock
                .Setup(x => x.GetAllTournamentsWIthPaging(out count, page, pageSize)).Returns(new List<Tournament>());

            var divisionServiceMock = new Mock<IDivisionService>();

            var controller = new TournamentController(tournamentServiceMock.Object, divisionServiceMock.Object);

            // Act & Assert
            controller
                .WithCallTo(x => x.Index(page, pageSize))
                .ShouldRenderDefaultView()
                .WithModel<StaticPagedList<TournamentGridViewModel>>();
        }
    }
}
