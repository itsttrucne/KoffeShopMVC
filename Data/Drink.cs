using System;
using System.Collections.Generic;

namespace WebBanNuocMVC.Data;

public partial class Drink
{
    public int DrinkId { get; set; }

    public string? DrinkName { get; set; }

    public int? CategoryId { get; set; }

    public decimal? Price { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
