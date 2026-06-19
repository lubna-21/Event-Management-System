using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class EventCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
