namespace DataAccess.Model
{
    public class BoxModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string BoxSize { get; set; }
        public int? BoxPlaceCount { get; set; }
        public string Description { get; set; }
        public int? DisplayOrder { get; set; }
        public bool Deleted { get; set; }
    }
}
