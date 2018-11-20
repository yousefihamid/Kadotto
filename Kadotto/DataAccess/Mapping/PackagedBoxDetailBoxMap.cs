using DataAccess.Model;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Mapping
{
    public class PackagedBoxDetailMap : EntityTypeConfiguration<PackagedBoxDetailModel>
    {
        public PackagedBoxDetailMap()
        {
            this.HasKey(m => m.ID);
            this.ToTable("PackagedBoxDetail");
        }
    }
}
