namespace e_commerce.Models
{
    public class order
    {
        public int Id { get; set; }
        public int product_id { get; set; }
        public string user_id { get; set; }
        public appuser user { get; set; }
        public product product { get; set; }
    }
}
