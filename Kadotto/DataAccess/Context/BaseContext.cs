using DataAccess.Mapping;
using DataAccess.Model;
using System.Data.Entity;

namespace DataAccess.Context
{
    public class BaseContext : DbContext
    {
        public BaseContext() : base("Name=KadottoConnectionString")
        {
            Database.SetInitializer<BaseContext>(null);
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<BoxModel> Boxes { get; set; }
        public DbSet<PartitionModel> Partitions { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ProductAllowedPartitionModel> ProductAllowedPartitions { get; set; }
        public DbSet<ProductCategoryModel> ProductCategories { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new BoxMap());
            modelBuilder.Configurations.Add(new PartitionMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductAllowedPartitionMap());
            modelBuilder.Configurations.Add(new ProductCategoryMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
