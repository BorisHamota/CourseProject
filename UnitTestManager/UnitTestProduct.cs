using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataAccessLogic.ADO;
using DataAccessLogic.Interfaces;
using DTO.Model;


namespace UnitTestManager
{
    [TestClass]
    public class UnitTestProduct
    {
        IProductDAL products = new ProductDAL("test");
        
       // [TestMethod]
        public void TestMethod_MostExpensiveProduct()
        {
            int currentIdProduct = products.GetMostExpensiveObj();
            int exeptedIdProduct = 1;//choko price 100

            //assert
            Assert.AreEqual(currentIdProduct, exeptedIdProduct);

        }
       // [TestMethod]
        public void TestMethod_AddNewValue()
        {

            Product temp = new Product();
            string nameM = "Pork";
            temp.NameObj = nameM;
            temp.CategoryID = 2;
            temp.PriceIn = 190;
            temp.PriceOut = 130;

            products.AddObj(temp);
            var tempObj = products.GetProducts().Find(x => x.NameObj == nameM);
            Assert.IsNotNull(tempObj);
        }
     // [TestMethod]
        public void TestMethod_RemoveValue()
        {
            Product temp = new Product();
            string nameM = "Korivka";
            temp.NameObj = nameM;
            temp.CategoryID = 3;
            temp.PriceIn = 233;
            temp.PriceOut = 250;
            products.AddObj(temp);

            var tempObj = products.GetProducts().Find(x => x.NameObj == nameM);
            products.DeleteObject(tempObj.Id);
            var tempObjDel = products.GetProducts().Find(x => x.NameObj == nameM);
            Assert.IsNull(tempObjDel);
        }
    }
}
