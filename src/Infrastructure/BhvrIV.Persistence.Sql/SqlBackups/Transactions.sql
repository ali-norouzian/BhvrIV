CREATE PROCEDURE sp_AddNewTransaction
    @ProductId INT,
    @WarehouseId INT,
    @TransactionType NVARCHAR(50),
    @Quantity INT
AS
BEGIN

INSERT INTO InventoryManagement.Transactions (ProductId, WarehouseId, TransactionType, Quantity)
VALUES (@ProductId, @WarehouseId, @TransactionType, @Quantity);
SELECT SCOPE_IDENTITY() AS Id;

END;


CREATE PROCEDURE [dbo].[sp_GetProductStockInWarehouse]
    @ProductId INT,
    @WarehouseId INT
AS
BEGIN

SELECT P.StockQuantity
FROM InventoryManagement.Transactions AS T
INNER JOIN InventoryManagement.Products AS P ON T.ProductId = P.Id
WHERE T.ProductId = @ProductId AND T.WarehouseId = @WarehouseId

END;


CREATE PROCEDURE [dbo].[sp_GetTransactionsByType]
    @TransactionType NVARCHAR(50)
AS
BEGIN

SELECT *
FROM InventoryManagement.Transactions
WHERE TransactionType = @TransactionType

END;
