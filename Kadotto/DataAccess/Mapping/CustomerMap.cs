using DataAccess.Model;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<CustomerModel>
    {
        public CustomerMap()
        {
            this.HasKey(m => m.ID);
            this.ToTable("Customer");
        }
    }
}
