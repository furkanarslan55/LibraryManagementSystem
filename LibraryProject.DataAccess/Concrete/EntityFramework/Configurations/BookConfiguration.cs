using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryProject.DataAccess.Concrete.EntityFramework.Configurations
{
    public class BookConfiguration :IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)"); // SQL'de para tipi ayarı

            builder.HasData(
                new Book
                {
                    Id = 1,
                    Title = "Dune",
                    Price = 250,
                    CategoryId = 1, // Bilim Kurgu
                    CreatedAt = DateTime.Now,
                    AuthorId = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "Suç ve Ceza",
                    Price = 180,
                    CategoryId = 2, // Dünya Klasikleri
                    CreatedAt = DateTime.Now,
                    AuthorId = 2
                },
                new Book
                {
                    Id = 3,
                    Title = "Atomik Alışkanlıklar",
                    Price = 200,
                    CategoryId = 3, // Kişisel Gelişim
                    CreatedAt = DateTime.Now,
                    AuthorId = 3,
                    
                    
                }
            );
        }
    }
}
