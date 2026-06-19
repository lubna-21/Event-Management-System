using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Booking
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int EventCategoryId { get; set; }

    public int SeatCount { get; set; }

    public double TotalPrice { get; set; }

    public DateTime BookingDate { get; set; }

    public string Status { get; set; } = null!;

    public virtual EventCategory EventCategory { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
