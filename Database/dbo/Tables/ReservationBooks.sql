CREATE TABLE ReservationBooks
(
	ReservationId int NOT NULL,
	BookId int NOT NULL,
	PRIMARY KEY (ReservationId, BookId),
	FOREIGN KEY (ReservationId) REFERENCES Reservations (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (BookId) REFERENCES Books (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);