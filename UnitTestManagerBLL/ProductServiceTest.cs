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
    internal class ProductServiceTest
    {
        private ServiceProduct _serviceProduct;
        private Mock<IProductDAL> _product;

        [SetUp]
        public void Setup()
        {
            _product = new Mock<IProductDAL>(MockBehavior.Strict);
            _serviceProduct = new ServiceProduct(_product.Object);
        }

        [Test]
        public void GetProduct_List_AreEqual()
        {
            DateTime timeUpdate = DateTime.Now;
            DateTime timeInsert = DateTime.Now;
           
            //Arrange
            List<Product> categoryCurrentArr = new List<Product>()
            {
                new Product{Id=6,NameObj="newProduct",CategoryID=1,PriceIn=100,PriceOut=110,RowInsertTime=timeInsert,RowUpdateTime=timeUpdate},
                new Product{Id=6,NameObj="newProduct1",CategoryID=1,PriceIn=110,PriceOut=120,RowInsertTime=timeInsert,RowUpdateTime=timeUpdate}
            };
            List<Product> categoryResultArr = new List<Product>()
            {
                new Product{Id=6,NameObj="newProduct",CategoryID=1,PriceIn=100,PriceOut=110,RowInsertTime=timeInsert,RowUpdateTime=timeUpdate},
                new Product{Id=6,NameObj="newProduct1",CategoryID=1,PriceIn=110,PriceOut=120,RowInsertTime=timeInsert,RowUpdateTime=timeUpdate }
            };
            _product.Setup(category => category.GetProducts()).Returns(categoryCurrentArr);
            //Act
            List<Product> resultArr = _serviceProduct.GetProducts();
            bool isEqual =ClassHelper.AreEqualListProduct(categoryResultArr, resultArr);
            //Assert
            NUnit.Framework.Assert.IsTrue(isEqual);
        }

        [Test]
        public void GetProduct_IntIn_Category_AreEqual()
        {
            DateTime timeUpdate = DateTime.Now;
            DateTime timeInsert = DateTime.Now;
            //Arrange
            Product categoryCurrent = new Product { Id = 6, NameObj = "newProduct", CategoryID = 1, PriceIn = 100, PriceOut = 110, RowInsertTime = timeInsert, RowUpdateTime = timeUpdate };
            Product categoryResult = new Product { Id = 6, NameObj = "newProduct", CategoryID = 1, PriceIn = 100, PriceOut = 110, RowInsertTime = timeInsert, RowUpdateTime = timeUpdate };
            _product.Setup(pr => pr.GetObj(6)).Returns(categoryCurrent);
            //Act
            Product resultItem = _serviceProduct.GetObj(6); 
            bool isEqual = resultItem.Equals(categoryResult);
            //Assert
            NUnit.Framework.Assert.IsTrue(isEqual);
        }
        [Test]
        public void GetProduct_IntString_ReturnCategory_AreEqual()
        {
            DateTime timeUpdate = DateTime.Now;
            DateTime timeInsert = DateTime.Now;
            //Arrange
            Product categoryCurrent = new Product { Id = 6, NameObj = "newProduct", CategoryID = 1, PriceIn = 100, PriceOut = 110, RowInsertTime = timeInsert, RowUpdateTime = timeUpdate  };
            Product categoryResult = new Product { Id = 6, NameObj = "newProduct", CategoryID = 1, PriceIn = 100, PriceOut = 110, RowInsertTime = timeInsert, RowUpdateTime = timeUpdate };
            _product.Setup(category => category.ChangeValueObj(6, "newvalue")).Returns(categoryCurrent);
            //Act
            Product resultItem = _serviceProduct.ChangeValueObj(6, "newvalue");
            bool isEqual = resultItem.Equals(categoryResult);
            //Assert
            NUnit.Framework.Assert.IsTrue(isEqual);
        }
    }
}
