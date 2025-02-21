using e_commerce.interfaces;
using e_commerce.Models;

namespace e_commerce.Reposatory
{
	public class categoryrepo:Icategory
	{
		private readonly appdb _appdb;
		public categoryrepo(appdb appdb)
		{
			_appdb = appdb;
		}

		public void create()
		{
			
		}

		public List<category> getall()
		{
			return _appdb.categories.ToList();
		}
	}
}
