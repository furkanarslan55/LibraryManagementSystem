using LibraryProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Entities.Concrete
{
    public class Loan :BaseEntity
    {
        // İLİŞKİ 1: Hangi Kullanıcı?
        public int UserId { get; set; }
        public User User { get; set; } // Navigation Property (EF Core için bağlaç)

        // İLİŞKİ 2: Hangi Kitap?
        public int BookId { get; set; }
        public Book Book { get; set; } // Navigation Property

        // ÖZELLİKLER
        public DateTime LoanDate { get; set; } // Aldığı tarih

        // İade tarihi "Nullable" (Boş geçilebilir) olmalı. 
        // Çünkü kitabı aldığı an henüz iade etmemiştir. Null ise kitap hala ondadır.
        public DateTime? ReturnDate { get; set; }

     
        // Kitap geri geldi mi? (True/False)
        public bool IsReturned { get; set; }
    }
}
