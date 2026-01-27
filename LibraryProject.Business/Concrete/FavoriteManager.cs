using AutoMapper;
using LibraryProject.Business.Abstract;
using LibraryProject.Business.DTOs.FavoriteDtos;
using LibraryProject.DataAccess.Abstract;
using LibraryProject.DataAccess.Concrete.EntityFramework;
using LibraryProject.DataAccess.Migrations;
using LibraryProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Business.Concrete
{
    public class FavoriteManager : IFavoriteService
    {
        private readonly IFavoriteDal _favoriteDal;
        private readonly IAuthenticatedUserService _authenticatedUserService; // Kim bu kullanıcı?
        private readonly IMapper _mapper;
        public FavoriteManager(IFavoriteDal favoriteDal, IAuthenticatedUserService authenticatedUserService, IMapper mapper)
        {
            _favoriteDal = favoriteDal;
            _authenticatedUserService = authenticatedUserService;
            _mapper = mapper;
        }




       public async Task AddFavoriteAsync(FavoriteAddDto favoriteAddDto)
        {
        
      
            int currentUserId = _authenticatedUserService.UserId ?? throw new Exception("Giriş yapmalısınız!");

       
        var existing = await _favoriteDal.GetAsync(x => x.UserId == currentUserId && x.BookId == favoriteAddDto.BookId);
            if (existing != null)
            {
                throw new Exception("Bu kitap zaten favorilerinizde.");
            }

            // 3. Ekleme
            var favorite = _mapper.Map<Favorite>(favoriteAddDto);
            favorite.UserId = currentUserId; // ID'yi Token'dan gelen bilgiyle dolduruyoruz.
            
            // Tarih ve CreatedBy alanlarını Interceptor otomatik dolduracak!
            await _favoriteDal.AddAsync(favorite);
}

        public async Task<List<FavoriteListDto>> GetMyFavoritesAsync()
        {
            int currentUserId = _authenticatedUserService.UserId ?? throw new Exception("Giriş yapmalısınız!");

            // Include(x => x.Book) diyerek kitap detaylarını da çekiyoruz
            var favorites = await _favoriteDal.GetAllAsync(x => x.UserId == currentUserId);

            return _mapper.Map<List<FavoriteListDto>>(favorites);
        }

        public async Task RemoveFavoriteAsync(int favoriteId)
        {
            // Sadece kendi favorisini silebilir!
            int currentUserId = _authenticatedUserService.UserId ?? throw new Exception("Giriş yapmalısınız!");

            var favorite = await _favoriteDal.GetByIdAsync(favoriteId);

            if (favorite == null) throw new Exception("Kayıt bulunamadı");

            if (favorite.UserId != currentUserId) throw new Exception("Bu işlem için yetkiniz yok.");

            _favoriteDal.Delete(favorite); // Soft Delete çalışacak
        }

    }







    }



