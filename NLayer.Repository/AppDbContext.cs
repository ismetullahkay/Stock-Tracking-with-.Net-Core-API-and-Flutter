using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)  //VT yolunu startup dosyasından vermek için option oluşturuldu
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //tüm dbconfları verdik onaylattık


            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {

                Id = 1,
                Color = "Kırmızı",
                Height = 120,
                Width = 200,
                ProductId = 1,
            },
            new ProductFeature()
            {

                Id = 2,
                Color = "Mavi",
                Height = 1320,
                Width = 1200,
                ProductId = 2,
            }
            );




            base.OnModelCreating(modelBuilder);
        }


    }
}
