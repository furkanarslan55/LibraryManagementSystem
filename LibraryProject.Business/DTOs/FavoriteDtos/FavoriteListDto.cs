using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Business.DTOs.FavoriteDtos
{
    public class FavoriteListDto
    {
        public int Id { get; set; } // Favori Kayıt ID'si (Silmek için lazım olur)
        public int BookId { get; set; }
        public string BookTitle { get; set; }

        public decimal BookPrice { get; set; }
    }
}
