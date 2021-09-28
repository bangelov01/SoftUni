USE SoftUni

SELECT TOP (5) E.EmployeeID
	,e.JobTitle
	,a.AddressID
	,a.AddressText
FROM Employees AS e
	JOIN Addresses AS a 
	ON e.AddressID = a.AddressID
ORDER BY a.AddressID

SELECT TOP (50) e.FirstName
	,e.LastName
	,t.[Name] AS Town
	,a.AddressText
FROM Employees AS e
	JOIN Addresses AS a 
	ON e.AddressID = a.AddressID
	JOIN Towns AS t
	ON t.TownID = a.TownID
ORDER BY e.FirstName, e.LastName

SELECT e.EmployeeID
	,e.FirstName
	,e.LastName
	,d.[Name] AS DepartmentName
FROM Employees AS e
	JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID

SELECT TOP (5) e.EmployeeID
	,e.FirstName
	,e.Salary
	,d.[Name] AS DepartmentName
FROM Employees AS e
	JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID

SELECT TOP (3) e.EmployeeID
	,e.FirstName
FROM Employees AS e
	LEFT JOIN EmployeesProjects AS ep
	ON e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID

SELECT e.FirstName
	,e.LastName
	,e.HireDate
	,d.[Name] AS DeptName
FROM Employees AS e
	JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-01-01' AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.HireDate

SELECT TOP (5) e.EmployeeID
	,e.FirstName
	,p.[Name] AS ProjectName
FROM Employees AS e
	JOIN EmployeesProjects AS ep
	ON e.EmployeeID = ep.EmployeeID
	JOIN Projects AS p
	ON p.ProjectID = ep.ProjectID
WHERE p.StartDate > '2002-08-13' AND
p.EndDate IS NULL
ORDER BY e.EmployeeID

SELECT e.EmployeeID
	,e.FirstName
	,CASE
		WHEN p.StartDate > '2004-12-31' THEN NULL
		ELSE p.[Name]
	END AS ProjectName
FROM Employees AS e
	JOIN EmployeesProjects AS ep
	ON e.EmployeeID = ep.EmployeeID
	JOIN Projects AS p
	ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24

SELECT e.EmployeeID
	,e.FirstName
	,m.EmployeeID AS ManagerID
	,m.FirstName AS ManagerName
FROM Employees AS e
	JOIN Employees AS m
	ON m.EmployeeID = e.ManagerID
WHERE e.ManagerID IN (3,7)
ORDER BY e.EmployeeID

SELECT TOP (50) e.EmployeeID
	,CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName
	,CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName
	,d.[Name] AS DepartmentName
FROM Employees AS e
	JOIN Employees AS m
	ON m.EmployeeID = e.ManagerID
	JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

SELECT 
	MIN(DeptAvg.Average) AS MinAverageSalary
FROM (
	SELECT
		AVG(e.Salary) AS Average
	FROM Employees AS e
		JOIN Departments AS d
		ON e.DepartmentID = d.DepartmentID
	GROUP BY d.[Name]
) AS DeptAvg

USE [Geography]

SELECT mc.CountryCode
	,m.MountainRange
	,p.PeakName
	,p.Elevation
FROM MountainsCountries AS mc
	JOIN Mountains AS m
	ON mc.MountainId = m.Id
	JOIN Peaks AS p
	ON p.MountainId = m.Id
WHERE p.Elevation > 2835 AND mc.CountryCode = 'BG'
ORDER BY p.Elevation DESC

SELECT c.CountryCode
	,COUNT(c.CountryCode) AS MountainRanges
FROM (
	SELECT mc.CountryCode
	FROM MountainsCountries AS mc
		JOIN Mountains AS m
	ON mc.MountainId = m.Id
) AS c
WHERE c.CountryCode IN ('BG', 'RU', 'US')
GROUP BY c.CountryCode

SELECT TOP (5) c.CountryName
	,r.RiverName
FROM Countries AS c
	JOIN Continents AS co
	ON c.ContinentCode = co.ContinentCode
	LEFT JOIN CountriesRivers AS cr
	ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers AS r
	ON r.Id = cr.RiverId
WHERE co.ContinentName = 'Africa'
ORDER BY c.CountryName