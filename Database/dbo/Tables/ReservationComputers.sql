CREATE TABLE ReservationComputers
(
	ReservationId int NOT NULL,
	ComputerId int NOT NULL,
	PRIMARY KEY (ReservationId, ComputerId),
	FOREIGN KEY (ReservationId) REFERENCES Reservations (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	FOREIGN KEY (ComputerId) REFERENCES Computers (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);