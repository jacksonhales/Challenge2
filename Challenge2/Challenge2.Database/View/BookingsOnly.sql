CREATE VIEW [dbo].[BookingsOnly]
	AS SELECT [bookingID], [payment], [dateBooked], [clientID], [eventID] FROM [Booking]
