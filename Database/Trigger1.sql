CREATE TRIGGER [Trigger1]
ON [dbo].[Employees]
INSTEAD OF DELETE
AS
BEGIN
	UPDATE Employees SET ReportsTo = NULL WHERE Id IN (SELECT Id FROM deleted);
	DELETE FROM Employees WHERE Id IN (SELECT Id FROM deleted);
END
