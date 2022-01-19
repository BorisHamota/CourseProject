using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLLService.IService;
using DataAccessLogic.Interfaces;
using DataAccessLogic.ADO;
using DTO.Model;

namespace BLLService.Service
{
   public  class ServiceCategory : IServiceCategory
    {
        readonly private ICategoryDAL _categories;

        public ServiceCategory(ICategoryDAL categories)
        {
            _categories = categories;
        }
        public void AddObj(Category temp)
        {
            _categories.AddObj(temp);
        }

        public void ChangeValueObj(int id, string name)
        {
            _categories.ChangeValueObj(id,name);
        }

        public void DeleteObject(int id, bool op)
        {
            _categories.DeleteObject(id, op);
        }

        public Category GetObj(int id)
        {
            return _categories.GetObj(id);
        }

        public List<Category> GetProducts()
        {
            return _categories.GetProducts();
        }

        public void ReadFromDataBase()
        {
            _categories.ReadFromDataBase();
        }
    }
}
