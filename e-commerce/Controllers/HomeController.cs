using e_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using e_commerce.interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace e_commerce.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly Iprodeuct _iprodeuct;
		private readonly SignInManager<appuser> _sign;
       
        public HomeController(ILogger<HomeController> logger,Iprodeuct product, SignInManager<appuser> sign)
		{
			_logger = logger;
			_iprodeuct = product;
			_sign = sign;
		}

		public IActionResult Index()
		{
			if (User.Identity.IsAuthenticated)
			{
				

				return View(_iprodeuct.getall());
			}
			else
			{
				return View(_iprodeuct.getrange(12));
			}
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
		[Authorize]
		public IActionResult Search(string searchQuery)
		{
			var products=_iprodeuct.search(searchQuery);
			if(products == null || products.Count==0)
			{
				ViewData["no_match"] = "no matching for this";
			}
            return View("Index",products);
        }

    }
}
