using System.ComponentModel.DataAnnotations;
using e_commerce.custom_valiation;

namespace e_commerce.viewmodels
{
    public class UserEditVM
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string UserName { get; set; }

        [optionalpasswordforediting]
        public string? NewPassword { get; set; }

       
 [optionalpasswordforediting]
        public string? ConfirmPassword { get; set; }
    }
}
