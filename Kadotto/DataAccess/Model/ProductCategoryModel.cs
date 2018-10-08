namespace DataAccess.Model
{
    public class ProductCategoryModel
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public long? ParentID { get; set; }
    }
}
