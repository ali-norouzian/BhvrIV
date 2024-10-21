namespace BhvrIV.Application.Features.Transaction.Queries.GetProductStockInWarehouse;

public record GetTransactionsByTypeQueryResult(
    int Id,
    int ProductId,
    int WarehouseId,
    string TransactionType,
    int Quantity,
    DateTime Date);