using BhvrIV.Domain.Entities.Common;
using BhvrIV.Domain.Entities.Enums;

namespace BhvrIV.Domain.Entities;

public class Transactions : EntityBase
{
    public int ProductId { get; set; }
    public int WarehouseId { get; set; }

    public TransactionType TransactionType { get; set; }
    public int Quantity { get; set; }
    public DateTime Date { get; set; }

    public Products Product { get; set; }
    public Warehouses Warehouse { get; set; }
}

