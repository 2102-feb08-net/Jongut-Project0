/********************************************************************************
   SCRIPT: PROJECTSQL.SQL
   DESCRIPTION: CREATES AND POPULATES THE PROJECT 0 DATABASE.
   DB SERVER: PROJECT0-SQL
   AUTHOR: JONATHAN GUTIERREZ
********************************************************************************/

/*******************************************************************************
   CREATE TABLES
********************************************************************************/
CREATE TABLE [CUSTOMER]
(
    [CUSTOMERID] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [FIRSTNAME] NVARCHAR(160) NOT NULL,
    [LASTNAME] NVARCHAR(160) NOT NULL,
);

CREATE TABLE [ORDER]
(
	[CUSTOMERID] INT NOT NULL,
    [ORDERID] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    STORELOCATIONID INT NOT NULL,
	 [DATETIME] DATETIME,
);

CREATE TABLE [ORDERLINE](

	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ORDERID INT NOT NULL,
	PRODUCTID INT NOT NULL,
	QUANTITY INT NOT NULL
);

CREATE TABLE [STORE]
(
	
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ADDRESS NVARCHAR(100) NOT NULL,
	CITY NVARCHAR(100) NOT NULL,
	STATE NVARCHAR(20) NOT NULL,
	PHONENUMBER NVARCHAR(20) NOT NULL,
);

CREATE TABLE [PRODUCT]
(
	[PRODUCTID] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [PRODUCTNAME] NVARCHAR(160) NOT NULL,
    [PRICE] MONEY NOT NULL,
);

CREATE TABLE [INVENTORY]
(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	STOREID INT NOT NULL,
	PRODUCTID INT NOT NULL,
	QUANTITY INT NOT NULL,

);
CREATE TABLE [STORELOCATION] (

	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ADDRESS NVARCHAR(100) NOT NULL,
	CITY NVARCHAR(100) NOT NULL,
	STATE NVARCHAR(20) NOT NULL,
	PHONENUMBER NVARCHAR(20) NOT NULL,
)

/*******************************************************************************
   CREATE FOREIGN KEYS
********************************************************************************/

--Commands to link Inventory to Product and Store Location.

ALTER TABLE [INVENTORY]
ADD FOREIGN KEY ([PRODUCTID]) REFERENCES [PRODUCT]([PRODUCTID])

ALTER TABLE [INVENTORY]
ADD FOREIGN KEY (STOREID) REFERENCES [STORELOCATION](ID)


--Commands to Link an Orderline with its Order and Product


ALTER TABLE [ORDERLINE]
ADD FOREIGN KEY (ORDERID) REFERENCES [ORDER](ORDERID)


ALTER TABLE [ORDERLINE]
ADD FOREIGN KEY (PRODUCTID) REFERENCES [PRODUCT]([PRODUCTID])


--Commands to link Orders with the Customers that placed them, as

ALTER TABLE [ORDER]
ADD FOREIGN KEY ([CUSTOMERID]) REFERENCES [CUSTOMER]([CUSTOMERID])

ALTER TABLE [ORDER]
ADD FOREIGN KEY (STORELOCATIONID) REFERENCES [STORELOCATION](ID)
