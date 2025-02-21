using System.ComponentModel.DataAnnotations;

namespace e_commerce.viewmodels
{
    public class userregisterviewmodel
    {
        [Required(ErrorMessage ="username is required ")]
        public string username { get; set; }
        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage ="email is required")]
        
        public string email { get; set; }
        [Required(ErrorMessage ="Confirm Password is required")]
        [Compare("Password",ErrorMessage ="Confirm Password must be compatable with Password")]
        public string Confirmpassword { get; set; }
    }
}
