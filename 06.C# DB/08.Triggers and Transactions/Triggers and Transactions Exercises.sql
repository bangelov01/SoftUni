USE Bank

CREATE TABLE Logs (
	LogId INT PRIMARY KEY IDENTITY NOT NULL
	,AccountId INT
	,OldSum MONEY
	,NewSum MONEY
)
GO

CREATE TRIGGER tr_LogWhenAccountSumChanges
ON Accounts AFTER UPDATE
AS
	INSERT INTO Logs(AccountId, OldSum, NewSum)
	SELECT i.Id, d.Balance, i.Balance
	FROM inserted AS i
	JOIN deleted AS d
	ON i.Id = d.Id
	WHERE i.Balance != d.Balance
GO

CREATE TABLE NotificationEmails (
	Id INT PRIMARY KEY IDENTITY NOT NULL
	,Recipient INT
	,[Subject] NVARCHAR(50)
	,Body NVARCHAR(50)
)
GO

CREATE TRIGGER tr_CreateEmailOnLogsUpdate
ON Logs AFTER INSERT
AS
	INSERT INTO NotificationEmails (Recipient, [Subject], Body)
		VALUES
			((SELECT AccountId FROM inserted)
			,CONCAT('Balance change for account: ', (SELECT AccountId FROM inserted))
			,CONCAT('On ', GETDATE(), ' your balance was changed from ', (SELECT OldSum FROM inserted), ' to ', (SELECT NewSum FROM inserted))
			)
GO

CREATE PROC usp_DepositMoney (@accountId INT, @moneyAmount DECIMAL(15,4))
AS
	BEGIN TRANSACTION
	UPDATE Accounts
		SET Balance += @moneyAmount
	WHERE Id = @accountId
		IF(@moneyAmount < 0)
		BEGIN
			ROLLBACK;
			THROW 50001, 'Invalid amount!', 1
			RETURN
		END
	COMMIT
GO


CREATE PROC usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL(15,4))
AS
	BEGIN TRANSACTION
	UPDATE Accounts
		SET Balance -= @moneyAmount
	WHERE Id = @accountId
		IF(@moneyAmount < 0)
		BEGIN
			ROLLBACK;
			THROW 50001, 'Invalid amount!', 1
			RETURN
		END
	COMMIT
GO

CREATE PROC usp_TransferMoney (@senderId INT, @receiverId INT, @amount DECIMAL(15,4))
AS
	BEGIN TRANSACTION
		EXEC dbo.usp_WithdrawMoney @senderId, @amount
		EXEC dbo.usp_DepositMoney @receiverId, @amount
			IF((SELECT Balance
				FROM Accounts
				WHERE Id = @senderId) < 0)
				BEGIN
					ROLLBACK
					RETURN
				END
			COMMIT
GO

USE SoftUni
GO

CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
	BEGIN TRANSACTION
		INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
			VALUES
				(@emloyeeId, @projectID)
	IF((SELECT COUNT(ProjectID)
		FROM EmployeesProjects
		GROUP BY EmployeeID
		HAVING EmployeeID = @emloyeeId) > 3)
			BEGIN
				ROLLBACK;
				THROW 50001, 'The employee has too many projects!',1
				RETURN
			END
	COMMIT
GO

CREATE TABLE Deleted_Employees 
(	 EmployeeId INT PRIMARY KEY IDENTITY NOT NULL
	,FirstName VARCHAR(50)
	,LastName VARCHAR(50)
	,MiddleName VARCHAR(50)
	,JobTitle VARCHAR(50)
	,DepartmentId INT
	,Salary MONEY
)
GO

CREATE TRIGGER tr_OnEmployeeDeleteAddToDeletedTable
ON Employees AFTER DELETE
AS
	BEGIN
		INSERT INTO Deleted_Employees
			SELECT FirstName
				,LastName
				,MiddleName
				,JobTitle
				,DepartmentID
				,Salary
			FROM deleted
	END