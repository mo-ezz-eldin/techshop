using e_commerce.interfaces;
using e_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.Reposatory
{
    public class wishrepo : Iwishlist
    {
        private readonly appdb _appdb;
        public wishrepo(appdb appdb)
        {
            _appdb = appdb;
        }
        public void create(wishlist wish)
        {
            _appdb.wishlist.Add(wish);
            _appdb.SaveChanges();
        }

        public wishlist GetByUserAndProduct(string userId, int productId)
        {
            return _appdb.wishlist.FirstOrDefault(x => x.user_id == userId && x.product_id == productId);
        }

		public List<product> GetProductsWhithUser(string userId)
		{


            return _appdb.wishlist.Where(x => x.user_id == userId).GroupJoin(

                _appdb.products,
                wish => wish.product_id,
                pro => pro.Id,
               (wish,pro) => pro)
                .SelectMany(pro => pro).ToList();



        }

        public void remove(wishlist wish)
        {
            _appdb.Remove(wish);
            _appdb.SaveChanges();
        }
    }
	}

