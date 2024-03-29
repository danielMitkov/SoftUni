CREATE TABLE [Cities]
(
    [CityID] 
        INT PRIMARY KEY IDENTITY,
    [Name] 
        VARCHAR(50) NOT NULL
)
CREATE TABLE [ItemTypes]
(
    [ItemTypeID] 
        INT PRIMARY KEY NOT NULL,--NOT IDENTITY FOR JUDGE
    [Name] 
        VARCHAR(50) NOT NULL
)
CREATE TABLE [Items]
(
    [ItemID] 
        INT 
        PRIMARY KEY NOT NULL,--NOT IDENTITY FOR JUDGE
    [Name] 
        VARCHAR(50) NOT NULL,
    [ItemTypeID] 
        INT NOT NULL 
        FOREIGN KEY REFERENCES [ItemTypes]([ItemTypeID]) 
)
CREATE TABLE [Customers]
(
    [CustomerID] 
        INT
        PRIMARY KEY IDENTITY,
    [Name] 
        VARCHAR(50) NOT NULL,
    [Birthday] 
        DATETIME2 NOT NULL,
    [CityID] 
        INT NOT NULL
        FOREIGN KEY REFERENCES [Cities]([CityID])
)
CREATE TABLE [Orders]
(
    [OrderID] 
        INT
        PRIMARY KEY IDENTITY,
    [CustomerID] 
        INT NOT NULL
        FOREIGN KEY REFERENCES [Customers]([CustomerID])
)
CREATE TABLE [OrderItems]
(
    [OrderID] 
        INT NOT NULL
        FOREIGN KEY REFERENCES [Orders]([OrderID]),
    [ItemID] 
        INT NOT NULL
        FOREIGN KEY REFERENCES [Items]([ItemID]),
    CONSTRAINT 
        [PK_OrderItems]
            PRIMARY KEY ([OrderID], [ItemID])
)