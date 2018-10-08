namespace Common.Core
{
    public class ProductCategoryDTO
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public long? ParentID { get; set; }

        public string ParentTitle { get; set; }
    }
}
