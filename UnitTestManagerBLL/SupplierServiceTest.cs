using BLLServiceManager.Service;
using DataAccessLogic.Interfaces;
using DTO.Model;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestManagerBLL
{
    [TestFixture]
    internal class SupplierServiceTest
    {
        private ServiceSupplier _serviceSupplier;
        private Mock<ISupplierDAL> _supplier;

        [SetUp]
        public void Setup()
        {
            _supplier = new Mock<ISupplierDAL>(MockBehavior.Strict);
            _serviceSupplier = new ServiceSupplier(_supplier.Object);
        }

        [Test]
        public void GetSupplier_List_AreEqual()
        {
            DateTime timeUpdate = DateTime.Now;
            DateTime timeInsert = DateTime.Now;
            //Arrange
            List<Supplier> categoryCurrentArr = new List<Supplier>()
            {
                new Supplier{Id=5,NameSupplier="Maria",ArrivingTime=timeInsert,RowUpdateTime=timeUpdate},
                new Supplier{Id=6,NameSupplier="Yura",ArrivingTime=timeInsert,RowUpdateTime=timeUpdate}
            };
            List<Supplier> categoryResultArr = new List<Supplier>()
            {
                new Supplier{Id=5,NameSupplier="Maria",ArrivingTime=timeInsert,RowUpdateTime=timeUpdate},
                new Supplier{Id=6,NameSupplier="Yura",ArrivingTime=timeInsert,RowUpdateTime=timeUpdate}
            };
            _supplier.Setup(category => category.GetProducts()).Returns(categoryCurrentArr);
            //Act
            List<Supplier> resultArr = _serviceSupplier.GetProducts();
            bool isEqual = ClassHelper.AreEqualListSupplier(categoryResultArr, resultArr);
            //Assert
            NUnit.Framework.Assert.IsTrue(isEqual);
        } 

        [Test]
        public void GetSupplier_IntIn_Category_AreEqual()
        {
            DateTime timeUpdate = DateTime.Now;
            DateTime timeInsert = DateTime.Now;
            //Arrange
            Supplier categoryCurrent = new Supplier { Id = 9, NameSupplier = "Maria", ArrivingTime = timeInsert, RowUpdateTime = timeUpdate };
            Supplier categoryResult = new Supplier { Id = 9, NameSupplier = "Maria", ArrivingTime = timeInsert, RowUpdateTime = timeUpdate };
            _supplier.Setup(category => category.GetObj(9)).Returns(categoryCurrent);
            //Act
            Supplier resultItem = _serviceSupplier.GetObj(9);
            bool isEqual = resultItem.Equals(categoryResult);
            //Assert
            NUnit.Framework.Assert.IsTrue(isEqual);
        }
        [Test]
        public void GetSupplier_IntString_ReturnCategory_AreEqual()
        {
            DateTime timeUpdate = DateTime.Now;
            DateTime timeInsert = DateTime.Now;
            //Arrange
            Supplier categoryCurrent = new Supplier { Id = 9, NameSupplier = "Maria", ArrivingTime = timeInsert, RowUpdateTime = timeUpdate };
            Supplier categoryResult = new Supplier { Id = 9, NameSupplier = "Maria", ArrivingTime = timeInsert, RowUpdateTime = timeUpdate };
            _supplier.Setup(category => category.ChangeValueObj(5, "newvalue")).Returns(categoryCurrent);
            //Act
            Supplier resultItem = _serviceSupplier.ChangeValueObj(5, "newvalue");
            bool isEqual = resultItem.Equals(categoryResult);
            //Assert
            NUnit.Framework.Assert.IsTrue(isEqual);
        }
    }
}
