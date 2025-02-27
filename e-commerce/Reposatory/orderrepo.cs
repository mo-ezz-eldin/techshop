using e_commerce.interfaces;
using e_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.Reposatory
{
    public class orderrepo : Iorder
    {
        private readonly appdb _db;
        public orderrepo(appdb db)
        {
           _db = db;
        }
        public List<order> get_all()
        {
            return _db.orders.Include(x=>x.product).Include(x=>x.user).ToList();
        }

        public List<order> get_orders_with_user(string userid)
        {
           return _db.orders.Include(x=>x.user ).Include(x=>x.product).Where(x=>x.user_id == userid ).ToList();
        }
    }
}
