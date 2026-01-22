using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Business.DTOs.LoanDtos
{
    public class LoanCreateDto
    {
        public int UserId { get; set; } // Kim alıyor?
        public int BookId { get; set; } // Hangi kitabı alıyor?
    }
}
