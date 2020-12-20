CREATE TABLE Users
(
	Id int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
	FirstName text NOT NULL,
	LastName text NOT NULL,
	PersonalCode text NOT NULL,
	Email text NOT NULL,
	Password text NOT NULL,
	IsActive bit NOT NULL,
	Birthday date NOT NULL
);