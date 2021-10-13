CREATE DATABASE Bitbucket

USE Bitbucket

--DB Creation
CREATE TABLE Users (
	Id INT PRIMARY KEY IDENTITY NOT NULL
		--CHECK(Id BETWEEN 0 AND 2147483647)
	,Username VARCHAR(30) NOT NULL
	,[Password] VARCHAR(30) NOT NULL
	,Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories (
	Id INT PRIMARY KEY IDENTITY NOT NULL
		--CHECK(Id BETWEEN 0 AND 2147483647)
	,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors (
	RepositoryId INT NOT NULL
		--CHECK(RepositoryId BETWEEN 0 AND 2147483647)
	,ContributorId INT NOT NULL
		--CHECK(ContributorId BETWEEN 0 AND 2147483647)
	,PRIMARY KEY CLUSTERED (RepositoryId, ContributorId)
	,FOREIGN KEY (RepositoryId) REFERENCES Repositories (Id)
	,FOREIGN KEY (ContributorId) REFERENCES Users (Id)
)

CREATE TABLE Issues (
	Id INT PRIMARY KEY IDENTITY NOT NULL
		--CHECK(Id BETWEEN 0 AND 2147483647)
	,Title VARCHAR(255) NOT NULL
	,IssueStatus VARCHAR(6) NOT NULL
		--CHECK(LEN(IssueStatus) = 6)
	,RepositoryId INT FOREIGN KEY REFERENCES Repositories (Id) NOT NULL
		--CHECK(RepositoryId BETWEEN 0 AND 2147483647)
	,AssigneeId INT FOREIGN KEY REFERENCES Users (Id) NOT NULL
		--CHECK(AssigneeId BETWEEN 0 AND 2147483647)
)

CREATE TABLE Commits (
	Id INT PRIMARY KEY IDENTITY NOT NULL
		--CHECK(Id BETWEEN 0 AND 2147483647)
	,[Message] VARCHAR(255) NOT NULL
	,IssueId INT FOREIGN KEY REFERENCES Issues (Id)
		--CHECK(IssueId BETWEEN 0 AND 2147483647)
	,RepositoryId INT FOREIGN KEY REFERENCES Repositories (Id) NOT NULL
		--CHECK(RepositoryId BETWEEN 0 AND 2147483647)
	,ContributorId INT FOREIGN KEY REFERENCES Users (Id) NOT NULL
		--CHECK(ContributorId BETWEEN 0 AND 2147483647)
)

CREATE TABLE Files (
	Id INT PRIMARY KEY IDENTITY NOT NULL
		--CHECK(Id BETWEEN 0 AND 2147483647)
	,[Name] VARCHAR(100) NOT NULL
	,Size DECIMAL(15,2) NOT NULL
	,ParentId INT FOREIGN KEY REFERENCES Files (Id)
		--CHECK(ParentId BETWEEN 0 AND 2147483647)
	,CommitId INT FOREIGN KEY REFERENCES Commits (Id) NOT NULL
		--CHECK(CommitId BETWEEN 0 AND 2147483647)
)

--DB Insert

INSERT INTO Files ([Name], Size, ParentId, CommitId)
	VALUES
		('Trade.idk', 2598.0, 1, 1)
		,('menu.net', 9238.31, 2, 2)
		,('Administrate.soshy', 1246.93, 3, 3)
		,('Controller.php', 7353.15, 4, 4)
		,('Find.java', 9957.86, 5, 5)
		,('Controller.json', 14034.87, 6, 6)
		,('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues (Title, IssueStatus, RepositoryId, AssigneeId)
	VALUES
		('Critical Problem with HomeController.cs file', 'open', 1, 4)
		,('Typo fix in Judge.html', 'open', 4, 3)
		,('Implement documentation for UsersService.cs', 'closed', 8, 2)
		,('Unreachable code in Index.cs', 'open', 9, 8)

--DB Update

UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6

--DB Delete

DELETE FROM RepositoriesContributors
WHERE RepositoryId = (SELECT Id FROM Repositories WHERE [Name] = 'Softuni-Teamwork')

DELETE FROM Issues
WHERE RepositoryId = (SELECT Id FROM Repositories WHERE [Name] = 'Softuni-Teamwork')

--DB Querrying

SELECT id, [Message], RepositoryId, ContributorId 
FROM Commits
ORDER BY Id, [Message], RepositoryId, ContributorId

SELECT Id, [Name], Size
FROM Files
WHERE Size > 1000 AND [Name] LIKE '%html%'
ORDER BY Size DESC, Id, [Name]



SELECT i.Id
	,CONCAT(u.Username, ' : ', i.Title) AS IssueAssignee
FROM Issues AS i
JOIN Users AS u
ON u.Id = i.AssigneeId
ORDER BY i.Id DESC, IssueAssignee



SELECT Id
	,[Name]
	,CONCAT(Size, 'KB') AS Size
FROM Files
WHERE Id NOT IN (SELECT ParentId
					FROM Files
					WHERE ParentId IS NOT NULL
					GROUP BY ParentId)
ORDER BY Id, [Name], Size DESC


SELECT u.Username
	,AVG(f.Size) AS Size
FROM Users AS u
JOIN Commits AS c
ON c.ContributorId = u.Id
JOIN Files AS f
ON f.CommitId = c.Id
GROUP BY u.Username
ORDER BY Size DESC, u.Username
GO

--DB Programmability

CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT
AS
	BEGIN
		DECLARE @result INT
		SET @result = (SELECT COUNT(c.id)
						FROM Users AS u
						LEFT JOIN Commits AS c
						ON c.ContributorId = u.Id
						WHERE u.Username = @username)
		RETURN @result
	END
GO

CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(20))
AS
	SELECT Id
		,[Name]
		,CONCAT(Size, 'KB') AS Size
	FROM Files AS f
	WHERE [Name] LIKE '%'+ @fileExtension
	ORDER BY id, [Name], f.Size DESC
GO

EXEC usp_SearchForFiles 'txt'