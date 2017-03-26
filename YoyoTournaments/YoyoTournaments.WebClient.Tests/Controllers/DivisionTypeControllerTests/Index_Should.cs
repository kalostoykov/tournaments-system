using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using YoyoTournaments.Services.Contracts;
using YoyoTournaments.WebClient.Controllers;
using YoyoTournaments.WebClient.Models;
using System.Linq;
using YoyoTournaments.Models;
using TestStack.FluentMVCTesting;

namespace YoyoTournaments.WebClient.Tests.Controllers.DivisionTypeControllerTests
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
        public void CallGetAllDivisionTypes()
        {
            // Arrange
            var divisionTypeServiceMock = new Mock<IDivisionTypeService>();
            divisionTypeServiceMock.Setup(x => x.GetAllDivisionTypes()).Returns(new List<DivisionType>().AsEnumerable());

            var controller = new DivisionTypeController(divisionTypeServiceMock.Object);

            // Act
            controller.Index();

            // Assert
            divisionTypeServiceMock.Verify(x => x.GetAllDivisionTypes(), Times.Once);
        }

        [TestMethod]
        public void ReturnIndexView()
        {
            // Arrange
            var divisionTypeServiceMock = new Mock<IDivisionTypeService>();
            divisionTypeServiceMock.Setup(x => x.GetAllDivisionTypes()).Returns(new List<DivisionType>().AsEnumerable());

            var controller = new DivisionTypeController(divisionTypeServiceMock.Object);

            // Act & Arrange & Assert
            controller
                .WithCallTo(x => x.Index())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void ReturnIndexViewWithDivisionTypeGridViewModel()
        {
            // Arrange
            var divisionTypeServiceMock = new Mock<IDivisionTypeService>();
            divisionTypeServiceMock.Setup(x => x.GetAllDivisionTypes()).Returns(new List<DivisionType>().AsEnumerable());

            var controller = new DivisionTypeController(divisionTypeServiceMock.Object);

            // Act & Arrange & Assert
            controller
                .WithCallTo(x => x.Index())
                .ShouldRenderDefaultView()
                .WithModel<List<DivisionTypeGridViewModel>>();
        }
    }
}
