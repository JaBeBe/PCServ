using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PCServ.Context;

namespace PCServ.Validation
{
    public class UniqueLogin : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ctx = (AppDbContext)validationContext.GetService(typeof(AppDbContext));

            var user = ctx.Users.Where(u => u.Login == value.ToString()).FirstOrDefault();

            if (user != null)
            {
                return new ValidationResult($"Login {value.ToString()} has been registered before.");
            }
            return ValidationResult.Success;
        }
    }
}
