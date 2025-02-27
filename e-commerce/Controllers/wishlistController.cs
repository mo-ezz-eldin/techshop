
using Microsoft.AspNetCore.Mvc;
using e_commerce.Models;
using e_commerce.interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace e_commerce.Controllers
{
    public class wishlistController : Controller
    {
        private readonly Iwishlist _iwishlist;
        private readonly UserManager<appuser> _usermanager;

        public wishlistController(Iwishlist iwishlist, UserManager<appuser> userManager)
        {
            _iwishlist = iwishlist;
            _usermanager = userManager;

        }

        public async Task<IActionResult> Index(string username)
        {
            var user = await _usermanager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound("this user is invalid");

            }


            return View("user_wishlist", _iwishlist.GetProductsWhithUser(user.Id));

        }
        [Authorize(Roles = "User")]
        public IActionResult AddToWishlist(int id, string userid)
        {
            try
            {
                var existingWish = _iwishlist.GetByUserAndProduct(userid, id);
                if (existingWish != null)
                {
                    TempData["Message"] = "This product is already in your wishlist.";
                    return RedirectToAction("view_details", "product", new { id = id });
                }
                var wish = new wishlist()
                {
                    user_id = userid,
                    product_id = id
                };

                _iwishlist.create(wish);


                TempData["Message"] = "Product added to your wishlist successfully!";
            }
            catch (Exception ex)
            {

                TempData["Error"] = "An error occurred while adding the product to your wishlist.";
            }
            return RedirectToAction("view_details", "product", new { id = id });
        }

        public async Task<IActionResult> remove(int product_id, string username)
        {
            var user = await _usermanager.FindByNameAsync(username);
            if (user == null) { return NotFound("this user is not here"); }
            var get_user_product=_iwishlist.GetByUserAndProduct(user.Id, product_id);
            _iwishlist.remove(get_user_product);
            return RedirectToAction("Index", new { username = username });
        }
    }
}
    
