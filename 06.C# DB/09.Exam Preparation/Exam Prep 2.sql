CREATE DATABASE [WMS]

USE [WMS]


--DB Creation
CREATE TABLE Clients (
	ClientId INT PRIMARY KEY IDENTITY NOT NULL
	,FirstName VARCHAR(50) NOT NULL
	,LastName VARCHAR(50) NOT NULL
	,Phone CHAR(12) NOT NULL
		CHECK(LEN(Phone) = 12)
)

CREATE TABLE Mechanics (
	MechanicId INT PRIMARY KEY IDENTITY NOT NULL
	,FirstName VARCHAR(50) NOT NULL
	,LastName VARCHAR(50) NOT NULL
	,[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE Models (
	ModelId INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Jobs (
	JobId INT PRIMARY KEY IDENTITY NOT NULL
	,ModelId INT FOREIGN KEY REFERENCES Models (ModelId) NOT NULL
	,[Status] VARCHAR(11) NOT NULL DEFAULT 'Pending'
		CHECK([Status] IN ('Pending', 'In Progress', 'Finished'))
	,ClientId INT FOREIGN KEY REFERENCES Clients (ClientId) NOT NULL
	,MechanicId INT FOREIGN KEY REFERENCES Mechanics (MechanicId)
	,IssueDate DATE NOT NULL
	,FinishDate DATE
)

CREATE TABLE Orders (
	OrderId INT PRIMARY KEY IDENTITY NOT NULL
	,JobId INT FOREIGN KEY REFERENCES Jobs (JobId) NOT NULL
	,IssueDate DATE
	,Delivered BIT NOT NULL DEFAULT 0
)

CREATE TABLE Vendors (
	VendorId INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Parts (
	PartId INT PRIMARY KEY IDENTITY NOT NULL
	,SerialNumber VARCHAR(50) NOT NULL UNIQUE
	,[Description] VARCHAR(255)
	,Price DECIMAL(6,2) NOT NULL
		CHECK(Price > 0)
	,VendorId INT FOREIGN KEY REFERENCES Vendors (VendorId) NOT NULL
	,StockQty INT NOT NULL DEFAULT 0
		CHECK(StockQty >= 0)
)

CREATE TABLE OrderParts (
	OrderId INT NOT NULL
	,PartId INT NOT NULL
	,PRIMARY KEY CLUSTERED (OrderId, PartId)
	,FOREIGN KEY (OrderId) REFERENCES Orders (OrderId)
	,FOREIGN KEY (PartId) REFERENCES Parts (PartId)
	,Quantity INT NOT NULL DEFAULT 1
		CHECK(Quantity > 0)
)

CREATE TABLE PartsNeeded (
	JobId INT NOT NULL
	,PartId INT NOT NULL
	,PRIMARY KEY CLUSTERED (JobId, PartId)
	,FOREIGN KEY (JobId) REFERENCES Jobs (JobId)
	,FOREIGN KEY (PartId) REFERENCES Parts (PartId)
	,Quantity INT NOT NULL DEFAULT 1
		CHECK(Quantity > 0)
)

--DB Insert

INSERT INTO Clients (FirstName, LastName, Phone)
	VALUES
		('Teri', 'Ennaco', '570-889-5187')
		,('Merlyn', 'Lawler', '201-588-7810')
		,('Georgene', 'Montezuma', '925-615-5185')
		,('Jettie', 'Mconnell', '908-802-3564')
		,('Lemuel', 'Latzke', '631-748-6479')
		,('Melodie', 'Knipp', '805-690-1682')
		,('Candida', 'Corbley', '908-275-8357')

INSERT INTO Parts (SerialNumber, [Description], Price, VendorId)
	VALUES
		('WP8182119', 'Door Boot Seal', 117.86, 2)
		,('W10780048', 'Suspension Rod', 42.81, 1)
		,('W10841140', 'Silicone Adhesive', 6.77, 4)
		,('WPY055980', 'High Temperature Adhesive', 13.94, 3)

--DB Update

UPDATE Jobs
SET MechanicId = 3
WHERE [Status] = 'Pending'

UPDATE Jobs
SET [Status] = 'In Progress'
WHERE MechanicId = 3 AND [Status] = 'Pending'

--DB Delete
DELETE FROM OrderParts
WHERE OrderId = 19

DELETE FROM Orders
WHERE OrderId = 19

--DB Querrying

SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic
	,j.[Status]
	,j.IssueDate
FROM Mechanics AS m
JOIN Jobs AS j
ON j.MechanicId = m.MechanicId
ORDER BY m.MechanicId
	,j.IssueDate
	,j.JobId


SELECT CONCAT(c.FirstName, ' ', c.LastName) AS Client
	,DATEDIFF(DAY,j.IssueDate, '2017-04-24') AS [Days going]
	,j.[Status]
FROM Clients AS c
JOIN Jobs AS j
ON j.ClientId = c.ClientId
WHERE j.[Status] != 'Finished'
ORDER BY [Days going] DESC
	,c.ClientId

SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic
	,AVG(DATEDIFF(DAY,j.IssueDate, j.FinishDate)) AS [Average Days]
FROM Mechanics AS m
JOIN Jobs AS j
ON j.MechanicId = m.MechanicId
GROUP BY m.MechanicId, CONCAT(m.FirstName, ' ', m.LastName)
ORDER BY m.MechanicId

--Long solution
SELECT Available
FROM
(SELECT m1.MechanicId
	,CONCAT(m1.FirstName, ' ', m1.LastName) AS Available
	,(SELECT COUNT(*)
	FROM Mechanics AS m
		LEFT JOIN Jobs AS j
		ON j.MechanicId = m.MechanicId
		WHERE m.MechanicId = m1.MechanicId) AS [AllJobsCount]
	,(SELECT COUNT(*)
	FROM Mechanics AS m
		LEFT JOIN Jobs AS j
		ON j.MechanicId = m.MechanicId
		WHERE m.MechanicId = m1.MechanicId AND (j.[Status] = 'Finished' OR j.[Status] IS NULL)) AS [FinishedJobsCount]
FROM Mechanics AS m1
LEFT JOIN Jobs AS j1
ON j1.MechanicId = m1.MechanicId) AS MainQuerry
WHERE AllJobsCount = FinishedJobsCount
GROUP BY MechanicId, Available
ORDER BY MechanicId

--Short solution
SELECT CONCAT(FirstName, ' ', LastName) AS Available
FROM Mechanics
WHERE MechanicId NOT IN (
						SELECT MechanicId
						FROM Jobs
						WHERE [Status] = 'In Progress'
						GROUP BY MechanicId)



SELECT j.JobId AS JobId
	,ISNULL(SUM(p.Price * op.Quantity), 0) AS Total
FROM Jobs AS j
LEFT JOIN Orders AS o
ON o.JobId = j.JobId
LEFT JOIN OrderParts AS op
ON op.OrderId = o.OrderId
LEFT JOIN Parts AS p
ON p.PartId = op.PartId
WHERE j.[Status] = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC, j.JobId

SELECT *
FROM
	(SELECT p.PartId
		,p.[Description]
		,pn.Quantity AS [Required]
		,p.StockQty AS [In Stock]
		,ISNULL(op.Quantity, 0) AS Ordered
	FROM Jobs AS j
	LEFT JOIN PartsNeeded AS pn
	ON pn.JobId = j.JobId
	LEFT JOIN Parts AS p
	ON p.PartId = pn.PartId
	LEFT JOIN Orders AS o
	ON o.JobId = j.JobId
	LEFT JOIN OrderParts AS op
	ON op.OrderId = o.OrderId
	WHERE j.[Status] != 'Finished' AND (o.Delivered = 0 OR o.Delivered IS NULL)) AS [PartsQntyQuerry]
WHERE [Required] > [In Stock] + Ordered
ORDER BY PartId
GO

--DB Programmability
