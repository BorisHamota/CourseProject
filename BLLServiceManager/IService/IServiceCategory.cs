using DTO.Model;
using System.Collections.Generic;

namespace BLLServiceManager.IService
{
    public interface IServiceCategory
    {
        void AddObj(Category temp); 
        void DeleteObject(int id, bool op);
        void ReadFromDataBase();
        List<Category> GetProducts();
        Category GetObj(int id);
        Category ChangeValueObj(int id, string name);
        List<Category> GetCategoriesBlocked();
    }
}
