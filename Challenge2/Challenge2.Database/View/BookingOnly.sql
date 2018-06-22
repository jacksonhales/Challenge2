CREATE VIEW [dbo].[BookingOnly]
	AS SELECT [payment], [dateBooked], [clientID], [eventID] FROM [Booking]
