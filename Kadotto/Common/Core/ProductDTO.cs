using System;

namespace Common.Core
{
    public class ProductDTO
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string BrifDescription { get; set; }
        public string LongDescription { get; set; }
        public long ProductCategoryID { get; set; }
        public string Vendor { get; set; }
        public int Quantity { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int DisplayOrder { get; set; }
        public bool Visible { get; set; }
        public decimal Price { get; set; }
        public string ImageName { get; set; }

        public string ProductCategoryTitle { get; set; }
        public string CreationDateString { get { return CreationDate.ToString("yyyy-MM-dd"); } set { } }
        public string UpdateDateString { get{ return UpdateDate.ToString("yyyy-MM-dd"); } set { } }
    }
}
