CREATE TABLE [Categories] 
(
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] VARCHAR(50) NOT NULL,
	[DailyRate] DECIMAL(5, 2) NOT NULL,
	[WeeklyRate] DECIMAL(5, 2) NOT NULL,
	[MonthlyRate] DECIMAL(5, 2) NOT NULL,
	[WeekendRate] DECIMAL(5, 2) NOT NULL
)
INSERT INTO [Categories] 
VALUES
('name1', 10.00, 10.00, 10.00, 10.00),
('name2', 20.00, 20.00, 20.00, 20.00),
('name3', 30.00, 30.00, 30.00, 30.00)

CREATE TABLE [Cars] 
(
	[Id] INT PRIMARY KEY IDENTITY,
	[PlateNumber] VARCHAR(20) NOT NULL,
	[Manufacturer] VARCHAR(50) NOT NULL,
	[Model] VARCHAR(50) NOT NULL,
	[CarYear] INT NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL,
	[Doors] INT NOT NULL,
	[Picture] IMAGE,
	[Condition] NVARCHAR(200) NOT NULL,
	[Available] BIT NOT NULL
)
INSERT INTO [Cars]
VALUES
('num1', 'Manufacturer1', 'Model1', 2001, 1, 2, NULL, 'Condition1', 0),
('num2', 'Manufacturer2', 'Model2', 2002, 2, 4, NULL, 'Condition2', 1),
('num3', 'Manufacturer3', 'Model3', 2003, 3, 6, NULL, 'Condition3', 0)

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
	[Id] INT PRIMARY KEY IDENTITY,
	[DriverLicenceNumber] INT NOT NULL,
	[FullName] VARCHAR(50) NOT NULL,
	[Address] VARCHAR(100) NOT NULL,
	[City] VARCHAR(50) NOT NULL,
	[ZIPCode] INT NOT NULL,
	[Notes] VARCHAR(500)
)
INSERT INTO [Customers]
VALUES
(111, 'name1', 'address1', 'city1', 1000, NULL),
(222, 'name2', 'address2', 'city2', 2000, NULL),
(333, 'name3', 'address3', 'city3', 3000, NULL)

CREATE TABLE [RentalOrders]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
	[CustomerId] INT FOREIGN KEY REFERENCES [Customers]([Id]) NOT NULL,
	[CarId] INT FOREIGN KEY REFERENCES [Cars]([Id]) NOT NULL,
	[TankLevel] INT NOT NULL,
	[KilometrageStart] INT NOT NULL,
	[KilometrageEnd] INT NOT NULL,
	[TotalKilometrage] INT NOT NULL,
	[StartDate] DATETIME2 NOT NULL,
	[EndDate] DATETIME2 NOT NULL,
	[TotalDays] INT NOT NULL,
	[RateApplied] DECIMAL(5, 2) NOT NULL,
	[TaxRate] DECIMAL(5, 2) NOT NULL,
	[OrderStatus] VARCHAR(50) NOT NULL,
	[Notes] VARCHAR(500)
)
INSERT INTO [RentalOrders]
VALUES
(1, 1, 1, 10, 100, 110, 111, '2001-01-01', '2011-11-11', 10, 100.00, 100.00, 'status1', NULL),
(2, 2, 2, 20, 200, 220, 222, '2002-02-02', '2022-12-22', 20, 200.00, 200.00, 'status2', NULL),
(3, 3, 3, 30, 300, 330, 333, '2003-03-03', '2033-12-31', 30, 300.00, 300.00, 'status3', NULL)