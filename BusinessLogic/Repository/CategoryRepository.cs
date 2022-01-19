using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    public class CategoryRepository
    {
        
        List<Category> categoriges = null;
        public CategoryRepository()
        {
            categoriges = new List<Category>();
        }

        public void Add(Category temp)
        {
            categoriges.Add(temp);
        }
        public Category RemoveByIndex(int index)
        {
            index -= 1;
            Category catTemp = categoriges[index];
            categoriges.RemoveAt(index);
            return catTemp;
        }
        public void ChangeOb(int index, string value)
        {
            categoriges[index].ChangeValue(value);
        }
        public int GetSize()
        {
            return categoriges.Count;
        }
        public Category GetElem(int index)
        {
            return categoriges[index];
        }
    }
}
