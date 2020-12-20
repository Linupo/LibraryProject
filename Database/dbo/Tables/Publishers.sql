CREATE TABLE Publishers
(
	Id int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	Name text NOT NULL,
	Address text NOT NULL,
	Email text NOT NULL,
	Password text NOT NULL
);