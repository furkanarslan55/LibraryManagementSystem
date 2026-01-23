using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Business.DTOs.BookDtos
{
    public class BookAddDto
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public int Stock { get; set; }
    }
}
