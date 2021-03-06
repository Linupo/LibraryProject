﻿CREATE TABLE Computers
(
	Id int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	CPU text NOT NULL,
	GPU text NOT NULL,
	Monitor text NOT NULL,
	LibraryId int NOT NULL,
	FOREIGN KEY (LibraryId) REFERENCES Libraries (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);