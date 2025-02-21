using e_commerce.interfaces;
using e_commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce.Controllers
{
    public class productController : Controller
    {
        private readonly Iprodeuct _product;
        private readonly UserManager<appuser> _userManager;
        private readonly Iwishlist _iwishlist;
        public productController(Iprodeuct product,UserManager<appuser>userManager,Iwishlist wish)
        {


          
             _product = product;
            _userManager = userManager;
            _iwishlist = wish;

        }
        [Authorize]
        
        public IActionResult view_details(int id)
        {
            var product = _product.getsingleproduct(id);
            if (product == null)
            {
                return NotFound();
            }

            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            if (user != null)
            {
                var existingWish = _iwishlist.GetByUserAndProduct(user.Id, id);
                ViewBag.IsInWishlist = existingWish != null; 
            }
            else
            {
                ViewBag.IsInWishlist = false; 
            }

            return View("product_detail", product);
        }


    }
}
