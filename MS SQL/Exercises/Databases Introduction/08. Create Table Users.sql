create table Users (
	Id int primary key identity,
	Username varchar(30) not null,
	[Password] varchar(26) not null,
	ProfilePicture varbinary(max),
	check (datalength(ProfilePicture) <= 900000),
	LastLoginTime datetime2,
	IsDeleted bit
)

insert into Users (Username,[Password])
	values
('name1','pass1'),
('name2','pass2'),
('name3','pass3'),
('name4','pass4'),
('name5','pass5')