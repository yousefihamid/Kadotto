﻿using DataAccess.Mapping;
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
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<PackagedBoxModel> PackagedBoxes { get; set; }
        public DbSet<PackagedBoxDetailModel> PackagedBoxDetails { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderDetailModel> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new BoxMap());
            modelBuilder.Configurations.Add(new PartitionMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductAllowedPartitionMap());
            modelBuilder.Configurations.Add(new ProductCategoryMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new PackagedBoxMap());
            modelBuilder.Configurations.Add(new PackagedBoxDetailMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
        }
    }
}
