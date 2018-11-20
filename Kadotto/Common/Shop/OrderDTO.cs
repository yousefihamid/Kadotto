using System;

namespace DataAccess.Shop
{
    public class OrderDTO
    {
        public long ID { get; set; }
        public long CustomerID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public DateTime? DeliverDate { get; set; }
    }
}
