USE Gringotts

SELECT 
	COUNT(*) AS [Count]
FROM WizzardDeposits

SELECT 
	MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits

SELECT DepositGroup
	, MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup

SELECT TOP (2) DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

SELECT DepositGroup
	,SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup


SELECT DepositGroup
	,SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator LIKE '%Ollivander family%'
GROUP BY DepositGroup

SELECT DepositGroup
	,SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator LIKE '%Ollivander family%'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) <  150000
ORDER BY TotalSum DESC

SELECT DepositGroup
	,MagicWandCreator
	,MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator

SELECT
	AgeGroup
	,COUNT(AgeGroup) AS WizardCount
FROM
	(SELECT 
		CASE
			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			WHEN Age > 60 THEN '[61+]'
		END AS AgeGroup
	FROM WizzardDeposits) AS CreateGroupQuerry
GROUP BY AgeGroup

SELECT LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits
GROUP BY LEFT(FirstName, 1), DepositGroup
HAVING DepositGroup LIKE '%Troll Chest%'

SELECT DepositGroup
	,IsDepositExpired
	,AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC
	,IsDepositExpired



SELECT SUM(a.[Difference]) AS SumDifference
FROM
	(SELECT w1.DepositAmount - w2.DepositAmount AS [Difference]
	FROM WizzardDeposits AS w1
		JOIN WizzardDeposits AS w2
		ON w2.Id = (w1.id + 1)) AS a


USE SoftUni
GO


SELECT DepartmentID
	,SUM(Salary) AS TotalSalary
FROM Employees 
GROUP BY DepartmentID
ORDER BY DepartmentID

SELECT DepartmentID
	,MIN(Salary) AS MinimumSalary
FROM Employees
WHERE HireDate > '2000-01-01'
GROUP BY DepartmentID
HAVING DepartmentID IN (2, 5, 7)


SELECT *
INTO Employees2
FROM Employees
WHERE Salary > 30000

DELETE FROM Employees2
WHERE ManagerID = 42

UPDATE Employees2
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID
	,AVG(Salary) AS AverageSalary
FROM Employees2
GROUP BY DepartmentID

SELECT DepartmentID
	,MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

SELECT COUNT(*) AS [Count]
FROM Employees
WHERE ManagerID IS NULL


SELECT DepartmentID
	,Salary AS ThirdHighestSalary
FROM
	(SELECT DepartmentID
		,Salary
		,DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Rank]
	FROM Employees
	GROUP BY DepartmentID, Salary) AS Ranking
WHERE [Rank] = 3

SELECT TOP (10) e.FirstName
	,e.LastName
	,e.DepartmentID
FROM Employees AS e
	,(SELECT DepartmentID
			,AVG(Salary) AS AverageSalary
		FROM Employees
		GROUP BY DepartmentID) AS d
WHERE (e.DepartmentID = d.DepartmentID) AND
	e.Salary > d.AverageSalary
ORDER BY e.DepartmentID







