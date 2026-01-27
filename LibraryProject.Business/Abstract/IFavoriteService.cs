using LibraryProject.Business.DTOs.FavoriteDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Business.Abstract
{
    public interface IFavoriteService
    {
        Task AddFavoriteAsync(FavoriteAddDto favoriteAddDto);

      
        Task RemoveFavoriteAsync(int id);

        // 3. Benim Favorilerimi Getir
        // Kullanıcı ID'si istemiyoruz, çünkü Token'dan kendimiz bulacağız.
        Task<List<FavoriteListDto>> GetMyFavoritesAsync();
    }
}
