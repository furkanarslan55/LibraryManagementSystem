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
    public class LoanConfiguration :IEntityTypeConfiguration<Loan>
    {

        public void Configure(EntityTypeBuilder<Loan> builder)
        {

            // Bir Ödünç işleminin bir kullanıcısı olur, Kullanıcının çok ödünç işlemi olabilir.
            builder.HasOne(x => x.User)
                   .WithMany() // User tarafında "Loans" listesi tutmadığımız için boş bıraktık.
                   .HasForeignKey(x => x.UserId);

            // Bir Ödünç işleminin bir kitabı olur.
            builder.HasOne(x => x.Book)
                   .WithMany()
                   .HasForeignKey(x => x.BookId);

            // 2. Özellik Ayarları
            builder.Property(x => x.LoanDate).IsRequired();
            // ReturnDate zaten nullable (DateTime?) olduğu için IsRequired dememize gerek yok.




        }

    }
}
