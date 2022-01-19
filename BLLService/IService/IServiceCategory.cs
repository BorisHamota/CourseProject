using System;

using DTO.Model;
using System.Collections.Generic;

namespace BLLService.IService
{
    public interface IServiceCategory
    {
        void AddObj(Category temp);
        void DeleteObject(int id, bool op);
        void ReadFromDataBase();
        List<Category> GetProducts();
        Category GetObj(int id);
        void ChangeValueObj(int id, string name);


    }
}
