using DataAccessLogic.Interfaces;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessLogic.ADO
{
    public class SupplierDAL : ISupplierDAL
    {
        List<Supplier> suppliers;
        private string connectionStr;

        public SupplierDAL(string test1="")
        {
            suppliers = new List<Supplier>();
            
            if (test1 == "test")
            {
                connectionStr = "Data Source=DESKTOP-LRMIV19;Initial Catalog=UTestManagerService;Integrated Security=True";
            }
            else
            {
                connectionStr = "Data Source=DESKTOP-LRMIV19;Initial Catalog=ManagerService;Integrated Security=True";
            }
            ReadFromDataBase();
        }
     
        public void ReadFromDataBase()
        {
            suppliers.Clear();
            try
            {
                using (SqlConnection connectionSql = new SqlConnection(connectionStr))
                {
                    using (SqlCommand comm = connectionSql.CreateCommand())
                    {
                        connectionSql.Open();
                        comm.CommandText = "select SupplierId, SupplierName, ArrivingTime, RowUpdateTime from Supplier";


                        SqlDataReader reader = comm.ExecuteReader();
                        while (reader.Read())
                        {
                            Supplier tempSupplier = new Supplier();
                            tempSupplier.Id = (int)reader["SupplierId"];
                            tempSupplier.NameSupplier = (string)reader["SupplierName"];
                            tempSupplier.ArrivingTime = Convert.ToDateTime(reader["ArrivingTime"]);
                            tempSupplier.RowUpdateTime = (DateTime)reader["RowUpdateTime"];
                            suppliers.Add(tempSupplier);
                          
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Error during read from databased: {ex.Message}");
            }
            
        }
        public void AddObj(Supplier tempObj)
        {
            suppliers.Add(tempObj);
            
            using (SqlConnection connectionSql = new SqlConnection(connectionStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "insert into Supplier(SupplierName,ArrivingTime,RowUpdateTime) " +
                      "values(@supplierName,@dataArriving,@timeUpdate)";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@supplierName", tempObj.NameSupplier);
                    comm.Parameters.AddWithValue("@dataArriving", tempObj.ArrivingTime);
                    comm.Parameters.AddWithValue("@timeUpdate", tempObj.RowUpdateTime);
                    int rowAffected = comm.ExecuteNonQuery();
                    

                }
            }
        }
        public void DeleteObject(int id)
        {
           
            var tempObj = suppliers.Where(x => x.Id == id).SingleOrDefault();
            if (tempObj != null)
            {
                suppliers.Remove(tempObj);
                using (SqlConnection connectionSql = new SqlConnection(connectionStr))
                {
                    using (SqlCommand comm = connectionSql.CreateCommand())
                    {
                        connectionSql.Open();
                        comm.CommandText = "delete from Supplier where SupplierId=@supplierId";
                        comm.Parameters.Clear();
                        comm.Parameters.AddWithValue("@supplierId", tempObj.Id);
                        int rowAffected = comm.ExecuteNonQuery();
                       
                    }
                }
            }
        }

        public List<Supplier> GetProducts()
        {
            return suppliers;
        }
        public Supplier GetObj(int idT)
        {
            int index = -1;
            for (int i = 0; i < suppliers.Count; i++)
            {
                if (suppliers[i].Id == idT)
                {
                    index = i;
                }
            }
            //index -= 1;
            return suppliers[index];
        }


        public Supplier ChangeValueObj(int id, string newName)
        {
            var tempObj = suppliers.Where(x => x.Id == id).SingleOrDefault();
            foreach (var cat in suppliers)
            {
                if (id == cat.Id)
                {
                    cat.ChangeObjName(newName);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(connectionStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "update Supplier set SupplierName=@newNameTemp, RowUpdateTime=@newTime where SupplierId=@suplId";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@newNameTemp", newName);
                    comm.Parameters.AddWithValue("@newTime", DateTime.Now);
                    comm.Parameters.AddWithValue("@suplId", tempObj.Id);
                    int row = comm.ExecuteNonQuery();
                   
                }
            } 
            return tempObj;
        }
        
    }
}
