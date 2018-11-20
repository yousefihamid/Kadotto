using DataAccess.Model;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Mapping
{
    public class PackagedBoxMap : EntityTypeConfiguration<PackagedBoxModel>
    {
        public PackagedBoxMap()
        {
            this.HasKey(m => m.ID);
            this.ToTable("PackagedBox");
        }
    }
}
