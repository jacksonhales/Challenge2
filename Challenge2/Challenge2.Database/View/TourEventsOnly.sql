CREATE VIEW [dbo].[TourEventsOnly]
	AS SELECT [eventID], [eventDay], [eventMonth], [eventYear], [fee], [tourID] FROM [TourEvent]
