using LibraryProject.Entities.Concrete;
using Microsoft.Extensions.Configuration; // GetSection için gerekli
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryProject.Business.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        private readonly IConfiguration _configuration;
        private readonly TokenOptions _tokenOptions;

        // Constructor ismi Sınıf ismiyle (JwtHelper) AYNI OLMALIDIR. Bu doğrudur.
        // Ama içeride "public int JwtHelper { get; set; }" gibi bir şey olmamalıdır.
        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;

            // GetSection ve Get<T> metotları için "Microsoft.Extensions.Configuration.Binder"
            // paketi Business katmanında yüklü olmalıdır.
            _tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration),
                Issuer = _tokenOptions.Issuer,
                Audience = _tokenOptions.Audience,
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AccessToken
            {
                Token = tokenHandler.WriteToken(token),
                Expiration = tokenDescriptor.Expires.Value
            };
        }
    }
}