using LibraryProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LibraryProject.DataAccess.Concrete.EntityFramework.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // İstersen veritabanı kurallarını da burada belirleyebilirsin:
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            // SEED DATA (Tohumlama)
            // HasData: Veritabanı oluşurken bu verileri "INSERT" eder.
            // DİKKAT: Burada ID vermek ZORUNLUDUR!
            builder.HasData(
                new Category { Id = 1, Name = "Bilim Kurgu", CreatedAt = DateTime.Now },
                new Category { Id = 2, Name = "Dünya Klasikleri", CreatedAt = DateTime.Now },
                new Category { Id = 3, Name = "Kişisel Gelişim", CreatedAt = DateTime.Now }
            );
        }
    }
}
