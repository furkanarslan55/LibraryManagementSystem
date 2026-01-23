using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Business.DTOs.StatisticsDtos
{
    public class DashboardDto
    {
        public int TotalBooks { get; set; }        // Toplam Kitap Sayısı
        public int TotalUsers { get; set; }        // Toplam Üye Sayısı
        public int ActiveLoans { get; set; }       // Şu an dışarıda olan (Dönmemiş) kitap sayısı
        public int TotalCategories { get; set; }   // Kaç farklı kategorimiz var?
    }
}
