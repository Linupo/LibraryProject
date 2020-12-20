CREATE TABLE Libraries
(
	Id int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	Name text NOT NULL,
	Address text NOT NULL,
	Phone text NOT NULL,
	OpenFrom time NOT NULL,
	OpenUntil time NOT NULL
);