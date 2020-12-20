CREATE TABLE Vacations
(
	Id int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	StartDate date NOT NULL,
	EndDate date NOT NULL,
	IsAccepted bit NOT NULL,
	EmployeeId int NOT NULL,
	FOREIGN KEY (EmployeeId) REFERENCES Employees (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);