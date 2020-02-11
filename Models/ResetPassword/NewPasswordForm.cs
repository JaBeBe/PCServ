using System;
using System.ComponentModel.DataAnnotations;

namespace PCServ.Models.ResetPassword
{
    public class NewPasswordForm
    {
        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
