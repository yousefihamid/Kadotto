namespace DataAccess.Model
{
    public class PackagedBoxModel
    {
        public long ID { get; set; }
        public long BoxID { get; set; }
        public decimal Price { get; set; }
        public string CustomerMessage { get; set; }
        public bool IsDeleted { get; set; }
    }
}
