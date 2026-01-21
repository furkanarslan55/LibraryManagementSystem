using LibraryProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Entities.Concrete
{
    public class User :BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public byte[] PasswordHash { get; set; } // şifreyi açıklamadan saklamak için hash kullanılır.
     
        public byte[] PasswordSalt { get; set; }
    

        public string Role { get; set; } // Kullanıcının rolü (örneğin, Admin, User vb.)
        public DateTime CreatedDate { get; set; }
    }
}
