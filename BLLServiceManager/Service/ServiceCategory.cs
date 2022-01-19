using System.Collections.Generic;
using BLLServiceManager.IService;
using DataAccessLogic.Interfaces;
using DTO.Model;

namespace BLLServiceManager.Service
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
        public Category ChangeValueObj(int id, string name)
        {
            return _categories.ChangeValueObj(id,name);
        }
        public void DeleteObject(int id, bool op)
        {
            _categories.DeleteObject(id, op);
        }

        public List<Category> GetCategoriesBlocked()
        {
           return  _categories.GetCategoriesBlocked();
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
