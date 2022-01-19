using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO.Model;
using System.Collections.Generic;

namespace BLLService.IService
{
    public interface IServiceProduct
    {
        void AddObj(Product temp);
        void DeleteObject(int id, bool op);
        void ReadFromDataBase();
        List<Product> GetProducts();
        Product GetObj(int id);
        void ChangeValueObj(int id, string name);
    }
}
