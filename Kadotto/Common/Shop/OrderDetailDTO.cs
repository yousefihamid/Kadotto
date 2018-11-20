using System;

namespace DataAccess.Shop
{
    public class OrderDetailDTO
    {
        public long ID { get; set; }
        public long OrderID { get; set; }
        public long PackagedBoxID { get; set; }
    }
}
