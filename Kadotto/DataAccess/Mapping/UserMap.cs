using DataAccess.Model;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Mapping
{
    public class UserMap : EntityTypeConfiguration<UserModel>
    {
        public UserMap()
        {
            this.HasKey(m => m.ID);
            this.ToTable("User");
        }
    }
}
