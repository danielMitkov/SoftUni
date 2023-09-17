create table [People] (
	[Id] int primary key identity,
	[Name] nvarchar(200) not null,
	[Picture] varbinary(max),
	[Height] decimal(3,2),
	[Weight] decimal(5,2),
	[Gender] char(1) not null,
	check ([Gender] = 'm' or [Gender] = 'f'),
	[Birthdate] date not null,
	[Biography] nvarchar(max)
)

insert into [People] ([Name],[Height],[Weight],[Gender],[Birthdate])
	values
('Pesho', 1.77, 75.2, 'm', '1998-05-25'),
('Gosho', NULL, NULL, 'm', '1977-11-05'),
('Maria', 1.65, 42.2, 'f', '1998-06-27'),
('Viki', NULL, NULL, 'f', '1986-02-02'),
('Vancho', 1.69, 77.8, 'm', '1999-03-03')