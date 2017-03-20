using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using YoyoTournaments.Data.Contracts;
using YoyoTournaments.Models;
using YoyoTournaments.Services;
using System.Data.Entity;

namespace YoyoTournaments.Services.Tests
{
    /// <summary>
    /// Summary description for DivisionTypeServiceTests
    /// </summary>
    [TestClass]
    public class DivisionTypeServiceTests
    {
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
            //var divisionTypeDbSet = new DbSet<DivisionType>() { };
            //var yoyoTournamentsDbContextMock = new Mock<IYoyoTournamentsDbContext>();
            //yoyoTournamentsDbContextMock.Setup(x => x.DivisionTypes).;
            //var divisionTypeService = new DivisionTypeService(yoyoTournamentsDbContextMock.Object);

            //Act

            //Assert
            Assert.IsTrue(true);
        }
    }
}
