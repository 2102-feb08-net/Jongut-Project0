/********************************************************************************
   Script: ProjectSQL.sql
   Description: Creates and populates the Project 0 database.
   DB Server: Project0-SQL
   Author: Jonathan Gutierrez
********************************************************************************/

/*******************************************************************************
   Create Tables
********************************************************************************/
CREATE TABLE [Customer]
(
    [CustomerID] INT NOT NULL IDENTITY UNIQUE,
    [FirstName] NVARCHAR(160) NOT NULL,
    [LastName] INT NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([CustomerID])
);
GO

CREATE TABLE [Order]
(
	[CustomerID] INT NOT NULL IDENTITY UNIQUE,
    [OrderID] INT NOT NULL IDENTITY UNIQUE,
    [Total] Decimal NOT NULL,
    [ProductID] INT NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([OrderID])
);

GO
CREATE TABLE [Store]
(
	[CustomerID] INT NOT NULL IDENTITY UNIQUE,
	[OrderID] INT NOT NULL IDENTITY UNIQUE,
    [StoreID] INT NOT NULL IDENTITY UNIQUE,
    [StoreName] NVARCHAR(160) NOT NULL,
    CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED ([StoreID])
);
GO

CREATE TABLE [Product]
(
	[ProductID] NVARCHAR(160) NOT NULL,
    [ProductName] NVARCHAR(160) NOT NULL,
    [Price] Decimal NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([ProductID])
);
GO

/*******************************************************************************
   Create Foreign Keys
********************************************************************************/

ALTER TABLE [Customer] ADD CONSTRAINT [FK_CustomerOrderID]
    FOREIGN KEY ([CustomerID]) REFERENCES [Order] (CustomerID) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

CREATE INDEX [FK_CustomerOrderID] ON [Customer] ([CustomerID]);
GO

ALTER TABLE [Order] ADD CONSTRAINT [FK_StoreOrderID]
    FOREIGN KEY ([OrderID]) REFERENCES [Store] (OrderID) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

CREATE INDEX [FK_StoreOrderID] ON [Order] ([OrderID]);
GO

ALTER TABLE [Store] ADD CONSTRAINT [FK_StoreCustomerID]
    FOREIGN KEY ([CustomerID]) REFERENCES [Customer] (CustomerID) ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

CREATE INDEX [FK_StoreCustomerID] ON [Store] ([StoreID]);
GO

/*******************************************************************************
   Populate Tables
********************************************************************************/
INSERT INTO [Customer] ([CustomerID], [FirstName], [LastName]) VALUES (1, N'Jonathan',N'Gutierrez');
INSERT INTO [Customer] ([CustomerID], [FirstName], [LastName]) VALUES (2, N'Alan',N'Walker');
INSERT INTO [Customer] ([CustomerID], [FirstName], [LastName]) VALUES (3, N'Chris',N'Allen');
INSERT INTO [Order] ([CustomerID], [OrderID], [Price]) VALUES (1, 1,10.00);
INSERT INTO [Order] ([CustomerID], [OrderID], [Price]) VALUES (1, 2,5.00);
INSERT INTO [Order] ([CustomerID], [OrderID], [Price]) VALUES (1, 3,20.00);
INSERT INTO [Order] ([CustomerID], [OrderID], [Price]) VALUES (2, 1,10.00);
INSERT INTO [Order] ([CustomerID], [OrderID], [Price]) VALUES (2, 2,5.00);
INSERT INTO [Order] ([CustomerID], [OrderID], [Price]) VALUES (2, 3,20.00);
INSERT INTO [Order] ([CustomerID], [OrderID], [Price]) VALUES (3, 1,10.00);
INSERT INTO [Order] ([CustomerID], [OrderID], [Price]) VALUES (3, 2,5.00);
INSERT INTO [Order] ([CustomerID], [OrderID], [Price]) VALUES (3, 3,20.00);
INSERT INTO [Store] ([OrderID], [StoreID], [CustomerID],[StoreName]) VALUES (1, 1, 1, N'Amazon');
INSERT INTO [Store] ([OrderID], [StoreID], [CustomerID], [StoreName]) VALUES (2, 1, 1, N'Amazon');
INSERT INTO [Store] ([OrderID], [StoreID], [CustomerID], [StoreName]) VALUES (3, 2, 1, N'Ebay');
INSERT INTO [Store] ([OrderID], [StoreID], [CustomerID],[StoreName]) VALUES (1, 1, 2, N'Amazon');
INSERT INTO [Store] ([OrderID], [StoreID], [CustomerID],[StoreName]) VALUES (2, 2, 2, N'Ebay');
INSERT INTO [Store] ([OrderID], [StoreID], [CustomerID],[StoreName]) VALUES (3, 3, 2, N'Walgreens');
INSERT INTO [Store] ([OrderID], [StoreID], [CustomerID],[StoreName]) VALUES (1, 1, 3, N'Amazon');
INSERT INTO [Store] ([OrderID], [StoreID], [CustomerID],[StoreName]) VALUES (2, 3, 3, N'Amazon');
INSERT INTO [Store] ([OrderID], [StoreID], [CustomerID],[StoreName]) VALUES (3, 4, 3, N'GoodWe');