using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO.Model;


namespace BLLServiceManager.IService
{
    public interface IServiceProduct
    { 
        void AddObj(Product temp);
        void DeleteObject(int id);
        void ReadFromDataBase();
        List<Product> GetProducts();
        Product GetObj(int id);
        Product ChangeValueObj(int id, string name);
    }
}
