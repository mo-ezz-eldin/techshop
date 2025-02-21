using e_commerce.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace e_commerce.interfaces
{
    public interface Iwishlist
    {
        public void create(wishlist wish);
        public wishlist GetByUserAndProduct(string userId, int productId);
        public List<product> GetProductsWhithUser(string userId);
        public void remove(wishlist wish);
    }
}
