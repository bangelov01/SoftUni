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

CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN

	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
							SELECT EmployeeID
							FROM Employees
							WHERE DepartmentID = @departmentId
	)

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (
							SELECT EmployeeID
							FROM Employees
							WHERE DepartmentID = @departmentId
	)

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT

	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN (
							SELECT EmployeeID
							FROM Employees
							WHERE DepartmentID = @departmentId
	)

	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*) FROM Employees
	WHERE DepartmentID = @departmentId
END
GO


USE [Bank]
GO

CREATE PROC usp_GetHoldersFullName
AS
BEGIN
	SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
	FROM AccountHolders
END
GO


CREATE PROC usp_GetHoldersWithBalanceHigherThan (@number DECIMAL(18,4))
AS
BEGIN
		SELECT FirstName
			,LastName
		FROM Accounts AS a
			JOIN AccountHolders AS ah
			ON a.AccountHolderId = ah.Id
		GROUP BY FirstName, LastName
		HAVING SUM(Balance) > @number
		ORDER BY FirstName, LastName
END
GO

CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(18,4), @yearlyRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL (18,4)
AS
BEGIN
	DECLARE @futureValue DECIMAL (18,4)
	SET @futureValue = @sum * (POWER((1 + @yearlyRate), @numberOfYears))

	RETURN @futureValue
END
GO

CREATE PROC usp_CalculateFutureValueForAccount (@accountID INT, @interestRate FLOAT)
AS
BEGIN
	SELECT a.Id AS [Account Id]
		,ah.FirstName AS [First Name]
		,ah.LastName AS [Last Name]
		,a.Balance AS CurrentBalance
		,dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
	FROM Accounts AS a
	JOIN AccountHolders AS ah
	ON a.AccountHolderId = ah.Id
	WHERE a.Id = @accountID
END
GO

USE Diablo
GO

CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(50))
RETURNS TABLE
AS 
RETURN 
SELECT(
				SELECT
					SUM(Cash)
				FROM
							(SELECT g.[Name]
								,ug.Cash
								,ROW_NUMBER() OVER(PARTITION BY g.[Name] ORDER BY ug.Cash DESC) AS [Row]
							FROM UsersGames AS ug
							JOIN Games AS g
							ON ug.GameId = g.Id
							WHERE g.[Name] = @gameName) AS RowQuerry
				WHERE [Row] % 2 = 1
		) AS SumCash