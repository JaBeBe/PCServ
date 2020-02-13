using System;
using System.ComponentModel.DataAnnotations;

namespace PCServ.Models.ResetPassword
{
    public class RequestResetForm
    {
        [Required]
        [EmailAddress]
        public string EMail { get; set; }
    }
}
