using DataAccess.Model;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Mapping
{
    public class BoxMap : EntityTypeConfiguration<BoxModel>
    {
        public BoxMap()
        {
            this.HasKey(m => m.ID);
            this.ToTable("Box");
        }
    }
}
