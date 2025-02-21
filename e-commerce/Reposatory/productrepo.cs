using e_commerce.interfaces;
using e_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.Reposatory
{
    public class productrepo : Iprodeuct
    {
        private readonly appdb _appdb;
        public productrepo(appdb appdb)
        {
            _appdb = appdb;
        }
        public List<product> getall()
        {
            return _appdb.products.ToList();
        }
        public List<product>getrange(int val)
        {
            return _appdb.products.OrderBy(x=>Guid.NewGuid()).Take(val).ToList();
        }

        public product getsingleproduct(int id)
        {
            return _appdb.products.FirstOrDefault(x => x.Id == id);
        }

        public List<product> search(string keyword)
        {
            return _appdb.products.Include(x=>x.cat).Where(x=>x.cat.Name.Contains(keyword) || x.Name.Contains(keyword)).ToList();
        }
    }
}
