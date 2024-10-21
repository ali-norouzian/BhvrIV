CREATE PROCEDURE sp_AddNewProduct
    @Name NVARCHAR(100),
    @Price DECIMAL(10, 2),
    @StockQuantity INT
AS
BEGIN

INSERT INTO InventoryManagement.Products (Name, Price, StockQuantity)
VALUES (@Name, @Price, @StockQuantity);
SELECT SCOPE_IDENTITY() AS Id;

END;
GO