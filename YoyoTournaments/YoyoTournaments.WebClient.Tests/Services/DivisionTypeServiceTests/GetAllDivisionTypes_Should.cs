using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YoyoTournaments.Models;
using Moq;
using YoyoTournaments.Data.Contracts;
using YoyoTournaments.WebClient.Tests.Helpers;
using YoyoTournaments.Services;
using System.Linq;

namespace YoyoTournaments.WebClient.Tests.Services.DivisionTypeServiceTests
{
    /// <summary>
    /// Summary description for GetAllDivisionTypes_Should
    /// </summary>
    [TestClass]
    public class GetAllDivisionTypes_Should
    {
        public GetAllDivisionTypes_Should()
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
        public void GetAllDivisions_ShouldReturnOneDivision()
        {
            //Arrange
            DivisionType divisionType = new DivisionType() { Name = "Test", Description = "Test" };
            var divisionTypeDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(divisionType);

            var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();
            yoyoTournamentsDbContextMock.Setup(x => x.DivisionTypes).Returns(divisionTypeDbSetMock.Object);

            var divisionTypeService = new DivisionTypeService(yoyoTournamentsDbContextMock.Object);

            //Act
            var result = divisionTypeService.GetAllDivisions().ToList();

            //Assert
            Assert.AreEqual(1, result.Count);
        }
    }
}
