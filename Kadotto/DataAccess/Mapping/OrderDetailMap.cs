using DataAccess.Model;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Mapping
{
    public class OrderDetailMap : EntityTypeConfiguration<OrderDetailModel>
    {
        public OrderDetailMap()
        {
            this.HasKey(m => m.ID);
            this.ToTable("OrderDetail");
        }
    }
}
