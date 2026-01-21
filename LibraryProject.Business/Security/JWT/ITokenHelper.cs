using LibraryProject.Entities.Concrete;

namespace LibraryProject.Business.Security.JWT
{
    public interface ITokenHelper
    {// Kullanıcıyı ve (ileride) Rollerini alıp Token üretecek.
        AccessToken CreateToken(User user);
    }
}
