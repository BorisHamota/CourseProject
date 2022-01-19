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
    internal class ManagerServiceTest
    {
        private ServiceManager _serviceManager;
        private Mock<IManagerDAL> _manager;

        [SetUp]
        public void Setup()
        {
            _manager = new Mock<IManagerDAL>(MockBehavior.Strict);
            _serviceManager = new ServiceManager(_manager.Object);
        }

        [Test]
        public void GetManager_List_AreEqual()
        {
            DateTime timeUpdate = DateTime.Now;
            DateTime timeInsert = DateTime.Now;
            Guid salt1 = Guid.Empty;
            Guid salt2 = Guid.Empty;
            
            string pass1 = "123";
            string pass2 = "1234";
            byte[] curpass1 = Manager.hash(pass1, Convert.ToString(salt1));
            byte[] curpass2 = Manager.hash(pass2, Convert.ToString(salt2));
            //Arrange
            List <Manager> managerCurrentArr = new List<Manager>()
            {
                new Manager{ID=5,Name="Maria",Email="log@gmail.com",Password=curpass1,Salt=salt1,TimeInsert=timeInsert,TimeUpdate=timeUpdate},
                new Manager{ID=6,Name="Yura",Email="log1@gmail.com",Password=curpass2,Salt=salt1,TimeInsert=timeInsert,TimeUpdate=timeUpdate}
            }; 
            List<Manager> managerResultArr = new List<Manager>()
            {
                new Manager{ID=5,Name="Maria",Email="log@gmail.com",Password=curpass1,Salt=salt1,TimeInsert=timeInsert,TimeUpdate=timeUpdate},
                new Manager{ID=6,Name="Yura",Email="log1@gmail.com",Password=curpass2,Salt=salt1,TimeInsert=timeInsert,TimeUpdate=timeUpdate}
            };
            _manager.Setup(m => m.GetProducts()).Returns(managerCurrentArr);
            //Act
            List<Manager> resultArr = _serviceManager.GetProducts();
            bool isEqual = ClassHelper.AreEqualListManager(managerResultArr, resultArr);
            //Assert
            NUnit.Framework.Assert.IsTrue(isEqual);
        }

        [Test]
        public void GetManager_IntIn_Category_AreEqual()
        {
            DateTime timeUpdate = DateTime.Now;
            DateTime timeInsert = DateTime.Now;
            Guid salt = Guid.Empty;
            
            string pass1 = "123";
            byte[] curpass1 = Manager.hash(pass1, Convert.ToString(salt));
            
            //Arrange
            Manager categoryCurrent = new Manager { ID = 5, Name = "Maria", Email = "log@gmail.com", Password =curpass1, Salt = salt, TimeInsert = timeInsert, TimeUpdate = timeUpdate };
            Manager categoryResult = new Manager { ID = 5, Name = "Maria", Email = "log@gmail.com", Password = curpass1, Salt = salt, TimeInsert = timeInsert, TimeUpdate = timeUpdate };
            _manager.Setup(m => m.GetObjById(5)).Returns(categoryCurrent);
            //Act
            Manager resultItem = _serviceManager.GetObjById(5);
            bool isEqual = resultItem.Equals(categoryResult);
            //Assert
            NUnit.Framework.Assert.IsTrue(isEqual);
        }
       
    }
}
