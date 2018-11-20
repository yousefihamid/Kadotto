using System.Collections.Generic;

namespace DataAccess.Shop
{
    public class PackagedBoxDTO
    {
        public long ID { get; set; }
        public long BoxID { get; set; }
        public decimal Price { get; set; }
        public string CustomerMessage { get; set; }
        public bool IsDeleted { get; set; }

        public string BoxTitle { get; set; }
        public string BoxImageName { get; set; }
        public List<PackagedBoxDetailDTO> PackagedBoxDetails { get; set; }
    }
}
