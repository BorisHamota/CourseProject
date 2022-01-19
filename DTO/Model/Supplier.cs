using System;

namespace DTO.Model
{
    public class Supplier
    {
        public int Id { get; set; }
        public string NameSupplier { get; set; }
        public DateTime ArrivingTime { get; set; }
        public DateTime RowUpdateTime { get; set; }

        public bool Equals(Supplier obj)
        {
            return obj != null
                && obj.Id == this.Id
                && obj.NameSupplier == this.NameSupplier
                && obj.ArrivingTime == this.ArrivingTime
                && obj.RowUpdateTime == this.RowUpdateTime; 
        }
        public void ChangeObjName(string nameNew)
        {
            NameSupplier = nameNew;
        }
        public string InfoString()
        {
            return $"Id: {Id}\tSupplier: {NameSupplier}\tTime arriving: {ArrivingTime}\tUpdate: {RowUpdateTime}";
        }
    }
}
