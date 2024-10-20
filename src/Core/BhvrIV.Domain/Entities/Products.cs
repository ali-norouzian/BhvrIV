using BhvrIV.Domain.Entities.Common;

namespace BhvrIV.Domain.Entities;

public class Products : EntityBase
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}