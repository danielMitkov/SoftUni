create table Directors (
	Id int primary key identity,
	DirectorName varchar(50) not null,
	Notes varchar(200)
)
insert into Directors (DirectorName)
values
('name1'),
('name2'),
('name3'),
('name4'),
('name5')
create table Genres (
	Id int primary key identity,
	GenreName varchar(50) not null,
	Notes varchar(200)
)
insert into Genres(GenreName)
values
('name1'),
('name2'),
('name3'),
('name4'),
('name5')
create table Categories (
	Id int primary key identity,
	CategoryName varchar(50) not null,
	Notes varchar(200)
)
insert into Categories(CategoryName)
values
('name1'),
('name2'),
('name3'),
('name4'),
('name5')
create table Movies (
	Id int primary key identity,
	Title varchar(50) not null,
	DirectorId int foreign key references Directors(Id) not null,
	CopyrightYear int not null,
	[Length] time not null,
	GenreId int foreign key references Genres(Id) not null,
	CategoryId int foreign key references Categories(Id) not null,
	Rating decimal(2,1) not null,
	Notes varchar(200)
)
insert into Movies
values
('title1',1,1975,'02:31:00',1,1,7.1,null),
('title2',2,1976,'02:32:00',2,2,7.2,null),
('title3',3,1977,'02:33:00',3,3,7.3,null),
('title4',4,1978,'02:34:00',4,4,7.4,null),
('title5',5,1979,'02:35:00',5,5,7.5,null)