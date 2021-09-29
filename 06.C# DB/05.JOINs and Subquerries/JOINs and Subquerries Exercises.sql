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
	,COUNT(mc.MountainID) AS MountainRanges
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
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



SELECT ContinentCode
	,CurrencyCode
	,CurrencyCount AS CurrencyUsage
FROM
	(SELECT ContinentCode
		,CurrencyCode
		,CurrencyCount
		,DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyCount DESC) AS CurrencyRank
	FROM
		(SELECT ContinentCode
			  ,CurrencyCode
			  ,COUNT(*) AS CurrencyCount
		FROM Countries
		GROUP BY ContinentCode, CurrencyCode) AS CountQuerry
	WHERE CurrencyCount > 1) AS RankingQuerry
WHERE CurrencyRank = 1
ORDER BY ContinentCode



SELECT COUNT(*) AS [Count]
FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
	ON c.CountryCode = mc.CountryCode
WHERE mc.MountainId IS NULL

SELECT TOP (5) CountryName
	,MAX(p.Elevation) AS HighestPeakElevation
	,MAX(r.[Length]) AS LongestRiverLength
FROM Countries AS c
	LEFT JOIN CountriesRivers AS cr
	ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers AS r
	ON cr.RiverId = r.Id
	LEFT JOIN MountainsCountries AS mc
	ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m
	ON mc.MountainId = m.Id
	LEFT JOIN Peaks AS p
	ON m.Id = p.MountainId
GROUP BY CountryName
ORDER BY HighestPeakElevation DESC
		,LongestRiverLength DESC
		,CountryName

SELECT TOP (5) Country
	,ISNULL(PeakName, '(no highest peak)') AS HighestPeakName
	,ISNULL(HighestPeakElevation, 0) AS HighestPeakElevation
	,ISNULL(MountainRange, '(no mountain)') AS Mountain
FROM
	(SELECT CountryName AS Country
		,PeakName
		,HighestPeakElevation
		,MountainRange
		,DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY HighestPeakElevation DESC) AS HRank
	FROM
		(SELECT CountryName
			,PeakName
			,MountainRange
			,MAX(p.Elevation) AS HighestPeakElevation
		FROM Countries AS c
			LEFT JOIN MountainsCountries AS mc
			ON c.CountryCode = mc.CountryCode
			LEFT JOIN Mountains AS m
			ON mc.MountainId = m.Id
			LEFT JOIN Peaks AS p
			ON m.Id = p.MountainId
		GROUP BY CountryName, PeakName, MountainRange) AS HighestPeakQuerry
	) AS RankingQuerry
WHERE HRank = 1
ORDER BY Country
	,HighestPeakName
