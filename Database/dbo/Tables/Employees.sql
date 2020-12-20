CREATE TABLE Employees
(
	Id int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	FirstName text NOT NULL,
	LastName text NOT NULL,
	PersonalCode text NOT NULL,
	Salary int NOT NULL,
	Email text NOT NULL,
	Password text NOT NULL,
	Duty int NOT NULL,
	ReportsTo int NULL,
	EmployedAt int NULL,
	FOREIGN KEY (Duty) REFERENCES Duties (Id),
	FOREIGN KEY (ReportsTo) REFERENCES Employees (Id),
	FOREIGN KEY (EmployedAt) REFERENCES Libraries (Id)
);
