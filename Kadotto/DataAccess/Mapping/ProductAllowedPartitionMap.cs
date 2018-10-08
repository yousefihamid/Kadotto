using DataAccess.Model;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Mapping
{
    public class ProductAllowedPartitionMap : EntityTypeConfiguration<ProductAllowedPartitionModel>
    {
        public ProductAllowedPartitionMap()
        {
            this.HasKey(m => m.ID);
            this.ToTable("ProductAllowedPartition");
        }
    }
}
