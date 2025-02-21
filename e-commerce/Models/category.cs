namespace e_commerce.Models
{
	public class category
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<product>? Products { get; set; }
	}
}
