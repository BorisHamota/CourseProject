using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLLServiceManager.IService;
using DTO.Model;
using DataAccessLogic.Interfaces;
using DataAccessLogic.ADO;

namespace BLLServiceManager.Service
{
    public class ServiceManager : IServiceManager
    {
        readonly private IManagerDAL _managers;
        public ServiceManager(IManagerDAL managers)
        {
            _managers = managers;
        }
        public void AddObj(Manager tempObj)
        {
            _managers.AddObj(tempObj);
        }

        public void DeleteObject(int id)
        { 
            _managers.DeleteObject(id);
        }

        public Manager GetObj(string idT)
        {
            return _managers.GetObj(idT);
        }

        public Manager GetObjById(int id)
        {
            return _managers.GetObjById(id);
        }

        public List<Manager> GetProducts()
        {
            return _managers.GetProducts();
        }

        public List<Manager> GetProductsWithoutPassword()
        {
            return _managers.GetProductsWithoutPassword();
        }

        public bool IsLogin(string Email, string Password)
        {
            return _managers.IsLogin(Email,Password);
        }

        public void ReadFromDataBase()
        {
            _managers.ReadFromDataBase();
        }
    }
}
