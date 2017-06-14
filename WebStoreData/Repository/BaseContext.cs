using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Configuration;
using WebStoreData.Mapping;
using WebStoreData.Models;


namespace WebStoreData.Repository
{
    public class BaseContext : DbContext
    {
        public BaseContext(string connectionString)
        {
            Database.Connection.ConnectionString = connectionString;
            Database.SetInitializer<BaseContext>(null);

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
            .HasOptional(c => c.Section)
            .WithMany(s => s.Categories)
            .HasForeignKey(c => c.SectionId);

            modelBuilder.Entity<Subcategory>()
           .HasOptional(sc => sc.Category)
           .WithMany(cr =>cr.Subcategories)
           .HasForeignKey(sc => sc.CategoryId);

            modelBuilder.Entity<Product>()
           .HasOptional(p => p.Subcategory)
           .WithMany(subc => subc.Products)
           .HasForeignKey(p => p.SubcategoryId);

            modelBuilder.Entity<ProductDescription>()
           .HasOptional(pd => pd.Product)
           .WithMany(p => p.ProductDescriptions)
           .HasForeignKey(pd => pd.ProductId);

            modelBuilder.Entity<ProductPicture>()
           .HasOptional(pp => pp.Product)
           .WithMany(p => p.ProductPictures)
           .HasForeignKey(pp => pp.PictureId);

            modelBuilder.Configurations.Add(new SectionMapping());
            modelBuilder.Configurations.Add(new CategoryMapping());
            modelBuilder.Configurations.Add(new SubcategoryMapping());
            modelBuilder.Configurations.Add(new ProductMapping());
            modelBuilder.Configurations.Add(new ProductDescriptionMapping());
            modelBuilder.Configurations.Add(new ProductPictureMapping());
            modelBuilder.Configurations.Add(new UserMapping());
            
        }

        //public BaseContext()
        //    : base(ConfigurationManager.ConnectionStrings["WebStore"].ConnectionString)
        //{
        //    Database.SetInitializer<BaseContext>(null);
        //}
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Subcategory> Subcategory { get; set; }
        public DbSet<ProductDescription> ProductDescription { get; set; }
        //public DbSet<ProductShortDescription> ProductShortDescription { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
    }
}
