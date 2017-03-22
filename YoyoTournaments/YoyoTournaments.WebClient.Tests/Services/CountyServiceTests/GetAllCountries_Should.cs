using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YoyoTournaments.Services;
using Moq;
using YoyoTournaments.Models;
using YoyoTournaments.WebClient.Tests.Helpers;
using YoyoTournaments.Data.Contracts;
using System.Linq;

namespace YoyoTournaments.WebClient.Tests.Services.CountyServiceTests
{
    /// <summary>
    /// Summary description for GetAllCountries_Should
    /// </summary>
    [TestClass]
    public class GetAllCountries_Should
    {
        public GetAllCountries_Should()
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
        public void ReturnOneCountry()
        {
            //Arrange
            Country country = new Country() { Name = "Bulgaria" };
            var countriesDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(new List<Country>() { country });

            var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();
            yoyoTournamentsDbContextMock.Setup(x => x.Countries).Returns(countriesDbSetMock.Object);

            var countryService = new CountryService(yoyoTournamentsDbContextMock.Object);

            //Act
            var result = countryService.GetAllCountries().ToList();

            //Assert
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void ReturnEmptyCollection_WhenThenThereAreNoResults()
        {
            //Arrange
            var countries = new List<Country>();
            var countriesDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(countries);

            var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();
            yoyoTournamentsDbContextMock.Setup(x => x.Countries).Returns(countriesDbSetMock.Object);

            var countryService = new CountryService(yoyoTournamentsDbContextMock.Object);

            //Act
            var result = countryService.GetAllCountries().ToList();

            //Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void ReturnIEnumerableCollectionOfCountries()
        {
            //Arrange
            var countries = new List<Country>();
            var countriesDbSetMock = QueryableDbSetMock.GetQueryableMockDbSet(countries);

            var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();
            yoyoTournamentsDbContextMock.Setup(x => x.Countries).Returns(countriesDbSetMock.Object);

            var countryService = new CountryService(yoyoTournamentsDbContextMock.Object);

            //Act
            var result = countryService.GetAllCountries().ToList();

            //Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Country>));
        }
    }
}
