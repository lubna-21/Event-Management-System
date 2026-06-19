using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs
{
        public class BookingDTO
        {
            public int Id { get; set; }

            public int UserId { get; set; }

            [Required]
            public int EventCategoryId { get; set; }

            [Required]
            [Range(1, 100)]
            public int SeatCount { get; set; }

            public double TotalPrice { get; set; }

            public DateTime BookingDate { get; set; }

            public string Status { get; set; } = "Confirmed";

            
            public string? UserName { get; set; }
            public string? EventCategoryName { get; set; }
            public double EventPrice { get; set; }
        }
    }
