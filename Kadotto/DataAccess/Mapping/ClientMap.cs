using DataAccess.Model;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Mapping
{
    public class ClientMap : EntityTypeConfiguration<ClientModel>
    {
        public ClientMap()
        {
            this.HasKey(m => m.ID);
            this.ToTable("Client");
        }
    }
}
