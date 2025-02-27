using e_commerce.Models;
namespace e_commerce.interfaces
    
{
    public interface Iorder
    {
        public List<order> get_all();
        public List<order> get_orders_with_user(string userid);
    }
}
