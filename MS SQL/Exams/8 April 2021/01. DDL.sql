CREATE TABLE Users
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(30) NOT NULL UNIQUE,
    [Password] VARCHAR(50) NOT NULL,
    [Name] VARCHAR(50),
    Birthdate DATETIME,
    Age INT CHECK(Age >= 14 AND Age <= 110),
    Email VARCHAR(50) NOT NULL
);
CREATE TABLE Departments
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    [Name] VARCHAR(50) NOT NULL
);
CREATE TABLE Employees
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(25),
    LastName VARCHAR(25),
    Birthdate DATETIME,
    Age INT CHECK(Age >= 18 AND Age <= 110),
    DepartmentId INT,
    FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
);
CREATE TABLE Categories
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    [Name] VARCHAR(50) NOT NULL,
    DepartmentId INT NOT NULL,
    FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
);
CREATE TABLE [Status]
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    [Label] VARCHAR(20) NOT NULL
);
CREATE TABLE Reports
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CategoryId INT NOT NULL,
    StatusId INT NOT NULL,
    OpenDate DATETIME NOT NULL,
    CloseDate DATETIME,
    [Description] VARCHAR(200) NOT NULL,
    UserId INT NOT NULL,
    EmployeeId INT,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
    FOREIGN KEY (StatusId) REFERENCES [Status](Id),
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
);
