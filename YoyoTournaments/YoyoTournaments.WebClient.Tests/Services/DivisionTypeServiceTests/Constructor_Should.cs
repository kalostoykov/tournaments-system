using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestExtensions;
using YoyoTournaments.Services;
using YoyoTournaments.Data.Contracts;
using Moq;

namespace YoyoTournaments.WebClient.Tests.Services.DivisionTypeServiceTests
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
        public void ThrowException_WhenDbContextIsNull()
        {
            // Arrange & Act & Assert
            ThrowsAssert.Throws<ArgumentNullException>(() => new DivisionTypeService(null));
        }

        [TestMethod]
        public void ReturnAnInstance_WhenDbContextIsPassed()
        {
            //Arrange
            var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();

            //Act
            var divisionTypeService = new DivisionTypeService(yoyoTournamentsDbContextMock.Object);

            //Assert
            Assert.IsNotNull(divisionTypeService);
        }
    }
}
