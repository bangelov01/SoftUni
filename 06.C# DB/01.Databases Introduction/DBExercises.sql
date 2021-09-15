CREATE DATABASE [Minions]

USE [Minions]

--First few exercises--Minions--

CREATE TABLE [Minions](
	[Id] INT
	,[Name] VARCHAR(20)
	,[Age] TINYINT
)

CREATE TABLE [Towns](
	[Id] INT
	,[Name] VARCHAR(20)
)

ALTER TABLE [Minions]
ALTER COLUMN [Id] INT NOT NULL

ALTER TABLE [Towns]
ALTER COLUMN [Id] INT NOT NULL

ALTER TABLE [Towns]
ADD CONSTRAINT PK_TownsId PRIMARY KEY (Id)

ALTER TABLE [Minions]
ADD CONSTRAINT PK_MinionsId PRIMARY KEY (Id)

ALTER TABLE [Minions]
ADD [TownId] INT NOT NULL

ALTER TABLE [Minions]
ADD FOREIGN KEY (TownId) REFERENCES [Towns](Id)

INSERT INTO [Towns] (Id, [Name]) 
	VALUES 
		(1, 'Sofia')
		,(2, 'Plovdiv')
		,(3, 'Varna')

INSERT INTO [Minions] (Id, [Name], Age, TownId) 
	VALUES 
		(1, 'Kevin', 22, 1)
		,(2, 'Bob', 15, 3)
		,(3, 'Steward', NULL, 2)

TRUNCATE TABLE [Minions]

DROP TABLE [Minions]
DROP TABLE [Towns]

--Next exercises - People--

CREATE TABLE [People] (
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL
	,[Name] NVARCHAR(200) NOT NULL
	,[Picture] VARBINARY(MAX)
	CHECK(DATALENGTH(Picture) <= 2097152)
	,[Height] DECIMAL(3,2)
	,[Weight] DECIMAL(4,2)
	,[Gender] CHAR NOT NULL
	CHECK(Gender = 'm' OR Gender = 'f')
	,[Birthdate] DATETIME2 NOT NULL
	,[Biography] NVARCHAR(MAX)
)


INSERT INTO [People] ([Name], Picture, Height, [Weight], Gender, [Birthdate], Biography)
	VALUES
		('Boby', NULL, 1.85, 90.00, 'm', '1993-11-12', 'asdasd')
		,('Peter', NULL, 1.70, 84.00, 'm', '1994-11-12', NULL)
		,('Ani', NULL, 1.68, 70.00, 'f', '1983-11-12', 'asdasd')
		,('Misho', NULL, 1.85, 85.50, 'm', '1991-11-12', 'asdasd')
		,('Momi', NULL, 1.85, 92.00, 'm', '1999-11-12', 'asdasd')

--Next exercises--Users--
CREATE TABLE [Users] (
	[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL
	,[Username] VARCHAR(30) UNIQUE NOT NULL
	,[Password] VARCHAR(26) UNIQUE NOT NULL
	,[ProfilePicture] VARBINARY(MAX)
	CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024)
	,[LastLoginTime] DATETIME2 NOT NULL
	,[IsDeleted] BIT NOT NULL
)

INSERT INTO [Users] (Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
	VALUES
		('user', '1234',NULL, '2021-10-10', 0)
		,('user1', '12345',NULL, '2021-10-10', 1)
		,('user2', '123456',NULL, '2021-10-10', 1)
		,('user3', '1234567',NULL, '2021-10-10', 0)
		,('user4', '12345678',NULL, '2021-10-10', 1)

ALTER TABLE [Users]
DROP CONSTRAINT PK__Users__3214EC073781D561

ALTER TABLE [Users]
ADD CONSTRAINT PK_User PRIMARY KEY (Id, [Username])

ALTER TABLE [Users]
ADD CHECK ([Password] >= 5)

ALTER TABLE [Users]
ADD CONSTRAINT DF_LastLoginTime
DEFAULT GETDATE() FOR [LastLoginTime]

INSERT INTO [Users] (Username, [Password], ProfilePicture,IsDeleted)
	VALUES
		('user5', '123456789',NULL, 0)

ALTER TABLE [Users]
DROP CONSTRAINT PK_User

ALTER TABLE [Users]
ADD PRIMARY KEY (Id)

ALTER TABLE [Users]
ADD UNIQUE ([Username])

--Movies Database Exercises

CREATE DATABASE [Movies]

USE [Movies]

CREATE TABLE [Directors] (
	Id BIGINT PRIMARY KEY IDENTITY NOT NULL
	,DirectorName VARCHAR(30) NOT NULL
	,Notes VARCHAR(MAX)
)

CREATE TABLE [Genres] (
	Id BIGINT PRIMARY KEY IDENTITY NOT NULL
	,GenreName VARCHAR(30) NOT NULL
	,Notes VARCHAR(MAX)
)

CREATE TABLE [Categories] (
	Id BIGINT PRIMARY KEY IDENTITY NOT NULL
	,CategoryName VARCHAR(30) NOT NULL
	,Notes VARCHAR(MAX)
)

CREATE TABLE [Movies] (
	Id BIGINT PRIMARY KEY IDENTITY NOT NULL
	,Title VARCHAR(30) NOT NULL
	,DirectorId BIGINT FOREIGN KEY REFERENCES Directors(Id) NOT NULL
	,CopyrightYear DATETIME2 NOT NULL
	,[Length] SMALLINT NOT NULL
	,GenreId BIGINT FOREIGN KEY REFERENCES Genres(Id) NOT NULL
	,CategoryId BIGINT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
	,Rating TINYINT
	,Notes VARCHAR(MAX)
)

INSERT INTO Directors (DirectorName, Notes)
	VALUES
		('Pesho', 'asda')
		,('Gosho', 'asdd')
		,('Misho', 'asdsadas')
		,('Ani', 'asdasdas')
		,('Banani', 'asdasdad')

INSERT INTO Genres (GenreName, Notes)
	VALUES
		('Horror', NULL)
		,('Mistery', NULL)
		,('Comedy', NULL)
		,('Thriller', NULL)
		,('Romance', NULL)

INSERT INTO Categories (CategoryName, Notes)
	VALUES
		('Short Film', 'aaaa')
		,('Long film', 'asdasd')
		,('Sitcom', 'asdasd')
		,('blabla', 'asdasd')
		,('blablabla', 'asdasdaaa')

INSERT INTO Movies (Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
	VALUES
		('Breaking Bad', 3, '05.05.2010', 60, 4, 3, 10, 'best sitcom ever')
		,('Jackass', 1, '06.05.2010', 120, 3, 2, 10, NULL)
		,('MyMovie1', 2, '06.05.2010', 160, 1, 1, 5, NULL)
		,('MyMovie2', 4, '06.07.2017', 120, 2, 4, 10, NULL)
		,('MyMovie3', 5, GETDATE(), 180, 5, 5, 8, 'blabla')

--Car rental db exercises--

CREATE DATABASE CarRental

USE [CarRental]

CREATE TABLE Categories (
	Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName VARCHAR(30) NOT NULL,
	DailyRate DECIMAL(4,2) NOT NULL,
	WeeklyRate DECIMAL(4,2) NOT NULL,
	MonthlyRate DECIMAL(4,2) NOT NULL,
	WeekendRate DECIMAL(4,2) NOT NULL,
)

CREATE TABLE Cars (
	Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
	PlateNumber VARCHAR(10) NOT NULL,
	Manufacturer VARCHAR(10),
	Model VARCHAR(30) NOT NULL,
	CarYear DATETIME2,
	CategoryId BIGINT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Doors TINYINT NOT NULL,
	Picture VARBINARY(MAX),
	Condition VARCHAR(30) NOT NULL,
	Available BIT NOT NULL,
)

CREATE TABLE Employees (
	Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30),
	Title VARCHAR(30) NOT NULL,
	Notes VARCHAR(30),
)

CREATE TABLE Customers (
	Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
	DriverLicenceNumber INT NOT NULL,
	FullName VARCHAR(60) NOT NULL,
	[Address] VARCHAR(30),
	City VARCHAR(30) NOT NULL,
	ZIPCode SMALLINT NOT NULL,
	Notes VARCHAR(30),
)

CREATE TABLE RentalOrders (
	Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId BIGINT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	CustomerId BIGINT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CarId BIGINT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
	TankLevel VARCHAR(30) NOT NULL
	CHECK(TankLevel = 'Empty' OR TankLevel = 'Full'),
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT,
	StartDate DATETIME2 NOT NULL,
	EndDate DATETIME2 NOT NULL,
	TotalDays SMALLINT,
	RateApplied VARCHAR(20),
	TaxRate NVARCHAR(10) NOT NULL,
	OrderStatus VARCHAR(30) NOT NULL
	CHECK(OrderStatus = 'Returned' OR OrderStatus = 'Not Returned'),
	Notes VARCHAR(MAX),
)

INSERT INTO [Categories] (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
	VALUES 
		('van', 50.00, 45.00, 30.00, 35.50),
		('sedan', 40.00, 35.00, 20.00, 25.50),
		('coupe', 60.00, 55.00, 40.50, 45.50)

INSERT INTO [Cars] (PlateNumber, Model, CategoryId, Doors, Condition, Available)
	VALUES
		('plate1', 'model1', 3, 4, 'good', 0),
		('plate2', 'model2', 1, 2, 'average', 1),
		('plate3', 'model3', 2, 5, 'good', 0)

INSERT INTO [Employees] (FirstName, Title)
	VALUES
		('Nikolai', 'Owner'),
		('Pesho', 'Worker'),
		('Gosho', 'Worker')


INSERT INTO [Customers] (DriverLicenceNumber, FullName, City, ZIPCode)
	VALUES
		(1234, 'Bobi Bobov', 'Sofia', 12345),
		(1233, 'Niki Bobov', 'Plovdiv', 2312),
		(1235, 'Toni Bobov', 'Vraca', 1234)

INSERT INTO [RentalOrders] (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, StartDate, EndDate, TaxRate, OrderStatus)
	VALUES
		(3, 2, 1, 'Full', 250000, 260000, '05.05.2020', '08.05.2020', '10%', 'Returned'),
		(2, 1, 3, 'Empty', 230000, 260450, '05.05.2020', '08.05.2020', '15%', 'Returned'),
		(1, 3, 2, 'Full', 300000, 360000, '05.05.2020', '08.05.2020', '10%', 'Not Returned')
