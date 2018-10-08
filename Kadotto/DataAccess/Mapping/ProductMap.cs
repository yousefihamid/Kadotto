using DataAccess.Model;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Mapping
{
    public class ProductMap : EntityTypeConfiguration<ProductModel>
    {
        public ProductMap()
        {
            this.HasKey(m => m.ID);
            this.ToTable("Product");
        }
    }
}
