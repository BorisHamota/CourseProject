using DTO.Model;
using System.Collections.Generic;

namespace DataAccessLogic.Interfaces
{
    public interface ISupplierDAL
    {
        List<Supplier> GetProducts();
        void AddObj(Supplier tempObj);
        void DeleteObject(int id);
        void ReadFromDataBase(); 
        Supplier GetObj(int idT);
        Supplier ChangeValueObj(int id, string newName);
    }
}
