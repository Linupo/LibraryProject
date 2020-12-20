CREATE TABLE Books
(
	Id int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	LibraryId int NULL,
	PublisherId int NULL,
	AuthorId int NOT NULL,
	Title text NOT NULL,
	Desciption text NOT NULL,
	YearWritten int NOT NULL,
	Country text NOT NULL,
	Language text NOT NULL,
	ISBN text NOT NULL,
	ReleaseDate date NOT NULL,
	PageCount int NOT NULL,
	MinAge int NOT NULL,
	Price int NOT NULL,
	GenreId int NOT NULL,
	ConditionId int NOT NULL,
	FOREIGN KEY (GenreId) REFERENCES Genres (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (ConditionId) REFERENCES Conditions (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (LibraryId) REFERENCES Libraries (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (PublisherId) REFERENCES Publishers (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (AuthorId) REFERENCES Authors (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);