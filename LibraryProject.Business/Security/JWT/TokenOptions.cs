namespace LibraryProject.Business.Security.JWT
{
    public class TokenOptions
    {
        public string Audience { get; set; } // Kimler kullanabilir? (www.google.com)
        public string Issuer { get; set; }   // Kim oluşturdu? (www.api.com)
        public int AccessTokenExpiration { get; set; } // Kaç dakika geçerli?
        public string SecurityKey { get; set; } // Gizli Anahtarımız
    }
}
