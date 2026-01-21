using LibraryProject.Business.Abstract;
using LibraryProject.Business.DTOs.AuthDtos;
using LibraryProject.Business.Security.Hashing;
using LibraryProject.DataAccess.Abstract;
using LibraryProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Business.Concrete
{
    public class AuthManager(IUserDal userDal) :IAuthService
    {
        private readonly IUserDal _userDal = userDal;

        public async Task<User> RegisterAsync(UserForRegisterDto userForRegisterDto)
        {
            // 1. Şifreyi Kriptola (Hashing)
            // out parametresi ile değişkenleri dolduruyoruz.
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);

            // 2. User Nesnesini Oluştur
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash, // Kriptolu
                PasswordSalt = passwordSalt, // Anahtar
                Role = "User", // Varsayılan rol
                CreatedDate = DateTime.Now
            };

            // 3. Veritabanına Kaydet
            await _userDal.AddAsync(user);
            return user;
        }

        public async Task<User> LoginAsync(UserForLoginDto userForLoginDto)
        {
            // 1. Kullanıcıyı Mail ile Bul
            // (GenericRepository'de GetAllAsync(filter) metodunu kullanıyoruz)
            var userList = await _userDal.GetAllAsync(u => u.Email == userForLoginDto.Email);
            var user = userList.FirstOrDefault();

            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı.");
            }

            // 2. Şifreyi Doğrula
            // Kullanıcının girdiği şifre (dto.Password) ile veritabanındaki hash'i karşılaştır.
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new Exception("Şifre hatalı.");
            }

            // 3. Başarılıysa User'ı dön
            return user;
        }

        public async Task<bool> UserExistsAsync(string email)
        {
            var users = await _userDal.GetAllAsync(u => u.Email == email);
            return users.Any();
        }
    }
}

