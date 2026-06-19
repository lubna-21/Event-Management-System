using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Validations
{
    public class PasswordMatch : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return new ValidationResult("Confirm Password is required");

            var obj = validationContext.ObjectInstance as UserDTO;
            if (obj != null && obj.Password != null && obj.Password.Equals(value.ToString()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Password and Confirm Password Mismatch");
        }
    }
}