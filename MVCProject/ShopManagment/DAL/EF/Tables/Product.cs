using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string ProductPrice { get; set; } = null!;

    public string ProductQuantity { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
