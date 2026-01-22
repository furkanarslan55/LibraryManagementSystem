using LibraryProject.Business.DTOs.AuthDtos;
using LibraryProject.Business.Security.JWT;
using LibraryProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Business.Abstract
{
    public interface IAuthService
    {// Kayıt Ol: DTO alır, geriye DTO (veya Token) dönebilir. 
        // Şimdilik kayıt olan kullanıcıyı (User) dönelim.
        Task<AccessToken> RegisterAsync(UserForRegisterDto userForRegisterDto);

        // Giriş Yap: DTO alır, başarılıysa User döner. (Token üretme işini sonra yapacağız)
        Task<AccessToken> LoginAsync(UserForLoginDto userForLoginDto);

        // Yardımcı Metot: Bu mail sistemde var mı?
        Task<bool> UserExistsAsync(string email);
    }
}
