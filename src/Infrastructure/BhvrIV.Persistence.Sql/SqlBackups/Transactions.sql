CREATE PROCEDURE sp_AddNewTransaction
    @ProductId INT,
    @WarehouseId INT,
    @TransactionType NVARCHAR(50),
    @Quantity INT
AS
BEGIN

INSERT INTO InventoryManagement.Transactions (ProductId, WarehouseId, TransactionType, Quantity)
VALUES (@ProductId, @WarehouseId, @TransactionType, @Quantity);

END;
