CREATE DATABASE Bakery

USE Bakery

--DB Creation
CREATE TABLE Countries (
	Id INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] NVARCHAR(50) UNIQUE
)

CREATE TABLE Customers (
	Id INT PRIMARY KEY IDENTITY NOT NULL
	,FirstName NVARCHAR(25)
	,LastName NVARCHAR(25)
	,Gender CHAR(1)
		CHECK(Gender IN ('M', 'F'))
	,Age INT 
	,PhoneNumber VARCHAR(10)
		CHECK(LEN(PhoneNumber) = 10)
	,CountryId INT FOREIGN KEY REFERENCES Countries (Id)
)

CREATE TABLE Products (
	Id INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] NVARCHAR(25) UNIQUE
	,[Description] NVARCHAR(250)
	,Recipe NVARCHAR(MAX)
	,Price DECIMAL(10,2)
		CHECK(Price >= 0)
)

CREATE TABLE Feedbacks (
	Id INT PRIMARY KEY IDENTITY NOT NULL
	,[Description] NVARCHAR(255)
	,Rate DECIMAL (10,2)
		CHECK(Rate BETWEEN 0 AND 10)
	,ProductId INT FOREIGN KEY REFERENCES Products (Id)
	,CustomerId INT FOREIGN KEY REFERENCES Customers (Id)
)

CREATE TABLE Distributors (
	Id INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] NVARCHAR(25) UNIQUE
	,AddressText NVARCHAR(30)
	,Summary NVARCHAR(200)
	,CountryId INT FOREIGN KEY REFERENCES Countries (Id)
)

CREATE TABLE Ingredients (
	Id INT PRIMARY KEY IDENTITY NOT NULL
	,[Name] NVARCHAR(30)
	,[Description] NVARCHAR(200)
	,OriginCountryId INT FOREIGN KEY REFERENCES Countries (Id)
	,DistributorId INT FOREIGN KEY REFERENCES Distributors (Id)
)

CREATE TABLE ProductsIngredients (
	ProductId INT 
	,IngredientId INT 
	,PRIMARY KEY CLUSTERED (ProductId, IngredientId)
	,FOREIGN KEY (ProductId) REFERENCES Products (Id)
	,FOREIGN KEY (IngredientId) REFERENCES Ingredients (Id)
)

--DB Insert

INSERT INTO Distributors ([Name], CountryId, AddressText, Summary)
	VALUES
		('Deloitte & Touche', 2, '6 Arch St #9757', 'Customizable neutral traveling')
		,('Congress Title', 13, '58 Hancock St', 'Customer loyalty')
		,('Kitchen People', 1, '3 E 31st St #77', 'Triple-buffered stable delivery')
		,('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group')
		,('Beck Corporation', 23, '21 E 64th Ave', 'Quality-focused 4th generation hardware')

INSERT INTO Customers (FirstName, LastName, Age, Gender, PhoneNumber, CountryId)
	VALUES
		('Francoise', 'Rautenstrauch', 15, 'M', '0195698399', 5)
		,('Kendra', 'Loud', 22, 'F', '0063631526', 11)
		,('Lourdes', 'Bauswell', 50, 'M', '0139037043', 8)
		,('Hannah', 'Edmison', 18, 'F', '0043343686', 1)
		,('Tom', 'Loeza', 31, 'M', '0144876096', 23)
		,('Queenie', 'Kramarczyk', 30, 'F', '0064215793', 29)
		,('Hiu', 'Portaro', 25, 'M', '0068277755', 16)
		,('Josefa', 'Opitz', 43, 'F', '0197887645', 17)

--DB Update

UPDATE Ingredients
SET DistributorId = 35
WHERE [Name] IN ('Bay Leaf', 'Paprika', 'Poppy')

UPDATE Ingredients
SET OriginCountryId = 14
WHERE OriginCountryId = 8

--DB Delete

DELETE FROM Feedbacks
WHERE CustomerId = 14 OR ProductId = 5

--DB Querrying

SELECT [Name], Price, [Description]
FROM Products
ORDER BY Price DESC, [Name]

SELECT f.ProductId
	,f.Rate
	,f.[Description]
	,f.CustomerId
	,c.Age
	,c.Gender
FROM Feedbacks AS f
JOIN Customers AS c
ON c.Id = f.CustomerId
WHERE f.Rate < 5
ORDER BY f.ProductId DESC, f.Rate

SELECT CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName
	,c.PhoneNumber
	,c.Gender
FROM Customers AS c
LEFT JOIN Feedbacks AS f
ON f.CustomerId = c.Id
WHERE f.Id IS NULL
ORDER BY c.Id

SELECT c.FirstName
	,c.Age
	,c.PhoneNumber
FROM Customers AS c
LEFT JOIN Countries AS cs
ON cs.Id = c.CountryId
WHERE (cs.[Name] != 'Greece') AND
(c.Age >= 21) AND
(c.FirstName LIKE '%an%') OR
(c.PhoneNumber LIKE '%38')
ORDER BY c.FirstName, c.Age DESC

SELECT *
FROM Distributors AS d
LEFT JOIN Ingredients AS i
ON i.DistributorId = d.Id


SELECT d.[Name] AS DistributorName
	,i.[Name] AS IngredientName
	,p.[Name] AS ProductName
	,AVG(f.Rate) AS AverageRate
FROM Distributors AS d
JOIN Ingredients AS i
ON i.DistributorId = d.Id
JOIN ProductsIngredients AS pin
ON pin.IngredientId = i.Id
JOIN Products AS p
ON p.Id = pin.ProductId
JOIN Feedbacks AS f
ON f.ProductId = p.Id
GROUP BY d.[Name], i.[Name], p.[Name]
HAVING AVG(f.Rate) BETWEEN 5 AND 8
ORDER BY d.[Name], i.[Name], p.[Name]



--SELECT d.[Name]
--	,COUNT(i.DistributorId) AS TotalIngredientsCount
--FROM Distributors AS d
--JOIN Ingredients AS i
--ON i.DistributorId = d.Id
--GROUP BY d.[Name]

SELECT CountryName
	,DisributorName
FROM
(SELECT CountryName
	,DisributorName
	,TotalIngredientsCount
	,DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY TotalIngredientsCount DESC) AS [Rank]
FROM(
	SELECT c.[Name] AS CountryName
		,d.[Name] AS DisributorName
		,COUNT(i.DistributorId) AS TotalIngredientsCount
	FROM Countries AS c
	LEFT JOIN Distributors AS d
	ON d.CountryId = c.Id
	LEFT JOIN Ingredients AS i
	ON i.DistributorId = d.Id
	GROUP BY c.[Name], d.[Name]) AS [CountQuerry]) AS [RankingQuerry]
WHERE [Rank] = 1
ORDER BY CountryName, DisributorName
GO

--DB Programmability
CREATE VIEW v_UserWithCountries AS
	SELECT CONCAT(FirstName, ' ', LastName) AS CustomerName
		,Age
		,Gender
		,co.[Name] AS CountryName
	FROM Customers AS c
	JOIN Countries AS co
	ON co.Id = c.CountryId
GO

CREATE TRIGGER tr_DeleteRelations
ON Products INSTEAD OF DELETE
AS
	DELETE FROM ProductsIngredients
	WHERE ProductId = (SELECT Id
						FROM deleted)
	DELETE FROM Feedbacks
	WHERE ProductId = (SELECT Id
						FROM deleted)
	DELETE FROM Products
	WHERE Id = (SELECT Id
				FROM deleted)
GO

DELETE FROM Products WHERE Id = 7