using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository
{
    class SupplierRepository
    {
        List<SupplierProduct> supplierArr = null;
        public SupplierRepository()
        {
            supplierArr = new List<SupplierProduct>();
        }

        public void Add(SupplierProduct temp)
        {
            supplierArr.Add(temp);
        }
        public SupplierProduct RemoveByIndex(int index)
        {
            index -= 1;
            SupplierProduct catTemp = supplierArr[index];
            supplierArr.RemoveAt(index);
            return catTemp;
        }
        public void ChangeOb(int index, string value)
        {
            supplierArr[index].ChangeValueSupplier(value);
        }
        public int GetSize()
        {
            return supplierArr.Count;
        }
        public SupplierProduct GetElem(int index)
        {
            return supplierArr[index];
        }
    }
}
