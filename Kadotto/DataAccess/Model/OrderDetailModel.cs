using System;

namespace DataAccess.Model
{
    public class OrderDetailModel
    {
        public long ID { get; set; }
        public long OrderID { get; set; }
        public long PackagedBoxID { get; set; }
    }
}
