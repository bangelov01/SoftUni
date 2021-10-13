CREATE DATABASE [Service]

USE [Service]


-- DB Creation

CREATE TABLE Departments (
	Id INT IDENTITY PRIMARY KEY NOT NULL
		CHECK(Id BETWEEN 0 AND 2147483647)
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Status] (
	Id INT IDENTITY PRIMARY KEY NOT NULL
		CHECK(Id BETWEEN 0 AND 2147483647)
	,[Label] VARCHAR(30) NOT NULL
)

CREATE TABLE Users (
	Id INT IDENTITY PRIMARY KEY NOT NULL
		CHECK(Id BETWEEN 0 AND 2147483647)
	,Username VARCHAR(30) UNIQUE NOT NULL
	,[Password] VARCHAR(50) NOT NULL
	,[Name] VARCHAR(50)
	,Birthdate DATETIME2
	,Age INT
		CHECK (Age BETWEEN 14 AND 110)
	,Email VARCHAR(50) NOT NULL
)

CREATE TABLE Employees (
	Id INT IDENTITY PRIMARY KEY NOT NULL
		CHECK(Id BETWEEN 0 AND 2147483647)
	,FirstName VARCHAR(25)
	,LastName VARCHAR(25)
	,Birthdate DATETIME2
	,Age INT
		CHECK (Age BETWEEN 18 AND 110)
	,DepartmentId INT FOREIGN KEY REFERENCES Departments (Id)
		CHECK(DepartmentId BETWEEN 0 AND 2147483647)
)

CREATE TABLE Categories (
	Id INT IDENTITY PRIMARY KEY NOT NULL
		CHECK(Id BETWEEN 0 AND 2147483647)
	,[Name] VARCHAR(50) NOT NULL
	,DepartmentId INT FOREIGN KEY REFERENCES Departments (Id) NOT NULL
		CHECK(DepartmentId BETWEEN 0 AND 2147483647)
)


CREATE TABLE Reports (
	Id INT IDENTITY PRIMARY KEY NOT NULL
		CHECK(Id BETWEEN 0 AND 2147483647)
	,CategoryId INT FOREIGN KEY REFERENCES Categories (Id) NOT NULL
		CHECK(CategoryId BETWEEN 0 AND 2147483647)
	,StatusId INT FOREIGN KEY REFERENCES [Status] (Id) NOT NULL
		CHECK(StatusId BETWEEN 0 AND 2147483647)
	,OpenDate DATETIME2 NOT NULL
	,CloseDate DATETIME2
	,[Description] VARCHAR(200) NOT NULL
	,UserId INT FOREIGN KEY REFERENCES Users (Id) NOT NULL
		CHECK(UserId BETWEEN 0 AND 2147483647)
	,EmployeeId INT FOREIGN KEY REFERENCES Employees (Id)
		CHECK(EmployeeId BETWEEN 0 AND 2147483647)
)

-- DB Insert

INSERT INTO Employees (FirstName, LastName, Birthdate, DepartmentId)
	VALUES
		('Marlo', 'O''Malley', '1958-9-21', 1)
		,('Niki', 'Stanaghan', '1969-11-26', 4)
		,('Ayrton', 'Senna', '1960-03-21', 9)
		,('Ronnie', 'Peterson', '1944-02-14', 9)
		,('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO Reports (CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
	VALUES
		(1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2)
		,(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5)
		,(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2)
		,(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

--DB Update

UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

DELETE Reports
WHERE StatusId = 4

--DB Querrying

SELECT [Description]
	,CONVERT(CHAR(16), OpenDate, 105) AS OpenDate
FROM Reports AS r
WHERE EmployeeId IS NULL
ORDER BY r.OpenDate
	,[Description]

SELECT [Description]
	,c.[Name] AS CategoryName
FROM Reports AS r
 JOIN Categories AS c
 ON r.CategoryId = c.Id
 ORDER BY [Description]
	,CategoryName

SELECT TOP (5) c.[Name]
	,COUNT(r.CategoryId) AS ReportsNumber
FROM Reports AS r
LEFT JOIN Categories AS c
ON c.Id = r.CategoryId
GROUP BY c.[Name]
ORDER BY ReportsNumber DESC
	,c.[Name]

SELECT u.Username
	,c.[Name] AS CategoryName
FROM Reports AS r
	JOIN Users AS u
	ON u.Id = r.UserId
	JOIN Categories AS c
	ON c.Id = r.CategoryId
WHERE DATEPART(DAY, r.OpenDate) = DATEPART(DAY, u.Birthdate)
ORDER BY u.Username
	,CategoryName

SELECT
	CONCAT(e.FirstName, ' ', e.LastName) AS FullName
	,COUNT(r.Id) AS UsersCount
FROM Employees AS e
	LEFT JOIN Reports AS r
	ON r.EmployeeId = e.Id
GROUP BY CONCAT(e.FirstName, ' ', e.LastName)
ORDER BY UsersCount DESC
	,FullName

SELECT 
	CASE
		WHEN e.FirstName IS NULL OR e.LastName IS NULL THEN 'None'
		ELSE CONCAT(e.FirstName, ' ', e.LastName)
	END AS Employee
	,ISNULL(d.[Name], 'None') AS Department
	,ISNULL(c.[Name], 'None') AS Category
	,ISNULL(r.[Description], 'None') AS [Description]
	,ISNULL(CONVERT(VARCHAR, OpenDate, 104), 'None') AS OpenDate
	,ISNULL(s.[Label], 'None') AS [Status]
	,ISNULL(u.[Name], 'None') AS [User]
FROM Reports AS r
	LEFT JOIN Employees AS e
	ON e.Id = r.EmployeeId
	LEFT JOIN Categories AS c
	ON c.Id = r.CategoryId
	LEFT JOIN Departments AS d
	ON d.Id = e.DepartmentId
	LEFT JOIN [Status] AS s
	ON s.Id = r.StatusId
	LEFT JOIN Users AS u
	ON u.Id = r.UserId
ORDER BY e.FirstName DESC
	,e.LastName DESC
	,[Department] ASC
	,Category ASC
	,[Description] ASC
	,r.OpenDate ASC
	,[Status] ASC
	,[User] ASC
GO

--DB Programmability

CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
	BEGIN
		DECLARE @result INT
		IF(@StartDate IS NULL OR @EndDate IS NULL)
			RETURN 0
		ELSE
		SET @result = DATEDIFF(HOUR,@StartDate, @EndDate)
		RETURN @result
	END
GO

CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
	BEGIN TRANSACTION
		UPDATE Reports
		SET EmployeeId = @EmployeeId
		WHERE Id = @ReportId

			IF((SELECT DepartmentId
				FROM Employees
				WHERE Id = @EmployeeId) 
				!= 
				(SELECT c.DepartmentId
				FROM Reports AS r
					LEFT JOIN Categories AS c
					ON c.Id = r.CategoryId
				WHERE r.Id = @ReportId))
				BEGIN
					ROLLBACK;
					THROW 50001, 'Employee doesn''t belong to the appropriate department!',1
					RETURN
				END
		COMMIT
GO
