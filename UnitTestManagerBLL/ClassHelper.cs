using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestManagerBLL
{
    public static class ClassHelper
    {
        public static bool AreEqualListManager(List<Manager> manager1, List<Manager> manager2)
        {
            bool res = true;
            for(int i=0; i < manager1.Count; i++)
            {
                if (manager1[i].Equals(manager2[i]) == false)
                {
                    res = false;
                }
            }
            return res;

        } 
        public static bool AreEqualListCategory(List<Category> manager1, List<Category> manager2)
        {
            bool res = true;
            for (int i = 0; i < manager1.Count; i++)
            {
                if (manager1[i].Equals(manager2[i]) == false)
                {
                    res = false;
                }
            }
            return res;

        }
        public static bool AreEqualListProduct(List<Product> manager1, List<Product> manager2)
        {
            bool res = true;
            for (int i = 0; i < manager1.Count; i++)
            {
                if (manager1[i].Equals(manager2[i]) == false)
                {
                    res = false;
                }
            }
            return res;

        }
        public static bool AreEqualListSupplier(List<Supplier> manager1, List<Supplier> manager2)
        {
            bool res = true;
            for (int i = 0; i < manager1.Count; i++)
            {
                if (manager1[i].Equals(manager2[i]) == false)
                {
                    res = false;
                }
            }
            return res;

        }
    }
}
