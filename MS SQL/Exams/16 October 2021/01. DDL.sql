CREATE TABLE Sizes
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    [Length] INT NOT NULL CHECK ([Length] >= 10 AND [Length] <= 25),
    RingRange DECIMAL(5,2) NOT NULL CHECK (RingRange >= 1.5 AND RingRange <= 7.5)
);

CREATE TABLE Tastes
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TasteType VARCHAR(20) NOT NULL,
    TasteStrength VARCHAR(15) NOT NULL,
    ImageURL VARCHAR(100) NOT NULL
);

CREATE TABLE Brands
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    BrandName VARCHAR(30) UNIQUE NOT NULL,
    BrandDescription VARCHAR(MAX)
);

CREATE TABLE Cigars
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    CigarName VARCHAR(80) NOT NULL,
    BrandId INT NOT NULL,
    TastId INT NOT NULL,
    SizeId INT NOT NULL,
    PriceForSingleCigar DECIMAL(10,2) NOT NULL,
    ImageURL NVARCHAR(100) NOT NULL,
    FOREIGN KEY (BrandId) REFERENCES Brands(Id),
    FOREIGN KEY (TastId) REFERENCES Tastes(Id),
    FOREIGN KEY (SizeId) REFERENCES Sizes(Id)
);

CREATE TABLE Addresses
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Town VARCHAR(30) NOT NULL,
    Country NVARCHAR(30) NOT NULL,
    Streat NVARCHAR(100) NOT NULL,
    ZIP VARCHAR(20) NOT NULL
);

CREATE TABLE Clients
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(30) NOT NULL,
    LastName NVARCHAR(30) NOT NULL,
    Email NVARCHAR(50) NOT NULL,
    AddressId INT NOT NULL,
    FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
);

CREATE TABLE ClientsCigars
(
    ClientId INT NOT NULL,
    CigarId INT NOT NULL,
    PRIMARY KEY (ClientId, CigarId),
    FOREIGN KEY (ClientId) REFERENCES Clients(Id),
    FOREIGN KEY (CigarId) REFERENCES Cigars(Id)
);