using e_commerce.interfaces;
using e_commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce.Controllers
{
    public class orderController : Controller
    {
        private readonly Iorder _order;
        private readonly UserManager<appuser> _usermanager;
        public orderController(Iorder order, UserManager<appuser>userManager)
        {
            _order = order;
            _usermanager = userManager;
        }
        [Authorize(Roles ="Admin")]
        
        public IActionResult Index()
        {
            return View("index",_order.get_all());
        }
        public async Task<IActionResult> orders_user(string userName)
        {
            var user=await _usermanager.FindByNameAsync(userName);
            if (user==null)
            {
                return NotFound();
            }
            return View("orders_per_user",_order.get_orders_with_user(user.Id));
        }
    }
}
