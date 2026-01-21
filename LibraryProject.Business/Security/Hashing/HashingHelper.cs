using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Business.Security.Hashing
{
    public static class HashingHelper
    {
        // 1. Şifre Oluşturma (Register anında çalışır)
        // Kullanıcının girdiği string şifreyi alır, geriye Hash ve Salt döner.
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key; // Her şifre için özel bir anahtar oluşturur.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // Şifreyi karıştırır.
            }
        }

        // 2. Şifre Doğrulama (Login anında çalışır)
        // Kullanıcı şifreyi girer, biz veritabanındaki Hash ve Salt ile eşleşiyor mu diye bakarız.
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt)) // Aynı anahtarı (Salt) kullanıyoruz.
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Oluşturulan hash ile veritabanındaki hash'i byte byte karşılaştır.
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false; // Bir byte bile tutmazsa şifre yanlıştır.
                    }
                }
                return true;
            }
        }
    }
}
