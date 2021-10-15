CREATE DATABASE TripService

USE TripService


--DB Creation
CREATE TABLE Cities (
	Id INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] NVARCHAR(20) NOT NULL
	,CountryCode NVARCHAR(2) NOT NULL
		--CHECK(LEN(CountryCode) = 2)
)

CREATE TABLE Hotels (
	Id INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] NVARCHAR(30) NOT NULL
	,CityId INT FOREIGN KEY REFERENCES Cities (Id) NOT NULL
	,EmployeeCount INT NOT NULL
	,BaseRate DECIMAL(10,2)
)

CREATE TABLE Rooms (
	Id INT PRIMARY KEY IDENTITY NOT NULL
	,Price DECIMAL(10,2) NOT NULL
	,[Type] NVARCHAR(20) NOT NULL
	,Beds INT NOT NULL
	,HotelId INT FOREIGN KEY REFERENCES Hotels (Id) NOT NULL
)

CREATE TABLE Trips (
	Id INT PRIMARY KEY IDENTITY NOT NULL
	,RoomId INT FOREIGN KEY REFERENCES Rooms (Id) NOT NULL
	,BookDate DATE NOT NULL
	,ArrivalDate DATE NOT NULL
	,ReturnDate DATE NOT NULL
	,CancelDate DATE
	,CHECK (CAST(BookDate AS DATE) < CAST(ArrivalDate AS DATE))
	,CHECK (CAST(ArrivalDate AS DATE) < CAST(ReturnDate AS DATE))
)

CREATE TABLE Accounts (
	Id INT PRIMARY KEY IDENTITY NOT NULL
	,FirstName NVARCHAR(50) NOT NULL
	,MiddleName NVARCHAR(20)
	,LastName NVARCHAR(50) NOT NULL
	,CityId INT FOREIGN KEY REFERENCES Cities (Id) NOT NULL
	,BirthDate DATE NOT NULL
	,Email NVARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE AccountsTrips (
	AccountId INT NOT NULL
	,TripId INT NOT NULL
	,PRIMARY KEY CLUSTERED (AccountId, TripId)
	,FOREIGN KEY (AccountId) REFERENCES Accounts (Id)
	,FOREIGN KEY (TripId) REFERENCES Trips (Id)
	,Luggage INT NOT NULL
		CHECK(Luggage >= 0)
)

--DB Insert

INSERT INTO Accounts (FirstName, MiddleName, LastName, CityId, BirthDate, Email)
	VALUES
		('John','Smith','Smith',34,'1975-07-21','j_smith@gmail.com')
		,('Gosho',NULL,'Petrov',11,'1978-05-16','g_petrov@gmail.com')
		,('Ivan','Petrovich','Pavlov',59,'1849-09-26','i_pavlov@softuni.bg')
		,('Friedrich','Wilhelm','Nietzsche',2,'1844-10-15','f_nietzsche@softuni.bg')

INSERT INTO Trips (RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate)
	VALUES
		(101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02')
		,(102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29')
		,(103, '2013-07-17', '2013-07-23', '2013-07-24', NULL)
		,(104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10')
		,(109,	'2017-08-07',	'2017-08-28',	'2017-08-29',	NULL)

--DB Update

UPDATE Rooms
SET Price += Price * 0.14
WHERE HotelId IN (5,7,9)

--DB Delete

DELETE FROM AccountsTrips
WHERE AccountId = 47

--DB Querrying

SELECT FirstName
	,LastName
	,CONVERT(VARCHAR(16), BirthDate, 110) AS BirthDate
	,c.[Name] AS Hometown
	,Email
FROM Accounts AS a
JOIN Cities AS c
ON c.Id = a.CityId
WHERE Email LIKE 'e%'
ORDER BY c.[Name]

SELECT c.[Name]
	,COUNT(h.[Name]) AS Hotels
FROM Cities AS c
JOIN Hotels AS h
ON h.CityId = c.Id
GROUP BY c.[Name]
ORDER BY Hotels DESC, c.[Name]



SELECT Id
	,CONCAT(FirstName, ' ', LastName) AS FullName
	,MAX(DaysDiff) AS LongestTrip
	,MIN(DaysDiff) AS ShortestTrip
FROM
	(SELECT a.Id
		,a.FirstName
		,a.LastName
		,DATEDIFF(DAY, ArrivalDate, ReturnDate) AS DaysDiff
	FROM Accounts AS a
	JOIN AccountsTrips as att
	ON att.AccountId = a.Id
	JOIN Trips AS t
	ON t.Id = att.TripId
	WHERE a.MiddleName IS NULL AND (t.CancelDate IS NULL)) AS DateDiffQuery
GROUP BY Id, CONCAT(FirstName, ' ', LastName)
ORDER BY LongestTrip DESC, ShortestTrip


SELECT TOP (10) c.Id
	,c.[Name] AS City
	,c.CountryCode AS Country
	,COUNT(a.id) AS Accounts
FROM Cities AS c
JOIN Accounts AS a
ON a.CityId = c.Id
GROUP BY c.Id, c.[Name], c.CountryCode
ORDER BY Accounts DESC


SELECT a.Id
	,a.Email
	,c.[Name] AS City
	,COUNT(h.CityId) AS Trips
FROM Accounts AS a
JOIN AccountsTrips AS att
ON att.AccountId = a.Id
JOIN Trips AS t
ON t.Id = att.TripId
JOIN Rooms AS r
ON r.Id = t.RoomId
JOIN Hotels AS h
ON h.Id = r.HotelId
JOIN Cities AS c
ON c.Id = h.CityId
WHERE a.CityId = h.CityId
GROUP BY a.Id, a.Email, c.[Name]
ORDER BY Trips DESC, a.Id

SELECT t.Id
	,CASE
		WHEN a.MiddleName IS NULL THEN CONCAT(A.FirstName, ' ', a.LastName)
		ELSE CONCAT(A.FirstName, ' ',a.MiddleName, ' ',a.LastName)
	 END AS [Full Name]
	,c.[Name] AS [From]
	,c2.[Name] AS [To]
	,CASE
		WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
		ELSE CONCAT(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate), ' ', 'days')
	 END AS Duration
FROM Trips AS t
JOIN AccountsTrips AS att
ON att.TripId = t.Id
JOIN Accounts AS a
ON a.Id = att.AccountId
JOIN Cities AS c
ON c.Id = a.CityId
JOIN Rooms AS r
ON r.Id = t.RoomId
JOIN Hotels AS h
ON h.Id = r.HotelId
JOIN Cities AS c2
ON h.CityId = c2.Id
ORDER BY [Full Name], t.Id
GO
--DB Programmability 

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(100)
AS
	BEGIN
		--final result
		DECLARE @result VARCHAR(100)
		--hotelbaserate
		DECLARE @hotelBaseRate DECIMAL(10,2)
		--room variables
		DECLARE @totalRoomPrice DECIMAL(10,2)

		DECLARE @roomId INT
		DECLARE @roomType NVARCHAR(20)
		DECLARE @beds INT

		SET @hotelBaseRate = (SELECT BaseRate FROM Hotels WHERE Id = @HotelId)
		SET @totalRoomPrice = (SELECT TOP (1) MAX(((Price + @hotelBaseRate) * @People))
								FROM Rooms AS r
								JOIN Trips AS t
								ON t.RoomId = r.Id
								WHERE HotelId = @HotelId AND
								(@Date NOT BETWEEN ArrivalDate AND ReturnDate) AND
								(DATEPART(YEAR,@Date) >= DATEPART(YEAR,ArrivalDate)) AND
								(CancelDate IS NULL) AND
								(Beds >= @People))
		IF(@totalRoomPrice IS NULL)
			BEGIN
				SET @result = 'No rooms available'
				RETURN @result
			END
		ELSE
			BEGIN
						SET @roomId = (SELECT TOP (1) r.Id
								FROM Rooms AS r
								JOIN Trips AS t
								ON t.RoomId = r.Id
								WHERE HotelId = @HotelId AND
								(@Date NOT BETWEEN ArrivalDate AND ReturnDate) AND
								(CancelDate IS NULL) AND
								(Beds >= @People) AND
								((Price + @hotelBaseRate) * @People) = @totalRoomPrice)

						SET @roomType = (SELECT TOP(1) r.[Type]
								FROM Rooms AS r
								JOIN Trips AS t
								ON t.RoomId = r.Id
								WHERE HotelId = @HotelId AND
								(@Date NOT BETWEEN ArrivalDate AND ReturnDate) AND
								(CancelDate IS NULL) AND
								(Beds >= @People) AND
								(r.Id = @roomId))

						SET @beds = (SELECT TOP (1) r.Beds
								FROM Rooms AS r
								JOIN Trips AS t
								ON t.RoomId = r.Id
								WHERE HotelId = @HotelId AND
								(@Date NOT BETWEEN ArrivalDate AND ReturnDate) AND
								(CancelDate IS NULL) AND
								(Beds >= @People) AND
								(r.Id = @roomId))

			END
		SET @result = CONCAT('Room ', @roomId, ': ', @roomType, ' (', @beds, ' beds) - $', @totalRoomPrice)
		RETURN @result
	END
GO