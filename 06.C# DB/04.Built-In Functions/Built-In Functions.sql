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

