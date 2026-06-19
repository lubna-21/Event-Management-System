using BLL.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
        public class UserDTO
        {
            public int Id { get; set; }

            [Required]
            public string FullName { get; set; } = null!;

            [Required]
            [EmailAddress]
            public string Email { get; set; } = null!;

            [Required]
            public string Password { get; set; } = null!;

            [Required]
            [PasswordMatch]
        public string ConfirmPassword { get; set; } = null!;
        }
    }
