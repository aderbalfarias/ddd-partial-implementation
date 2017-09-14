using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DDDExample.Mvc.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = @"Required Field")]
        [DisplayName(@"User")]
        public string Login { get; set; }

        [Required(ErrorMessage = @"Required Field")]
        [DisplayName(@"Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName(@"Remember Me")]
        public bool RememberMe { get; set; }

        [Required(ErrorMessage = @"Required Field")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = @"Fill in with a valid email")]
        [DisplayName(@"Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = @"Required Field")]
        [DisplayName(@"Recover Code")]
        public string CodigoRecover { get; set; }

        [Required(ErrorMessage = @"Required Field")]
        [StringLength(100, ErrorMessage = @"The field should have at least {2} characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = @"New Password")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = @"Required Field")]
        [DataType(DataType.Password)]
        [Display(Name = @"Confirm the new Password")]
        [Compare("NewPassword", ErrorMessage = @"A nova senha e a confimirmação não conferem.")]
        public string ConfirmPassword { get; set; }
    }
}