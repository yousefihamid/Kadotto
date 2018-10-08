using DataAccess.Model;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Mapping
{
    public class PartitionMap : EntityTypeConfiguration<PartitionModel>
    {
        public PartitionMap()
        {
            this.HasKey(m => m.ID);
            this.ToTable("Partition");
        }
    }
}
