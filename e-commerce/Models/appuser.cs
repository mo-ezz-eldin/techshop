using Microsoft.AspNetCore.Identity;

namespace e_commerce.Models
{
    public class appuser : IdentityUser
    {
        public List<wishlist> wishlist { get; set; }
        public List<order>orders { get; set; }
    }
}
