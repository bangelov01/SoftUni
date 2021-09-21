USE SoftUni

SELECT [Name]
FROM Departments

SELECT FirstName
	,LastName
	,Salary
FROM Employees

SELECT FirstName
	,MiddleName
	,LastName
FROM Employees

SELECT CONCAT(FirstName, '.', LastName,'@softuni.bg') AS 'Full Email Address'
FROM Employees

SELECT DISTINCT Salary
FROM Employees

SELECT * FROM Employees
WHERE JobTitle = 'Sales Representative'

SELECT FirstName
	,LastName
	,JobTitle 
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS 'Full Name'
FROM Employees
WHERE Salary = 25000 OR
	  Salary = 14000 OR
	  Salary = 12500 OR
	  Salary = 23600

SELECT FirstName
	,LastName
FROM Employees
WHERE ManagerID IS NULL

SELECT FirstName
	,LastName
	,Salary
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

SELECT TOP (5) FirstName
	,LastName
FROM Employees
ORDER BY Salary DESC

SELECT FirstName
	,LastName
FROM Employees
WHERE DepartmentId != 4

SELECT *
FROM Employees
ORDER BY Salary DESC
	,FirstName ASC
	,LastName DESC
	,MiddleName ASC

CREATE VIEW V_EmployeeNameJobTitle AS
SELECT CONCAT(FirstName, ' ', COALESCE(MiddleName, ''), ' ', LastName) AS [Full Name],
	JobTitle
FROM Employees

CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName
	,LastName
	,Salary
FROM Employees

SELECT DISTINCT JobTitle
FROM Employees

SELECT TOP (10) *
FROM Projects
ORDER BY StartDate
		,[Name]

SELECT TOP (7) FirstName
	,LastName
	,HireDate
FROM Employees
ORDER BY HireDate DESC

UPDATE Employees
SET Salary += (Salary * 0.12)
WHERE DepartmentId = 1 OR
	  DepartmentId = 2 OR
	  DepartmentId = 4 OR
	  DepartmentId = 11
SELECT Salary 
FROM Employees

USE [Geography]

SELECT PeakName
FROM Peaks
ORDER BY PeakName ASC

SELECT TOP (30) CountryName
	,[Population]
FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY [Population] DESC
	,CountryName ASC

SELECT CountryName, CountryCode,
	CASE
		WHEN CurrencyCode = 'EUR' THEN 'Euro'
		ELSE 'Not Euro'
	END AS [Currency]
FROM Countries
ORDER BY CountryName ASC

USE Diablo

SELECT [Name]
FROM Characters
ORDER BY [Name] ASC