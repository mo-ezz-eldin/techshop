using e_commerce.Models;

namespace e_commerce.interfaces
{
    public interface Iprodeuct
    {
        public List<product> getall();
        public List<product> getrange(int val);
        public product getsingleproduct(int id);
        public List<product> search(string keyword);
    }
}
