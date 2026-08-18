using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Order
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public double TotalPrice { get; set; }

    public DateOnly OrderDate { get; set; }

    public string OrderStatus { get; set; } = null!;

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
