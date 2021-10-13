USE SoftUni

SELECT FirstName
	,LastName
FROM Employees
WHERE FirstName LIKE 'Sa%'

SELECT FirstName
	,LastName
FROM Employees
WHERE LastName LIKE '%ei%'

SELECT FirstName
FROM Employees
WHERE (DepartmentID = 3 OR DepartmentID = 10) 
	AND
		(CAST(HireDate AS DATE) BETWEEN '1995-01-01' AND '2005-12-31')

SELECT FirstName
	,LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

SELECT [Name]
FROM Towns
WHERE LEN([Name]) = 5 OR 
LEN([Name]) = 6
ORDER BY [Name] ASC

SELECT TownID 
	,[Name]
FROM Towns
WHERE [Name] LIKE '[M,K,B,E]%'
ORDER BY [Name] ASC

SELECT TownID 
	,[Name]
FROM Towns
WHERE [Name] LIKE '[^R,B,D]%'
ORDER BY [Name] ASC

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName
	,LastName
FROM Employees
WHERE Cast(Hiredate AS DATE) > '2000-12-31'

SELECT FirstName
	,LastName
FROM Employees
WHERE LEN(LastName) = 5

SELECT EmployeeID
	,FirstName
	,LastName
	,Salary
	,DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
FROM Employees
WHERE (Salary BETWEEN 10000 AND 50000)
ORDER BY Salary DESC

SELECT *
FROM (
	SELECT EmployeeID
	,FirstName
	,LastName
	,Salary
	,DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
	FROM Employees
) AS m
WHERE m.Rank = 2 AND m.Salary BETWEEN 10000 AND 50000
ORDER BY m.Salary DESC

USE [Geography]

SELECT CountryName
	,IsoCode
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

USE [Geography]

SELECT PeakName,
	RiverName,
	CONCAT(LOWER(PeakName), SUBSTRING(LOWER(RiverName),2, (LEN(RiverName) - 1))) AS Mix
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix ASC

USE Diablo

SELECT TOP 50 [Name]
	,CONVERT(VARCHAR,[Start],23) AS [Start]
FROM Games
WHERE DATEPART(YEAR, [Start]) = '2011' OR DATEPART(YEAR, [Start]) = '2012'
ORDER BY [Start], [Name]

SELECT Username
	,RIGHT([Email], CHARINDEX('@', REVERSE([Email])) - 1) AS 'EmailProvider'
FROM Users
ORDER BY EmailProvider
		,Username

SELECT Username
	,IpAddress
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username ASC

SELECT [Name] AS Game
	,CASE
		WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
		WHEN DATEPART(HOUR, [Start]) >= 18 AND DATEPART(HOUR, [Start]) < 24 THEN 'Evening'
	END AS 'PartOfTheDay'
	,CASE
		WHEN [Duration] <= 3 THEN 'Extra Short'
		WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
		WHEN [Duration] > 3 THEN 'Long'
		WHEN [Duration] IS NULL THEN 'Extra Long'
	END AS 'Duration'
FROM Games
ORDER BY Game, Duration

CREATE TABLE Orders (
	Id INT PRIMARY KEY IDENTITY NOT NULL
	,ProductName VARCHAR(30) NOT NULL
	,OrderDate DATETIME2 NOT NULL
)

INSERT INTO Orders (ProductName, OrderDate)
	VALUES 
		('Butter', '2016-09-19')
		,('Milk', '2016-09-30')
		,('Cheese', '2016-09-04')
		,('Bread', '2015-12-20')
		,('Tomatoes', '2015-12-30')


SELECT ProductName
	,OrderDate
	,DATEADD(DAY, 3, OrderDate) AS PayDue
	,DATEADD(MONTH, 1, OrderDate) AS DeliverDue
FROM Orders