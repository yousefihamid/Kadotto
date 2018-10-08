using DataAccess.Model;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Mapping
{
    public class ProductCategoryMap : EntityTypeConfiguration<ProductCategoryModel>
    {
        public ProductCategoryMap()
        {
            this.HasKey(m => m.ID);
            this.ToTable("ProductCategory");
        }
    }
}
