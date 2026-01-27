using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Business.DTOs.Comment
{
    public class ListCommentDto
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Score { get; set; }
        public string UserName { get; set; } // Yorumu yapanın adı
        public DateTime CreatedDate { get; set; } // Ne zaman yazdı?
    }
}
