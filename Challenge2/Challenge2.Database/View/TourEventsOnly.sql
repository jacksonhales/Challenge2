CREATE VIEW [dbo].[TourEventsOnly]
	AS SELECT [eventDay], [eventMonth], [eventYear], [fee], [tourID] FROM [TourEvent]
