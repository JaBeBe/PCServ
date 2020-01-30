using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PCServ.Context;

namespace PCServ.Validation
{
    public class UniqueEmail : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null)
                return ValidationResult.Success;

            var ctx = (AppDbContext)validationContext.GetService(typeof(AppDbContext));

            var user = ctx.Users.Where(u => u.EMail == value.ToString()).FirstOrDefault();

            if (user != null)
            {
                return new ValidationResult($"Email {value.ToString()} has been registered before.");
            }
            return ValidationResult.Success;
        }
    }
}
