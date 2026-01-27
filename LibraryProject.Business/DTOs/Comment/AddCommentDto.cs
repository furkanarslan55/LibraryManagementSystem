using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Business.DTOs.Comment
{
    public class AddCommentDto
    {
        public int BookId { get; set; }
        public string Comment { get; set; }
        public int Score { get; set; } // 1-5 arası kontrol edilecek
    }
}
