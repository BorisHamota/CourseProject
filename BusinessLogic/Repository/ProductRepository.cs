using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogic.Repository
{
    public class ProductRepository
    {
        List<Product> arrayDataBase;
        public ProductRepository()
        {
            arrayDataBase = new List<Product>();
        }
        public List<Product> Array() 
        {
            return arrayDataBase;
        }
        public void Add(Product temp) 
        {
            arrayDataBase.Add(temp);
        }
        public void RemoveByIndex(int index) 
        {
            index -= 1;
            arrayDataBase.RemoveAt(index);
        }
        public void ChangeValueCategory(string categoryCurr, string categoryNew) 
        {
            foreach(Product temp in arrayDataBase)
            {
                if (temp.Category == categoryCurr)
                {
                    temp.ChangeValueCategory(categoryNew);
                }
            }
        }
        public void GetMetodToRead() { }
    }
}
