CREATE TABLE [Employees]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Title] VARCHAR(50) NOT NULL,
	[Notes] VARCHAR(500)
)
INSERT INTO [Employees]
VALUES
('first1', 'last1', 'title1', NULL),
('first2', 'last2', 'title2', NULL),
('first3', 'last3', 'title3', NULL)

CREATE TABLE [Customers]
(
	[AccountNumber] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[PhoneNumber] INT NOT NULL,
	[EmergencyName] VARCHAR(50),
	[EmergencyNumber] INT,
	[Notes] VARCHAR(500)
)
INSERT INTO [Customers]
VALUES
('first1', 'last1', 111, 'name1', 1111, NULL),
('first2', 'last2', 222, 'name2', 2222, NULL),
('first3', 'last3', 333, 'name3', 3333, NULL)

CREATE TABLE [RoomStatus]
(
	[RoomStatus] VARCHAR(50) PRIMARY KEY NOT NULL,
	[Notes] VARCHAR(500)
)
INSERT INTO [RoomStatus]
VALUES
('status1', NULL),
('status2', NULL),
('status3', NULL)

CREATE TABLE [RoomTypes]
(
	[RoomType] VARCHAR(50) PRIMARY KEY NOT NULL,
	[Notes] VARCHAR(500)
)
INSERT INTO [RoomTypes]
VALUES
('RoomType1', NULL),
('RoomType2', NULL),
('RoomType3', NULL)

CREATE TABLE [BedTypes]
(
	[BedType] VARCHAR(50) PRIMARY KEY NOT NULL,
	[Notes] VARCHAR(500)
)
INSERT INTO [BedTypes]
VALUES
('BedType1', NULL),
('BedType2', NULL),
('BedType3', NULL)

CREATE TABLE [Rooms]
(
	[RoomNumber] INT PRIMARY KEY IDENTITY,
	[RoomType] VARCHAR(50) FOREIGN KEY REFERENCES [RoomTypes](RoomType) NOT NULL,
	[BedType] VARCHAR(50) FOREIGN KEY REFERENCES [BedTypes](BedType) NOT NULL,
	[Rate] DECIMAL(4,2) NOT NULL,
	[RoomStatus] VARCHAR(50) FOREIGN KEY REFERENCES [RoomStatus](RoomStatus) NOT NULL,
	[Notes] VARCHAR(500)
)
INSERT INTO [Rooms]
VALUES
('RoomType1', 'BedType1', 10.00, 'status1', NULL),
('RoomType2', 'BedType2', 20.00, 'status2', NULL),
('RoomType3', 'BedType3', 30.00, 'status3', NULL)

CREATE TABLE [Payments]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id) NOT NULL,
	[PaymentDate] DATETIME2 NOT NULL,
	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers](AccountNumber) NOT NULL,
	[FirstDateOccupied] DATETIME2 NOT NULL,
	[LastDateOccupied] DATETIME2 NOT NULL,
	[TotalDays] INT NOT NULL,
	[AmountCharged] DECIMAL(6, 2) NOT NULL,
	[TaxRate] DECIMAL(4, 2) NOT NULL,
	[TaxAmount] DECIMAL(4, 2) NOT NULL,
	[PaymentTotal] DECIMAL(6, 2) NOT NULL,
	[Notes] VARCHAR(500)
)
INSERT INTO [Payments]
VALUES
(1, '2001-01-01', 1, '2001-01-01', '2001-01-11', 10, 1000.00, 10.00, 10.00, 1000.00, NULL),
(2, '2002-02-02', 2, '2002-02-02', '2002-02-22', 20, 2000.00, 20.00, 20.00, 2000.00, NULL),
(3, '2003-03-03', 3, '2003-03-03', '2003-03-31', 30, 3000.00, 30.00, 30.00, 3000.00, NULL)
	 
CREATE TABLE [Occupancies]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id) NOT NULL,
	[DateOccupied] DATETIME2 NOT NULL,
	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers](AccountNumber) NOT NULL,
	[RoomNumber] INT FOREIGN KEY REFERENCES [Rooms](RoomNumber) NOT NULL,
	[RateApplied] DECIMAL(4, 2) NOT NULL,
	[PhoneCharge] DECIMAL(4, 2) NOT NULL,
	[Notes] VARCHAR(500)
)				  	
INSERT INTO [Occupancies]
VALUES
(1, '2023-01-01', 1, 1, 10.00, 10.00, NULL),
(2, '2023-01-02', 2, 2, 20.00, 20.00, NULL),
(3, '2023-01-03', 3, 3, 30.00, 30.00, NULL)