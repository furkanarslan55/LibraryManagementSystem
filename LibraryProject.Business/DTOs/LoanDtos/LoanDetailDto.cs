using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Business.DTOs.LoanDtos
{
    public class LoanDetailDto
    {
        public int Id { get; set; }        // İşlem ID'si
        public string BookName { get; set; } // DİKKAT: BookId değil, Kitap Adı!
        public string UserName { get; set; } // Kim almış?
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; }
    }
}
