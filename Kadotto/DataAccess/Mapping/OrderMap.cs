using DataAccess.Model;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Mapping
{
    public class OrderMap : EntityTypeConfiguration<OrderModel>
    {
        public OrderMap()
        {
            this.HasKey(m => m.ID);
            this.ToTable("Order");
        }
    }
}
