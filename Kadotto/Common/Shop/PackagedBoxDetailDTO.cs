namespace DataAccess.Shop
{
    public class PackagedBoxDetailDTO
    {
        public long ID { get; set; }
        public long PackagedBoxID { get; set; }
        public long ProductID { get; set; }
        public bool IsDeleted { get; set; }
    }
}
