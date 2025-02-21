using e_commerce.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce.Controllers
{
	public class categoryController : Controller
	{
		private readonly Icategory _categoryservice;
		public categoryController(Icategory categoryservice)
		{
			_categoryservice = categoryservice;
		}
		public IActionResult index()
		{
			
			return View("category_details",_categoryservice.getall());
		}
	}
}
