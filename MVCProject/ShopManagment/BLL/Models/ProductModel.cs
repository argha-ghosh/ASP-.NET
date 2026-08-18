using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public string ProductPrice { get; set; } = null!;

        public string ProductQuantity { get; set; } = null!;
    }
}
