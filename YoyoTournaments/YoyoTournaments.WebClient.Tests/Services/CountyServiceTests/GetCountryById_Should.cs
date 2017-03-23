using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YoyoTournaments.Data.Contracts;
using Moq;
using YoyoTournaments.Services;
using YoyoTournaments.Models;
using YoyoTournaments.WebClient.Tests.Helpers;

namespace YoyoTournaments.WebClient.Tests.Services.CountyServiceTests
{
    /// <summary>
    /// Summary description for GetCountryById_Should
    /// </summary>
    [TestClass]
    public class GetCountryById_Should
    {
        public GetCountryById_Should()
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
        //[TestMethod]
        //public void ReturnNull_WhenIdIsNotProvided()
        //{
        //    //Arrange
        //    Guid? id = null;
        //    var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();

        //    var countryService = new CountryService(yoyoTournamentsDbContextMock.Object);

        //    //Act
        //    var result = countryService.GetCountryById(id);

        //    //Assert
        //    Assert.IsNull(result);
        //}

        [TestMethod]
        public void ReturnCountryWithProvidedId()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            Country expectedCountry = new Country() { Id= id, Name = "Bulgaria" };

            var countryDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(new List<Country>() { expectedCountry });
            countryDbSetMock.Setup(x => x.Find(expectedCountry.Id)).Returns(expectedCountry);

            var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();
            yoyoTournamentsDbContextMock.Setup(x => x.Countries).Returns(countryDbSetMock.Object);

            var countryService = new CountryService(yoyoTournamentsDbContextMock.Object);

            //Act
            var actualCountry = countryService.GetCountryById(id);

            //Assert
            Assert.AreSame(expectedCountry, actualCountry);
        }

        [TestMethod]
        public void ReturnNullWhenCountryWithIdIsNotFound()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            Country expectedCountry = new Country() { Id= id, Name = "Bulgaria" };

            var countryDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(new List<Country>() { expectedCountry });
            countryDbSetMock.Setup(x => x.Find(expectedCountry.Id)).Returns((Country)null);

            var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();
            yoyoTournamentsDbContextMock.Setup(x => x.Countries).Returns(countryDbSetMock.Object);

            var countryService = new CountryService(yoyoTournamentsDbContextMock.Object);

            //Act
            var actualCountry = countryService.GetCountryById(id);

            //Assert
            Assert.IsNull(actualCountry);
        }
    }
}
