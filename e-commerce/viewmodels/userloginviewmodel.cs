using System.ComponentModel.DataAnnotations;

namespace e_commerce.viewmodels
{
    public class userloginviewmodel
    {
        [Required(ErrorMessage ="email is required")]
        public string email { get; set; }
        [Required(ErrorMessage = "password is required")]
        public string password { get; set; }
        public bool remember_me { get; set; }
      
    }
}
