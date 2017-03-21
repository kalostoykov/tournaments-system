using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using YoyoTournaments.Data.Contracts;
using YoyoTournaments.Services;
using YoyoTournaments.Models;
using YoyoTournaments.WebClient.Tests.Helpers;

namespace YoyoTournaments.WebClient.Tests.Services.DivisionTypeServiceTests
{
    /// <summary>
    /// Summary description for GetDivisionTypeById_Should
    /// </summary>
    [TestClass]
    public class GetDivisionTypeById_Should
    {
        public GetDivisionTypeById_Should()
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
        public void ReturnNull_WhenIdIsNotProvided()
        {
            //Arrange
            Guid? id = null;
            var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();

            var divisionTypeService = new DivisionTypeService(yoyoTournamentsDbContextMock.Object);

            //Act
            var result = divisionTypeService.GetDivisionTypeById(id);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ReturnDivisionTypeWithProvidedId()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            DivisionType expectedDivisionType = new DivisionType() { Id = id, Name = "Test", Description = "Test" };

            var divisionTypeDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(new List<DivisionType>() { expectedDivisionType });
            divisionTypeDbSetMock.Setup(x => x.Find(expectedDivisionType.Id)).Returns(expectedDivisionType);

            var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();
            yoyoTournamentsDbContextMock.Setup(x => x.DivisionTypes).Returns(divisionTypeDbSetMock.Object);

            var divisionTypeService = new DivisionTypeService(yoyoTournamentsDbContextMock.Object);

            //Act
            var actualDivisionType = divisionTypeService.GetDivisionTypeById(id);

            //Assert
            Assert.AreSame(expectedDivisionType, actualDivisionType);
        }

        [TestMethod]
        public void ReturnNullWhenDivisionTypeWithIdIsNotFound()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            DivisionType divisionType = new DivisionType() { Id = id, Name = "Test", Description = "Test" };

            var divisionTypeDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(new List<DivisionType>() { divisionType });
            divisionTypeDbSetMock.Setup(x => x.Find(Guid.NewGuid())).Returns((DivisionType)null);

            var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();
            yoyoTournamentsDbContextMock.Setup(x => x.DivisionTypes).Returns(divisionTypeDbSetMock.Object);

            var divisionTypeService = new DivisionTypeService(yoyoTournamentsDbContextMock.Object);

            //Act
            var actualDivisionType = divisionTypeService.GetDivisionTypeById(id);

            //Assert
            Assert.IsNull(actualDivisionType);
        }
    }
}
