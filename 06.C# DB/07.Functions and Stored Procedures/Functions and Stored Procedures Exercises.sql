USE SoftUni
GO

CREATE PROC usp_GetEmployeesSalaryAbove35000 
AS 
	SELECT FirstName
		,LastName
	FROM Employees
	WHERE Salary > 35000
GO

CREATE PROC usp_GetEmployeesSalaryAboveNumber (@salaryThreshold DECIMAL(18,4))
AS 
	SELECT FirstName
		,LastName
	FROM Employees
	WHERE Salary >= @salaryThreshold
GO

CREATE PROC usp_GetTownsStartingWith (@startString VARCHAR(50))
AS
	SELECT [Name] AS Town
	FROM Towns
	WHERE [Name] LIKE @startString + '%'
GO

CREATE PROC usp_GetEmployeesFromTown (@townName VARCHAR(50))
AS
	SELECT e.FirstName
		,e.LastName
	FROM Employees AS e
		JOIN Addresses AS a
		ON e.AddressID = a.AddressID
		JOIN Towns AS t
		ON a.TownID = t.TownID
	WHERE t.[Name] = @townName
GO

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(10)
AS
BEGIN
	DECLARE @salaryLevel NVARCHAR(10)
		IF (@salary < 30000)
			SET @salaryLevel = 'Low'
		ELSE IF (@salary BETWEEN 30000 AND 50000)
			SET @salaryLevel = 'Average'
		ELSE IF (@salary > 50000)
			SET @salaryLevel = 'High'
	RETURN @salaryLevel
END
GO

CREATE PROC usp_EmployeesBySalaryLevel (@salaryLevel NVARCHAR(10))
AS
	SELECT FirstName
		,LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel
GO

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(20), @word NVARCHAR(20))
RETURNS BIT
AS
BEGIN
	DECLARE @i TINYINT = 0
	DECLARE @result BIT = 1

	WHILE @i < LEN(@word) AND @result > 0
		BEGIN
			SET @i = @i + 1
			DECLARE @currentChar CHAR(1) = LOWER(SUBSTRING(@word,@i,1))
			DECLARE @index INT = CHARINDEX(@currentChar, @setOfLetters, 0)

			IF (@index > 0)
				SET @result = 1
			ELSE
				SET @result = 0
		END
	RETURN @result
END
GO
