using LibraryProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryProject.DataAccess.Concrete.EntityFramework.Configurations
{
    public class AuthorConfiguration: IEntityTypeConfiguration<Author>
    {

        public void Configure(EntityTypeBuilder<Author> builder)
        {

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);

            // Seed Data (Başlangıç Verileri)
            builder.HasData(
                new Author { Id = 1, FirstName = "J.K.", LastName = "Rowling", BirthDate = new DateTime(1965, 7, 31), CreatedAt = DateTime.Now },
                new Author { Id = 2, FirstName = "George", LastName = "Orwell", BirthDate = new DateTime(1903, 6, 25), CreatedAt = DateTime.Now },
                new Author { Id = 3, FirstName = "Fyodor", LastName = "Dostoyevski", BirthDate = new DateTime(1821, 11, 11), CreatedAt = DateTime.Now }
            );


        }

    }
}
